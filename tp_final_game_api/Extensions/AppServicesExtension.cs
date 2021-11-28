using System.Reflection;
using tp_final_game_api.Repositories;
using tp_final_game_api.Repositories.Interfaces;
namespace tp_final_game_api.Extensions
{
    public static class AppServicesExtension
    {

        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
        }

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
