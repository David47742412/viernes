namespace Dulcepastel.Models.utility.interfaces.transformable.transform;

public interface IMapperTransformable<in T, TS>
{
    TS Transformable(T setClass, TS convertClass);
}