using Microsoft.EntityFrameworkCore;
using gFit.Context;
using Microsoft.OpenApi.Models;
using gFit.Repositories.Implementation;
using gFit.Repositories.Interface;
using gFit.Services.Implementation;
using gFit.Services.Interface;
using gFit.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Database Config
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

// AutoMapper Config
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Cors

builder.Services.AddCors(Options =>
{
    Options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Dependecy Injection Service and Repository
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();

builder.Services.AddScoped<IExerciseCategoryRepository, ExerciseCategoryRepository>();
builder.Services.AddScoped<IExerciseCategoryService, ExerciseCategoryService>();

builder.Services.AddScoped<IExerciseImageRepository, ExerciseImageRepository>();
builder.Services.AddScoped<IExerciseImageService, ExerciseImageService>();

builder.Services.AddScoped<IMuscleRepository, MuscleRepository>();
builder.Services.AddScoped<IMuscleService, MuscleService>();

builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();

builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();

builder.Services.AddScoped<ITrainingSeriesRepository, TrainingSeriesRepository>();
builder.Services.AddScoped<ITrainingSeriesService, TrainingSeriesService>();

builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();
builder.Services.AddScoped<IPersonalService, PersonalService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<IEmailConfirmationService, EmailConfirmationService>();

// Swagger Config 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "gFit",
        Version = "v1",
        Description = "An API for gym.",
        Contact = new OpenApiContact
        {
            Name = "Giovana Assis",
            Email = "giovana.sant@hotmail.com"
        }
    });
});

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
