using Fitness_Tracker_App_00012951.Data;
using Fitness_Tracker_App_00012951.Models;
using Fitness_Tracker_app.Repositories;
using Fitness_Tracker_App_00012951.Repositories;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>

{

    options.AddPolicy(MyAllowSpecificOrigins,

               policy =>

               {

                   policy.WithOrigins("http://localhost:4200")

                           .AllowAnyHeader()

                           .AllowAnyMethod()

                           .AllowAnyOrigin();

               });

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<GeneralDBContext>(
    o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IRepository<Workout>, WorkoutRepository>();
builder.Services.AddScoped<IRepository<WorkoutType>, WorkoutTypeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
