
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;
using StoreMarient.EntitiesConfig.Base;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class PhoneTypeDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<PhoneType>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            #endregion

        }
    }
}
