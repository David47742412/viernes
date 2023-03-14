using System.Data;
using Dulcepastel.Models.usuario;
using Dulcepastel.Models.utility.context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Dulcepastel.Models.login;

public class Login
{
    private string? _email;
    private string? _password;

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
        Usuario? usuario = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(DulcepastelContext.Context))
            {
                using (SqlCommand command = new SqlCommand("SP_LOGIN", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                    connection.Open();
                    var result = command.ExecuteReader();
                    string? password = "";
                    if (result.HasRows)
                    {
                        result.Read();
                        usuario = new Usuario
                        {
                            Id = result["usuario_id"] as string,
                            Nombre = result["usuario_nombre"] as string,
                            Apellido = result["usuario_apellido"] as string,
                            Celular = result["usuario_celular"] as string,
                            Foto = result["usuario_foto"] as string,
                            FchNacimiento = result["f_nacimiento"] as string
                        };
                        password = result["usuario_password"] as string;
                    }
                    return BCrypt.Net.BCrypt.Verify(user.Password, password) ? usuario : null;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}