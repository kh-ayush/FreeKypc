using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeKypc.Classes
{
    public abstract class CWord
    {
        string original;
        string translation;
        public string Original
        { 
            get => original; set => original = value;
        }
        public string Translation
        { 
            get => translation; set => translation = value;
        }
        public CWord(string orig, string trans) 
        {
            Original = orig;
            Translation = trans;
        }
        public CWord()
        {
            Original = "";
            Translation = "";
        }
        public string GetTranslation() { return Translation; }
        public string GetOriginal() { return Original; }
    }
}
