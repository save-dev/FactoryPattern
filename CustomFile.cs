using System;

namespace FactoryPattern
{
    internal abstract class CustomFile
    {
        public abstract void ShowStatus();
    }

    internal class TXTFile : CustomFile
    {
        public override void ShowStatus() { Console.WriteLine("Created an empty txt file"); }
    }

    internal class XLSXFile : CustomFile // дублируется метод done typeOf
    {
        public override void ShowStatus() { Console.WriteLine("Created an empty excel file"); }
    }

    internal class PNGFile : CustomFile
    {
        public override void ShowStatus() { Console.WriteLine("created an empty png file"); }
    }
}
