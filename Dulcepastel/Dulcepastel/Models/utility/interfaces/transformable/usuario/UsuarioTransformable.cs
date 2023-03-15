using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.interfaces.transformable.transform;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.utility.interfaces.transformable.usuario;

public class UsuarioTransformable : IMapperTransformable<SqlDataReader, Usuario>
{
    public Usuario Transformable(SqlDataReader setClass, Usuario convertClass)
    {
        return new Usuario
        {
            Id = setClass["usuario_id"] as string, 
            Nombre = setClass["usuario_nombre"] as string, 
            Apellido = setClass["usuario_apellido"] as string, 
            Celular = setClass["usuario_celular"] as string, 
            Foto = setClass["usuario_foto"] as string, 
            FchNacimiento = setClass["f_nacimiento"] as string
        };
    }
}