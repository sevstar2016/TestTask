using Autofac;
using GQL.GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQL.SystemTextJson;
using Newtonsoft.Json;

namespace GQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<CarContext>();
            
            services
                .AddGraphQL(
                    (options, provider) =>
                    {
                        // Load GraphQL Server configurations
                        var graphQLOptions = Configuration
                            .GetSection("GraphQL")
                            .Get<GraphQLOptions>();
                        options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
                        options.EnableMetrics = graphQLOptions.EnableMetrics;
                        // Log errors
                        var logger = provider.GetRequiredService<ILogger<Startup>>();
                        options.UnhandledExceptionDelegate = ctx =>
                            logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                    })
                .AddGraphTypes()
                .AddDataLoader()
                .AddSystemTextJson();
        }
        
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<CarRepo>().As<ICarRepo>().InstancePerLifetimeScope();

            builder.RegisterType<DocumentWriter>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<QueryObject>().AsSelf().SingleInstance();
            builder.RegisterType<MutationObject>().AsSelf().SingleInstance();
            builder.RegisterType<CarSchema>().AsSelf().SingleInstance();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<CarSchema>();
            app.UseGraphQLAltair(new GraphQLAltairOptions {Path = "/"});

            app.UseHttpsRedirection();
        }
    }
}