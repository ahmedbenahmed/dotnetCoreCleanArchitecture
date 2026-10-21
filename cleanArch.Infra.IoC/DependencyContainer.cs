
using cleanArch.Application.Interfaces;
using cleanArch.Application.Services;
using infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace cleanArch.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<ICourseService, CourseService>();
            // Infra.Data Layer
            services.AddScoped<ICourseRepository, CoursesRepository>();
        }
    }
}
