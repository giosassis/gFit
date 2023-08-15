using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using gFit.Context; // Substitua pelo namespace correto do seu projeto
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Configuração do ambiente e das opções
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDeveloperExceptionPage(); // UseDeveloperExceptionPage() no ASP.NET 7
}
else
{
    // Configurações para ambiente de produção
}

// Configuração do banco de dados
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração da autenticação
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddControllersWithViews(); // Adicionando suporte a controllers

var app = builder.Build();

// Configuração da pipeline de requisição
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // UseDeveloperExceptionPage() no ASP.NET 7
}
else
{
    // Configurações para ambiente de produção
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
