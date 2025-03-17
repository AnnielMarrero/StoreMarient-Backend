using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class CoverTypeDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<CoverType>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<CoverType>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });


            #endregion

        }
    }
}
