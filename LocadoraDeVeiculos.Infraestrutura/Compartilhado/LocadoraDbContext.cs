﻿using ControleCinema.Infra.Orm.ModuloSala;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloPrecosCombustiveis;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloAluguel;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraDeVeiculos.Infraestrutura.ModuloPrecosCombustiveis;
using LocadoraDeVeiculos.Infraestrutura.ModuloTaxaEServico;
using LocadoraDeVeiculos.Web.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Web.Dominio.ModuloUsuario;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado;

public class LocadoraDbContext : IdentityDbContext<Usuario, Perfil, int>
{
    public DbSet<GrupoDeAutomoveis> GrupoDeAutomoveis { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Condutor> Condutores { get; set; }
    public DbSet<PrecosCombustiveis> PrecosCombustiveis { get; set; }
    public DbSet<TaxaEServico> TaxasEServicos { get; set; }
    public DbSet<PlanoCobranca> PlanosCobrancas { get; set; }
    public DbSet<Aluguel> Alugueis { get; set; }

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
        modelBuilder.ApplyConfiguration(new MapeadorVeiculo());
        modelBuilder.ApplyConfiguration(new MapeadorGrupoDeVeiculosEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorCliente());
        modelBuilder.ApplyConfiguration(new MapeadorCondutorEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorPrecosCombustiveisEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorTaxaEServicoEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorAluguel());
        

        base.OnModelCreating(modelBuilder);
    }
}