using ImageMagick;

using Newtonsoft.Json.Linq;

namespace ImageMetadata.Transform.Transformers
{
    class ShortArrayTransformer : Transformer
    {
        internal override TransformType Type => TransformType.ShortArray;

        protected override JProperty Transform(IExifValue value)
        {
            ushort[] values = (ushort[])value.GetValue();
            return new JProperty(Name, new JArray(values));
        }
    }
}
