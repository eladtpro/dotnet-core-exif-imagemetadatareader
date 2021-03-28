using System;
using System.Collections.Generic;
using System.Linq;
using ImageMetadata.Transform.Transformers;
using Microsoft.Extensions.DependencyInjection;

namespace ImageMetadata.Transform
{
    static class TransformProvider
    {
        private static readonly Lazy<IServiceProvider> provider = new(() => {
            ServiceCollection services = new();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        });

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Transformer, StringTransformer>();
            services.AddTransient<Transformer, DateTimeTransformer>();
            services.AddTransient<Transformer, ByteArrayTransformer>();
            services.AddTransient<Transformer, ByteVersionTransformer>();
            services.AddTransient<Transformer, ShortArrayTransformer>();
            services.AddTransient<Transformer, RationalArrayTransformer>();
            services.AddTransient<Transformer, ComponentsConfigurationTransformer>();
        }

        private static IServiceProvider Provider => provider.Value;

        internal static Transformer GetService(TransformType type)
        {
            IEnumerable<Transformer> services = Provider.GetServices<Transformer>();
            Transformer service = services.First(t => t.Type == type);
            return service;
        }
    }
}
