using System;
using System.Linq;

namespace Com.GitHub.ZachDeibert.WordRotEncrypt {
    class Word {
        public readonly string Original;
        public readonly string Prepared;
        public string Translated;
        public readonly bool Translates;

        public Word(string text) {
            Original = text;
            Prepared = Original.ToLower();
            Translates = Prepared.All(c => c >= 'a' && c <= 'z');
        }
    }
}
