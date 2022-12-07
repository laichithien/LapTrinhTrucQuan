using System;
using System.Collections.Generic;
using System.IO;

namespace Bai02
{
    public class File : Item
    {
        private long size;

        public File(string name, DateTime lastMod, long size) : base(name, lastMod)
        {
            this.size = size;
        }

        public override void Display()
        {
            Console.WriteLine("{0}\t{1}\t{2}", lastMod, size, name);
        }
    }
    public class Folder : Item
    {
        public Folder(string name, DateTime lastMod) : base(name, lastMod)
        {
        }

        public override void Display()
        {
            Console.WriteLine("\t{0}\t{1}\t{2}\t", lastMod, "<DIR>", name);
        }
    }
    public abstract class Item
    {
        protected string name;
        protected DateTime lastMod;

        public Item(string name, DateTime lastMod)
        {
            this.name = name;
            this.lastMod = lastMod;
        }

        public virtual void Display()
        {
            return;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao duong dan: ");
            string path = Console.ReadLine();
            List<Item> listItems = GetAllFilesAndFolders(path);
            DisplayAllFilesAndFolder(listItems);
        }

        private static void DisplayAllFilesAndFolder(List<Item> listItems)
        {
            foreach (Item i in listItems)
                i.Display();
        }

        private static List<Item> GetAllFilesAndFolders(string path)
        {
            List<Item> Result = new List<Item>();
            if (Directory.Exists(path))
            {
                string[] listFiles = Directory.GetFiles(path);
                foreach (string filePath in listFiles)
                {
                    FileInfo info = new FileInfo(filePath);
                    File tmp = new File(info.Name, info.LastWriteTime, info.Length);
                    Result.Add(tmp);
                }
                string[] listFolders = Directory.GetDirectories(path);
                foreach (string folderPath in listFolders)
                {
                    DirectoryInfo info = new DirectoryInfo(folderPath);
                    Folder tmp = new Folder(info.Name, info.LastWriteTime);
                    Result.Add(tmp);
                }
            }
            return Result;
        }
    }
}