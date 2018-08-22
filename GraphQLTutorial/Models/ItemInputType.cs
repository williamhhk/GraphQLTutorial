using GraphQL.Types;

namespace GraphQLTutorial.Models
{
    public class ItemInputType : InputObjectGraphType
    {
        public ItemInputType()
        {
            Name = "ItemInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}