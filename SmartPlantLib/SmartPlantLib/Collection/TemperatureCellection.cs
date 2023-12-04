using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPlantLib.Model;

namespace SmartPlantLib.Collection
{
    public class TemperatureCellection
    {
        private List<Temperature> _tempList;
     
        
        public TemperatureCellection() {
            _tempList= new List<Temperature>();
        }

        public Temperature Add(Temperature temperature)
        {
            _tempList.Add(temperature);

            return temperature;
        }

        public Temperature GetById(int id)
        {
            Temperature? temperature = _tempList.Find(t => t.Id == id);

            if (temperature is null)
            {
                throw new KeyNotFoundException();
            }
            return temperature;
        }

        public IEnumerable<Temperature> GetAll()
        {
            return new List<Temperature>(_tempList);
        }


        public override string ToString()
        {
            return $"{{String.join(', ', _tempList)}}"; 
        }
    }
}
