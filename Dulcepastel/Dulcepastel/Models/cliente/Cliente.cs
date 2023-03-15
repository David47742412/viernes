using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dulcepastel.Models.cliente;

public class Cliente : IGeneric<Cliente, GenericView>, IMain
{

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

    public void Equals(Cliente? set, Cliente? get)
    {
        set!._nombre = get?._nombre ?? set._nombre;
        set._apellido = get?._apellido ?? set._apellido;
        set._tipoDocId = get?._tipoDocId ?? set._tipoDocId;
        set._nroDoc = get?._nroDoc ?? set._nroDoc;
        set._direccion = get?._direccion ?? set._direccion;
        set._celular = get?._celular ?? set._celular;
        set._telFijo = get?._telFijo ?? set._telFijo;
        set._fNacimiento = get?._fNacimiento ?? set._fNacimiento;
        set._iduserUpd = get?._iduserUpd ?? set._iduserUpd;
    }

    public List<GenericView> Find(params dynamic[] param)
    {
        List<GenericView> genericList = new List<GenericView>();

        GenericView generic = new GenericView();

        using var connection = new SqlConnection(DulcepastelContext.Context);
        using var command = new SqlCommand("SP_VIEW_CLIENTES", connection);
        command.CommandType = CommandType.StoredProcedure; 
        command.Parameters.Add("@Id", SqlDbType.VarChar).Value = generic.Value1 ?? "_"; 
        command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = generic.Value2 ?? "_"; 
        command.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = generic.Value3 ?? "_"; 
        command.Parameters.Add("@DesDocument", SqlDbType.VarChar).Value = generic.Value4 ?? "_"; 
        command.Parameters.Add("@NroDoc", SqlDbType.VarChar).Value = generic.Value5 ?? "_"; 
        command.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = generic.Value6 ?? "_"; 
        command.Parameters.Add("@Celular", SqlDbType.VarChar).Value = generic.Value7 ?? "_"; 
        command.Parameters.Add("@TelfFijo", SqlDbType.VarChar).Value = generic.Value8 ?? "_"; 
        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = generic.Value9 ?? "_"; 
        command.Parameters.Add("@F_NACIMIENTO", SqlDbType.DateTime).Value = generic.Value10 ?? "1900-01-01"; 
        connection.Open(); 
        using var result = command.ExecuteReader(); 
        while (result.Read()) 
        { 
            generic.Value1 = result["cliente_id"];
            generic.Value2 = result["cliente_nombre"]; 
            generic.Value3 = result["cliente_apellido"]; 
            generic.Value4 = result["tipo_documento_descripcion"]; 
            generic.Value5 = result["cliente_nroDoc"]; 
            generic.Value6 = result["cliente_direccion"]; 
            generic.Value7 = result["cliente_celular"]; 
            generic.Value8 = result["cliente_telefonoFijo"]; 
            generic.Value9 = result["cliente_email"]; 
            generic.Value10 = result["f_nacimiento"]; 
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
            command.Parameters.Add("@Usuario_id_create", SqlDbType.VarChar).Value = Usuario.User;
            command.Parameters.Add("@Usuario_id_update", SqlDbType.VarChar).Value = Usuario.User;
            connection.Open();
            using var response = command.ExecuteReader();
            message = response["Msj"] as string;
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return message;
    }

    public string Update(string id, Cliente? objeto)
    {
        return "";
    }

    public string Delete(string id, string idUser)
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