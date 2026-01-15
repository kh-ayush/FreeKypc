using FreeKypc.Classes;
using System.Security.Cryptography;
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
        private ISaveWords isave;
        private List<CWord> words;
        private List<CWord> currentwords;
        private CTrainer trainer;
        public MainWindow()
        {
            InitializeComponent();

            NextWordB.IsEnabled = false;
            isave = new CStorage();
            words = new List<CWord>();  //{ new CWord("monkey", "бибизян", "Animals"),
                                        //new CWord("beaver", "бобёр", "Animals"),
                                        //new CWord("sheep", "кишка", "Animals"),
                                        //new CWord("bober", "петух", "Animals"),
                                        //new CWord("buffalo", "буйвол", "Animals"),

                                        //new CWord("carrot", "марков", "Vegetables"), 
                                        //new CWord("broccoli", "брокколи", "Vegetables"), 
                                        //new CWord("corgete", "кобачок", "Vegetables"), 
                                        //new CWord("cucumber", "огурец", "Vegetables"),
                                        //new CWord("pumpkin", "тыковка", "Vegetables"),

                                        //new CWord("to translate", "переводить", "Verbs"),
                                        //new CWord("to type", "печатать", "Verbs"),
                                        //new CWord("to read", "читать", "Verbs"),
                                        //new CWord("to imagine", "воображать", "Verbs"),
                                        //new CWord("to dance", "танцевать", "Verbs") };
            trainer = new CTrainer(words);

            CategoryCB.ItemsSource = words.Select(x => x.Category).Distinct();

            DataContext = trainer.Stats;
            CategoryCB.SelectedIndex = 0;
        }
        private void NewWord_Click(object sender, RoutedEventArgs e)
        {
            Window2 nw = new Window2(words);
            nw.ShowDialog();
            currentwords = words;
            trainer = new CTrainer(words);
            DataContext = trainer.Stats;
            CategoryCB.ItemsSource = words.Select(x => x.Category).Distinct();
        }        
        private void NextWord_Click(object sender, RoutedEventArgs e)
        {
            NextWord();
        }
        private void DeleteWord_Click(object sender, RoutedEventArgs e)
        {
            if (words.Where(w => w.Category == trainer.CurrentWord.Category).ToList().Count <= 4) 
            {
                MessageBox.Show("Нельзя удалять слова из этой категории, так как в ней должно быть минимум 4 слова для тренировки.", 
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            words.Remove(trainer.CurrentWord);
            currentwords = words;
            trainer = new CTrainer(words);
            DataContext = trainer.Stats;
            CategoryCB.ItemsSource = words.Select(x => x.Category).Distinct();
            NextWord();
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
            CategoryCB.SelectedIndex = 0;

            NextWord();
        }
        private void Option_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button) sender;
            bool res = trainer.CheckAnswers(btn.Content.ToString());
            if (res) 
            {
                btn.Background = Brushes.LightGreen; btn.Foreground = Brushes.White;
                if (currentwords.Count == 1)
                {
                    MessageBox.Show("Поздравляем! Вы прошли все слова в этой категории!",
                                                             "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NextWordB.IsEnabled = false;
                }
                else 
                {
                    currentwords.Remove(trainer.CurrentWord); 
                    NextWordB.IsEnabled = true;
                }
                AnswerButton1.IsHitTestVisible = false;
                AnswerButton2.IsHitTestVisible = false;
                AnswerButton3.IsHitTestVisible = false;
                AnswerButton4.IsHitTestVisible = false;
            }
            else 
            {
                btn.Background = Brushes.LightPink; btn.Foreground = Brushes.White;
                btn.IsHitTestVisible = false;
            }
        }
        private void CategoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentwords = words;
            NextWordB.IsEnabled = false;
            NextWord();
        }
        public void NextWord()
        {
            trainer.Start(CategoryCB.SelectedItem.ToString(), currentwords);
            MainWordTB.Text = trainer.CurrentWord.Original;
            ButtonsProp();

            AnswerButton1.Content = trainer.CurrentAnswers[0];
            AnswerButton2.Content = trainer.CurrentAnswers[1];
            AnswerButton3.Content = trainer.CurrentAnswers[2];
            AnswerButton4.Content = trainer.CurrentAnswers[3];
        }
        public void ButtonsProp() 
        {
            AnswerButton1.Background = Brushes.WhiteSmoke;
            AnswerButton2.Background = Brushes.WhiteSmoke;
            AnswerButton3.Background = Brushes.WhiteSmoke;
            AnswerButton4.Background = Brushes.WhiteSmoke;

            AnswerButton1.Foreground = Brushes.Black;
            AnswerButton2.Foreground = Brushes.Black;
            AnswerButton3.Foreground = Brushes.Black;
            AnswerButton4.Foreground = Brushes.Black;

            AnswerButton1.IsHitTestVisible = true;
            AnswerButton2.IsHitTestVisible = true;
            AnswerButton3.IsHitTestVisible = true;
            AnswerButton4.IsHitTestVisible = true;
        }
    }
}