using System;

namespace Com.GitHub.ZachDeibert.WordRotEncrypt {
    class Translator {
        EncryptionDictionary Dictionary;
        int Key;

        public string Translate(string input) {
            return input;
        }

        public Translator(EncryptionDictionary dictionary, int key) {
            Dictionary = dictionary;
            Key = key;
        }
    }
}
