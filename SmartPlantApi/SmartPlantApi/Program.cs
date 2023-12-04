using SmartPlantLib.Collection;
using SmartPlantApiData.Repos;
using SmartPlantApiData;

using (var context = new SmartPlantContext())
{
    context.Database.EnsureCreated();
}


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SmartPlantContext>();

builder.Services.AddSingleton<TemperatureCellection>();
builder.Services.AddSingleton<TemperatureRepo>();

//builder.Services.AddSingleton<>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
