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

// Registrar os servi�os
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configure o pipeline de solicita��o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // O valor padr�o do HSTS � de 30 dias. Voc� pode querer alterar isso para cen�rios de produ��o, veja https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
