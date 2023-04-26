using FluentValidation.AspNetCore;
using Leonardo.LabschoolProjeto.Repository.IntarfaceRepository;
using Leonardo.LabschoolProjeto.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Leonardo.LabschoolProjeto.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(options =>
{
    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

    // Automatic registration of validators in assembly
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}); ;


builder.Services.AddDbContext<LabSchoolContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LabSchoolContext")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IPedagogoRepository, PedagogoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
