/*
 * Author: Oleg Sivers
 * Date: 03.06.2020
 * Desc: Window for displaying orders
*/
using grpcCalls;
using SDV701common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WinClientWPF
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        List<ClientOrder> orderlist = new List<ClientOrder>();
        public Orders()
        {
            InitializeComponent();
        }
        public async Task Init()
        {
            orderlist = await gRPCClient.GetListOfOrders();
            GridOrders.ItemsSource = orderlist;
            recalcSum();
        }

        public void recalcSum()
        {
            string currency = orderlist.Count > 0 ? orderlist.First().Currency : "";
            lblTotal.Content = $"{orderlist.Sum(x => x.Summ)} {currency}";
        }

        private async void menuDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (GridOrders.SelectedItem != null)
            {
                try
                {

                    if (MessageBox.Show($"Delete {GridOrders.SelectedItem.ToString()}", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Type t = GridOrders.SelectedItem.GetType();
                        int res = await gRPCClient.Delete(GridOrders.SelectedItem, t);
                        if (res == 1)
                        {
                            orderlist.Remove(GridOrders.SelectedItem as ClientOrder);
                            GridOrders.Items.Refresh();
                            recalcSum();
                        }
                        else
                        {
                            await Init();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().Message);
                }
            }
            else
                MessageBox.Show("Nothing selected");

        }
    }
}
