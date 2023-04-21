using Microsoft.IdentityModel.Tokens;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace Dulcepastel.Models.utility.img;

public static class Img
{
    public static async Task<string> ValidatedImg(string? urlImg, IFormFile? file = null)
    {
        try
        {
            string[] extension = { ".jpg", ".png", ".jpeg", ".bmp", ".tiff", ".tif" };
            if (!File.Exists(urlImg) && file == null)
                return "1"; //"La Dirección proporcionada no contiene una imagen";

            var info = new FileInfo(urlImg ?? file!.FileName);
            var isValid = extension.Any(t => info.Extension == t);
            if (!isValid) return "2"; //Formato no aceptado;

            using var stream = new MemoryStream();
            if (file != null && urlImg.IsNullOrEmpty())
            {
                await file.CopyToAsync(stream);
                stream.Seek(0, SeekOrigin.Begin);
            }

            using var image =
                urlImg.IsNullOrEmpty() ? await Image.LoadAsync(stream) : await Image.LoadAsync(urlImg!);


            if (image.Width == 0 || image.Height == 0) return "3"; // "Tamaño no valido"

            if (image.Width > 1000 || image.Height > 1000)
                image.Mutate(re => re.Resize(new ResizeOptions
                {
                    Size = new Size(1000, 1000),
                    Mode = ResizeMode.Max
                }));

            var filePath = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot", "uploads",
                Guid.NewGuid() + info.Extension);
            await image.SaveAsync(filePath, new JpegEncoder { Quality = 75 });
            return filePath; // "Todo estuvo correcto"
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}