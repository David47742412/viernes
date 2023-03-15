using Dulcepastel.Models.utility.interfaces;

namespace Dulcepastel.Models.ocupacion;

public class Ocupacion : IMain
{
    private string? _id;
    private string? _descripcion;
    private string? _userIdCre;
    private DateTime? _create;
    private string? _idUserUpd;
    private DateTime? _update;

    public string? Id
    {
        get => _id;
        set => _id = value;
    }

    public string? Descripcion
    {
        get => _descripcion;
        set => _descripcion = value;
    }

    public string? UserIdCre
    {
        get => _userIdCre;
        set => _userIdCre = value;
    }

    public DateTime? Create
    {
        get => _create;
        set => _create = value;
    }

    public string? IdUserUpd
    {
        get => _idUserUpd;
        set => _idUserUpd = value;
    }

    public DateTime? Update
    {
        get => _update;
        set => _update = value;
    }
}