using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Dulcepastel.Models.utility.transformable.usuario;

namespace Dulcepastel.Models.usuario;

public class Usuario : IGeneric<Usuario, GenericView>
{

    private readonly UsuarioTransformable _transformable = new();
    
    private string? _id;
    private string? _nombre;
    private string? _apellido;
    private string? _celular;
    private string? _nroDoc;
    private string? _email;
    private string? _password;
    private string? _idTipoDoc;
    private string? _idEstado;
    private string? _foto;
    private string? _ocupacion;
    private string? _fchNacimiento;
    
    public List<GenericView> Find(string data, string param, bool isFecha = false)
    {
        var lts = new GenericView();
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_VIEW_USUARIO", connection);
            
        }
        catch (Exception ex)
        {
            
        }
        throw new NotImplementedException();
    }

    public Task<string?> Crud(Usuario? objecto, Usuario user, char opc)
    {
        throw new NotImplementedException();
    }

    public string? Id
    {
        get => _id;
        set => _id = value;
    }

    public string? Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public string? Apellido
    {
        get => _apellido;
        set => _apellido = value;
    }

    public string? Celular
    {
        get => _celular;
        set => _celular = value;
    }

    public string? NroDoc
    {
        get => _nroDoc;
        set => _nroDoc = value;
    }

    public string? Email
    {
        get => _email;
        set => _email = value;
    }

    public string? Password
    {
        get => _password;
        set => _password = value;
    }

    public string? IdTipoDoc
    {
        get => _idTipoDoc;
        set => _idTipoDoc = value;
    }

    public string? IdEstado
    {
        get => _idEstado;
        set => _idEstado = value;
    }

    public string? Foto
    {
        get => _foto;
        set => _foto = value;
    }

    public string? Ocupacion
    {
        get => _ocupacion;
        set => _ocupacion = value;
    }

    public string? FchNacimiento
    {
        get => _fchNacimiento;
        set => _fchNacimiento = value;
    }
}