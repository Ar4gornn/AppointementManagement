using Microsoft.EntityFrameworkCore;
using AppointmentManagement.Data;
using AutoMapper;
using AppointmentManagement.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper and register profiles
builder.Services.AddAutoMapper(typeof(AppointmentProfile), typeof(AvailabilityProfile), typeof(UnavailabilityProfile), typeof(AppointmentTypeProfile));

// Swagger/OpenAPI configuration
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

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    
    // Ensure the database is created before seeding
    await context.Database.MigrateAsync();
    await DataSeeder.SeedData(context);
}

app.Run();