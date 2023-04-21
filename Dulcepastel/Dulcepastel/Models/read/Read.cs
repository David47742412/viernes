namespace Balance.Models.read;

public class Read
{
    public static async Task<string> CreateFile(IFormFile file)
    {
        var fileName = file.Name + Guid.NewGuid() + ".xlsx";
        var filePath = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot", "temp", fileName);
        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
        return fileName;
    }
}