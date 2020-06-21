/*
 * Author: Oleg Sivers
 * Date: 03.06.2020
 * Desc: Represents a user control, which contains a part
*/
using SDV701common;
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
