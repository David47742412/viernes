using System.Data;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Dulcepastel.Models.utility.transformable.tipoDocumento;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Dulcepastel.Models.tipoDocumento;

public class TipoDocumento : IGeneric<TipoDocumento, GenericView>
{

    private readonly TipoDocumentoTransformable _transformable = new();
    
    private string? _tipoDocId;
    private string? _descripcion;
    private string? _idUserCre;
    private DateTime? _create;
    private string? _idUserUpd;
    private DateTime? _update;
    
    public List<GenericView> Find(string data, string param, bool isFecha = false)
    {
        var genericList = new List<GenericView>();
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_VIEW_TIPO_DOCUMENTO", connection);
            command.CommandType = CommandType.StoredProcedure;
            
            if (!data.IsNullOrEmpty() && !param.IsNullOrEmpty() && isFecha == false)
                command.Parameters.Add($"@{param}", SqlDbType.VarChar).Value = data;
            else if (!data.IsNullOrEmpty() && !param.IsNullOrEmpty() && isFecha)
                command.Parameters.Add($"@{param}", SqlDbType.DateTime).Value = data;
            
            connection.Open();
            using var response = command.ExecuteReader();
            while (response.Read())
                genericList.Add(_transformable.Convert(response));
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return genericList;
    }

    public Task<string?> Crud(TipoDocumento? objecto, Usuario user, char opc)
    {
        throw new NotImplementedException();
    }

    public string? TipoDocId
    {
        get => _tipoDocId;
        set => _tipoDocId = value;
    }

    public string? IdUserCre
    {
        get => _idUserCre;
        set => _idUserCre = value;
    }

    public DateTime? Create
    {
        get => _create;
        set => _create = value;
    }

    public string? IdUserUpd
    {
        get => _idUserUpd;
        set => _idUserUpd = value;
    }

    public DateTime? Tupdate
    {
        get => _update;
        set => _update = value;
    }

    public string? Descripcion
    {
        get => _descripcion;
        set => _descripcion = value;
    }
}