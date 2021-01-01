using System;
using System.IO;
using System.Threading;

namespace FactoryPattern
{
    internal class FileManager
    {
        public void ValidateInputs(string dir, string name, string ext)
        {
            if (string.IsNullOrEmpty(name) && name?.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
            {
                Console.WriteLine("Invalid file name");
                Restart();
            }

            try
            {
                var fullPath = Path.Combine(dir, $"{name}.{ext}");
                var getFullPath = Path.GetFullPath(fullPath);

                if (fullPath.Equals(getFullPath))
                {
                    StartCreation(fullPath, ext);
                }
                else
                {
                    Console.WriteLine($"\n{fullPath} is relative path: {getFullPath}");
                    Console.WriteLine("Specify absolute path");
                    Restart();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Restart();
            }
        }

        private void StartCreation(string fullPath, string ext)
        {
            Console.WriteLine(File.Exists(fullPath) ? $"\nOverwriting file... {fullPath}" : $"\nCreating empty file... {fullPath}");

            FileFactories newFile = null;
            switch (ext)
            {
                case "txt":
                    newFile = new TXTCreator();
                    break;
                case "xlsx":
                    newFile = new XLSXCreator();
                    break;
                case "png":
                    newFile = new PNGCreator();
                    break;
                default:
                    Console.WriteLine("Bad extension");
                    Restart();
                    break;
            }

            newFile?.CreateFile(fullPath);
            Console.WriteLine($"Successfully created a {ext} file");
        }

        private void Restart()
        {
            Console.WriteLine("Restarting...");
            Thread.Sleep(2000);
            Program.Main();
        }
    }
}
