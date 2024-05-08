using API.Core.DTOs;
using API.Data.Entities;

namespace API.Core.Configurations
{
    public static class MyMapper
    {
        public static ApiUser ApiUserToDTO(this UserDTO userDto)
        {
            return new ApiUser
            {
                Nombre = userDto.FirstName,
                Apellido = userDto.LastName,
            };
        }

        public static Area AreaToDTO(this AreaDTO userDto)
        {
            return new Area
            {
                Descripcion = userDto.Descripcion,
                IdDepartamento = userDto.IdDepartamento,
                IdEmpresa = userDto.IdEmpresa,
            };
        }
    }
}
