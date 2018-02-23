using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Com.GitHub.ZachDeibert.WordRotEncrypt {
    class EncryptionDictionary {
        List<PartOfSpeech> PartsOfSpeech;

        public bool TryTranslate(ref string word, int key) {
            string _word = word;
            PartOfSpeech pos = PartsOfSpeech.FirstOrDefault(p => p.Contains(_word));
            if (pos == null) {
                return false;
            } else {
                word = pos.Translate(_word, key);
                return true;
            }
        }

        public void Load(string dir) {
            PartsOfSpeech = Directory.GetFiles(dir, "data.*")
                    .Select(file => new PartOfSpeech(file))
                    .ToList();
        }
    }
}
