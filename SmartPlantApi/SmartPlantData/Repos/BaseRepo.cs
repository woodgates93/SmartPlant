using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantApiData.Repos
{
    public abstract class BaseRepo<T> where T : class
    {
        public SmartPlantContext Context { get; }
        public BaseRepo(SmartPlantContext context)
        {
            Context = context;
        }

        public T Save(T entity)
        {
            return Context.SaveEntity(entity);
        }

        public ICollection<T> Save(ICollection<T> entities)
        {
            return Context.SaveEntities(entities);
        }
    }
}
