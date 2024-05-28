using Microsoft.AspNetCore.Mvc;

namespace API.Core.Services
{
    public abstract class ResponseBase
    {
        protected ControllerBase? controller;

        internal void SetController(ControllerBase controller) =>
            this.controller = controller;

        internal ControllerBase? GetController() => this.controller;

        public ResponseBase(ResponseStatus status, List<string>? messages)
        {
            this.Status = status;
            this.Messages = messages ?? new List<string>();
        }

        protected ResponseBase(ResponseStatus status)
        {
            this.Status = status;
            this.Messages = new List<string>();
        }

        public ResponseStatus Status { get; }
        public List<string> Messages { get; }
    }

}
