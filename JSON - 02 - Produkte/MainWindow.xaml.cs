using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using JSON___02___Produkte.Klassen;

namespace JSON___02___Produkte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String[] kategorienStrings;
        public String[][] produkteStrings;
        public String[][] preisStrings;

        public MainWindow()
        {
            InitializeComponent();
            String jsonPath = "D:\\Produkte.json";
            String jsonString = File.ReadAllText(jsonPath);
            Category[] kategorien = JsonSerializer.Deserialize<Category[]>(jsonString);

            int anzKat = kategorien.Length;
            int anzProd;

            kategorienStrings = new string[anzKat];
            produkteStrings = new string[anzKat][];
            preisStrings = new string[anzKat][];

            // String-Arrays erzeugen
            for (int i=0; i< anzKat; i++)
            {
                kategorienStrings[i] = kategorien[i].CategoryName;
                anzProd = kategorien[i].Products.Count;
                produkteStrings[i] = new string[anzProd];
                preisStrings[i] = new string[anzProd];
                for (int k=0; k< anzProd; k++)
                {
                    produkteStrings[i][k] = kategorien[i].Products[k].Name;
                    preisStrings[i][k] = kategorien[i].Products[k].Price.ToString() + " €";
                }
            }


            comboBoxKategorie.ItemsSource = kategorienStrings;
            comboBoxKategorie.SelectedIndex = 0;
            //ProdukteAnzeigen(0);
            //NameUndPreisAnzeigen(0, 0);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void KategorieWahl(object sender, SelectionChangedEventArgs e)
        {
            ProdukteAnzeigen(comboBoxKategorie.SelectedIndex);
        }

        private void ProdukteAnzeigen(int kategorieIndex)
        {
            listBoxProdukte.ItemsSource = produkteStrings[kategorieIndex];
            listBoxProdukte.SelectedIndex = 0;
            textBoxProduktname.Text = produkteStrings[kategorieIndex][0];
            textBoxPreis.Text = preisStrings[kategorieIndex][0];
            NameUndPreisAnzeigen(kategorieIndex, 0);
        }

        private void Produktwahl(object sender, SelectionChangedEventArgs e)
        {
            NameUndPreisAnzeigen(comboBoxKategorie.SelectedIndex, listBoxProdukte.SelectedIndex);
        }

        private void NameUndPreisAnzeigen(int kategorieIndex, int produktIndex)
        {
            textBoxProduktname.Text = produkteStrings[kategorieIndex][produktIndex];
            textBoxPreis.Text = preisStrings[kategorieIndex][produktIndex];

        }
    }
}