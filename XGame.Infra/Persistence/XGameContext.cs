using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameContext :DbContext
    {
        public XGameContext() : base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Jogador> Jogadores { get; set; }

        public IDbSet<Plataforma> Plataformas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar varchar ao invés de nvarchar
            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));

            //Caso eu esqueça de informar o tamanho  do campo ele irá colocar varchar 100
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(100));

            //Mapeia as entidades
            //modelBuilder.Configurations.Add(new JogadorMap());
            //modelBuilder.Configurations.Add(new PlataformaMap());

            //Adiciona entidade mapeada automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
