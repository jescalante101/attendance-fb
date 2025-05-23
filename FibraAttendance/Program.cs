using FibraAttendance.Data;
using FibraAttendance.Infrastructure.Core.Infrastructure;
using FibraAttendance.Infrastructure.Service;
using FibraAttendance.Mappers;
using FibraAttendance.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", // Un nombre descriptivo para la política
        policy =>
        {
            policy.AllowAnyOrigin() // Permite cualquier origen
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .WithExposedHeaders("x-pagination");
        });
});
builder.Services.AddScoped<QueryLogger>(); // Registrar QueryLogger como un servicio
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           );

builder.Services.AddHostedService<ZkPollingService>();

builder.Services.AddScoped<IZktecoService, ZktecoDeviceService>();
// Registra ZktecoService
builder.Services.AddScoped<ZktecoDeviceService>();


builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
