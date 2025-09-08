using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenCenter
{
    public class DataModel
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public int LocationId { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }
        public double LowLevel { get; set; }
        public double HighLevel { get; set; }
    }
}
