using System;

namespace FactoryPattern
{
    internal abstract class CustomFile
    {
        private string FullPath { get; }
        protected CustomFile(string fullPath) { FullPath = fullPath; }

        protected virtual void ShowProperties() { Console.WriteLine($"Full path = {FullPath}"); }
    }

    internal class TXTFile : CustomFile
    {
        public string Encoding { get; set; }

        public TXTFile(string fullPath) : base(fullPath) { }

        protected override void ShowProperties()
        {
            base.ShowProperties();
            Console.WriteLine($"Encoding = {Encoding}");
        }
    }

    internal class XLSXFile : CustomFile
    {
        public int SheetCount { get; set; }

        public XLSXFile(string fullPath) : base(fullPath) { }

        protected override void ShowProperties()
        {
            base.ShowProperties();
            Console.WriteLine($"Sheet count = {SheetCount}");
        }
    }

    internal class PNGFile : CustomFile
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public PNGFile(string fullPath) : base(fullPath) { }

        protected override void ShowProperties()
        {
            base.ShowProperties();
            Console.WriteLine($"Width = {Width}");
            Console.WriteLine($"Height = {Height}");
        }
    }
}
