/*
 * Author: Oleg Sivers
 * Date: 03.06.2020
 * Desc: Represents a user control layout for Wired parts
*/
using SDV701common;

namespace WinClientWPF
{
    public partial class PartsWired : NPartContainer
    {
        public PartsWired(NPart part) : base(part)
        {
            InitializeComponent();
        }
    }
}
