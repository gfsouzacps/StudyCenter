﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol.Plugins;
using StudyCenter.API.Data.Repositories;

namespace StudyCenter.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<MateriasRepository>();
            services.AddScoped<IMateriasRepository, MateriasRepository>();

            services.AddScoped<SessoesRepository>();
            services.AddScoped<ISessoesRepository, SessoesRepository>();

            services.AddScoped<TopicosRepository>();
            services.AddScoped<ITopicosRepository, TopicosRepository>();
        }
    }
}
