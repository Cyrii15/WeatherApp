using Microsoft.EntityFrameworkCore;
using Weather.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDataContext>(options =>
    options.UseCosmos(
        "AccountEndpoint=https://cosmos-cloudsoc-demo.documents.azure.com:443/;AccountKey=aIpNp05wt4VTzYdTDCr4f1MKcOb6eF6yJMlcWYkSjziObh6TBLFjjSmTkEckirTUdfhYIMSaFzlKepgWpLia4A==;",
        "Database"
    ));

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

