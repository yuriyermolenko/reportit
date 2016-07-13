using ReportIT.Infrastructure.Base.Adapter;

namespace ReportIT.Application.Extensions
{
    public static class TypeAdapters
    {
        public static TDest Create<TSource, TDest>(this TSource source)
        {
            return TypeAdapterFactory.Create().Create<TSource, TDest>(source);
        }

        public static void UpdateFrom<TTarget, TSource>(this TTarget target, TSource source)
        {
            TypeAdapterFactory.Create().Update(target, source);
        }
    }
}
