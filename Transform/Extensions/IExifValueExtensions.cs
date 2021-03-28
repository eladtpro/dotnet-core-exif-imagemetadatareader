using ImageMagick;

namespace ImageMetadata.Transform.Extensions
{
    public static class IExifValueExtensions
    {
        public static string GetName(this IExifValue value)
        {
            return value.Tag.ToString();
        }
    }
}
