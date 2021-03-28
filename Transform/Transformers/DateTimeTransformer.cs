
using Newtonsoft.Json.Linq;
using ImageMagick;
using System;
using System.Globalization;

namespace ImageMetadata.Transform.Transformers
{
    class DateTimeTransformer : Transformer
    {
        internal override TransformType Type => TransformType.DateTime;

        protected override JProperty Transform(IExifValue value)
        {
            return (DateTime.TryParseExact(value.ToString(), "yyyy:MM:dd hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt)) ?
                new JProperty(Name, dt) :
                new JProperty(Name, value.ToString());
        }
    }
}
