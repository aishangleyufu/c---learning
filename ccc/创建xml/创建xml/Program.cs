using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace 创建xml
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec=doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement books = doc.CreateElement("Books");
            doc.AppendChild(books);
            XmlElement book1 = doc.CreateElement("Book");
            books.AppendChild(book1);

            XmlElement name1 = doc.CreateElement("Name");
            name1.InnerText = "金瓶梅";
            name1.InnerXml = "<p>我是一个p标签</p>";
            name1.SetAttribute("name", "黄色");
            book1.AppendChild(name1);

            XmlElement price1 = doc.CreateElement("Price");
            price1.InnerText = "10";
            book1.AppendChild(price1);

            XmlElement des1 = doc.CreateElement("Des");
            des1.InnerText = "历史名著";
            book1.AppendChild(des1);

            XmlElement book2 = doc.CreateElement("Book");
            books.AppendChild(book2);

            XmlElement name2 = doc.CreateElement("Name");
            name2.InnerText = "水浒传";
            book2.AppendChild(name2);

            XmlElement price2 = doc.CreateElement("Price");
            price2.InnerText = "20";
            book2.AppendChild(price2);

            XmlElement des2 = doc.CreateElement("Des");
            des2.InnerText = "四大名著";
            book2.AppendChild(des2);


            doc.Save("Books.xml");
            Console.WriteLine("保存成功");
            Console.ReadKey();
        }
    }
}
