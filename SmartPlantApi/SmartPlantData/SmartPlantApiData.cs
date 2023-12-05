using Microsoft.EntityFrameworkCore;
using SmartPlantLib.Entities;

namespace SmartPlantData
{
    public class SmartPlantContext : DbContext
    {
        DbSet<TemperatureEntity> Temperatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemperatureEntity>()
                .Property(e => e.CreatedTimestamp)
                .HasDefaultValueSql("GETUTCDATE()");
        }


        public T SaveEntity<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }

            Set<T>().Update(entity);

            try
            {
                SaveChanges();
                return entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public ICollection<T> SaveEntities<T>(ICollection<T> entities) where T : class
        {
            if (entities == null || entities.Count == 0)
            {
                throw new ArgumentNullException(nameof(entities), "List of entities cannot be null or empty");
            }

            Set<T>().UpdateRange(entities);

            try
            {
                SaveChanges();
                return entities;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public ICollection<T> Get<T>(int rows = 100) where T : class
        {
            using var context = new SmartPlantContext();

            var entityType = context.Model.FindEntityType(typeof(T));
            if (entityType == null || entityType.FindProperty("CreatedTimestamp") == null)
            {
                throw new InvalidOperationException("Type must have a CreatedTimestamp property.");
            }

            return context.Set<T>()
                .OrderByDescending(e => EF.Property<DateTime>(e, "CreatedTimestamp"))
                .Take(rows)
                .ToList();
        }

    }
}
