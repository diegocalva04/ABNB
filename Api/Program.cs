using Application.Departamentos.Queries;
using Domain;
using Infraestructure.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IDepartamentoGetAll, DepartamentoGetAll>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet(
    "/departamentos", 
    async (IDepartamentoGetAll departamentoGetAll) =>
{
    var result = await departamentoGetAll.Execute();
    return Results.Ok(result);
})
.WithName("GetDepartamentos");

app.UseHttpsRedirection();

app.Run();


