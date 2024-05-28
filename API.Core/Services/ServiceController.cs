using Microsoft.AspNetCore.Mvc;

namespace API.Core.Services
{
    public abstract class ServiceController : ControllerBase
    {
        protected new Response Ok() => this.CreateResponse(ResponseStatus.Ok);
        protected new Response NoContent() => this.CreateResponse(ResponseStatus.NoContent);
        protected Response BadRequest(params string[] messages) => this.CreateResponse(ResponseStatus.BadRequest, messages);
        protected Response Forbidden() => this.CreateResponse(ResponseStatus.Forbidden);
        protected new Response NotFound() => this.CreateResponse(ResponseStatus.NotFound);
        protected Response Conflict(string message) => this.CreateResponse(ResponseStatus.Conflict, message);

        protected Response From(Response response)
        {
            response.SetController(this);
            return response;
        }

        protected Response<T> Ok<T>(T data)
        {
            var response = new Response<T>(ResponseStatus.Ok, data);
            response.SetController(this);
            return response;
        }

        private Response CreateResponse(ResponseStatus status, params string[] messages)
        {
            var response = new Response(status, messages.ToList());
            response.SetController(this);
            return response;
        }
    }
}
