using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hamitov2pk2_pz22
{
    internal static class FileManager
    {
        public static void CreateFile(string filename, ListBox list, TextBox text) //сначала проверка на существование файла, затем создание файла
        {
            string pathToFile = @$"{Directory.GetCurrentDirectory()}\data\{filename}";

            if (File.Exists(pathToFile))
            {
                MessageBox.Show("Такой файл уже существует");
            }
            else
            {
                using (FileStream file = new FileStream(pathToFile, FileMode.Create));
                list.Items.Add(filename);
                text.Text = "";
            }
        }
        public static void SaveFile(string filename, TextBox text)
        {
            string pathToFile = @$"{Directory.GetCurrentDirectory()}\data\{filename}";
            using (FileStream fileW = new FileStream(pathToFile, FileMode.Open))
            {
                using (StreamWriter writer = new StreamWriter(fileW))
                {
                    writer.Write(text.Text);
                }
            }
        }
        public static void OpenFile(string filename, TextBox text)
        {
            string pathToFile = @$"{Directory.GetCurrentDirectory()}\data\{filename}";
            using (FileStream fileW = new FileStream(pathToFile, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileW))
                {
                    text.Text = reader.ReadToEnd();
                }
            }
        }
        public static void DeleteFile(string filename, ListBox list, TextBox text)
        {
            text.Text = "";
            string pathToFile = @$"{Directory.GetCurrentDirectory()}\data\{filename}";
            File.Delete(pathToFile);
            list.Items.Remove(filename);
        }
    }
}
