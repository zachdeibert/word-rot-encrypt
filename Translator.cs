using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.GitHub.ZachDeibert.WordRotEncrypt {
    class Translator {
        EncryptionDictionary Dictionary;
        int Key;

        public string Translate(string input) {
            List<Word> words = new List<Word>();
            List<char> text = new List<char>();
            bool isWord = false;
            foreach (char c in input.ToCharArray()) {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')) {
                    if (!isWord) {
                        if (text.Count > 0) {
                            words.Add(new Word(new string(text.ToArray())));
                            text.Clear();
                        }
                        isWord = true;
                    }
                } else if (isWord) {
                    if (text.Count > 0) {
                        words.Add(new Word(new string(text.ToArray())));
                        text.Clear();
                    }
                    isWord = false;
                }
                text.Add(c);
            }
            if (text.Count > 0) {
                words.Add(new Word(new string(text.ToArray())));
            }
            foreach (Word word in words) {
                if (word.Translates) {
                    word.Translated = word.Original;
                    Dictionary.TryTranslate(ref word.Translated, Key);
                }
            }
            return string.Join("", words.Select(word => word.Translates ? word.Translated : word.Original));
        }

        public Translator(EncryptionDictionary dictionary, int key) {
            Dictionary = dictionary;
            Key = key;
        }
    }
}
