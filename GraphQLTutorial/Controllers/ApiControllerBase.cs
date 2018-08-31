using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GraphQLTutorial.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected IHttpActionResult CreateHttpResponse(Func<IHttpActionResult> function)
        {
            IHttpActionResult response = null;

            try
            {
                response = function.Invoke();
            }
            catch (Exception ex)
            {
                response = BadRequest(ex.Message);
            }

            return response;
        }

        protected async Task<IHttpActionResult> CreateHttpResponseAsync(Func<Task<IHttpActionResult>> function)
        {
            //public static Task<TResult> Run<TResult>(Func<TResult> function);
            try
            {
                return await Task.Run(function);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message));
            }
        }
    }
}