namespace SirenCenter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._labTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._labSriverStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._sirenStatus = new System.Windows.Forms.Panel();
            this._grid = new System.Windows.Forms.DataGridView();
            this._btnOffSiren = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(-233, -172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1267, 64);
            this.label1.TabIndex = 11;
            this.label1.Text = "CONNECTION TORQUE LOG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-224, 602);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "TT kết nối Driver:";
            // 
            // _labTime
            // 
            this._labTime.AutoSize = true;
            this._labTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labTime.Location = new System.Drawing.Point(555, 75);
            this._labTime.Name = "_labTime";
            this._labTime.Size = new System.Drawing.Size(183, 20);
            this._labTime.TabIndex = 8;
            this._labTime.Text = "dd/MM/YYYY HH:mm:ss";
            this._labTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "TT kết nối Driver:";
            // 
            // _labSriverStatus
            // 
            this._labSriverStatus.AutoSize = true;
            this._labSriverStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labSriverStatus.Location = new System.Drawing.Point(145, 75);
            this._labSriverStatus.Name = "_labSriverStatus";
            this._labSriverStatus.Size = new System.Drawing.Size(98, 20);
            this._labSriverStatus.TabIndex = 12;
            this._labSriverStatus.Text = "Driver status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "TT kết nối Driver:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Blue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(-2, -3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(740, 64);
            this.label6.TabIndex = 14;
            this.label6.Text = "BÁO CÒI TẬP TRUNG";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Trạng Thái Cảnh Báo";
            // 
            // _sirenStatus
            // 
            this._sirenStatus.BackColor = System.Drawing.SystemColors.ControlDark;
            this._sirenStatus.Location = new System.Drawing.Point(306, 122);
            this._sirenStatus.Name = "_sirenStatus";
            this._sirenStatus.Size = new System.Drawing.Size(200, 100);
            this._sirenStatus.TabIndex = 16;
            // 
            // _grid
            // 
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 263);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(713, 559);
            this._grid.TabIndex = 17;
            // 
            // _btnOffSiren
            // 
            this._btnOffSiren.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._btnOffSiren.Location = new System.Drawing.Point(592, 166);
            this._btnOffSiren.Name = "_btnOffSiren";
            this._btnOffSiren.Size = new System.Drawing.Size(133, 56);
            this._btnOffSiren.TabIndex = 18;
            this._btnOffSiren.Text = "Tắt Còi";
            this._btnOffSiren.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 834);
            this.Controls.Add(this._btnOffSiren);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._sirenStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._labSriverStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._labTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _labTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _labSriverStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel _sirenStatus;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Button _btnOffSiren;
    }
}

