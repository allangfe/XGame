using System.Data.Entity.ModelConfiguration;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence.Map
{
    public class MapJogo : EntityTypeConfiguration<Jogo>
    {
        public MapJogo()
        {
            ToTable("Jogo");

            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Descricao).HasMaxLength(255).IsRequired();
            Property(x => x.Produtora).HasMaxLength(50);
            Property(x => x.Distribuidora).HasMaxLength(50);
            Property(x => x.Genero).HasMaxLength(50).IsRequired();
            Property(x => x.Site).HasMaxLength(200);
        }
    }
}
