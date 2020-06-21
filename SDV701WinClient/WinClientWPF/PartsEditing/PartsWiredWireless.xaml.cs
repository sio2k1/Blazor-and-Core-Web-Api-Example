/*
 * Author: Oleg Sivers
 * Date: 03.06.2020
 * Desc: Represents a user control layout for mixed parts
*/
using SDV701common;

namespace WinClientWPF
{
    public partial class PartsWiredWireless : NPartContainer
    {

        public PartsWiredWireless(NPart part) : base(part)
        {
            InitializeComponent();
        }
    }
}
