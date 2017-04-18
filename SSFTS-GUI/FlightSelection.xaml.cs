using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SSFTS_GUI {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        ObservableCollection<Country> countries;
        ObservableCollection<Airline> airlines;
        public MainWindow() {
            new Thread(this.LoadFleets).Start();
            InitializeComponent();
            LoadCountries();
            LoadAirlines();
            LoadAirports(this.countries[0]);
            InitComboBoxes();
        }

        private void LoadAirlines() => this.airlines = new ObservableCollection<Airline>(PythonHandler.GetAirlines());
        private void LoadFleets() {
            this.Dispatcher.Invoke(() => {
                this.cb_airline.IsEnabled = false;
                this.cb_airline.Items.Add(new ComboBoxItem());
                this.cb_airline.SelectedIndex = 0;
                (this.cb_airline.SelectedItem as ComboBoxItem).Content = "Loading...";
            });
                foreach (Airline airline in this.airlines) {
                    airline.Fleet = PythonHandler.GetFleet(airline);
                }
            this.Dispatcher.Invoke(() => {
                this.cb_airline.SelectionChanged += this.Cb_airline_SelectionChanged;
                this.cb_airline.IsEnabled = true;
            });
        }

        private void LoadCountries() => this.countries = new ObservableCollection<Country>(PythonHandler.GetCountries());
        private void LoadAirports(Country country) => country.Airports = country.Airports ?? PythonHandler.GetAirports(country);

        private ComboBox GetAirportBox(ComboBox countrybox) => (countrybox == this.cb_from_country) ? this.cb_from_airport : this.cb_to_airport;
        private ComboBox GetCountryBox(ComboBox airportbox) => (airportbox == this.cb_from_airport) ? this.cb_from_country : this.cb_to_country;
        private Image GetCountryImage(ComboBox countrybox) => (countrybox == this.cb_from_country) ? this.img_from_country : this.img_to_country; 

        private ObservableCollection<Airline> GetPossibleAirlines() {
            ObservableCollection<Airline> collection = new ObservableCollection<Airline>();
            foreach (Airline airline in this.airlines) {

            }
            return collection;
        }

        private void InitComboBoxes() {
            List<ComboBox> countryboxes = new List<ComboBox>() { this.cb_from_country, this.cb_to_country };
            List<ComboBox> airportboxes = new List<ComboBox>() { this.cb_from_airport, this.cb_to_airport };

            foreach (ComboBox countrybox in countryboxes) {
                countrybox.ItemsSource = this.countries;
                countrybox.DisplayMemberPath = "Name";
                countrybox.SelectionChanged += this.Countrybox_SelectionChanged;
                countrybox.SelectedIndex = 0;
                GetCountryImage(countrybox).Source =  new BitmapImage((countrybox.SelectedItem as Country).Image);
            }
            foreach (ComboBox airportbox in airportboxes) {
                airportbox.ItemsSource = this.countries[0].Airports;
                airportbox.DisplayMemberPath = "Name";
                airportbox.SelectedIndex = 0;
            }


        }

        private void Cb_airline_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void Countrybox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBox countrybox = (sender as ComboBox);
            ComboBox airportbox = GetAirportBox(countrybox);
            Country country = (countrybox.SelectedItem as Country);

            GetCountryImage(countrybox).Source =  new BitmapImage(country.Image);

            LoadAirports(country);           
            airportbox.ItemsSource = new ObservableCollection<Airport>(country.Airports);
            airportbox.SelectedIndex = 0;
        }
    }
}
