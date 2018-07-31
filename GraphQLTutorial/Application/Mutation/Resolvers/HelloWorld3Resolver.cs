using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLTutorial.Application.Mutation.Resolvers
{
    public class HelloWorld3Resolver : IHelloWorld3Resolver
    {
        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<StringGraphType>(
                name: "hello3",
                resolve: context => "Changing"
            );
        }
    }
}