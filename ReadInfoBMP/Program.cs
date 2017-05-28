using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadInfoBMP
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStream = File.Open("./Files/Image.bmp", FileMode.OpenOrCreate);
            var binReader = new BinaryReader(fileStream);

            binReader.BaseStream.Seek(18, SeekOrigin.Begin);
            int width = binReader.ReadInt32();

            binReader.BaseStream.Seek(22, SeekOrigin.Begin);
            int height = binReader.ReadInt32();

            binReader.BaseStream.Seek(28, SeekOrigin.Begin);
            short bpp = binReader.ReadInt16();

            Console.WriteLine($"Ancho = {width}");
            Console.WriteLine($"Alto = {height}");
            Console.WriteLine($"Bit por pixel= {bpp}");

            binReader.Close();
            fileStream.Close();

            Console.ReadLine();
        }
    }
}
