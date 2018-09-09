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
using System.IO.Ports;

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
        private ObservableCollection<string> listOfNames;
        //private string[] listOfNames;
        private CancellationTokenSource ReadCancellationTokenSource;

        public CATMANHome()
        {
            this.InitializeComponent();
            connectButton.IsEnabled = false;
            disconnectButton.IsEnabled = false;
            listOfDevices = new ObservableCollection<DeviceInformation>();
            listOfNames = new ObservableCollection<string>();
            // listOfNames = new string[12];
            ListAvailablePorts();
        }

        /// <summary>
        /// connectButton_Click: Action to take when 'Connect' button is clicked
        /// - Get the selected device index and use Id to create the SerialDevice object
        /// - Configure default settings for the serial port
        /// - Create the ReadCancellationTokenSource token
        /// - Start listening on the serial port input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            // View Device Data page
            CATMANData CATMANdataPage = new CATMANData(this.DeviceListSource.SelectedItem);
            this.NavigationService.Navigate(CATMANdataPage);
        }

        /// <summary>
        /// disconnectButton_Click: Action to take when 'Disconnect' button is clicked on
        /// - Cancel all read operations
        /// - Close and dispose the SerialDevice object
        /// - Enumerate connected devices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            // View Device Data page
            CATMANData CATMANdataPage = new CATMANData(this.DeviceListSource.SelectedItem);
            this.NavigationService.Navigate(CATMANdataPage);
        }

        /// <summary>
        /// ListAvailablePorts
        /// - Use SerialDevice.GetDeviceSelector to enumerate all serial devices
        /// - Attaches the DeviceInformation to the ListBox source so that DeviceIds are displayed
        /// </summary>
        private async void ListAvailablePorts()
        {
            try
            {
                string aqs = SerialDevice.GetDeviceSelector();
                var dis = await DeviceInformation.FindAllAsync(aqs);
   
                status.Text = "Select a device and click \"Connect\"";

                for (int i = 0; i < dis.Count; i++)
                // for (int i = 0; i < dis.Count; i++)
                    {
                    // listOfDevices.Add(dis[i]);
                    listOfNames.Add(dis[i].Name);
                    // listOfNames.Add("List " + i.ToString());
                    // listOfNames[i] = "List " + i.ToString();
                }

                // DeviceListSource.ItemsSource = listOfDevices;
                DeviceListSource.ItemsSource = listOfNames;
                // DeviceListSource = listOfNames;
                connectButton.IsEnabled = true;
                DeviceListSource.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                status.Text = ex.Message;
            }
        }

    }
}
