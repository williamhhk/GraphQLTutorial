using GraphQL;
using GraphQL.Types;
using GraphQLTutorial.Application.Query;

namespace GraphQLTutorial.Schema
{
    public class GraphQLSchema : GraphQL.Types.Schema
    {
        public GraphQLSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = (GraphQLQuery)resolver.Resolve(typeof(GraphQLQuery));
            //Mutation = (GraphQLMutation)resolver.Resolve(typeof(GraphQLMutation));
        }
    }
}