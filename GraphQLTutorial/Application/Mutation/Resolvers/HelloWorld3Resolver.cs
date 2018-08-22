using GraphQL.Types;
using GraphQLTutorial.Models;
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
                name: "create",
                resolve: context => "Changing"
            );

            /*
                {
	                "query" : "mutation ($item:ItemInput!) {createName(item:$item) { name}	}",
	                "variables": {
	                 "item": {
	                   "name": "Test"
	                 }
	                }
                }
             */
            graphQLMutation.Field<ItemType>(
            //graphQLMutation.Field<StringGraphType>(
                "createName",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "item" }
                ),
                resolve: context =>
                {
                    var item = context.GetArgument<Item>("item");
                    return new Item() { Name = " Changed " };
                });

        }
    }

}