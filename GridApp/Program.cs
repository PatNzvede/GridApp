using GridApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PalkDbContext>(options => options.UseSqlServer(conn));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("GridCORS", policy =>
{
    policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("GridCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
