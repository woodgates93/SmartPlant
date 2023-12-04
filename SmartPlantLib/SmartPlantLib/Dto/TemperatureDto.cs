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
        [DataMember(Name = "temp")]
        public double Temp { get; set; }
    }
}
