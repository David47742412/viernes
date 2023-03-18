using Dulcepastel.Models.cliente;
using Dulcepastel.Models.ocupacion;

namespace Dulcepastel.Models.utility.interfaces;

public interface IGeneric<in T, TS>
{
    List<TS> Find(string data, string param, bool isFecha = false);

    string? Insert(T? objecto);

    string Update(T? objeto);

    string Delete(string id);

}