using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace FreeKypc.Classes
{
    public interface ISave
    {
        List<CWord> Load();
        void Save(List<CWord> words);
    }
    public class CStorage : ISave
    {
        private const string filename = "words.json";
        public List<CWord> Load() 
        {
            if (!File.Exists(filename)) { return new List<CWord>(); }
            return JsonSerializer.Deserialize<List<CWord>>(File.ReadAllText(filename));
        }
        public void Save(List<CWord> words)
        {
            File.WriteAllText(filename, JsonSerializer.Serialize(words, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
