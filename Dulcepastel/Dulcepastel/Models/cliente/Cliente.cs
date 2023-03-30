using System.ComponentModel.DataAnnotations;
using System.Data;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.cookie;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Dulcepastel.Models.utility.transformable.cliente;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Dulcepastel.Models.cliente;

public class Cliente : IGeneric<Cliente, GenericView>
{

    private readonly ClienteTransformable _transformable = new();


    private string? _id;
    private string? _nombre;
    private string? _apellido;
    private string? _tipoDocId;
    private string? _nroDoc;
    private string? _direccion;
    private string? _celular;
    private string? _telFijo;
    private string? _email;
    private DateTime _fNacimiento;

    public Cliente() {}

    public List<GenericView> Find(string data, string param, bool isFecha = false)
    {
        var genericList = new List<GenericView>();
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_VIEW_CLIENTE", connection);
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

    public async Task<string?> Crud(Cliente? objecto, Usuario user, char opc)
    {
        var message = "";
        try
        {
            await using var connection = new SqlConnection(DulcepastelContext.Context);
            await using var command = new SqlCommand("SP_CLIENTE", connection);
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

    public string? Id { get => _id; set => _id = value; }
    public string? Nombre { get => _nombre; set => _nombre = value; }
    public string? Apellido { get => _apellido; set => _apellido = value; }
    public string? TipoDocId { get => _tipoDocId; set => _tipoDocId = value; }
    public string? NroDoc { get => _nroDoc; set => _nroDoc = value; }
    public string? Direccion { get => _direccion; set => _direccion = value; }
    public string? Celular { get => _celular; set => _celular = value; }
    public string? TelFijo { get => _telFijo; set => _telFijo = value; }
    public string? Email { get => _email; set => _email = value; }
    public DateTime FNacimiento { get => _fNacimiento; set => _fNacimiento = value; }
}