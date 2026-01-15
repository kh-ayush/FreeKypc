using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FreeKypc.Classes
{
    public class AnswerCheckedEventArgs : EventArgs 
    {
        public bool IsCorrect { get; }
        public AnswerCheckedEventArgs(bool isCorrect)
        {
            IsCorrect = isCorrect;
        }
    }
    public interface ITrainer 
    {
        void Start(string category, List<CWord> currentwords);    
        bool CheckAnswers(string answer);    
    }
    public class CTrainer : ITrainer
    {
        private readonly List<CWord> words;
        public CStats Stats { get; } = new CStats();
        private CWord currentword;
        public CWord CurrentWord => currentword;
        public List<string> CurrentAnswers { get; private set; }
        private Random rand = new Random();
        public CTrainer(List<CWord> words)
        {
            this.words = words;
        }
        public void Start(string category, List<CWord> currentwords) 
        {
            var restpool = currentwords.Where(w => w.Category == category).ToList();
            var wholepool = words.Where(w => w.Category == category).ToList();
            currentword = restpool[rand.Next(restpool.Count)];

            CurrentAnswers = wholepool.Select(w => w.Translation).Distinct().OrderBy(x => rand.Next()).Take(4).ToList();

            if (!CurrentAnswers.Contains(currentword.Translation))
                CurrentAnswers[0] = currentword.Translation;

            CurrentAnswers = CurrentAnswers.OrderBy(x => rand.Next()).ToList();
        }
        public bool CheckAnswers(string answer) 
        {
            bool correct = (answer == currentword.Translation);
            Stats.AddResult(correct);
            return correct;
        }
    }
}
