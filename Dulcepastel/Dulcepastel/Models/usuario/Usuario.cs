using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Dulcepastel.Models.usuario;

public class Usuario
{ 
    [Key]
    private string? _id;

    [Required(ErrorMessage = "El Campo Nombre es obligatorio")]
    private string? _nombre;
    
    [Required(ErrorMessage = "El Campo Apellido es obligatorio")]
    private string? _apellido;
    
    [Required(ErrorMessage = "El Campo Celular es obligatorio")]
    private string? _celular;
    
    [Required(ErrorMessage = "El Campo N° Documento es obligatorio")]
    private string? _nroDoc;

    [Required(ErrorMessage = "El Campo Email es obligatorio")]
    private string? _email;

    [Required(ErrorMessage = "El Campo Password es obligatorio")]
    private string? _password;
    
    [Required(ErrorMessage = "El Campo Tipo de Documento es obligatorio")]
    private string? _idTipoDoc;
    
    [Required(ErrorMessage = "El Campo Estado es obligatorio")]
    private string? _idEstado;

    [Required(ErrorMessage = "El Campo Foto es obligatorio")]
    private string? _foto;
    
    [Required(ErrorMessage = "El Campo Ocupacion es obligatorio")]
    private string? _ocupacion;

    [Required(ErrorMessage = "El Campo Fecha de nacimiento es obligatorio")]
    private string? _fchNacimiento;

    public static Usuario? User { get; set; }

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