using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FreeKypc.Classes
{
    public  class CWord
    {
        public string Original { get; set; }
        public string Translation { get; set; }
        public string Category { get; set; }
        public CWord(string original, string translation, string category)
        {
            Original = original;
            Translation = translation;
            Category = category;
        }
    }
    public class CStats : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = null) 
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private int total;
        private int correct;
        public int Total 
        {
            get => total;
            private set 
            {
                total = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Wrong));
            }
        }
        public int Correct 
        {
            get => correct;
            private set 
            {
                correct = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Wrong));
            }
        }
        public int Wrong => Total - Correct;
        public void AddResult(bool correct) 
        {
            Total++;
            if (correct) Correct++;
        }
    }
}
