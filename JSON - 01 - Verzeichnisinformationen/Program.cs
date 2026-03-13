using System.Text.Json;
namespace JSON___01___Verzeichnisinformationen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String suchpfad = "C:\\Windows\\system32";
            String jsonPfad = "D:\\windows.json";
            List<DirInfo> dirs = new List<DirInfo>();

            // Aufruf der rekursiven Funktion, die die Liste mit Objekten füllt
            Console.WriteLine("Bitte warten, die Liste wird gefüllt.");
            Search(suchpfad, dirs);

            Console.WriteLine("Liste wurde gefüllt.");

            // Speichern der Liste in einer json Datei
            FileStream fs = File.Create(jsonPfad);
            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            StreamWriter sw = new StreamWriter(fs);
            String jsonString;
            foreach (DirInfo d in dirs)
            {
                jsonString = JsonSerializer.Serialize(d, opt);
                sw.WriteLine(jsonString);
            }
            sw.Close();
            fs.Close();
            Console.WriteLine($"Json wurde erstellt: {jsonPfad}");

            // Json Datei einlesen
            Console.WriteLine("Json wird eingelesen.");
            List<String> jsonLines = new List<string>();
            jsonLines.AddRange(File.ReadLines(jsonPfad));

            //List<DirInfo> deSerializedDirs = new List<DirInfo>();
            List<DirInfo> deSerializedDirs = JsonSerializer.Deserialize<List<DirInfo>>(File.ReadAllText(jsonPfad));
            //foreach (String line in jsonLines)
            //{
            //    deSerializedDirs.Add(JsonSerializer.Deserialize<DirInfo>(line));
            //}

            // Ausgeben der Objekte
            Console.WriteLine("Objekte werden ausgegeben:");
            foreach (DirInfo d in deSerializedDirs)
            {
                Console.WriteLine(d);
            }
        }

        // Rekursive Funktion die die Ordnerinformationen abruft
        static void Search(String pfad, List<DirInfo> dirs)
        {
            String[] dateiPfade = null;
            String[] ordnerPfade = null;
            int dateiAnzahl = 0;
            bool zugriff = false;
            if (CanAccessFolder(pfad)) zugriff = true;
            if (zugriff)
            {
                dateiPfade = Directory.GetFiles(pfad);
                ordnerPfade = Directory.GetDirectories(pfad);
                dateiAnzahl = dateiPfade.Length;
            }
            dirs.Add(new DirInfo()
            {
                OrdnerAnzahlDateien = dateiAnzahl,
                OrdnerErstelldatum = Directory.GetCreationTime(pfad).ToShortDateString(),
                OrdnerName = Path.GetDirectoryName(pfad),
                OrdnerPfad = pfad
            });
            foreach (String ordnerPfad in ordnerPfade)
            {
                if (CanAccessFolder(ordnerPfad) && ordnerPfad != null)
                {
                    Search(ordnerPfad, dirs);
                }
                else
                {
                    dirs.Add(new DirInfo()
                    {
                        OrdnerAnzahlDateien = 0,
                        OrdnerErstelldatum = Directory.GetCreationTime(ordnerPfad).ToShortDateString(),
                        OrdnerName = Path.GetDirectoryName(ordnerPfad),
                        OrdnerPfad = ordnerPfad
                    });
                }
            }
        }

        static bool CanAccessFolder(string folderPath)
        {
            try
            {
                Directory.GetDirectories(folderPath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false; // Zugriff verweigert
            }
            catch (IOException)
            {
                return false; // Anderer I/O Fehler
            }
        }
    }
}
