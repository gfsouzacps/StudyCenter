using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

namespace StudyCenter.Shared.Infraestrutura.Backend.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            services.AddDbContext<StudyCenterDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<AnotacoesTopicosQueryRepository>();
            services.AddScoped<IAnotacoesTopicosCommandRepository, AnotacoesTopicosCommandRepository>();
            services.AddScoped<IAnotacoesTopicosQueryRepository, AnotacoesTopicosQueryRepository>();

            services.AddScoped<MateriasQueryRepository>();
            services.AddScoped<IMateriasCommandRepository, MateriasCommandRepository>();
            services.AddScoped<IMateriasQueryRepository, MateriasQueryRepository>();

            services.AddScoped<SessaoTopicosQueryRepository>();
            services.AddScoped<ISessaoTopicosCommandRepository, SessaoTopicosCommandRepository>();
            services.AddScoped<ISessaoTopicosQueryRepository, SessaoTopicosQueryRepository>();

            services.AddScoped<SessoesQueryRepository>();
            services.AddScoped<ISessoesCommandRepository, SessoesCommandRepository>();
            services.AddScoped<ISessoesQueryRepository, SessoesQueryRepository>();

            services.AddScoped<TopicosQueryRepository>();
            services.AddScoped<ITopicosCommandRepository, TopicosCommandRepository>();
            services.AddScoped<ITopicosQueryRepository, TopicosQueryRepository>();
        }
    }
}
