using grpcCalls;
using Newtonsoft.Json;
using SDV701common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinClientWPF
{
    public abstract class Editing : Window
    {
        protected object _obj;
        protected string originalSerializedObj;
        private Type _objType;
        private Type _TPHType;
        private Type _TPHTypeDeleteInsert; // rather a table name of superclass
        public void InitEditing(object obj, Type objType, Type TPHType = null, Type TPHTypeDeleteInsert = null) //specify superclass for TPH in TPHType
        {
            _obj = obj;
            _objType = objType;
            _TPHType = TPHType;
            _TPHTypeDeleteInsert = TPHTypeDeleteInsert;
            originalSerializedObj = JsonConvert.SerializeObject(_obj);
        }

        private bool hasChanges()
        {

            return JsonConvert.SerializeObject(_obj) == originalSerializedObj ? false : true; 
        }

        private void rollbackObj() // returning object to its original state b4 editing.
        {

            var original = JsonConvert.DeserializeObject(originalSerializedObj, _objType);
            foreach (var prop in _objType.GetProperties())
            {
                prop.SetValue(_obj, prop.GetValue(original));
            }
            //return JsonConvert.SerializeObject(_obj) == originalSerializedObj ? false : true;
        }

        protected virtual Task<int> save() 
        {
            return update();
        }
        protected async void Editing_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanges())
            {
                MessageBoxResult result = MessageBox.Show("This window has unsaved changes, save?", "Warning", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    string validationResult = "";
                    if (_obj is Model) // we have to provide Model based object for validation, same happends on server.
                    {
                        validationResult = (_obj as Model).IsValid(); // client validation, same happen on server 
                    }
                    if (validationResult != "") 
                    {
                        e.Cancel = true;
                        MessageBox.Show($"Validation error: {validationResult}");
                    }
                    else
                    {
                        int rows = await save(); // if rows == 0 it means object was not updated
                        if (rows == 0)
                        {
                            MessageBox.Show($"Record is not existing in database. Try to refresh a list.");
                            rollbackObj();
                        }
                    }
                }
                if (result == MessageBoxResult.No)
                {
                    rollbackObj();
                }
                if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        protected async Task<int> update()
        {
            int i = 0;
            try
            {
                i = await gRPCClient.Update(_obj, _objType, _TPHType);
            } catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().Message);
            }
            return i;
        }
        protected async Task<int> delete(object o, Type oType) // use to delete another object, we need to specify another TPHTypeDelete, as we will be in previous editing window in most of cases which wont handle TPH itself.
        {
            int i = 0;
            try
            {
                i = await gRPCClient.Delete(o, oType, _TPHTypeDeleteInsert);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().Message);
            }
            return i;
        }
        protected async Task<int> insert(object o, Type oType) // use to insert another object, we need to specify another TPHTypeDelete, as we will be in previous editing window in most of cases which wont handle TPH itself.
        {
            int i = 0;
            try
            {
                i = await gRPCClient.Insert(o, oType, _TPHTypeDeleteInsert);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().Message);
            }
            return i;
        }
        protected async Task<int> delete()
        {
            int i = 0;
            try
            {
                i = await gRPCClient.Delete(_obj, _objType, _TPHType);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().Message);
            }
            return i;
        }
    }
}
