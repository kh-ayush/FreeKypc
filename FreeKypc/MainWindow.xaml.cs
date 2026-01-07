using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FreeKypc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NewWord_Click(object sender, RoutedEventArgs e)
        {
            Window2 nw = new Window2();
            nw.ShowDialog();
        }
        private void DeleteWord_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CategoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Option_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}