using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLTutorial.Application.Query.Resolvers
{
    public class HelloWorldResolver : IHelloWorldResolver
    {
        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<StringGraphType>(
                name: "hello",
                resolve: context => "Hello World"
            );
        }
    }
}