using Microsoft.EntityFrameworkCore;
using SAPCS.Models;

namespace SAPCS.Data
{
    public class SAPCSContext : DbContext
    {
        public SAPCSContext(DbContextOptions<SAPCSContext> options)
            : base(options)
        {
        }

        public ICurrentUser CurrentUser;

        #region DbSet
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Seguradora> Seguradoras { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<ApoliceSegur> ApolicesSegur { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"connectionString"
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Cliente
            var ClienteBuilder = modelBuilder.Entity<Cliente>();
            ClienteBuilder.Property(cli => cli.Id).IsRequired();
            ClienteBuilder.Property(cli => cli.NomeCli).IsRequired().HasColumnType("varchar(100)");
            ClienteBuilder.Property(cli => cli.TelCli).IsRequired().HasColumnType("varchar(11)");
            ClienteBuilder.Property(cli => cli.ValTel).HasColumnType("varchar(11)");
            ClienteBuilder.Property(cli => cli.EmailCli).HasColumnType("varchar(60)");
            ClienteBuilder.Property(cli => cli.ValEmail).HasColumnType("varchar(11)");
            ClienteBuilder.Property(cli => cli.CPFCli).HasColumnType("varchar(11)");
            ClienteBuilder.Property(cli => cli.DtCadastro).HasDefaultValueSql("getdate()");
            ClienteBuilder.Property(cli => cli.DtModificacao).HasDefaultValueSql("getdate()");
            #endregion Cliente
            #region Funcionário
            var FuncionarioBuilder = modelBuilder.Entity<Funcionario>();
            FuncionarioBuilder
                    .HasOne(func => func.Usuario).WithOne(usu => usu.Funcionario)
                    .HasForeignKey<Usuario>(usu => usu.FuncionarioId);
            FuncionarioBuilder.Property(func => func.Id).IsRequired();
            FuncionarioBuilder.Property(func => func.TelFunc).HasColumnType("varchar(13)");
            #endregion Funcionário
            #region Usuário
            var UsuarioBuilder = modelBuilder.Entity<Usuario>();
            UsuarioBuilder.Property(usu => usu.Id).IsRequired();
            UsuarioBuilder.Property(usu => usu.Email).HasColumnType("varchar(50)").IsRequired();
            UsuarioBuilder.Property(usu => usu.Senha).HasColumnType("varchar(50)").IsRequired();
            #endregion Usuário
            #region Seguradora
            var SeguradoraBuilder = modelBuilder.Entity<Seguradora>();
            SeguradoraBuilder.Property(segur => segur.Id).IsRequired();
            SeguradoraBuilder.Property(segur => segur.NomeSegur).HasColumnType("varchar(50)").IsRequired();
            SeguradoraBuilder.Property(segur => segur.EndSegur).HasColumnType("varchar(100)");
            SeguradoraBuilder.Property(segur => segur.TelSegur).HasColumnType("varchar(13)");
            SeguradoraBuilder.Property(segur => segur.SiteSegur).HasColumnType("varchar(40)");
            SeguradoraBuilder.Property(segur => segur.NomeContSegur).HasColumnType("varchar(80)");
            SeguradoraBuilder.Property(segur => segur.EmailContSegur).HasColumnType("varchar(50)");
            #endregion Seguradora
            #region Serviço
            var ServicoBuilder = modelBuilder.Entity<Servico>();
            ServicoBuilder.Property(serv => serv.Id).IsRequired();
            ServicoBuilder.Property(serv => serv.NomeServ).HasColumnType("varchar(60)");
            #endregion Serviço
            #region Cotação
            var CotacaoBuilder = modelBuilder.Entity<Cotacao>();
            CotacaoBuilder.Property(cot => cot.Id).IsRequired();
            CotacaoBuilder.Property(cot => cot.ClienteId).IsRequired();
            CotacaoBuilder.Property(cot => cot.FuncionarioId).IsRequired();
            CotacaoBuilder.Property(cot => cot.ServicoId).IsRequired();
            CotacaoBuilder.Property(cot => cot.StatusCot).IsRequired();
            #endregion Cotação
            #region Apólice Seguro
            var ApoliceSegurBuilder = modelBuilder.Entity<ApoliceSegur>();
            ApoliceSegurBuilder.Property(aseg => aseg.Id).IsRequired();
            ApoliceSegurBuilder.Property(aseg => aseg.ClienteId).IsRequired();
            ApoliceSegurBuilder.Property(aseg => aseg.FuncionarioId).IsRequired();
            ApoliceSegurBuilder.Property(aseg => aseg.NomeArquivo).HasColumnType("varchar(30)").IsRequired();
            #endregion Apólice Seguro
        }
    }
}
