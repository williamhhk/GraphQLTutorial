using GraphQL.Types;

namespace GraphQLTutorial.Models
{
    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(i => i.Name);
        }
    }
}