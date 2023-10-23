using Microsoft.EntityFrameworkCore;
using ProgettoPtco.Data;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string cnnStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddSqlite<TemperatureDBContext>(cnnStr);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetService<TemperatureDBContext>();
    ctx.Database.Migrate();
    if (!ctx.detections.Any())
    {
        string json = File.ReadAllText("IotData.json");
        List<Detection> det = JsonSerializer.Deserialize<List<Detection>>(json);
        det.ForEach(t => t.id = 0);
        List<Detection> dtid = det.FindAll(x => x.idDevice == 6);
        ctx.detections.AddRange(dtid);
        ctx.SaveChanges();
    }
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
