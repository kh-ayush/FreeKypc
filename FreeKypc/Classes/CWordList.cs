using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeKypc.Classes
{
    public class CWordList
    {
        ObservableCollection<CWord> words;
        public CWordList(ObservableCollection<CWord> words)
        {
            this.words = words;
        }
        public CWordList()
        {
            words = new ObservableCollection<CWord>();
        }
        public void AddWord(CWord word) { words.Add(word); }
        public List<string> GetRest(CWord word)
        {
            List<string> rest = [];
            //var rand = new Random();

            foreach (CWord w in words) { if (w != word) rest.Add(w.GetTranslation()); }
            //rest = rest.OrderBy(x => rand.Next()).ToList();

            return rest;
        }
        public List<string> GetFour(CWord word) 
        {
            var rand = new Random();

            List<string> four = GetRest(word).OrderBy(x => rand.Next()).ToList().Slice(0,3);

            four.Add(word.GetTranslation());
            four = four.OrderBy(x => rand.Next()).ToList();

            return four;
        }
    }
}
