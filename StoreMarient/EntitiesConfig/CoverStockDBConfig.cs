
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;
using StoreMarient.EntitiesConfig.Base;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class CoverStockDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<CoverStock>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<CoverStock>(entity =>
            {
                entity.HasIndex(e => new { e.CoverId, e.CoverTypeId }).IsUnique();
            });

            #endregion

        }
    }
}
