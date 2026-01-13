using FreeKypc.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

namespace FreeKypc
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private List<CWord> words;
        public Window2(List<CWord> _words)
        {
            InitializeComponent();
            words = _words;

            CategoryCB.ItemsSource = words.Select(w => w.Category).Distinct();
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            words.Add(new CWord(NameTB.Text, TransTB.Text, CategoryCB.Text));
            this.Close();
        }
    }
}
