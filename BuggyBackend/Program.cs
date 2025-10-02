using BuggyBackend.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add database services to the container.
TestResultsService testResultsService = new("Data Source=TestAutomation.db;");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(testResultsService);

var app = builder.Build();

app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

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

// Used for the IntegrationTests project to work.
public partial class Program { }
