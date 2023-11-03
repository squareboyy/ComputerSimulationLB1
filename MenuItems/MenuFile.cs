using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OfficeOpenXml;
using System.Collections.ObjectModel;

namespace ComputerSimulationLB1.MenuItems
{
    public class MenuFile
    {
        public void Import()
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files (*.*)|*.*";

            ExportWindow exportWindow = new();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    exportWindow.Show();

                    string filePath = openFileDialog.FileName;
                    ImportAction(filePath, exportWindow);
                }
                catch
                {
                    exportWindow.Close();
                    MessageBox.Show("Помилка, перевірте коректність даних в excel відповідно до таблиці, яку ви хочете заповнити");
                }
            }
        }

        private void ImportAction(string filePath, ExportWindow exportWindow)
        {
            MainWindow mainWindow = new();
            List<string> list = new();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        if (!string.IsNullOrWhiteSpace(worksheet.Cells[row, col].Value.ToString()))
                        {
                            list.Add(worksheet.Cells[row, col].Value.ToString());
                        }
                    }

                    list.Add(mainWindow.CalculateData(list[1]));
                    exportWindow.AddingData(list);
                    list.Clear();
                }
            }
        }

        public void Export(ObservableCollection<StaticModel> dataCollection)
        {
            var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            worksheet.Cells[1, 1].Value = "№";
            worksheet.Cells[1, 2].Value = "Кількість чавуну(т)";
            worksheet.Cells[1, 3].Value = "Час плавки(ч)";

            int row = 2;
            foreach (var dataRow in dataCollection)
            {
                worksheet.Cells[row, 1].Value = dataRow.Number;
                worksheet.Cells[row, 2].Value = dataRow.FactorValue;
                worksheet.Cells[row, 3].Value = dataRow.ResponseValue;

                row++;
            }

            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "result.xlsx";
            saveFileDialog.CheckFileExists = false;

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                package.SaveAs(new FileInfo(filePath));
            }
        }   
    }
}
