using SmartPlantLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantLib.Model
{
    public class SensorData
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Moisture { get; set; }
        public double WaterLevel { get; set; }
        public double LightResistance { get; set; }
        public DateTime CreatedTime { get; set; }

        public SensorData(TemperatureEntity e)
        {
            Temperature = e.Temperature;
            CreatedTime = e.CreatedTimestamp;
            Humidity = e.Humidity;
            Moisture = e.Moisture;
            WaterLevel = e.WaterLevel;
            LightResistance = e.LightResistance;
        }
    }
}
