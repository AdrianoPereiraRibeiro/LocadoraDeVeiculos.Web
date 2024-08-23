using ControleCinema.Infra.Orm.ModuloSala;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado;

public class LocadoraDbContext : DbContext
{
    public DbSet<GrupoDeAutomoveis> GrupoDeAutomoveis { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MapeadorGrupoDeVeiculosEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorVeiculo());

        base.OnModelCreating(modelBuilder);
    }
}