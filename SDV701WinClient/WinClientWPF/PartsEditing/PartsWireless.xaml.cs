/*
 * Author: Oleg Sivers
 * Date: 03.06.2020
 * Desc: Represents a user control layout for Wireless parts
*/
using SDV701common;

namespace WinClientWPF
{
    public partial class PartsWireless : NPartContainer
    {
        public PartsWireless(NPart part) : base(part)
        {
            InitializeComponent();
        }
    }
}
