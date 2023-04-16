using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.interfaces.transformable;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.utility.transformable.usuario;

public class UsuarioTransformable : IMappersTransformable<SqlDataReader, SqlCommand, Usuario, Usuario, Usuario>
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

    public GenericView ConvertUserById(SqlDataReader objeto) => new()
    {
        Value1 = objeto["Nombre"] as string,
        Value2 = objeto["Apellido"] as string,
        Value3 = objeto["Email"] as string,
        Value4 = objeto["Celular"] as string,
        Value5 = objeto["Direccion"] as string,
        Value6 = objeto["NroDoc"] as string,
        Value7 = objeto["Tipo de Documento"] as string,
        Value8 = objeto["Estado_descripcion"] as string,
        Value9 = objeto["Foto"] as string,
        Value10 = objeto["OcuDescripcion"] as string,
        Value11 = objeto["FchNacimiento"]
    };

    public void ConvertSqlCommand(SqlCommand command, Usuario objeto, Usuario user, char opc)
    {
        throw new NotImplementedException();
    }
}