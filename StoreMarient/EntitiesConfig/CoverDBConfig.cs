
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;
using StoreMarient.EntitiesConfig.Base;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class CoverDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Cover>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Cover>(entity =>
            {
                entity.HasIndex(e => new { e.Model, e.PhoneTypeId }).IsUnique();
            });

            #endregion

        }
    }
}
