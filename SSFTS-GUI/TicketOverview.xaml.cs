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
using System.Windows.Shapes;

namespace SSFTS_GUI
{
    /// <summary>
    /// Interaction logic for TicketOverview.xaml
    /// </summary>
    public partial class TicketOverview : Window {
        filehandler fh;

        public TicketOverview()
        {
            InitializeComponent();
        }

        public void fillList() {
            
            if (!fh.load()) {
                return;
            }
            foreach (Flight flight in fh.TicketList) {
                Airport sAirport = flight.From;
                Airport dAirport = flight.To;
                lb_tickets.Items.Add(sAirport.IATA + " - " + dAirport.IATA);
            }
            lb_tickets.EndInit();
        }

        private void lb_tickets_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            int selection = int.Parse(lb_tickets.SelectedItem.ToString());
            Flight flight = fh.TicketList[selection];
            Airplane airplane = flight.Airplane;
            l_flight.Content = flight.FlightNumber;
            l_from.Content = flight.From;
            l_to.Content = flight.To;
            l_airplane.Content = airplane.Code;
        }
    }
}
