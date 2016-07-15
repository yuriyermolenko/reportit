using System;
using ReportIT.Infrastructure.Base.Adapter;

namespace ReportIT.Infrastructure.Adapter
{
    public class AutoMapperTypeAdapter : ITypeAdapter
    {
        public TResult Create<TSource, TResult>(TSource source)
        {
            return AutoMapper.Mapper.Map<TResult>(source);
        }

        public void Update<TSource, TResult>(TSource source, TResult result)
        {
            AutoMapper.Mapper.Map(source, result);
        }
    }
}
