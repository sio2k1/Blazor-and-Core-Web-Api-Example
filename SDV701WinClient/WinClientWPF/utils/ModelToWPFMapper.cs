using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WinClientWPF.utils
{
   /* public class cbxItem
    {
        public int id { get; set; }
        public object obj { get; set; }
        public override string ToString()
        {
            return obj.ToString();
        }
    }

    public static class ModelToWPFMapper
    {


        private static List<T> GetElementsInGrid<T>(Grid grd)
        {
            return grd.Children.OfType<T>().ToList();
        }
        public static void SetComboBoxesBasedOnModel(object model, Grid grd)
        {
            List<ComboBox> tbl = GetElementsInGrid<ComboBox>(grd);
            Type type = model.GetType();
            tbl.ForEach(item => {
                foreach (var prop in type.GetProperties())
                {
                    if (item.Name == prop.Name)
                    {
                        try
                        {
                            int id = (int)prop.GetValue(model);
                            cbxItem selected = item.Items.OfType<cbxItem>().ToList().Find(x => x.id == id);
                            item.SelectedItem = selected;
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Can't set {item.Name}, value is not supported: {e.GetBaseException().Message}");
                        }
                    }
                }
            });
        }
        public static void SetModelValuesBasedOnComboBoxes(object model, Grid grd)
        {
            List<ComboBox> tbl = GetElementsInGrid<ComboBox>(grd);
            Type type = model.GetType();
            tbl.ForEach(item => {
                foreach (var prop in type.GetProperties())
                {
                    if (item.Name == prop.Name)
                    {
                        try
                        {
                            prop.SetValue(model, (item.SelectedItem as cbxItem).id);
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Can't set {item.Name}, value is not supported: {e.GetBaseException().Message}");
                        }
                    }
                }
            });
        }

        public static void SetModelValuesBasedOnTextBoxes(object model, Grid grd)
        {
            List<TextBox> tbl = GetElementsInGrid<TextBox>(grd);
            Type type = model.GetType();
            tbl.ForEach(item => {
                foreach (var prop in type.GetProperties())
                {
                    if (item.Name == prop.Name)
                    {
                        try
                        {
                            if (prop.PropertyType == typeof(float))
                            {
                                prop.SetValue(model, float.Parse(item.Text));
                            }
                            else
                            if (prop.PropertyType == typeof(int))
                            {
                                prop.SetValue(model, int.Parse(item.Text));
                            }
                            else
                            if (prop.PropertyType == typeof(string))
                            {
                                prop.SetValue(model, item.Text);
                            }
                            else
                            if (prop.PropertyType == typeof(DateTime))
                            {
                                prop.SetValue(model, DateTime.Parse(item.Text));
                            }
                            else
                                throw new Exception($"Type {prop.PropertyType} is not supported by mapper.");

                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Can't set {item.Name}, value is not supported: {e.GetBaseException().Message}");
                        }
                    }
                }
            });
        }

        public static void SetTextBoxesBasedOnModel(object model, Grid grd)
        {
            List<TextBox> tbl = GetElementsInGrid<TextBox>(grd);
            Type type = model.GetType();
            tbl.ForEach(item => {
                foreach (var prop in type.GetProperties())
                {
                    if (item.Name == prop.Name)
                    {
                        try
                        {
                            item.Text = prop.GetValue(model).ToString();
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Can't set {item.Name}, value is not supported: {e.GetBaseException().Message}");
                        }
                    }
                }
            });
        }
    }*/
}
