using A_Angular.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers()
     .AddNewtonsoftJson(option =>
     {
         option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
         option.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
     });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:5018", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyOrigin()
                                .AllowAnyMethod();
        });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ItemDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("appCon")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.UseAuthorization();

app.MapControllers();

app.Run();
