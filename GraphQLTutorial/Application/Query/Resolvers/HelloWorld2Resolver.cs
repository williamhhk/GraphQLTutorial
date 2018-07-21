using GraphQL.Types;

namespace GraphQLTutorial.Application.Query.Resolvers
{
    public class HelloWorld2Resolver : IHelloWorld2Resolver
    {
        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<StringGraphType>(
                name: "hello2",
                resolve: context => "Hello World 2"
            );

        //    graphQLQuery.Field<ItemType>(
        //               "item",
        //               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "barcode" }),
        //               resolve: context =>
        //               {
        //                   var barcode = context.GetArgument<string>("barcode");
        //                   return new DataSource().GetItemByBarcode(barcode);
        //               }
        //           );
        //    /*
        //       {  
        //          "query":"{
        //           items {
        //               title 
        //               sellingPrice
        //               barcode
        //               }
        //           }"
        //       }
        //     */

        //    graphQLQuery.Field<ListGraphType<ItemType>>(
        //    "items",
        //    resolve: context =>
        //    {
        //        return new DataSource().GetItems();
        //    }
        //);
        }
    }
}