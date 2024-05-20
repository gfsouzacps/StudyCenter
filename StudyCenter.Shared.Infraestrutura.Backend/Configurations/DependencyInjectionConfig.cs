using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol.Plugins;
using StudyCenter.API.Api.Controllers;
using StudyCenter.API.Data.Repositories;

namespace StudyCenter.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddScoped<AnotacoesTopicosRepository>();
            services.AddScoped<IAnotacoesTopicosRepository, AnotacoesTopicosRepository>();

            services.AddScoped<MateriasRepository>();
            services.AddScoped<IMateriasRepository, MateriasRepository>();

            services.AddScoped<SessaoTopicosRepository>();
            services.AddScoped<ISessaoTopicosRepository, SessaoTopicosRepository>();

            services.AddScoped<SessoesRepository>();
            services.AddScoped<ISessoesRepository, SessoesRepository>();

            services.AddScoped<TopicosRepository>();
            services.AddScoped<ITopicosRepository, TopicosRepository>();
        }
    }
}
