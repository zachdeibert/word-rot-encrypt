using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Com.GitHub.ZachDeibert.WordRotEncrypt {
    class PartOfSpeech {
        List<string> Words;

        public bool Contains(string word) {
            return Words.Contains(word);
        }

        public string Translate(string word, int key) {
            int index = Words.IndexOf(word);
            if (index < 0) {
                throw new IndexOutOfRangeException("Word is not in list");
            }
            index += key;
            while (index < 0) {
                index += Words.Count;
            }
            index %= Words.Count;
            return Words[index];
        }

        public PartOfSpeech(string file) {
            Words = File.ReadAllLines(file)
                    .Where(line => !line.StartsWith(" "))
                    .Select(line => line.Split(' '))
                    .Select(arr => arr[4])
                    .Select(word => word.Replace('_', ' '))
                    .OrderBy(word => word)
                    .ToList();
        }
    }
}
