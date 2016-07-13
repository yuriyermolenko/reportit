namespace ReportIT.Infrastructure.Base.Adapter
{
    public interface ITypeAdapter
    {
        TResult Create<TSource, TResult>(TSource source);
        void Update<TSource, TResult>(TSource source, TResult result);
    }
}
