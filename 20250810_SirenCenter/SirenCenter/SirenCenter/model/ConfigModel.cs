using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenCenter
{
    public class ConfigModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeviceId { get; set; }
        public double LowLevel { get; set; }
        public double HighLevel { get; set; }
    }
}
