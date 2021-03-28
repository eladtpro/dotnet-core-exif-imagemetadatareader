
using Newtonsoft.Json.Linq;
using ImageMagick;

namespace ImageMetadata.Transform.Transformers
{
    class StringTransformer : Transformer
    {
        internal override TransformType Type => TransformType.String;
        protected override JProperty Transform(IExifValue value)
        {
            return new JProperty(Name, value.ToString());
        }
    }
}
