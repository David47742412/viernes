namespace Dulcepastel.Models.utility.interfaces.transformable.transformable;

public interface IMappersTransformable<T, TS>
{
    TS Convert(T objeto);
}