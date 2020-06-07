using SDV701common;
using System;
using System.Collections.Generic;
using System.Linq;
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
using WinClientWPF.PartsEditing;

namespace WinClientWPF
{
    /// <summary>
    /// Interaction logic for PartsWired.xaml
    /// </summary>
    public partial class PartsWireless : NPartContainer
    {
        public PartsWireless(NPart part) : base(part)
        {
            InitializeComponent();
        }
        /*
        public bool isDataValid()
        {
            return true;
            //return tbEthernetPortType.Text.All(char.IsDigit); // if port number is integer;
        }

        public void UpdateContainerWithNPartValues(NPart part)
        {
            NWirelesspart p = (part as NWirelesspart);
            tbWiFiStandard.Text = p.WiFiStandard;
        }

        public NPart UpdateNPartWithContainerValues(NPart part)
        {
            NWirelesspart p = (part as NWirelesspart);
            p.WiFiStandard = tbWiFiStandard.Text;
            return p;
        }*/
    }
}
