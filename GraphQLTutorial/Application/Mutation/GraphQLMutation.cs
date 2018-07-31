using GraphQL;
using GraphQL.Types;
using GraphQLTutorial.Application.Mutation.Resolvers;
using System;
using System.Linq;


namespace GraphQLTutorial.Application.Mutation
{

    public class GraphQLMutation : ObjectGraphType
    {
        public GraphQLMutation(IDependencyResolver resolver)
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
                    typeResolver.Resolve(this);
                }
            }

        }
    }

}