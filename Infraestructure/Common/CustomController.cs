using Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infraestructure.Common
{
    public class CustomController : ControllerBase
    {
        public ActionResult<Response<T>> Evaluate<T>(Response<T> response)
        {
            return response.Errors != null && response.Errors.Any() ? BadRequest(response) : Ok(response);
        }
    }
}
