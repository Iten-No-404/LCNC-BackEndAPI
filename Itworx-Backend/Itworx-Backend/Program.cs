using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository;
using Itworx_Backend.Repository.Repository;
using Itworx_Backend.Service.Interfaces;
using Itworx_Backend.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Service Injected
builder.Services.AddScoped(typeof(iRepository<>), typeof(Repository<>));
builder.Services.AddScoped<Iunit<Unit>, UnitService>();
builder.Services.AddScoped<IuserServices<User>, UserService>();
builder.Services.AddScoped<Iwidget<Widget>, WidgetService>();
builder.Services.AddScoped<ICodeSnippet<WidgetCodeSnippet>, WidgetCodeSnippetService>();
builder.Services.AddScoped<IServices<WidgetProperty>, WidgetPropertyService>();
builder.Services.AddScoped<IServices<Property>, PropertyService>();
builder.Services.AddScoped<IServices<PropertyUnit>, PropertyUnitService>();
builder.Services.AddScoped<IPropertyValue<PropertyValue>, PropertyValueService>();
builder.Services.AddScoped<ItargetFramework<TargetFramework>, TargetFrameworkService>();
builder.Services.AddScoped<IappType<AppType>, AppTypeService>();
builder.Services.AddScoped<Iproject<Project>, ProjectService>();
builder.Services.AddScoped<IServices<ImageFile>, FileServices>();
#endregion

var app = builder.Build();

app.UseCors("corsapp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
