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
    public partial class PartsWired : NPartContainer
    {


        public PartsWired(NPart part) : base(part)
        {
            InitializeComponent();

           // _part = part;
           // DataContext = _part;
        }
        /*
        public bool isDataValid()
        {
            return tbEthernetPortType.Text.All(char.IsDigit); // if port number is integer;
        }

        public void UpdateContainerWithNPartValues(NPart part)
        {
            NWiredPart p = (part as NWiredPart);
            tbEthernetPortNumber.Text = p.NumberOfPorts;
            tbEthernetPortType.Text = p.EthernetPortType;
        }

        public NPart UpdateNPartWithContainerValues(NPart part)
        {
            NWiredPart p = (part as NWiredPart);
            p.NumberOfPorts= tbEthernetPortNumber.Text;
            p.EthernetPortType= tbEthernetPortType.Text;
            return p;
        }*/
    }
}
