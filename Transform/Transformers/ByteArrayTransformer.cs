using System;
using ImageMagick;

using Newtonsoft.Json.Linq;
using ImageMetadata.Transform.Extensions;

namespace ImageMetadata.Transform.Transformers
{
    public class ByteArrayTransformer : Transformer
    {
        internal override TransformType Type => TransformType.ByteArray;

        protected override JProperty Transform(IExifValue value)
        {
            Byte[] bytes = (Byte[])value.GetValue();
            string str = bytes.GetString();
            return new JProperty(Name, str);
        }
    }
}
