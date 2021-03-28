using ImageMagick;

using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;

namespace ImageMetadata.Transform.Transformers
{
    class ComponentsConfigurationTransformer : Transformer
    {

        private static string GetComponent(int component)
        {
            return component switch
            {
                0 => "-",
                1 => "Y",
                2 => "Cb",
                3 => "Cr",
                4 => "R",
                5 => "G",
                6 => "B",
                _ => "Unknown"
            };
        }

        internal override TransformType Type => TransformType.ComponentsConfiguration;

        protected override JProperty Transform(IExifValue value)
        {
            Byte[] bytes = (Byte[])value.GetValue();
            int[] keys = ((IEnumerable)value.GetValue()).Cast<object>().Select(obj => Convert.ToInt32(obj)).ToArray();
            string[] components = keys.Select(k => GetComponent(k)).ToArray();
            return new JProperty(Name, new JArray(components.ToArray()));
        }
    }
}
