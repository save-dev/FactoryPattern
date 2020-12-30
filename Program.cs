using System;
using System.Threading;

namespace FactoryPattern
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter directory");
            var dir = Console.ReadLine();
            dir.IsExit();

            Console.WriteLine("Enter file name");
            var name = Console.ReadLine();
            name.IsExit();

            Console.WriteLine("Enter extension");
            var ext = Console.ReadLine();
            ext.IsExit();

            var fileManager = new FileManager();
            fileManager.ValidateInputs(dir, name, ext);
        }
    }

    internal static class StringIsExitExtension
    {
        public static void IsExit(this string str)
        {
            if (str.Equals("Exit"))
            {
                Console.WriteLine("Quitting..");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
    }
}
