
using System.Reflection;
using ControleCinema.Infra.Orm.ModuloSala;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Aplicacao.Servicos;

namespace LocadoraDeVeiculos.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LocadoraDbContext>();

            builder.Services.AddScoped<IRepositorioGrupoDeAutomoveis, RepositorioGrupoDeVeiculosEmOrm>();
            builder.Services.AddScoped<GrupoDeAutomoveisService>();
            builder.Services.AddScoped<IRepositorioVeiculo, RepositorioVeiculoEmOrm>();
            builder.Services.AddScoped<VeiculoService>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();
            builder.Services.AddScoped<ClienteService>();

            builder.Services.AddAutoMapper(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {

                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}