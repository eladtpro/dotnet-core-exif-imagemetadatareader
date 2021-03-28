
using Newtonsoft.Json.Linq;
using System;
using ImageMagick;
using ImageMetadata.Transform.Extensions;

namespace ImageMetadata.Transform
{
    public abstract class Transformer
    {
        protected string Name { get; set; }
        internal abstract TransformType Type { get; }

        protected abstract JProperty Transform(IExifValue value);

        public static JProperty Transform(TransformType type, IExifValue value)
        {
            try
            {
                Transformer service = TransformProvider.GetService(type);
                service.Name = value.GetName();
                return service.Transform(value);
            }
            catch (Exception ex)
            {
                string name = value.GetName();
                return new JProperty(name, ex.Message);
            }
        }
    }
}
