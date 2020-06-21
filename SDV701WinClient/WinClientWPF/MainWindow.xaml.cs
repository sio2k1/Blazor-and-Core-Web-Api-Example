/*
 * Author: Oleg Sivers
 * Date: 03.06.2020
 * Desc: Main window
*/
using System.Windows;

namespace WinClientWPF
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            Categories c = new Categories();
            await c.Init();
            c.Show();
        }

        private async void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders o = new Orders();
            await o.Init();
            o.ShowDialog();
        }
    }
}
