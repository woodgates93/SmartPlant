using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantLib.Entities
{
    public class TemperatureEntity
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Moisture { get; set; }
        public double WaterLevel { get; set; }
        public double LightResistance { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
