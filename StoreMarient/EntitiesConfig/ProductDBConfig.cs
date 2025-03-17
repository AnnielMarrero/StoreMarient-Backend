
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;
using StoreMarient.EntitiesConfig.Base;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class ProductDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Product>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            #endregion

        }
    }
}
