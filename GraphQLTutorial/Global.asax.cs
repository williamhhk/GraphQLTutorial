

using GraphQL;
using GraphQLTutorial.Application.Mutation;
using GraphQLTutorial.Application.Mutation.Resolvers;
using GraphQLTutorial.Application.Query;
using GraphQLTutorial.Application.Query.Resolvers;
using GraphQLTutorial.Schema;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
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

            container.Register<IHelloWorldResolver, HelloWorldResolver>(Lifestyle.Scoped);
            container.Register<IHelloWorld2Resolver, HelloWorld2Resolver>(Lifestyle.Scoped);
            container.Register<IHelloWorld3Resolver, HelloWorld3Resolver>(Lifestyle.Scoped);
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
