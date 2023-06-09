namespace Dulcepastel.Models.utility.context;

public class DulcepastelContext
{
    public static DulcepastelContext GetInstance(string conexion) => _credentials ?? new DulcepastelContext(conexion);

    private DulcepastelContext(string context) => Context = context;
    
    public static string? Context;

    private static DulcepastelContext? _credentials = null;
}
