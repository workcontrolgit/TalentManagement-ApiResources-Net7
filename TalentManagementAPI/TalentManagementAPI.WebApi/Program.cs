using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Text.Json;
using TalentManagementAPI.Application;
using TalentManagementAPI.Infrastructure.Persistence;
using TalentManagementAPI.Infrastructure.Persistence.Contexts;
using TalentManagementAPI.Infrastructure.Shared;
using TalentManagementAPI.WebApi.Extensions;

try
{
    var builder = WebApplication.CreateBuilder(args);
    // load up serilog configuraton
    Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
    builder.Host.UseSerilog(Log.Logger);
    builder.Services.AddApplicationLayer();
    builder.Services.AddPersistenceInfrastructure(builder.Configuration);
    builder.Services.AddSharedInfrastructure(builder.Configuration);
    builder.Services.AddSwaggerExtension();
    builder.Services.AddControllersExtension();
    // CORS
    builder.Services.AddCorsExtension();
    builder.Services.AddHealthChecks()
        .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
    //API Security
    builder.Services.AddJWTAuthentication(builder.Configuration);
    builder.Services.AddAuthorizationPolicies(builder.Configuration);
    // API version
    builder.Services.AddApiVersioningExtension();
    // API explorer
    builder.Services.AddMvcCore()
        .AddApiExplorer();
    // API explorer version
    builder.Services.AddVersionedApiExplorerExtension();
    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        // use context
        // For fast prototype, use dbContext.Database.EnsureCreated()
        dbContext.Database.EnsureCreated();
        // To automate migration on startup, use dbContext.Database.Migrate();
        // dbContext.Database.Migrate();
    }


    // Add this line; you'll need `using Serilog;` up the top, too
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseRouting();
    //Enable CORS
    app.UseCors("AllowAll");
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSwaggerExtension();
    app.UseErrorHandlingMiddleware();
    //app.UseHealthChecks("/health");
    //app.UseHealthChecks("/health", new HealthCheckOptions
    //{
    //    Predicate = check => check.Tags.Contains("database"),
    //    ResponseWriter = async (context, report) =>
    //    {
    //        context.Response.ContentType = "application/json";
    //        var options = new JsonSerializerOptions
    //        {
    //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    //        };
    //        var json = JsonSerializer.Serialize(new
    //        {
    //            status = report.Status.ToString(),
    //            database = report.Entries["database"].Status.ToString()
    //        }, options);
    //        await context.Response.WriteAsync(json);
    //    }
    //});
    app.MapHealthChecks("/health");
    app.MapControllers();
    app.Run();

    Log.Information("Application Starting");

}
catch (Exception ex)
{
    Log.Warning(ex, "An error occurred starting the application");
}
finally
{
    Log.CloseAndFlush();
}
