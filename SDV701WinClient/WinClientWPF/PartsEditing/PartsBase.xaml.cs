using grpcCalls;
using SDV701common;
using System;
using System.CodeDom;
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
using WinClientWPF.PartsEditing;
using WinClientWPF.utils;

namespace WinClientWPF
{
    /// <summary>
    /// Interaction logic for BaseParts.xaml
    /// </summary>
    public partial class BaseParts : Editing
    {
        private NPart part;

        public class SubItem
        {
            public Type itemType { get; set; }
            public Type TPHtype { get; set; }

            public Type DisplayComponent { get; set; }

        }
        public BaseParts(NPart prt)
        {
            InitializeComponent();
            part = prt;
            DataContext = part;

            List<SubItem> lst = new List<SubItem> {
                new SubItem { itemType= typeof(NWiredPart), DisplayComponent = typeof(PartsWired),TPHtype = typeof(NPart) } ,
                new SubItem { itemType= typeof(NWiredWirelesspart),DisplayComponent = typeof(PartsWiredWireless) ,TPHtype = typeof(NPart) } ,
                new SubItem { itemType= typeof(NWirelesspart), DisplayComponent = typeof(PartsWireless), TPHtype = typeof(NPart) }
            };
            bool found = false;
            lst.ForEach(item => {              
                if (prt.GetType().Name==item.itemType.Name)
                {
                    found = true;
                    InitEditing(part, item.itemType, item.TPHtype);
                    try
                    {
                        NPartContainer container = (NPartContainer)Activator.CreateInstance(item.DisplayComponent, new object[] { part });
                        extraSpecs.Content = container;
                    } catch(Exception e)
                    {
                        MessageBox.Show($"Cannot create instance of {item.DisplayComponent.Name} Erorr:{e.GetBaseException().Message}");
                    }
                }
            });
            if (!found)
            {
                MessageBox.Show($"Type: {prt.GetType().Name} not handled in BaseParts constructor.");
            }

           /* NPartContainer container = null;
            switch (prt.GetType().Name)
            {             
                case "NWiredPart":
                    InitEditing(part, typeof(NWiredPart), typeof(NPart));
                    container = new PartsWired(part);
                    //Activator.CreateInstance()
                    extraSpecs.Content = container;
                    break;
                case "NWiredWirelesspart":
                    InitEditing(part, typeof(NWiredWirelesspart), typeof(NPart));
                    container = new PartsWiredWireless(part);
                    extraSpecs.Content = container;
                    break;
                case "NWirelesspart":
                    InitEditing(part, typeof(NWirelesspart), typeof(NPart));
                    container = new PartsWireless(part);
                    extraSpecs.Content = container;
                    break;
                default:
                    MessageBox.Show($"Type: {prt.GetType().Name} not handled in BaseParts constructor.");
                    break;
            }*/
        }

        public async Task Init()
        {
            try
            {
                List<Category> lst = await gRPCClient.GetListOfCategories();
                lst.ForEach(item =>
                {
                    CategoryID.Items.Add(item);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().Message);
            }
        }

        protected override async Task<int> save()
        {
            part.LastModified = DateTime.Now;
            int rows = await update();
            tbxLastModified.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            return rows;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*try 
            {
                ModelToWPFMapper.SetModelValuesBasedOnComboBoxes(part, mainGrid);
                ModelToWPFMapper.SetModelValuesBasedOnTextBoxes(part, mainGrid);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("dd");*/
        }


    }
}
