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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        MainWindow mainWindow;
        TicketOverview ticketOverview;

        public Menu()
        {
            InitializeComponent();
            this.mainWindow = new MainWindow();
            this.ticketOverview = new TicketOverview();
        }

        private void btn_selectflight_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Show();
            this.Close();
        }

        private void btn_viewflights_Click(object sender, RoutedEventArgs e)
        {

            this.ticketOverview.Show();
            this.Close();
        }
    }
}
