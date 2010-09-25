using System;
using System.IO.MemoryMappedFiles;

namespace Experiments.MemoryMappedFiles.Client
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Memory mapped file reader started");

            using (var file = MemoryMappedFile.OpenExisting("myFile"))
            {
                using (var reader = file.CreateViewAccessor(0, 24))
                {
                    var bytes = new byte[24];
                    reader.ReadArray(0, bytes, 0, bytes.Length);

                    Console.WriteLine("Reading bytes");
                    foreach (var t in bytes)
                        Console.Write((char)t + " ");

                    Console.WriteLine(string.Empty);
                }
            }

            Console.WriteLine("Press any key to exit ...");
            Console.ReadLine();
        }
    }
}
