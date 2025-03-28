using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PharmaAPI.Business.Business.Interface;
using PharmaAPI.Business.Business;
using PharmaAPI.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IClienteBusiness, ClienteBusiness>();
builder.Services.AddScoped<IMateriaPrimaBusiness, MateriaPrimaBusiness>();
builder.Services.AddScoped<IPedidoBusiness, PedidoBusiness>();
builder.Services.AddScoped<IMedicamentoBusiness, MedicamentoBusiness>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pharma API", Version = "v1" });
});

var app = builder.Build();


app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharma API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();

