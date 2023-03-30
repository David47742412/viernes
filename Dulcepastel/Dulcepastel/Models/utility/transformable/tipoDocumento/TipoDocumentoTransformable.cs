using Dulcepastel.Models.tipoDocumento;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.interfaces.transformable;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.utility.transformable.tipoDocumento;

public class TipoDocumentoTransformable : IMappersTransformable<SqlDataReader, SqlCommand, TipoDocumento, Usuario, GenericView>
{
    public GenericView Convert(SqlDataReader objeto) => new()
    {
        Value1 = objeto["tipo_documento_id"] as string,
        Value2 = objeto["tipo_documento_descripcion"] as string
    };

    public void ConvertSqlCommand(SqlCommand command, TipoDocumento objeto, Usuario user, char opc)
    {
        throw new NotImplementedException();
    }
}