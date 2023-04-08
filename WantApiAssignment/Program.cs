using DatabaseProject.DatabaseContext;
using DatabaseProject.Interfaces;
using DatabaseProject.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// UseInMemoryDatabase
//builder.Services.AddDbContext<WatnContentDbContext>(options => options.UseInMemoryDatabase("WatnWebContentDb"));

//SQL Server Database 
builder.Services.AddDbContext<WatnContentDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));


builder.Services.AddScoped<IPostContentRepository, PostContentRepository>();

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
