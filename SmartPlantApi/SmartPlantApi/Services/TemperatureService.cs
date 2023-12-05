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

        public List<Temperature> GetLatest()
        {
            List<TemperatureEntity> entities = new List<TemperatureEntity>(_temperatureRepo.GetLatest());
            var temperatures = new List<Temperature>();
            entities.ForEach(e => temperatures.Add(new Temperature() {Temp = e.Value, CreatedTime = e.CreatedTimestamp}));
            return temperatures;
        }

        public List<Temperature> Get(int rows)
        {
            List<TemperatureEntity> entities = new List<TemperatureEntity>(_temperatureRepo.GetLatest(rows));
            var temperatures = new List<Temperature>();
            entities.ForEach(e => temperatures.Add(new Temperature() { Temp = e.Value, CreatedTime = e.CreatedTimestamp }));
            return temperatures;
        }

        public TemperatureEntity Save(TemperatureEntity temperatureEntity)
        {
            return _temperatureRepo.Save(temperatureEntity);
        }
    }
}
