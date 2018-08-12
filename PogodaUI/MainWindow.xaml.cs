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
using System.Net.Http;
using System.Net;
using System.Xml.Linq;

namespace PogodaUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            string url = "https://xml.meteoservice.ru/export/gismeteo/point/1072.xml";
            
            WebClient webclient = new WebClient();
            string output = "";
            string xmlData = webclient.DownloadString(url);
            var xmlCollect = XDocument.Parse(xmlData)
                .Descendants("MMWEATHER")
                .Descendants("REPORT")
                .Descendants("TOWN")
                .Descendants("FORECAST")
                .Descendants("TEMPERATURE").ToArray();

            foreach(var e in xmlCollect)
            {
                output += e.Attribute("max").Value.ToString() + " ";
            }
            Pogoda.Text = output;
        }
    }
}
