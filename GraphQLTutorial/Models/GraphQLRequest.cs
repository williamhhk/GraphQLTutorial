using Newtonsoft.Json.Linq;

namespace GraphQLTutorial.Models
{
    public class GraphQLRequest
    {
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}