namespace JSON___03___FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String jsonFilename;
            List<Word> wörter;

            // Festlegen des json-Dateinamens
            Console.Write("Welche json soll eingelesen werden? D:\\");
            jsonFilename = $"D:\\{Console.ReadLine()}";

            try 
            { 
                wörter = FizzBuzz.ReadJson(jsonFilename); // Auslesen der json-Datei
                Console.WriteLine();
                FizzBuzz.PrintWordInfo(wörter); // Informationen über die Wortliste ausgeben
                Console.WriteLine();
                FizzBuzz.Print(wörter, 100); // Ausgabe der Zahlen und der Wörter
            }
            catch (Exception e) { Console.WriteLine($"Fehler: {e.Message}"); } 
        }
    }
}
