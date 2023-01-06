using System.Reflection;

public interface IModuleDefinition
{
    void AddModules(WebApplicationBuilder builder);
    public void UseModules(WebApplication app);
}

public static class ModuleDefinitionExtensions
{
    public static void AddModules(this WebApplicationBuilder builder)
    {
        var endpointsDefinitions = new List<IModuleDefinition>();

        endpointsDefinitions.AddRange(Assembly.GetCallingAssembly().ExportedTypes
            .Where(x => typeof(IModuleDefinition).IsAssignableFrom(x) && !x.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IModuleDefinition>());


        foreach (var endpoint in endpointsDefinitions)
        {
            endpoint.AddModules(builder);
        }

        builder.Services.AddSingleton(endpointsDefinitions as IReadOnlyCollection<IModuleDefinition>);
    }

    public static void AddModuleDefinitions(this WebApplicationBuilder builder, params Type[] scanMarkers)
    {
        var endpointsDefinitions = new List<IModuleDefinition>();

        foreach (var marker in scanMarkers)
        {
            endpointsDefinitions.AddRange(marker.Assembly.ExportedTypes
                .Where(x => typeof(IModuleDefinition).IsAssignableFrom(x) && !x.IsInterface &&
                            x.Name.Contains(marker
                                .Name))
                .Select(Activator.CreateInstance)
                .Cast<IModuleDefinition>());
        }

        foreach (var endpoint in endpointsDefinitions)
        {
            endpoint.AddModules(builder);
        }

        builder.Services.AddSingleton(endpointsDefinitions as IReadOnlyCollection<IModuleDefinition>);
    }

    public static void UseModules(this WebApplication app)
    {
        var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IModuleDefinition>>();

        foreach (var featureDefinition in definitions)
        {
            featureDefinition.UseModules(app);
        }
    }
}
