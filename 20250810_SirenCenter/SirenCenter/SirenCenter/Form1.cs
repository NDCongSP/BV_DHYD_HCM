using Dapper;
using EasyScada.Core;
using EasyScada.Winforms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SirenCenter
{
    public partial class Form1 : Form
    {
        EasyDriverConnector _easyDriverConnector;

        private double _sirenValue = 0;

        private Timer _timer = new Timer();

        private int _countOk = 0;

        private bool _offSiren = false;

        private readonly Database _db;

        public bool _isWrite = false;
        public Form1(Database db)
        {
            _db = db;
        }

        public Form1() : this(new Database())
        {
            InitializeComponent();

            _easyDriverConnector = new EasyDriverConnector();
            _easyDriverConnector.ConnectionStatusChaged += _easyDriverConnector_ConnectionStatusChaged;
            _easyDriverConnector.BeginInit();
            _easyDriverConnector.EndInit();
            _labSriverStatus.Text = _easyDriverConnector.ConnectionStatus.ToString();
            _easyDriverConnector.Started += _easyDriverConnector_Started;
            if (_easyDriverConnector.IsStarted)
            {
                _easyDriverConnector_Started(null, null);
            }

            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
        }

        private void _easyDriverConnector_ConnectionStatusChaged(object sender, ConnectionStatusChangedEventArgs e)
        {
            if (_labSriverStatus.InvokeRequired)
            {
                _labSriverStatus.BeginInvoke(new Action(() =>
                {
                    _labSriverStatus.BackColor = GetConnectionStatusColor(e.NewStatus);
                    _labSriverStatus.Text = _easyDriverConnector.ConnectionStatus.ToString();
                }));
            }
            else
            {
                _labSriverStatus.BackColor = GetConnectionStatusColor(e.NewStatus);
                _labSriverStatus.Text = _easyDriverConnector.ConnectionStatus.ToString();
            }
        }

        private System.Drawing.Color GetConnectionStatusColor(ConnectionStatus status)
        {
            switch (status)
            {
                case ConnectionStatus.Connected:
                    return System.Drawing.Color.Lime;
                case ConnectionStatus.Connecting:
                case ConnectionStatus.Reconnecting:
                    return System.Drawing.Color.Orange;
                case ConnectionStatus.Disconnected:
                    return System.Drawing.Color.Red;
                default:
                    return System.Drawing.Color.White;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn tắt app?!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            _easyDriverConnector.ConnectionStatusChaged -= _easyDriverConnector_ConnectionStatusChaged;
            _easyDriverConnector.Started -= _easyDriverConnector_Started;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dataCheck = GetLatestDataWithLocation();
            _grid.DataSource = dataCheck;

            _btnOffSiren.Click += _btnOffSiren_Click;

            _timer.Interval = 10000;
            _timer.Tick += _timer_Tick;
            _timer.Enabled = true;
        }

        private void _btnOffSiren_Click(object sender, EventArgs e)
        {
            if (!_offSiren)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn tắt còi không?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                _offSiren = true;
            }
            else
            {
                _offSiren = false;
            }
        }

        private void _easyDriverConnector_Started(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            //foreach (var item in _ovensInfo)
            {
                //easyDriverConnector1.GetTag($"{item.Path}/Temperature").QualityChanged += Temperature_QualityChanged;
                _easyDriverConnector.GetTag($"Local Station/Channel1/Device1/Siren").ValueChanged += Siren_ValueChanged;

                Siren_ValueChanged(_easyDriverConnector.GetTag($"Local Station/Channel1/Device1/Siren")
                    , new TagValueChangedEventArgs(_easyDriverConnector.GetTag($"Local Station/Channel1/Device1/Siren")
                    , "", _easyDriverConnector.GetTag($"Local Station/Channel1/Device1/Siren").Value));
            }
        }

        private void Siren_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                var path = e?.Tag.Parent.Path;

                _sirenValue = double.TryParse(e.NewValue, out double value) ? value : 0;

                if (_sirenValue == 0)
                {
                    if (_sirenStatus.InvokeRequired)
                    {
                        _sirenStatus.BeginInvoke(new Action(() =>
                        {
                            _sirenStatus.BackColor = Color.Green;
                        }));
                    }
                    else _sirenStatus.BackColor = Color.Green;
                }
                else
                {
                    if (_sirenStatus.InvokeRequired)
                    {
                        _sirenStatus.BeginInvoke(new Action(() =>
                        {
                            _sirenStatus.BackColor = Color.Red;
                        }));
                    }
                    else _sirenStatus.BackColor = Color.Red;
                }
            }
            catch (Exception ex) { }
        }

        private async void _timer_Tick(object sender, EventArgs e)
        {
            Timer t = (Timer)sender;
            try
            {
                var dataCheck = GetLatestDataWithLocation();

                if (dataCheck != null)
                {
                    if (_grid.InvokeRequired)
                    {
                        _grid.BeginInvoke(new Action(() =>
                        {
                            _grid.DataSource = null;
                            _grid.DataSource = dataCheck;

                            foreach (DataGridViewRow row in _grid.Rows)
                            {
                                if (row.Cells["Value"].Value != null &&
                                    row.Cells["LowLevel"].Value != null &&
                                    row.Cells["HighLevel"].Value != null)
                                {
                                    double value = Convert.ToDouble(row.Cells["Value"].Value);
                                    double low = Convert.ToDouble(row.Cells["LowLevel"].Value);
                                    double high = Convert.ToDouble(row.Cells["HighLevel"].Value);

                                    if (value < low || value > high || row.Cells["Value"].Value == "Bad")
                                    {
                                        row.DefaultCellStyle.BackColor = Color.Red; // màu nền
                                        row.DefaultCellStyle.ForeColor = Color.White; // màu chữ
                                    }
                                }
                            }

                        }));
                    }
                    else
                    {
                        _grid.DataSource = null;
                        _grid.DataSource = dataCheck;

                        foreach (DataGridViewRow row in _grid.Rows)
                        {
                            if (row.Cells["Value"].Value != null &&
                                row.Cells["LowLevel"].Value != null &&
                                row.Cells["HighLevel"].Value != null)
                            {
                                double value = Convert.ToDouble(row.Cells["Value"].Value);
                                double low = Convert.ToDouble(row.Cells["LowLevel"].Value);
                                double high = Convert.ToDouble(row.Cells["HighLevel"].Value);

                                if (value < low || value > high || row.Cells["Value"].Value == "Bad")
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red; // màu nền
                                    row.DefaultCellStyle.ForeColor = Color.White; // màu chữ
                                }
                            }
                        }
                    }

                    _countOk = 0;

                    foreach (var item in dataCheck)
                    {
                        var value = item.Value != "Bad" ? Convert.ToDouble(item.Value) : 0;

                        if (item.Value == "Bad" || value > item.HighLevel || value < item.LowLevel)
                        {
                            if (_offSiren == true)
                            {
                                if (_sirenValue == 1) _easyDriverConnector.GetTag("Local Station/Channel1/Device1/Siren").Write("0");
                                continue;
                            }
                            else if (_offSiren == false)
                            {
                                if (_sirenValue == 0) _easyDriverConnector.GetTag("Local Station/Channel1/Device1/Siren").Write("1");
                                break;
                            }
                        }
                        else _countOk += 1;
                    }

                    if (_countOk == dataCheck.Count)
                    {
                        _offSiren = false;
                        _isWrite = false;

                        if (_sirenValue == 1)
                            _easyDriverConnector.GetTag("Local Station/Channel1/Device1/Siren").Write("0");
                    }
                }

                if (_labTime.InvokeRequired)
                {
                    _labTime.BeginInvoke(new Action(() =>
                    {
                        _labTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    }));
                }
                else
                {
                    _labTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                }

                if (_btnOffSiren.InvokeRequired)
                {
                    _btnOffSiren.BeginInvoke(new Action(() =>
                    {
                        _btnOffSiren.Text = $"Tắt còi = {_offSiren}";
                    }));
                }
                else
                {
                    _btnOffSiren.Text = $"Tắt còi = {_offSiren}";
                }
            }
            catch (Exception ex) { }
            finally
            {
                t.Enabled = true;
            }
        }

        public List<DataModel> GetLatestDataWithLocation()
        {
            string sql = @"
                SELECT 
                    td.Id,
                    td.DateTime as CreateAt,
                    td.LocationId,
                    td.LocationName,
                    td.Value,
                    configModel.LowLevel,
                    configModel.HighLevel
                FROM gateway.test_realtime td
                JOIN gateway.test_location configModel
                    ON configModel.Id = td.LocationId;
            ";

            using (var conn = _db.GetConnection())
            {
                return conn.Query<DataModel>(sql).ToList();
            }
        }
    }
}
