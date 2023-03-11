using Dulcepastel.Models.context;
using Dulcepastel.Models.utility.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dulcepastel.Models.cliente;

public class Cliente : IGeneric<Cliente>
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

    public List<Cliente?> Find(params dynamic[] param)
    {
        return new List<Cliente?>(_context.Cliente.FromSqlRaw("SELECT * FROM clientes"));
    }

    public string Insert(Cliente? objecto)
    {
        return "";
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