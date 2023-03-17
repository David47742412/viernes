using Dulcepastel.Models.cliente;
using Dulcepastel.Models.utility.structView;

namespace Dulcepastel.Models.utility.interfaces;

public interface IMain<T>
{
    IEnumerable<T> Find2 { get; set; }

    T Insert { get; set; }

}