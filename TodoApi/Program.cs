using Microsoft.EntityFrameworkCore;
using TodoApi.Database;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.Load();
builder.Services.AddDbContext<TodoContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
