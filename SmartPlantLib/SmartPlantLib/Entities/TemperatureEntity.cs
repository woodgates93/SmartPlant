using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantLib.Entities
{
    public class TemperatureEntity
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
