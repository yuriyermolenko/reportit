using System;
using System.Collections.Generic;
using AutoMapper;
using ReportIT.Infrastructure.Base.Adapter;

namespace ReportIT.Infrastructure.Adapter
{
    public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
    {
        private readonly AutoMapperTypeAdapter _typeAdapter;
        private readonly List<Profile> _profiles;

        public AutomapperTypeAdapterFactory()
        {
            _typeAdapter = new AutoMapperTypeAdapter();
            _profiles = new List<Profile>();
        }


        public ITypeAdapter Create()
        {
            if (_typeAdapter == null)
            {
                Mapper.Initialize(config =>
                {
                    foreach (var profile in _profiles)
                    {
                        config.AddProfile(profile);
                    }
                });
            }

            return _typeAdapter ?? new AutoMapperTypeAdapter();
        }

        public void Register(Profile profile)
        {
            _profiles.Add(profile);
        }
    }
}
