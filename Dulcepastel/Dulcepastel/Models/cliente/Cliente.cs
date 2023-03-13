using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dulcepastel.Models.cliente;

public class Cliente : IGeneric<Cliente, GenericView>
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
        
        using (SqlConnection connection = new(DulcepastelContext.Context))
        {
            using (SqlCommand command = new("SP_VIEW_CLIENTES", connection))
            {
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
                var result = command.ExecuteReader();
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
                
            }
        }
        
        return genericList;
    }

    public string Insert(Cliente? objecto)
    {
        string response = "";
        return response;
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