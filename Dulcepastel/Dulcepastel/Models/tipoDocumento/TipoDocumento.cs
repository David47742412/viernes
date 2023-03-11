namespace Dulcepastel.Models.tipoDocumento;

public class TipoDocumento
{
    private string? _tipoDocId;
    private string? _descripcion;
    private string? _idUserCre;
    private DateTime? _create;
    private string? _idUserUpd;
    private DateTime? _update;

    public string? TipoDocId
    {
        get => _tipoDocId;
        set => _tipoDocId = value;
    }

    public string? IdUserCre
    {
        get => _idUserCre;
        set => _idUserCre = value;
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

    public string? Descripcion
    {
        get => _descripcion;
        set => _descripcion = value;
    }
}