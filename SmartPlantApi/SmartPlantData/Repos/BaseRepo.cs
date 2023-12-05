using SmartPlantApiData;

namespace SmartPlantData.Repos
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

        public ICollection<T> GetLatest(int rows = 100)
        {
            return Context.Get<T>(rows);
        }
    }
}
