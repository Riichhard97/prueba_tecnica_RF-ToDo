using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Infrestructure
{
    public static class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg, params Assembly[] assemblies)
        {
            if (cfg is null)
            {
                throw new ArgumentNullException(nameof(cfg));
            }

            if (assemblies is null)
            {
                throw new ArgumentNullException(nameof(assemblies));
            }

            if (assemblies.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty collection.", nameof(assemblies));
            }

            cfg.AddMaps(assemblies);
        }
    }
}
