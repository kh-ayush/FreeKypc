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
        private ISave isave;
        private List<CWord> words;
        private CTrainer trainer;
        public MainWindow()
        {
            InitializeComponent();

            isave = new CStorage();
            words = new List<CWord>() { new CWord("monkey", "бибизян", "Animals"),
                                        new CWord("beaver", "бобёр", "Animals"),
                                        new CWord("sheep", "моя булочка", "Animals"),
                                        new CWord("bober", "петух", "Animals"),
                                        new CWord("carrot", "марков", "Vegetables"), 
                                        new CWord("to translate", "переводить", "Verbs") };
            trainer = new CTrainer(words);

            CategoryCB.ItemsSource = words.Select(x => x.Category).Distinct();

            DataContext = trainer.Stats;
        }
        private void NewWord_Click(object sender, RoutedEventArgs e)
        {
            Window2 nw = new Window2(words);
            nw.ShowDialog();
            CategoryCB.ItemsSource = words.Select(x => x.Category).Distinct();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryCB.SelectedItem == null) return;

            trainer.Start(CategoryCB.SelectedItem.ToString());

            MainWordTB.Text = trainer.CurrentWord.Original;

            AnswerButton1.Background = Brushes.WhiteSmoke;
            AnswerButton2.Background = Brushes.WhiteSmoke;
            AnswerButton3.Background = Brushes.WhiteSmoke;
            AnswerButton4.Background = Brushes.WhiteSmoke;

            AnswerButton1.Content = trainer.CurrentAnswers[0];
            AnswerButton2.Content = trainer.CurrentAnswers[1];
            AnswerButton3.Content = trainer.CurrentAnswers[2];
            AnswerButton4.Content = trainer.CurrentAnswers[3];
        }
        private void NextWord_Click(object sender, RoutedEventArgs e)
        {
            AnswerButton1.Background = Brushes.WhiteSmoke;
            AnswerButton2.Background = Brushes.WhiteSmoke;
            AnswerButton3.Background = Brushes.WhiteSmoke;
            AnswerButton4.Background = Brushes.WhiteSmoke;
        }
        private void DeleteWord_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            isave.Save(words);
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            words.Clear();
            words = isave.Load();
            trainer = new CTrainer(words);
            DataContext = trainer.Stats;
            CategoryCB.ItemsSource = words.Select(x => x.Category).Distinct();
        }
        private void Option_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            bool res = trainer.CheckAnswers(btn.Content.ToString());

            if (res) { btn.Background = Brushes.LightGreen; btn.Foreground = Brushes.White; }
            else { btn.Background = Brushes.LightPink; btn.Foreground = Brushes.White; }
        }
    }
}