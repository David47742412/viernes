using System.ComponentModel.DataAnnotations;
using System.Data;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.cookie;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.interfaces.transformable.cliente;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Dulcepastel.Models.cliente;

public class Cliente : IGeneric<Cliente, GenericView>
{

    private readonly ClienteTransformable _transformable = new();

    [Key]
    private string? _id;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _nombre;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _apellido;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _tipoDocId;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _nroDoc;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _direccion;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _celular;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _telFijo;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _email;
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private DateTime _fNacimiento;

    public Cliente() {}

    public List<GenericView> Find(string data, string param, bool isFecha = false)
    {
        var genericList = new List<GenericView>();
        GenericView generic;
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
        { 
            generic = _transformable.Convert(result);
            genericList.Add(generic);
        }
        connection.Close();
        return genericList;
    }
    
    public async Task<string?> Insert(Cliente? objecto, HttpContext context)
    {
        var message = "";
        var user = await GetCookie.GetData(context);
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_CLIENTE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Opc", SqlDbType.Char).Value = "N";
            command.Parameters.Add("@Cliente_id", SqlDbType.VarChar).Value = "_";
            command.Parameters.Add("@Cliente_nombre", SqlDbType.VarChar).Value = objecto?._nombre ?? "";
            command.Parameters.Add("@Cliente_apellido", SqlDbType.VarChar).Value = objecto?._apellido ?? "";
            command.Parameters.Add("@TipoDocId", SqlDbType.VarChar).Value = objecto?.TipoDocId ?? "01";
            command.Parameters.Add("@NroDoc", SqlDbType.VarChar).Value = objecto?._nroDoc ?? "";
            command.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = objecto?._direccion ?? "";
            command.Parameters.Add("@Celular", SqlDbType.VarChar).Value = objecto?._celular ?? "";
            command.Parameters.Add("@TelfFijo", SqlDbType.VarChar).Value = objecto?._telFijo ?? "";
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = objecto?._email ?? "";
            command.Parameters.Add("@f_nacimiento", SqlDbType.DateTime).Value = objecto?.FNacimiento;
            command.Parameters.Add("@Usuario_id_create", SqlDbType.VarChar).Value = user.Id;
            command.Parameters.Add("@Usuario_id_update", SqlDbType.VarChar).Value = user.Id;
            command.Parameters.Add("@Msj", SqlDbType.VarChar).Value = "";
            connection.Open();
            using var response = command.ExecuteReader();
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

    public async Task<string?> Update(Cliente? objeto, HttpContext context)
    {
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_CLIENTES", connection);
            
            return "";
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<string?> Delete(string idUser, HttpContext context)
    {
        return "";
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