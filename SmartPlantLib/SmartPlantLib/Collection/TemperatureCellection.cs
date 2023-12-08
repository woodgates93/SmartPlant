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
        private List<SensorData> _tempList;
     
        
        public TemperatureCellection() {
            _tempList= new List<SensorData>();
        }

        public SensorData Add(SensorData sensorData)
        {
            _tempList.Add(sensorData);

            return sensorData;
        }

        public SensorData GetById(int id)
        {
            throw new NotImplementedException();
            //SensorData? sensorData = _tempList.Find(t => t.Id == id);

            //if (sensorData is null)
            //{
            //    throw new KeyNotFoundException();
            //}
            //return sensorData;
        }

        public IEnumerable<SensorData> GetAll()
        {
            return new List<SensorData>(_tempList);
        }


        public override string ToString()
        {
            return $"{{String.join(', ', _tempList)}}"; 
        }
    }
}
