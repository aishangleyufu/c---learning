using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace path222
{
    class Program
    {
        static void Main(string[] args)
        {
            string str=@"C:\Users\c\Desktop\yy所有\xlarge_ySvY_169800008a18118f.jpg";
            Console.WriteLine(Path.GetFileName(str));
            Console.WriteLine(Path.GetFileNameWithoutExtension(str));
            Console.WriteLine(Path.GetDirectoryName(str));
            Console.WriteLine(Path.GetFullPath(str));

        }
    }
}
