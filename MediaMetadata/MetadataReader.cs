using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageMagick;
using ImageMetadata.Transform;
using Newtonsoft.Json.Linq;

namespace ImageMetadata.MediaMetadata
{
    public class MetadataReader
    {
        public static JObject Read(Stream stream)
        {
            // Read image from file
            using MagickImage image = new(stream);
            // Retrieve the exif information
            IExifProfile profile = image.GetExifProfile();

            // Check if image contains an exif profile
            if (profile == null)
                return new JObject(new JProperty("warning", "Image does not contain exif information."));

            JObject metadata = new();
            IList<JProperty> properties = new List<JProperty>();
            // Write all values to the console
            foreach (IExifValue value in profile.Values)
            {
                string name = value.Tag.ToString();
                JProperty property;
                if (!value.IsArray)
                {
                    property = name switch
                    {
                        "DateTime" or "DateTimeDigitized" or "DateTimeOriginal" => Transformer.Transform(TransformType.DateTime, value),
                        _ => Transformer.Transform(TransformType.String, value)
                    };
                }
                else
                {
                    property = value.ToString() switch
                    {
                        "ImageMagick.ExifByteArray" =>
                            name switch
                            {
                                "ComponentsConfiguration" => Transformer.Transform(TransformType.ComponentsConfiguration, value),
                                "GPSVersionID" => Transformer.Transform(TransformType.ByteVersion, value),
                                _ => Transformer.Transform(TransformType.ByteArray, value)
                            },
                        "ImageMagick.ExifShortArray" => Transformer.Transform(TransformType.ShortArray, value),
                        "ImageMagick.ExifRationalArray" => Transformer.Transform(TransformType.RationalArray, value),
                        _ => Transformer.Transform(TransformType.String, value)
                    };
                }

                properties.Add(property);
            }

            foreach (JProperty prop in properties.OrderBy(p => p.Name))
                metadata.Add(prop);
            Console.WriteLine(metadata);
            return metadata;
        }
    }
}