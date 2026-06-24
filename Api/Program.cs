using Application.Departamentos.Queries;
using Infraestructure;
using Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfraestructure();
builder.Services.AddScoped<IDepartamentoGetAll, DepartamentoGetAll>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
    if (!dbContext.Departamentos.Any())
{
    dbContext.Departamentos.AddRange(
        new Domain.Departamento { Nombre = "Departamento 1" },
        new Domain.Departamento { Nombre = "Departamento 2" },
        new Domain.Departamento { Nombre = "Departamento 3" }
    );
    dbContext.SaveChanges();
}
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