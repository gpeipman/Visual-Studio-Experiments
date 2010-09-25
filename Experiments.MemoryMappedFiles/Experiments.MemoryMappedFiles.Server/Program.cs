using System;
using System.IO.MemoryMappedFiles;

namespace Experiments.MemoryMappedFiles.Server
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Memory mapped file server started");

            using (var file = MemoryMappedFile.CreateNew("myFile", int.MaxValue))
            {
                var bytes = new byte[24];
                for (var i = 0; i < bytes.Length; i++)
                    bytes[i] = (byte)(65 + i);

                using (var writer = file.CreateViewAccessor(0, bytes.Length))
                {
                    writer.WriteArray<byte>(0, bytes, 0, bytes.Length);
                }

                Console.WriteLine("Before exiting run memory mapped file reader");
                Console.WriteLine("Press any key to exit ...");
                Console.ReadLine();
            }
        }
    }
}
