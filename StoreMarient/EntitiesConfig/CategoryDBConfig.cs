using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class CategoryDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Category>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });


            #endregion

        }
    }
}
