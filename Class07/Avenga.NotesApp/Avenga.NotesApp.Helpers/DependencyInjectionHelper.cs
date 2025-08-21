using Avenga.NotesApp.DataAccess;
using Avenga.NotesApp.DataAccess.Implementations;
using Avenga.NotesApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Avenga.NotesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection service)
        {
            service.AddDbContext<NotesAppDbContext>(x => x.UseSqlServer("Server=.;Database=NotesAppDb;Trusted_Connection=True;TrustServerCertificate=True;"));
        }

        public static void InjectRepositories(IServiceCollection service)
        {
            service.AddTransient<IRepository<Note>, NoteRepository>();
            service.AddTransient<IRepository<User>, UserRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
        }
    }
}
