using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.IRepository;
using Repositories.Repository;
using Services.IService;
using Services.Service;
using System.IO;
using System.Windows;
using TranGiaPhuFall2024WPF;

namespace TranGiaPhuFall2024WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
            .Build();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ITagRepository, TagRepository>();
            services.AddSingleton<ISystemAccountRepository, SystemAccountRepository>();
            services.AddSingleton<INewsArticleRepository, NewArticleRepository>();
            services.AddSingleton<ISystemAccountService, SystemAccountService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<INewsArticleService, NewsArticleService>();
            services.AddSingleton<ITagService, TagService>();
            services.AddSingleton<Login>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<CategoryWindow>();
            services.AddSingleton<AccountWindow>();
            services.AddTransient<PopupCategoryWindow>();
            services.AddTransient<PopupAccountWindow>();
            services.AddTransient<PopupNewsArticle>();
            services.AddTransient<PopupProfileWindow>();
            services.AddTransient<ReportNewsArticle>();
            services.AddTransient<HistoryNewsArticle>();
            services.AddSingleton<IConfiguration>(configuration);
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var login = _serviceProvider.GetService<Login>();
            login.Show();
        }   
    }

}
