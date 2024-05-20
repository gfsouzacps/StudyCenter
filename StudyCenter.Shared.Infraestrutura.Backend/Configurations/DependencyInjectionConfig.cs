using Microsoft.Extensions.DependencyInjection;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

namespace StudyCenter.Shared.Infraestrutura.Backend.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAnotacoesTopicosCommandRepository, AnotacoesTopicosCommandRepository>();
            services.AddScoped<IAnotacoesTopicosQueryRepository, AnotacoesTopicosQueryRepository>();

            services.AddScoped<IMateriasCommandRepository, MateriasCommandRepository>();
            services.AddScoped<IMateriasQueryRepository, MateriasQueryRepository>();

            services.AddScoped<ISessaoTopicosCommandRepository, SessaoTopicosCommandRepository>();
            services.AddScoped<ISessaoTopicosQueryRepository, SessaoTopicosQueryRepository>();

            services.AddScoped<ISessoesCommandRepository, SessoesCommandRepository>();
            services.AddScoped<ISessoesQueryRepository, SessoesQueryRepository>();

            services.AddScoped<ITopicosCommandRepository, TopicosCommandRepository>();
            services.AddScoped<ITopicosQueryRepository, TopicosQueryRepository>();
        }
    }
}
