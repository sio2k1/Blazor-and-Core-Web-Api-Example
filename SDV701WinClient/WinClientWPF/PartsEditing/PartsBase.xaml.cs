/*
 * Author: Oleg Sivers
 * Date: 03.06.2020
 * Desc: Parent window for editing all types of parts 
*/
using grpcCalls;
using SDV701common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WinClientWPF
{
    /// <summary>
    /// Interaction logic for BaseParts.xaml
    /// </summary>
    public class SubItem
    {
        public Type itemType { get; set; }
        public Type TPHtype { get; set; }
        public Type DisplayComponent { get; set; }

    }
    public partial class BaseParts : Editing
    {
        private NPart part;

        public BaseParts(NPart prt)
        {
            InitializeComponent();
            part = prt;
            DataContext = part;

            List<SubItem> lst = new List<SubItem> {
                new SubItem { itemType= typeof(NWiredPart), DisplayComponent = typeof(PartsWired), TPHtype = typeof(NPart) } ,
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
    }
}
