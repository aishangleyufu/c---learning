using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 文件流
{
    class Program
    {
        static void Main(string[] args)
        {

            //FileStream fsread = new FileStream(@"C:\Users\c\Desktop\kk.txt", FileMode.OpenOrCreate, FileAccess.Read);
            //byte[] buffer = new byte[1024 * 1024 * 5];
            //int r = fsread.Read(buffer, 0, buffer.Length);
            //string s = Encoding.UTF8.GetString(buffer, 0, r);
            //fsread.Close();
            //fsread.Dispose();
            //Console.WriteLine(s);
            //Console.ReadKey();

            //using(FileStream fswrite=new FileStream(@"C:\Users\c\Desktop\kk.txt",FileMode.OpenOrCreate,FileAccess.Write))
            //{
            //    string str="看我有没有把你覆盖";
            //    byte[] buffer2=Encoding.Default.GetBytes(str);
            //    fswrite.Write(buffer2,0,buffer2.Length);
                
            //}
            //Console.ReadKey();


            string source = @"C:\Users\c\Desktop\yy所有\小渔夫 童话 .mp3";
            string target = @"C:\Users\c\Desktop\小渔夫 童话 .mp3";
            CopyFile(source, target);
            Console.WriteLine("复制成功");
            Console.ReadKey();
        }

        public static void CopyFile(string source,string target){
            using(FileStream fsRead=new FileStream(source,FileMode.OpenOrCreate,FileAccess.Read))
            {
               using(FileStream fsWrite=new FileStream(target,FileMode.OpenOrCreate,FileAccess.Write))
               {
                   
                   byte[] buffer=new byte[1024*1024*5];
                   while(true){
                       int r = fsRead.Read(buffer, 0, buffer.Length);
                       if(r==0){
                           break;
                         }
                       fsWrite.Write(buffer, 0, r);
                   }
               }

            }
        }
       
    }
}
