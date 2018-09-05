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

using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using Windows.Devices.Enumeration;
using System.Collections.ObjectModel;
using System.Threading;

namespace CATMANWPF
{
    /// <summary>
    /// Interaction logic for CATManHome.xaml
    /// </summary>
    public partial class CATMANHome : Page
    {
        /// <summary>
        /// Private variables
        /// </summary>
        private SerialDevice serialPort = null;
        DataWriter dataWriteObject = null;
        DataReader dataReaderObject = null;

        bool readFlag = false;
        bool writeFlag = false;

        private ObservableCollection<DeviceInformation> listOfDevices;
        private CancellationTokenSource ReadCancellationTokenSource;

        public CATMANHome()
        {
            //this.InitializeComponent();
            connectButton.IsEnabled = false;
            disconnectButton.IsEnabled = false;
            // listOfDevices = new ObservableCollection<DeviceInformation>();
            // ListAvailablePorts();
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            // View Device Data page
            CATMANDataPage CATMANdataPage = new CATMANDataPage(this.connectDevices.SelectedItem);
            this.NavigationService.Navigate(CATMANdataPage);
        }

        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            // View Device Data page
            CATMANDataPage CATMANdataPage = new CATMANDataPage(this.connectDevices.SelectedItem);
            this.NavigationService.Navigate(CATMANdataPage);
        }


     }
}
