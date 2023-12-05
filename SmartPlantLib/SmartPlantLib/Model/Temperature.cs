using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantLib.Model
{
    public class Temperature
    {
        public double Temp { get; set; }
        public DateTime CreatedTime { get; set; }


        public override string ToString()
        {
            return $"{{{nameof(CreatedTime)}={CreatedTime.ToString()},{nameof(Temp)}={Temp.ToString()}}}";
        }




    }
}
