using System;

namespace FactoryPattern
{
    internal abstract class CustomFile
    {
        public abstract void ShowStatus();
    }

    internal class TXTFile : CustomFile
    {
        public override void ShowStatus() {}
    }

    internal class XLSXFile : CustomFile
    {
        public override void ShowStatus() {}
    }

    internal class PNGFile : CustomFile
    {
        public override void ShowStatus() {}
    }
}
