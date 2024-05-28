using Microsoft.AspNetCore.Mvc;

namespace API.Core.Services
{
    public sealed class Response : ResponseBase
    {
        public Response(ResponseStatus status, List<string> messages) : base(status, messages)
        { }

        public static implicit operator ActionResult(Response response)
        {
            if (response.controller is null)
                throw new InvalidOperationException("The controller is not set");

            return response.Status switch
            {
                ResponseStatus.Ok => response.controller.Ok(),
                ResponseStatus.BadRequest => response.controller.BadRequest(response),
                ResponseStatus.Forbidden => response.controller.Forbid(),
                ResponseStatus.NotFound => response.controller.NotFound(),
                ResponseStatus.Conflict => response.controller.Conflict(response),
                ResponseStatus.NoContent => response.controller.NoContent(),
                _ => throw new NotSupportedException()
            };
        }

        public static Response Ok(params string[] messages) => new Response(ResponseStatus.Ok, messages.ToList());
        public static Response BadRequest(params string[] messages) => new Response(ResponseStatus.BadRequest, messages.ToList());
    }

    public sealed class Response<T> : ResponseBase
    {
        public Response(ResponseStatus status, T data, List<string>? messages = null)
            : base(status, messages)
        {
            this.Data = data;
        }

        public T Data { get; }

        public static implicit operator Response<T>(Response response)
        {
            var newResponse = new Response<T>(response.Status, default!, response.Messages);
            newResponse.SetController(response.GetController()!);
            return newResponse;
        }

        public static implicit operator ActionResult(Response<T> response)
        {
            if (response.controller is null)
                throw new InvalidOperationException("The controller is not set");

            return response.Status switch
            {
                ResponseStatus.Ok => response.controller.Ok(response),
                ResponseStatus.BadRequest => response.controller.BadRequest(response),
                ResponseStatus.Forbidden => response.controller.Forbid(),
                ResponseStatus.NotFound => response.controller.NotFound(),
                ResponseStatus.Conflict => response.controller.Conflict(response),
                _ => throw new NotSupportedException()
            };
        }
    }

}
