using grpcCalls;
using SDV701common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {
        public Categories()
        {
            InitializeComponent();
        }

        public async Task Init()
        {
            try
            {
                List<Category> lst = await gRPCClient.GetListOfCategories();
                lst.ForEach(item =>
                {
                    lbxCategories.Items.Add(item);
                });
            } catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().Message);
            }
        }

        private async void lbxCategories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxCategories.SelectedItem != null)
            {
                CategoryEditing ce = new CategoryEditing(lbxCategories.SelectedItem as Category);
                await ce.Init();
                ce.ShowDialog();
                lbxCategories.Items.Refresh();
            }
            else
                MessageBox.Show("Nothing selected");
            //lbxCategories.DrawMode = DrawMode.Normal;

            //List<NPart> lst = await gRPCClient.GetListOfPartsByCategoryId<NPart>((lbxCategories.SelectedItem as Category).CategoryId);
            //MessageBox.Show("Edit");

        }

        private void lbxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbDescription.Text = (lbxCategories.SelectedItem as Category).Description;
        }
    }
}
