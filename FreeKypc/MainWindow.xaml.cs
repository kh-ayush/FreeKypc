using FreeKypc.Classes;
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
            currentword = new CWordAnimals("Dog", "Бабака");
            wordlist.AddWord(currentword);
            wordlist.AddWord(new CWordAnimals("Cat", "Кошка"));
            wordlist.AddWord(new CWordAnimals("Horse", "Лошадь"));
            wordlist.AddWord(new CWordAnimals("Cow", "Корова"));
            wordlist.AddWord(new CWordAnimals("Wolf", "Волк"));
        }
        CWordList wordlist = new CWordList();
        CWord currentword;
        List<string> otherwords;
        private void NewWord_Click(object sender, RoutedEventArgs e)
        {
            Window2 nw = new Window2();
            nw.ShowDialog();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainWordTB.Text = currentword.GetOriginal();
            otherwords = wordlist.GetFour(currentword);
            AnswerButton1.Content = otherwords[0];
            AnswerButton2.Content = otherwords[1];
            AnswerButton3.Content = otherwords[2];
            AnswerButton4.Content = otherwords[3];
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
        
        private void Option_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}