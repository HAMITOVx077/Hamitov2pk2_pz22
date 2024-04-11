using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hamitov2pk2_pz22
{
    /// <summary>
    /// Логика взаимодействия для CreateFileWindow.xaml
    /// </summary>
    public partial class CreateFileWindow : Window
    {
        public CreateFileWindow()
        {
            InitializeComponent();
        }
        public string FileName //свойство для передачи имени строки
        {
            get => fileNameTextBox.Text;
        }
        public CreateFileWindow(Window owner) //конструктор принимает ссылку на владельца
        {
            this.Owner = owner; //нужен для центровки окно относительно родителя
            InitializeComponent();
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
