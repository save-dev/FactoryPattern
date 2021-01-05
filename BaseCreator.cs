using System;
using System.Drawing;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace FactoryPattern
{
    internal abstract class BaseCreator
    {
        public abstract CustomFile CreateFile(string fullPath);
    }

    internal class TXTCreator : BaseCreator
    {
        public override CustomFile CreateFile(string fullPath)
        {
            File.WriteAllText(fullPath, string.Empty, new UTF8Encoding(false));
            var createdFile = new TXTFile(fullPath) {Encoding = "UTF8"};
            return createdFile;
        }
    }

    internal class XLSXCreator : BaseCreator
    {
        public override CustomFile CreateFile(string fullPath)
        {
            var excelApp = new Application {Visible = true, SheetsInNewWorkbook = 5};
            var workBook = excelApp.Workbooks.Add(Type.Missing);
            workBook.SaveAs(fullPath);
            return new XLSXFile(fullPath) {SheetCount = 5};
        }
    }

    internal class PNGCreator : BaseCreator
    {
        public override CustomFile CreateFile(string fullPath)
        {
            var image = new Bitmap(150, 150);
            image.Save(fullPath);
            return new PNGFile(fullPath) {Width = 150, Height = 150};
        }
    }
}
