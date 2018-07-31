namespace Store.Product.API.V1.Mappers
{
    public interface IMapper<TSource, TDestination>
    {
         TDestination Map(TSource source);
    }
}