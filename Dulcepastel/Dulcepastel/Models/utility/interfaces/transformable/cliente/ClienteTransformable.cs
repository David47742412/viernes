using Dulcepastel.Models.cliente;
using Dulcepastel.Models.utility.interfaces.transformable.transformable;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.utility.interfaces.transformable.cliente;

public class ClienteTransformable : IMappersTransformable<SqlDataReader, GenericView>
{
    public GenericView Convert(SqlDataReader objecto)
    {
        return new GenericView
        {
            Value1 = objecto["cliente_id"],
            Value2 = objecto["cliente_nombre"],
            Value3 = objecto["cliente_apellido"], 
            Value4 = objecto["tipo_documento_descripcion"], 
            Value5 = objecto["cliente_nroDoc"],
            Value6 = objecto["cliente_direccion"], 
            Value7 = objecto["cliente_celular"],
            Value8 = objecto["cliente_telefonoFijo"], 
            Value9 = objecto["cliente_email"],
            Value10 = objecto["f_nacimiento"],
        };
    }
}