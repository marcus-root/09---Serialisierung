namespace JSON___01___Verzeichnisinformationen
{
    internal class DirInfo
    {
        public String OrdnerName { get; set; }
        public String OrdnerPfad { get; set; }
        public String OrdnerErstelldatum { get; set; }
        public int OrdnerAnzahlDateien { get; set; }

        public override String ToString()
        {
            return $"{OrdnerPfad}\nErstelldatum: {OrdnerErstelldatum}, Dateien: {OrdnerAnzahlDateien}";
        }



    }

    
    }
