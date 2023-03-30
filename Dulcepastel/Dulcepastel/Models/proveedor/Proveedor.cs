using System.Data;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Dulcepastel.Models.utility.transformable.proveedor;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Dulcepastel.Models.proveedor;

public class Proveedor : IGeneric<Proveedor, GenericView>
{
    private readonly ProveedorTransformable _transformable = new();
    
    private string? _codigo;
    private string? _ruc;
    private string? _nComercial;
    private string? _razonSocial;
    private string? _celular;
    private string? _telefono;
    private string? _pagina;
    private string? _email;
    private string? _direccion;
    private string? _descripcion;
    private string? _codTipoDoc;

    public List<GenericView> Find(string data, string param, bool isFecha = false)
    {
        var genericList = new List<GenericView>();
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_VIEW_PROVEEDOR", connection);
            command.CommandType = CommandType.StoredProcedure;

            if (!data.IsNullOrEmpty() && !param.IsNullOrEmpty() && isFecha == false)
                command.Parameters.Add($"@{param}", SqlDbType.VarChar).Value = data;
            else if (!data.IsNullOrEmpty() && !param.IsNullOrEmpty() && isFecha)
                command.Parameters.Add($"@{param}", SqlDbType.DateTime).Value = data;

            connection.Open();
            using var result = command.ExecuteReader();
            while (result.Read())
                genericList.Add(_transformable.Convert(result));

            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return genericList;
    }

    public async Task<string?> Crud(Proveedor? objecto, Usuario user, char opc)
    {
        var message = "";
        try
        {
            await using var connection = new SqlConnection(DulcepastelContext.Context);
            await using var command = new SqlCommand("SP_PROVEEDOR", connection);
            _transformable.ConvertSqlCommand(command, objecto, user, opc);
            connection.Open();
            await using var response = command.ExecuteReader();
            response.Read();
            if (response.HasRows) message = response["Msj"] as string;
            connection.Close();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return message;
    }
    
    public string? Id
    {
        get => _codigo;
        set => _codigo = value;
    }

    public string? Ruc
    {
        get => _ruc;
        set => _ruc = value;
    }

    public string? Ncomercial
    {
        get => _nComercial;
        set => _nComercial = value;
    }

    public string? RazonSocial
    {
        get => _razonSocial;
        set => _razonSocial = value;
    }

    public string? Celular
    {
        get => _celular;
        set => _celular = value;
    }

    public string? Telefono
    {
        get => _telefono;
        set => _telefono = value;
    }

    public string? PaginaWeb
    {
        get => _pagina;
        set => _pagina = value;
    }

    public string? Email
    {
        get => _email;
        set => _email = value;
    }

    public string? Direccion
    {
        get => _direccion;
        set => _direccion = value;
    }

    public string? Descripcion
    {
        get => _descripcion;
        set => _descripcion = value;
    }

    public string? TipoDocId
    {
        get => _codTipoDoc;
        set => _codTipoDoc = value;
    }
}