using System.Text.Json;
using System.Text.RegularExpressions;

namespace JSON___03___FizzBuzz
{
    internal static class FizzBuzz
    {
        public static void Print(List<Word> wörter, int grenze)
        {
            String replace;
            for (int i = 1; i <= grenze; i++)
            {
                replace = "";
                foreach (Word w in wörter)
                {
                    // Wenn die aktuelle Zahl teilbar durch Value ist, ergänze den ausgabe-String um das Wort
                    if (i % w.Value == 0) replace += $"{w.Output}, ";
                }
                replace = Regex.Replace(replace, @", $", ""); // Lösche das letzte Vorkommen von ", "
                if (replace != "") Console.WriteLine(replace); // Wenn die Zahl ersetzt werden soll, replace ausgeben
                else Console.WriteLine(i); // ansonsten die Zahl ausgeben
            }
        }

        public static void PrintWordInfo(List<Word> wörter)
        {
            foreach (Word w in wörter)
            {
                Console.WriteLine(w);
            }
        }

        public static List<Word> ReadJson(String filename)
        {
            if (!File.Exists(filename)) throw new Exception("Die Datei existiert nicht!");

            String jsonString = File.ReadAllText($"{filename}"); // Einlesen der json-Datei
            List<Word> wörter = JsonSerializer.Deserialize<List<Word>>(jsonString); // Befüllen der Wörter-Liste

            return wörter;
        }
    }
}
