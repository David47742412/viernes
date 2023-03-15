using Dulcepastel.Models.cliente;
using Dulcepastel.Models.utility.interfaces.transformable.transform;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.utility.interfaces.transformable.cliente;

public class ClienteTransformable : IMapperTransformable<GenericView, Cliente>
{
    public Cliente Transformable(GenericView setClass, Cliente convertClass)
    {
        return new Cliente
        {
            Id = setClass.Value1,
            Nombre = setClass.Value2,
            Apellido = setClass.Value3,
            NroDoc = setClass.Value5,
            Direccion = setClass.Value6,
            Celular = setClass.Value7,
            TelFijo = setClass.Value8,
            Email = setClass.Value9,
            FNacimiento = setClass.Value10
        };
    }

    public GenericView DbClienteTransformable(SqlDataReader response)
    {
        return new GenericView
        {
            Value1 = response["cliente_id"],
            Value2 = response["cliente_nombre"],
            Value3 = response["cliente_apellido"], 
            Value4 = response["tipo_documento_descripcion"], 
            Value5 = response["cliente_nroDoc"],
            Value6 = response["cliente_direccion"], 
            Value7 = response["cliente_celular"],
            Value8 = response["cliente_telefonoFijo"], 
            Value9 = response["cliente_email"],
            Value10 = response["f_nacimiento"],
        };
    }

}