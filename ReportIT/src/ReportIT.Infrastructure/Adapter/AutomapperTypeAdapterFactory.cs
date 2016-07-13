using System;
using ReportIT.Infrastructure.Base.Adapter;

namespace ReportIT.Infrastructure.Adapter
{
    public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
    {
        private readonly AutoMapperTypeAdapter _typeAdapter;

        public AutomapperTypeAdapterFactory()
        {
            //scan all assemblies finding Automapper Profile
            var profiles = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(a => a.GetTypes())
                                    .Where(t => t.BaseType == typeof(AutoMapper.Profile));

            AutoMapper.Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles.Where(item => item.FullName != "AutoMapper.SelfProfiler`2"))
                {
                    cfg.AddProfile(Activator.CreateInstance(item) as AutoMapper.Profile);
                }
            });
        }


        public ITypeAdapter Create()
        {
            return _typeAdapter != null ? _typeAdapter : new AutoMapperTypeAdapter();
        }
    }
}
