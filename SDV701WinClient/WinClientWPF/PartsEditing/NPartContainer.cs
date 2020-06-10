using SDV701common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WinClientWPF
{
    public abstract class NPartContainer : UserControl
    {
        NPart _part;
        public NPartContainer(NPart part)
        {
            _part = part;
            DataContext = _part;
        }
    }
}
