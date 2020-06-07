using grpcCalls;
using SDV701common;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
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

namespace WinClientWPF
{
    /// <summary>
    /// Interaction logic for CategoryEditing.xaml
    /// </summary>
    public partial class CategoryEditing : Editing
    {
        private Category cat;
        public CategoryEditing(Category ctg)
        {
            InitializeComponent();
            cat = ctg;
            InitEditing(cat, typeof(Category), null, typeof(NPart));
            tbxCategoryName.Text = cat.Categoryname;
            tbxCategoryDescription.Text = cat.Description;
            DataContext = cat;
        }

        public async Task refreshList()
        {
            lbxParts.Items.Clear();
            try
            {
                List<NPart> lst = await gRPCClient.GetListOfPartsByCategoryId<NPart>(cat.id);
                lst.ForEach(item =>
                {
                    lbxParts.Items.Add(item);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().Message);
            }
        }
        public async Task Init()
        {
            await refreshList();

            var createMenuItem = new MenuItem { Header = "Create" };
            List<Type> types = new List<Type> { typeof(NWiredPart), typeof(NWiredWirelesspart), typeof(NWirelesspart) };
            types.ForEach(tp => {
                var item = new MenuItem { Header = tp.Name, Tag = tp };
                item.Click += menuCreate_Click;
                createMenuItem.Items.Add(item);

            });
            
            lbxParts.ContextMenu.Items.Insert(0, createMenuItem);
        }
        private async void menuDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (lbxParts.SelectedItem != null)
            {
                try { 
                    
                    if (MessageBox.Show($"Delete {lbxParts.SelectedItem.ToString()}", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Type t = lbxParts.SelectedItem.GetType();
                        await delete(lbxParts.SelectedItem, t);
                        await refreshList();
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().Message);
                }
            }
            else
                MessageBox.Show("Nothing selected");
            
        }

        private async void menuEdit_Click(object sender, RoutedEventArgs e)
        {
            await openEdit();
        }

        private async void menuCreate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem)
            {
                try
                {
                    if ((sender as MenuItem).Tag is Type)
                    {
                        Type t = (sender as MenuItem).Tag as Type;
                        NPart newPart = (NPart)Activator.CreateInstance(t);
                        newPart.ClassName = ((sender as MenuItem).Tag as Type).FullName;
                        newPart.Name = "New item";
                        newPart.LastModified = DateTime.Now;
                        newPart.Currency = "NZD";
                        newPart.CategoryID = cat.id;
                        await insert(newPart, t);
                        await refreshList();
                    }
                    else
                        throw new Exception("Internal error, no type of object was provided.");
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().Message);
                }
            }
        }



        /*protected override async Task save()
        {
            await update();
        }*/

        private async Task openEdit()
        {
            if (lbxParts.SelectedItem != null)
            {
                BaseParts bp = new BaseParts(lbxParts.SelectedItem as NPart);
                await bp.Init();
                bp.ShowDialog();
                if ((lbxParts.SelectedItem as NPart).CategoryID != cat.id)
                    lbxParts.Items.Remove(lbxParts.SelectedItem);
                lbxParts.Items.Refresh();
            }
            else
                MessageBox.Show("Nothing selected");
        }

        private async void lbxParts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            await openEdit();
        }

        private void lbxParts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            await refreshList();
        }
    }

        
}
