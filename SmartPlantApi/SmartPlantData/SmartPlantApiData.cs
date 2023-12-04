using Microsoft.EntityFrameworkCore;
using SmartPlantLib.Entities;
using SmartPlantLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantApiData
{
    public class SmartPlantContext : DbContext
    {
        DbSet<TemperatureEntity> Temperatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
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
    }
}
