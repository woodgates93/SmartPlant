using Microsoft.EntityFrameworkCore;
using SmartPlantLib.Entities;
using SmartPlantLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantApiData.Repos
{
    public class TemperatureRepo : BaseRepo<TemperatureEntity>
    {
        public TemperatureRepo(SmartPlantContext context) : base(context)
        {
        }

        public void CreateTemperature(TemperatureEntity temperature)
        {
            base.Save(temperature);
        }
    }
}
