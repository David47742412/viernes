using Dulcepastel.Models.cliente;
using Dulcepastel.Models.ocupacion;
using Dulcepastel.Models.usuario;

namespace Dulcepastel.Models.utility.interfaces;

public interface IGeneric<in T, TS>
{
    List<TS> Find(string data, string param, bool isFecha = false);

    Task<string?> Crud(T? objecto, Usuario user, char opc);


}