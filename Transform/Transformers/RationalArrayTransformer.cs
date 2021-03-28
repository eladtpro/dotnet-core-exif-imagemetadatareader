using ImageMagick;

using Newtonsoft.Json.Linq;
using System.Linq;

namespace ImageMetadata.Transform.Transformers
{
    class RationalArrayTransformer : Transformer
    {
        internal override TransformType Type => TransformType.RationalArray;

        protected override JProperty Transform(IExifValue value)
        {
            Rational[] rationals = (Rational[])value.GetValue();
            string[] unique = rationals.Distinct().Select(r => r.ToString()).ToArray();
            return new JProperty(Name, new JArray(unique));
        }
    }
}
