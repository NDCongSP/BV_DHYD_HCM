using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenCenter
{
    public class DataModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateAt { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public double LowLevel { get; set; }
        public double HighLevel { get; set; }
    }
}
