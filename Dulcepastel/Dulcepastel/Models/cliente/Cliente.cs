using Dulcepastel.Models.context;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Microsoft.EntityFrameworkCore;

namespace Dulcepastel.Models.cliente;

public class Cliente : IGeneric<Cliente, GenericView>
{

    private readonly DulcepastelContext _context;
    
    public Cliente(DulcepastelContext context)
    {
        _context = context;
    }
    
    private string? _id;
    private string? _nombre;
    private string? _apellido;
    private string? _tipoDocId;
    private string? _nroDoc;
    private string? _direccion;
    private string? _celular;
    private string? _telFijo;
    private string? _email;
    private DateTime? _fNacimiento;
    private string? _idUserCre;
    private DateTime? _create;
    private string? _iduserUpd;
    private DateTime? _update;

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
        set._update = get?._update ?? set._update;
    }

    public List<GenericView> Find(params dynamic[] param)
    {
        List<GenericView> genericList = new List<GenericView>();
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT C.cliente_id, C.cliente_nombre, C.cliente_apellido,T.tipo_documento_descripcion, C.cliente_nroDoc, C.cliente_direccion, C.cliente_celular, C.cliente_email, C.cliente_telefonoFijo, C.f_nacimiento FROM clientes C JOIN tipo_documento T ON C.tipo_documento_id = T.tipo_documento_id";
            _context.Database.OpenConnection();

            using (var result = command.ExecuteReader())
            {
                GenericView generic = new GenericView();
                for (int i = 0; result.Read(); i++)
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
                    genericList.Insert(i,generic);
                }
            }
        }
        return genericList;
    }

    public string Insert(Cliente? objecto)
    {
        string response = "";
        try
        {
            _context.Cliente.FromSqlRaw("EXEC SP_CLIENTES " +
                                        $"@Opc = 'N', @Cliente_id = _, @Cliente_nombre = '{objecto?._nombre ?? ""}', " +
                                        $"@Cliente_apellido = '{objecto?._apellido ?? ""}', @TipoDocId = '{objecto?.TipoDocId}', @NroDoc = {objecto?._nroDoc ?? ""}, " +
                                        $"@Direccion = '{objecto?._direccion ?? ""}', @Celular = {objecto?._celular ?? ""}, @TelfFijo = _, @email = _, " +
                                        "@f_nacimiento = _, @Usuario_id_create = _, @Usuario_id_update = _, " +
                                        "@Msj = _");
        }
        catch (Exception ex)
        {
            response = ex.Message;
        }
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
    public string? IdUserCre { get => _idUserCre; set => _idUserCre = value; }
    public DateTime? Create { get => _create; set => _create = value; }
    public string? IduserUpd { get => _iduserUpd; set => _iduserUpd = value; }
    public DateTime? CUpdate { get => _update; set => _update = value; }
}