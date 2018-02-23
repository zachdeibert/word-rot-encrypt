using System;
using System.IO;
using System.Linq;

namespace Com.GitHub.ZachDeibert.WordRotEncrypt {
    class Program {
        static void PrintUsage() {
            Console.Error.WriteLine("Usage: {0} <key> [text ...]", AppDomain.CurrentDomain.FriendlyName);
            Console.Error.WriteLine("key     must be an integer");
            Console.Error.WriteLine("text    is either the text to encrypt/decrypt, or the text is read over STDIN");
            Environment.Exit(1);
        }

        static void Main(string[] args) {
            if (args.Length < 1) {
                Console.Error.WriteLine("Not enough arguments.");
                PrintUsage();
            } else {
                int key;
                if (int.TryParse(args[0], out key)) {
                    EncryptionDictionary dict = new EncryptionDictionary();
                    try {
                        dict.Load("dict");
#if DEBUG
                    } catch (Exception ex) {
                        Console.Error.WriteLine(ex);
#else
                    } catch (Exception) {
#endif
                        Console.Error.WriteLine("Unable to find dictionary.");
                        Console.Error.WriteLine("Please download the following tarball and extract it to the {0} directory", Path.Combine(Environment.CurrentDirectory, "dict"));
                        Console.Error.WriteLine("http://wordnet.princeton.edu/wordnet/download/current-version/");
                        Environment.Exit(1);
                    }
                    Translator translator = new Translator(dict, key);
                    if (args.Length > 1) {
                        Console.WriteLine(translator.Translate(string.Join(' ', args.Skip(1))));
                    } else {
                        while (true) {
                            Console.WriteLine(translator.Translate(Console.ReadLine()));
                        }
                    }
                } else {
                    Console.Error.WriteLine("Invalid key.");
                    PrintUsage();
                }
            }
        }
    }
}
