using ImageMagick;

using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace ImageMetadata.Transform.Transformers
{
    class ByteVersionTransformer : Transformer
    {
        internal override TransformType Type => TransformType.ByteVersion;

        protected override JProperty Transform(IExifValue value)
        {
            Byte[] bytes = (Byte[])value.GetValue();
            string[] strings = bytes.Select(b => b.ToString()).ToArray();
            string version = string.Join('.', strings);
            return new JProperty(Name, version);
        }
    }
}
