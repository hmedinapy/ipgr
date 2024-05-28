namespace API.Core.Services
{
    public enum ResponseStatus
    {
        Ok = 200,
        NoContent = 204,
        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409
    }

}
