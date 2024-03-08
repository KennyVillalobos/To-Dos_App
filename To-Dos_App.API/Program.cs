using Microsoft.EntityFrameworkCore;
using To_Dos_App.Application.Services;
using To_Dos_App.Core.Interfaces;
using To_Dos_App.Infraestructure.Data;
using To_Dos_App.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Adding Db Services
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IToDoTaskServices, ToDoTaskServices>();
builder.Services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();


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
