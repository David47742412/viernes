using Dulcepastel.Models.cliente;
using Dulcepastel.Models.ocupacion;

namespace Dulcepastel.Models.utility.interfaces;

public interface IGeneric<in T, TS>
{
    List<TS> Find(string data, string param, bool isFecha = false);

    Task<string?> Insert(T? objecto, HttpContext context);

    Task<string?> Update(T? objeto, HttpContext context);

    Task<string?> Delete(string id, HttpContext context);

}