using APPLICATION.APPLICATION.CONFIGURATIONS;
using APPLICATION.DOMAIN.DTOS.CONFIGURATION;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

try
{
    // Preparando builder.
    var builder = WebApplication.CreateBuilder(args);

    // Pegando configurações do appsettings.json.
    var configurations = builder.Configuration;

    builder.Services.AddSignalR();

    /// <summary>
    /// Chamada das configurações do projeto.
    /// </summary>
    builder.Services
        .AddHttpContextAccessor()
        .Configure<AppSettings>(configurations).AddSingleton<AppSettings>()
        .AddEndpointsApiExplorer()
        .AddOptions()
        .ConfigureLanguage()
        .ConfigureContexto(configurations)
        .ConfigureAuthorization(configurations)
        .ConfigureAuthentication(configurations)
        .ConfigureApllicationCookie()
        .ConfigureSwagger(configurations)
        .ConfigureDependencies(configurations, builder.Environment)
        .ConfigureRefit(configurations);

    // Se for em produção executa.
    if (builder.Environment.IsProduction())
    {
        builder.Services
            .ConfigureTelemetry(configurations)
            .ConfigureApplicationInsights(configurations);
    }

    // Continuação do pipeline...
    builder.Services
        //.ConfigureSerilog()
        .ConfigureGraphQL()
        .ConfigureHealthChecks(configurations)
        .ConfigureCors()
        //.ConfigureFluentSchedulerJobs()
        //.ConfigureHangFire(configurations)
        .AddControllers(options =>
        {
            options.EnableEndpointRouting = false;

            options.Filters.Add(new ProducesAttribute("application/json"));

        })
        .AddNewtonsoftJson();

    // Preparando WebApplication Build.
    var applicationbuilder = builder.Build();

    // Chamada das connfigurações do WebApplication Build.
    applicationbuilder
        .UseHttpsRedirection()
        .UseDefaultFiles()
        .UseStaticFiles()
        .UseCookiePolicy()
        .UseRouting()
        .UseCors("CorsPolicy")
        .UseResponseCaching()
        .UseAuthorization()
        .UseAuthentication()
        .UseHealthChecks()
        .UseSwaggerConfigurations(configurations)
        .UseEndpoints();
        //.UseHangfireDashboard();

    // Chamando a configuração do GraphQL.
    applicationbuilder.MapGraphQL();

    Log.Information($"[LOG INFORMATION] - Inicializando aplicação [TOOLS.API]\n");

    // Iniciando a aplicação com todas as configurações já carregadas.
    applicationbuilder.Run();
}
catch (Exception exception)
{
    Log.Error("[LOG ERROR] - Ocorreu um erro ao inicializar a aplicacao [TOOLS.API]\n", exception.Message);
}