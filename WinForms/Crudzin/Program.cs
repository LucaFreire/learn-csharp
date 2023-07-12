using Crudzin.Model;
using Crudzin.Repository;
using Crudzin.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Crudzin
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            ApplicationConfiguration.Initialize();
            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                services.AddScoped<CrudWinformsContext>();
                services.AddTransient<IProductService, ProductService>();
                services.AddTransient<IRepository<Produto>, ProdutoRepository>();
                services.AddTransient<IRepository<Estoque>, EstoqueRepository>();
                services.AddTransient<Form1>();
            });
        }

    }
}