using Honeyside.Api.Data.DAL;
using Microsoft.EntityFrameworkCore;
using NLog;

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
var logger = LogManager.Setup().GetCurrentClassLogger();

try {
    logger.Debug("Starting API");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    // Add database context
    var connectionString = builder.Configuration.GetConnectionString("HoneysideDb");
    builder.Services.AddDbContext<HoneysideDbContext>(options => options.UseSqlServer(connectionString));

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

    logger.Debug("API is running");
}
catch (Exception ex) {
    logger.Error(ex, "Stopped API because of an exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}
