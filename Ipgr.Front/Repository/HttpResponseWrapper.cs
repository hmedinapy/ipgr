﻿using System.Globalization;
using System.Net;

namespace Ipgr.Front.Repository
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }


        public async Task<string?> GetErrorMessageAsync()
        {
            //video 4 - 12.25
            if (Error)
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado";
            }

            if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }

            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Debe estar logueado";
            }

            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "No tiene permisos";
            }

            return "Error inesperado";
        }
    }
}