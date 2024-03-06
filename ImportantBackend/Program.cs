using TestAutomation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add database services to the container.
DeviceService deviceService = new("Data Source=TestAutomation.db;Version=3;");
builder.Services.AddSingleton<IDeviceService>(deviceService);

builder.Services.AddControllers();
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



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
