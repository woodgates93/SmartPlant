using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantLib.Model
{
    public class Temperature
    {
        private int _id;
        private double _temperature;


        public int Id { get { return _id; } set { _id = value; } }
        public double Temp { get { return _temperature; } set { _temperature = value; } }


        public Temperature() {
            _id= 0;
            _temperature = 0;
        }

        public Temperature(int id, double temperature)
        {
            _id = id;
            _temperature = temperature;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()},{nameof(Temp)}={Temp.ToString()}}}";
        }




    }
}
