// Arquivo Program.cs

using MudBlazor.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StudyCenter.Web.UI.Configurations;
using StudyCenter.Web.UI.Components;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();

// Register HttpClient
builder.Services.AddHttpClient();

// Registrar os serviços
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // O valor padrão do HSTS é de 30 dias. Você pode querer alterar isso para cenários de produção, veja https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
