using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Hamitov2pk2_pz22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string oldFileName = "";
        public string filename = "";
        public bool isSave = false;

        public MainWindow()
        {
            InitializeComponent();
            FilesShow();
            StatusBar();
        }
        private void CreateFileMenuIntem_Click(object sender, RoutedEventArgs e)
        {
            //в конструкторе передаем текущее окно (this)в качестве владельца
            CreateFileWindow fileCreate = new CreateFileWindow(this);
            string filename = "";

            if (fileCreate.ShowDialog() == true)
                //получаем имя файла если нажали OK
                filename = fileCreate.FileName;

            //если имя файла не пусто, то файл старый файл сохраняется и создаётся новый
            if (filename != "")
            {
                if (oldFileName != "")
                    FileManager.SaveFile(oldFileName, EditField);
                FileManager.CreateFile(filename, filesListBox, EditField);
            }

            StatusBar();
            oldFileName = filename;
            filename = "";
            //TODO создание файла и его открытие на редактирование
        }
        private void FilesShow()
        {
            string pathToFiles = @$"{Directory.GetCurrentDirectory()}\data";
            string[] files = Directory.GetFiles(pathToFiles);
            foreach (string file in files)
            {
                FileInfo nameFile = new FileInfo(file);
                filesListBox.Items.Add(nameFile.Name);
            }
        }
        private void DeleteFileMenuIntem_Click(object sender, RoutedEventArgs e)
        {
            filename = filesListBox.SelectedItem.ToString();
            FileManager.DeleteFile(filename, filesListBox, EditField);
            filename = "";
            oldFileName = "";
        }
        private void DeleteAllFileMenuIntem_Click(object sender, RoutedEventArgs e)
        {
            filesListBox.Items.Clear();
        }
        private void filesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            filename = filesListBox.SelectedItem.ToString();
            if (oldFileName != "")
                FileManager.SaveFile(oldFileName, EditField);
            FileManager.OpenFile(filename, EditField);
            isSave = true;
            StatusBar();
            oldFileName = filename;
        }
        private void SaveText_Click(object sender, RoutedEventArgs e)
        {
            if (filename != "")
            {
                filename = filesListBox.SelectedItem.ToString();
                FileManager.SaveFile(filename, EditField);
                isSave = true;
                StatusBar();
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл");
            }
            
        }
        private void StatusBar()
        {
            LeftBlockInformation();
            RightBlockInformation();
        }
        private void LeftBlockInformation()
        {
            LeftBlock.Text = "";
            UpdateCursorPosition();
            if (isSave)
                LeftBlock.Text += "\tСохранено";
            else
                LeftBlock.Text += "\tТребуется сохранение";
        }
        private void RightBlockInformation()
        {
            if(filename!= "")
            {
                RightBlock.Text = "";
                string pathToFile = @$"{Directory.GetCurrentDirectory()}\data\{filename}";
                FileInfo file = new FileInfo(pathToFile);

                long filesize = file.Length;

                DateTime timeOfCreate = file.CreationTime;
                RightBlock.Text = $"{timeOfCreate} размер: {filesize} Кб";
            }
            else
            {
                RightBlock.Text = $"Файл не выбран";
            }
            

        }
        private void UpdateCursorPosition()
        {
            int row = EditField.GetLineIndexFromCharacterIndex(EditField.CaretIndex);
            int col = EditField.CaretIndex - EditField.GetLineIndexFromCharacterIndex(row);
            LeftBlock.Text = $"строка: {row + 1} столбец: {col + 1}";
        }
        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            StatusBar();
        }
        private void EditFieldTextChanged(object sender, TextChangedEventArgs e)
        {
            isSave = false;
            StatusBar();
        }
        private void Bold_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CrossedOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextCenter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextRight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextWidth_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AboutAftorInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AboutProgramInformation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}