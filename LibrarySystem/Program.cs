using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;
using LibrarySystem.Services;
using LibrarySystem.UI;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IBookRepository, InMemoryBookRepository>();
            services.AddSingleton<ILibraryService, LibraryService>();

            services.AddSingleton<IMagazineRepository, InMemoryMagazineRepository>();
            services.AddSingleton<IMagazineService, MagazineService>();
            services.AddSingleton<ConsoleUI>();
            
            var provider = services.BuildServiceProvider();
            var app = provider.GetRequiredService<ConsoleUI>();
            app.Run();

            
        }
    }
}
