
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;
using StoreMarient.EntitiesConfig.Base;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class MicaDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Mica>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Mica>(entity =>
            {
                entity.HasIndex(e => new { e.Model, e.PhoneTypeId }).IsUnique();
            });

            #endregion

        }
    }
}
