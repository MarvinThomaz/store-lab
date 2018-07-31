namespace Store.Common.Infra
{
    public interface IMapper<TSource, TDestination>
    {
         TDestination Map(TSource source);
    }
}