using SmartPlantApiData;
using SmartPlantLib.Entities;

namespace SmartPlantData.Repos
{
    public class TemperatureRepo : BaseRepo<TemperatureEntity>
    {
        public TemperatureRepo(SmartPlantContext context) : base(context)
        {
        }
    }
}
