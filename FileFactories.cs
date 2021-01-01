using System;
using System.Drawing;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace FactoryPattern
{
    internal abstract class FileFactories
    {
        public abstract CustomFile CreateFile(string fullPath);
    }

    internal class TXTCreator : FileFactories
    {
        public override CustomFile CreateFile(string fullPath)
        {
            File.WriteAllText(fullPath, string.Empty, new UTF8Encoding(false));
            return new TXTFile();
        }
    }

    internal class XLSXCreator : FileFactories
    {
        public override CustomFile CreateFile(string fullPath)
        {
            var excelApp = new Application {Visible = true, SheetsInNewWorkbook = 5};
            var workBook = excelApp.Workbooks.Add(Type.Missing);
            workBook.SaveAs(fullPath);     
            return new XLSXFile();
        }
    }

    internal class PNGCreator : FileFactories
    {
        public override CustomFile CreateFile(string fullPath)
        {
            var image = new Bitmap(150, 150);
            image.Save(fullPath);
            return new PNGFile();
        }
    }
}
