using GraphQL;
using GraphQL.Types;
using GraphQLTutorial.Application.Query.Resolvers;
using System;
using System.Linq;

namespace GraphQLTutorial.Application.Query
{
    public class GraphQLQuery : ObjectGraphType
    {
        public GraphQLQuery(IDependencyResolver resolver)
        {
            var type = typeof(IResolver);
            var resolversTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var resolverType in resolversTypes)
            {
                var resolverTypeInterface = resolverType.GetInterfaces().Where(x => x != type).FirstOrDefault();
                if (resolverTypeInterface != null)
                {
                    var typeResolver = resolver.Resolve(resolverTypeInterface) as IResolver;
                    //GlobalConfiguration.Configuration.DependencyResolver.GetService(resolverTypeInterface) as IResolver;
                    //var resolver = serviceProvider.GetService(resolverTypeInterface) as IResolver;
                    typeResolver.Resolve(this);
                }
            }

        }
    }
}