using System.Data;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.tipoDocumento;

public class TipoDocumento : IGeneric<TipoDocumento, GenericView>
{
    public List<GenericView> Find(string data, string param, bool isFecha = false)
    {
        var genericList = new List<GenericView>();
        var generic = new GenericView();
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_VIEW_TIPO_DOCUMENTO", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = generic.Value1 ?? "_";
            command.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = generic.Value2 ?? "_";
            connection.Open();
            using var response = command.ExecuteReader();
            while (response.Read())
            {
                generic.Value1 = response["tipo_documento_id"];
                generic.Value2 = response["tipo_documento_descripcion"];
                genericList.Add(generic);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return genericList;
    }

    public Task<string?> Insert(TipoDocumento? objecto, HttpContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> Update(TipoDocumento? objeto, HttpContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> Delete(string id, HttpContext context)
    {
        throw new NotImplementedException();
    }
    
    private string? _tipoDocId;
    private string? _descripcion;
    private string? _idUserCre;
    private DateTime? _create;
    private string? _idUserUpd;
    private DateTime? _update;

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