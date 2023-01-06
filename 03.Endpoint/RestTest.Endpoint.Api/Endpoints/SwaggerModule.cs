using ModuleDefinitions;

public class SwaggerModule : IModuleDefinition
{
    public void AddModules(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
    }

    public void UseModules(WebApplication app)
    {        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
