using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository;
using Itworx_Backend.Repository.Repository;
using Itworx_Backend.Service.Interfaces;
using Itworx_Backend.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Service Injected
builder.Services.AddScoped(typeof(iRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IServices<Unit>, UnitService>();
builder.Services.AddScoped<IuserServices<User>, UserService>();
builder.Services.AddScoped<IServices<Widget>, WidgetService>();
builder.Services.AddScoped<IServices<WidgetCodeSnippet>, WidgetCodeSnippetService>();
builder.Services.AddScoped<IServices<WidgetProperty>, WidgetPropertyService>();
builder.Services.AddScoped<IServices<Property>, PropertyService>();
builder.Services.AddScoped<IServices<PropertyUnit>, PropertyUnitService>();
builder.Services.AddScoped<IServices<PropertyValue>, PropertyValueService>();
builder.Services.AddScoped<ItargetFramework<TargetFramework>, TargetFrameworkService>();
builder.Services.AddScoped<IappType<AppType>, AppTypeService>();
builder.Services.AddScoped<IServices<Project>, ProjectService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
