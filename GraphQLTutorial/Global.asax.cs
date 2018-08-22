

using GraphQL;
using GraphQLTutorial.Application.Mutation;
using GraphQLTutorial.Application.Mutation.Resolvers;
using GraphQLTutorial.Application.Query;
using GraphQLTutorial.Application.Query.Resolvers;
using GraphQLTutorial.Schema;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace GraphQLTutorial
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:

            //container.Register<IHelloWorldResolver, HelloWorldResolver>(Lifestyle.Scoped);
            //container.Register<IHelloWorld2Resolver, HelloWorld2Resolver>(Lifestyle.Scoped);
            //container.Register<IHelloWorld3Resolver, HelloWorld3Resolver>(Lifestyle.Scoped);

            //var assembly = Assembly.GetExecutingAssembly();
            var assembly = Assembly.Load("GraphQLTutorial");
            var mutations = assembly.GetExportedTypes().Where(type => type.Namespace == "GraphQLTutorial.Application.Mutation.Resolvers" && type.GetInterfaces().Any())
                .Select(type => new { Service = type.GetInterfaces().Where(i => i.Name != "IMutation").Single(), Implementation = type })
                .ToList();
            foreach (var mutation in mutations)
            {
                container.Register(mutation.Service, mutation.Implementation, Lifestyle.Scoped);
            }

            var queries = assembly.GetExportedTypes().Where(type => type.Namespace == "GraphQLTutorial.Application.Query.Resolvers" && type.GetInterfaces().Any(i=>i.Name !="IQuery"))
                .Select(type => new { Service = type.GetInterfaces().Where(i => i.Name != "IQuery").Single(), Implementation = type })
                .ToList();
            //foreach (var query in queries)
            //{
            //    container.Register(query.Service, query.Implementation, Lifestyle.Scoped);
            //}



            //container.Register<IGraphQLQuery, GraphQLQuery>(Lifestyle.Scoped);
            container.Register(() => new GraphQLQuery(new FuncDependencyResolver(type => container.GetInstance(type))), Lifestyle.Singleton);
            container.Register(() => new GraphQLMutation(new FuncDependencyResolver(type => container.GetInstance(type))), Lifestyle.Singleton);
            container.Register(() => new GraphQLSchema(new FuncDependencyResolver(type => container.GetInstance(type))), Lifestyle.Singleton);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
