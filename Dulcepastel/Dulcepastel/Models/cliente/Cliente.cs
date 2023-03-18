using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.interfaces.transformable.cliente;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    private DateTime? _fNacimiento;
    private string? _iduserUpd;

    public Cliente() {}

    public List<GenericView> Find(string data, string param, bool isFecha = false)
    {
        List<GenericView> genericList = new List<GenericView>();
        var generic = new GenericView();
        using var connection = new SqlConnection(DulcepastelContext.Context);
        using var command = new SqlCommand("SP_VIEW_CLIENTES", connection);
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
    
    public string? Insert(Cliente? objecto)
    {
        var message = "";
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_CLIENTES", connection);
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
            command.Parameters.Add("@f_nacimiento", SqlDbType.VarChar).Value = objecto?._email ?? "";
            command.Parameters.Add("@Usuario_id_create", SqlDbType.VarChar).Value = Usuario.User?.Id;
            command.Parameters.Add("@Usuario_id_update", SqlDbType.VarChar).Value = Usuario.User?.Id;
            command.Parameters.Add("@Msj", SqlDbType.VarChar).Value = "";
            connection.Open();
            using var response = command.ExecuteReader();
            response.Read();
            if (response.HasRows) message = response["Msj"] as string;
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return message;
    }

    public string Update(Cliente? objeto)
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

    public string Delete(string idUser)
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
    public DateTime? FNacimiento { get => _fNacimiento; set => _fNacimiento = value; }
    public string? IduserUpd { get => _iduserUpd; set => _iduserUpd = value; }
}