using Dulcepastel.Models.utility.structView;
using OfficeOpenXml;

namespace Dulcepastel.Models.export;

public static class Export
{
    public static async Task ExportData(List<GenericView>? data, List<string> titles)
    {
        reinicio:
        try
        {
            var excelPath = @$"{Directory.GetCurrentDirectory()}\wwwroot\temp\Dulcepastel.xlsx";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(new FileInfo(excelPath));
            var worksheet = package.Workbook.Worksheets[0];
            worksheet.Name = titles[0];
            worksheet.Cells.Clear();
            for (var col = 1; col != titles.Count; col++)
                worksheet.Cells[1, col].Value = titles[col];

            for (var rowData = 2; rowData < data?.Count + 2; rowData++)
            {
                worksheet.Cells[rowData, 1].Value = data?[rowData - 2].Value1?.ToString();
                worksheet.Cells[rowData, 2].Value = data?[rowData - 2].Value2?.ToString();
                worksheet.Cells[rowData, 3].Value = data?[rowData - 2].Value3?.ToString();
                worksheet.Cells[rowData, 4].Value = data?[rowData - 2].Value4?.ToString();
                worksheet.Cells[rowData, 5].Value = data?[rowData - 2].Value5?.ToString();
                worksheet.Cells[rowData, 6].Value = data?[rowData - 2].Value6?.ToString();
                worksheet.Cells[rowData, 7].Value = data?[rowData - 2].Value7?.ToString();
                worksheet.Cells[rowData, 8].Value = data?[rowData - 2].Value8?.ToString();
                worksheet.Cells[rowData, 9].Value = data?[rowData - 2].Value9?.ToString();
                worksheet.Cells[rowData, 10].Value = data?[rowData - 2].Value10?.ToString();
                worksheet.Cells[rowData, 11].Value = data?[rowData - 2].Value11?.ToString();
                worksheet.Cells[rowData, 12].Value = data?[rowData - 2].Value12?.ToString();
                worksheet.Cells[rowData, 13].Value = data?[rowData - 2].Value13?.ToString();
                worksheet.Cells[rowData, 14].Value = data?[rowData - 2].Value14?.ToString();
                worksheet.Cells[rowData, 15].Value = data?[rowData - 2].Value15?.ToString();
                worksheet.Cells[rowData, 16].Value = data?[rowData - 2].Value16?.ToString();
            }

            await package.SaveAsync();
        }
        catch (Exception)
        {
            goto reinicio;
        }
    }
}