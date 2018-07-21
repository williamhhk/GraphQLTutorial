using GraphQL;
using GraphQLTutorial.Models;
using GraphQLTutorial.Schema;
using System.Threading.Tasks;
using System.Web.Http;

namespace GraphQLTutorial.Controllers
{
    [Route("api/graphql")]
    public class GraphQLController : ApiController
    {
        GraphQLSchema _Schema;

        public GraphQLController(GraphQLSchema schema)
        {
            _Schema = (GraphQLSchema)schema;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] GraphQLRequest request)
        {
            //http://fiyazhasan.me/graphql-with-asp-net-core-part-v-fields-arguments-variables/
            var input = request.Variables.ToInputs();
            var schema = _Schema;
            var result = await new DocumentExecuter().ExecuteAsync(doc =>
            {
                doc.Schema = schema;
                doc.Query = request.Query;
                doc.Inputs = input;
            }).ConfigureAwait(false);
            return Ok(result);
        }
    }
}