
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;
using StoreMarient.EntitiesConfig.Base;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class PhoneDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Phone>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasIndex(e => new { e.Model, e.PieceId }).IsUnique();
            });

            #endregion

        }
    }
}
