using ApiCoreEmpleadosRoutes.Data;
using ApiCoreEmpleadosRoutes.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryEmpleados>();
builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();

// Redirigir la raíz a /scalar
app.MapGet("/", context =>
{
context.Response.Redirect("/scalar");
    return Task.CompletedTask;
});

app.UseAuthorization();

app.MapControllers();

app.Run();
