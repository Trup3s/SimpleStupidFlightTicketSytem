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
    /// Interaction logic for TicketPreview.xaml
    /// </summary>
    public partial class TicketPreview : Window
    {
        MainWindow mainWindow;

        public TicketPreview()
        {
            InitializeComponent();
            this.mainWindow = new MainWindow();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Show();
            this.Close();
        }
    }
}
