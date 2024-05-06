using API.DTOs;
using API.Models;

namespace API.Configurations
{
    public static class MyMapper
    {
        public static ApiUser UserDTOToApiUser(this UserDTO userDto)
        {
            return new ApiUser
            {
                Nombre = userDto.FirstName,
                Apellido = userDto.LastName,
            };
        }
    }
}
