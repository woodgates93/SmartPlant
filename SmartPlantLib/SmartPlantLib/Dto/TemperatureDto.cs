using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantLib.Dto
{
    public class TemperatureDto
    {
        [DataMember(Name = "temperature")]
        public double Temperature { get; set; }

        [DataMember(Name = "humidity")]
        public double Humidity { get; set; }

        [DataMember(Name = "moisture")]
        public double Moisture { get; set; }

        [DataMember(Name = "waterlevel")]
        public double WaterLevel { get; set; }

        [DataMember(Name = "lightresistance")]
        public double LightResistance { get; set; }


    }
}
