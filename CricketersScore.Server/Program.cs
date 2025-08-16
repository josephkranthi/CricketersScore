using CricketersScore.Server.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Adding DBContext Service
builder.Services.AddDbContext<TestContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(
        options => options.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader()
    );



app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
