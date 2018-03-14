using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
namespace 追加XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists("Books.xml"))
            {
                doc.Load("Books.xml");
                XmlElement books = doc.DocumentElement;

            }
            else
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);
                XmlElement books = doc.CreateElement("Books");
                doc.AppendChild(books);
            }
            doc.Save("Books.xml");
            Console.WriteLine("保存成功");
            Console.ReadKey();
        }
    }
}
