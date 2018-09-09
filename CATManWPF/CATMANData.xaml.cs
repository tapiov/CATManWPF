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
using System.Collections.ObjectModel;
using System.Threading;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using Windows.Devices.Enumeration;

namespace CATMANWPF
{
    /// <summary>
    /// Interaction logic for CATMANData.xaml
    /// </summary>
    public partial class CATMANData : Page
    {
        public CATMANData()
        {
            InitializeComponent();
        }

        // Custom constructor to pass expense report data
        public CATMANData(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }
    }
}
