using SDV701common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WinClientWPF.Models;

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
