
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;
using StoreMarient.EntitiesConfig.Base;

namespace StoreMarient.EntitiesConfig.Base
{
    internal class PieceDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Piece>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Piece>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            #endregion

        }
    }
}
