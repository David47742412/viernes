using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.interfaces.transformable.transformable;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.utility.interfaces.transformable.usuario;

public class UsuarioTransformable : IMappersTransformable<SqlDataReader, Usuario>
{
    public Usuario Convert(SqlDataReader objeto)
    {
        return new Usuario
        {
            Id = objeto["usuario_id"] as string, 
            Nombre = objeto["usuario_nombre"] as string, 
            Apellido = objeto["usuario_apellido"] as string, 
            Email = objeto["usuario_email"] as string,
            Celular = objeto["usuario_celular"] as string, 
            Foto = objeto["usuario_foto"] as string, 
            FchNacimiento = objeto["f_nacimiento"] as string
        };
    }
}