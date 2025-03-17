
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;

namespace StoreMarient.EntitiesConfig.Base
{
    public class BaseDBConfiguracion<TEntity> where TEntity : BasicEntity
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad

            modelBuilder.Entity<TEntity>().Property(entity => entity.Id).IsRequired()
                         .ValueGeneratedOnAdd();

            modelBuilder.Entity<TEntity>().HasKey(entity => entity.Id);

            #endregion
        }
    }
}
