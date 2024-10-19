using Commander.Data;
using Microsoft.EntityFrameworkCore;

namespace Commander;

internal sealed class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer(GetConnectionString()));
        services.AddScoped<ICommanderRepo, MockCommander>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    private string GetConnectionString()
    {
        const string connectionStringName = "CommanderConnection";
        const string serverPattern = "{DB_SERVER}";
        const string userPattern = "{DB_USER}";
        const string passwordPattern = "{DB_PASSWORD}";

        var server = GetEnvVar("TEST_TSQL_SERVER");
        var user = GetEnvVar("TEST_TSQL_USER");
        var password = GetEnvVar("TEST_TSQL_PASSWORD");

        var connectionString = Configuration.GetConnectionString(connectionStringName);
        if (connectionString == null) throw new ApplicationException($"Could not get {connectionStringName} connection string");
        ReplaceInConnString([(serverPattern, server), (userPattern, user), (passwordPattern, password)]);
        return connectionString;

        string GetEnvVar(string envVar)
        {
            var envVarContent = Environment.GetEnvironmentVariable(envVar);
            if (envVarContent == null) throw new ApplicationException($"Could not get {envVar} environment variable");
            return envVarContent;
        }

        void ReplaceInConnString((string, string)[] patterns)
        {
            foreach (var (pattern, replacement) in patterns)
            {
                if (!connectionString.Contains(pattern))
                    throw new ApplicationException($"{pattern} is not valid to be replaced in the connection string");
                connectionString = connectionString.Replace($"{pattern}", replacement);
            }
        }
    }
}
