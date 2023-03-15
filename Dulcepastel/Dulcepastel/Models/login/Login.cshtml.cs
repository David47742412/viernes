using System.ComponentModel.DataAnnotations;
using System.Data;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces.transformable.usuario;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.login;

public class Login
{

    private readonly UsuarioTransformable _transformable;
    
    [Required(ErrorMessage = "Este Campo es Requerido")]
    [EmailAddress(ErrorMessage = "El correo electronico no es valido")]
    private string? _email;
    
    [Required(ErrorMessage = "Este Campo es Requerido")]
    private string? _password;

    public Login(UsuarioTransformable transformable)
    {
        _transformable = transformable;
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

    public Usuario? IsValidUser(Login user)
    {
        try
        {
            using var connection = new SqlConnection(DulcepastelContext.Context);
            using var command = new SqlCommand("SP_LOGIN", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email; 
            connection.Open();
            using var result = command.ExecuteReader(); 
            result.Read();
            if (!result.HasRows) return null;
            var usuario = _transformable.Transformable(result, new Usuario());
            var password = result["usuario_password"] as string; 
            return BCrypt.Net.BCrypt.Verify(user.Password, password) ? usuario : null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}