using System;

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
                    // TODO Encrypt it
                } else {
                    Console.Error.WriteLine("Invalid key.");
                    PrintUsage();
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
