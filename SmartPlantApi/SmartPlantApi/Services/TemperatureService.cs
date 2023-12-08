using SmartPlantData.Repos;
using SmartPlantLib.Entities;
using SmartPlantLib.Model;

namespace SmartPlantApi.Services
{
    public class TemperatureService
    {
        private readonly TemperatureRepo _temperatureRepo;

        public TemperatureService(TemperatureRepo temperatureRepo)
        {
            _temperatureRepo = temperatureRepo;
        }

        public List<SensorData> GetLatest()
        {
            List<TemperatureEntity> entities = new List<TemperatureEntity>(_temperatureRepo.GetLatest());
            var temperatures = new List<SensorData>();
            entities.ForEach(e => temperatures.Add(new SensorData(e)));
            return temperatures;
        }

        public List<SensorData> Get(int rows)
        {
            List<TemperatureEntity> entities = new List<TemperatureEntity>(_temperatureRepo.GetLatest(rows));
            var temperatures = new List<SensorData>();
            entities.ForEach(e => temperatures.Add(new SensorData(e)));
            return temperatures;
        }

        public TemperatureEntity Save(TemperatureEntity temperatureEntity)
        {
            return _temperatureRepo.Save(temperatureEntity);
        }
    }
}

