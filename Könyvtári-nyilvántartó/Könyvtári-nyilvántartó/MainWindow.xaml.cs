using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Könyvtári_nyilvántartó
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Adatok> l = new List<Adatok>();
        List<Ja2> l2 = new List<Ja2>();
        List<Ja3> l3 = new List<Ja3>();
        public MainWindow()
        {
            InitializeComponent();
        }

        class Adatok
        {
            public int id { get; set; }
            public string szerzo { get; set; }
            public string cim { get; set; }
            public string ev { get; set; }
            public string kiado { get; set; }
            public bool ig { get; set; }
            public Adatok(string sor)
            {
                string[] resz = sor.Split(';');
                id = Convert.ToInt32(resz[0]);
                szerzo = resz[1];
                cim = resz[2];
                ev = resz[3];
                kiado = resz[4];
                ig = Convert.ToBoolean(resz[5]);

            }
        }

        class Ja2
        {
            public int olvasid { get; set; }
            public string nev { get; set; }
            public DateTime szul { get; set; }
            public int szam { get; set; }
            public string telepules { get; set; }
            public string utca { get; set; }
            public Ja2(string sor)
            {
                string[] resz = sor.Split(';');
                olvasid = Convert.ToInt32(resz[0]);
                nev = resz[1];
                szul = Convert.ToDateTime(resz[2]);
                szam = Convert.ToInt32(resz[3]);
                telepules = resz[4];
                utca = resz[5];


            }
        }

        class Ja3
        {
            public int kolcsonid { get; set; }
            public int olvasid { get; set; }
            public int konyvid { get; set; }
            public DateTime koldatum { get; set; }
            public DateTime visszdatum { get; set; }
            public Ja3(string sor)
            {
                string[] resz = sor.Split(';');
                kolcsonid = Convert.ToInt32(resz[0]);
                olvasid = Convert.ToInt32(resz[1]);
                konyvid = Convert.ToInt32(resz[2]);
                koldatum = Convert.ToDateTime(resz[3]);
                visszdatum = Convert.ToDateTime(resz[3]);
            }
        }


        private void Konyvek_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("konyvek.txt"))
            {
                l.Add(new Adatok(item));
            }
            Konyv.ItemsSource = l;

            Konyv.AutoGenerateColumns = false;
        }

        private void Tagok_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("tagok.txt"))
            {
                l2.Add(new Ja2(item));


            }
            Tag.ItemsSource = l2;
            Tag.AutoGenerateColumns = false;
        }

        private void Kolcsonzes_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("kolcsonzesek.txt"))
            {
                l3.Add(new Ja3(item));
            }
            Kolcson.ItemsSource = l3;
            Kolcson.AutoGenerateColumns = false;
        }
    }
}
