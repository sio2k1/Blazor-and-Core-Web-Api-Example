/*
 * Author: Oleg Sivers
 * Date: 01.06.2020
 * Desc: Models and validation
*/
using System;
using System.Linq;

namespace SDV701common
{
    public abstract class Model
    {
        public virtual string IsValid()
        {
            string res = "";
            var props = this.GetType().GetProperties();
            props.ToList().FindAll(x => x.PropertyType == typeof(string)).ForEach(p => {
                object o = p.GetValue(this);
                if (o != null)
                {
                    var val = p.GetValue(this).ToString();
                    if (val.Length > 255) res += $"Field length should be less than 255 chars: {p.Name}. ";
                }
            });       
            return res;
        }
    }
    public abstract class NPart : Model
    {
        public int id { get; set; } = -1;
        public string Name { get; set; }
        public string ClassName { get; set; }
        public float Price { get; set; }
        public string  Currency { get; set; }
        public int QtyInStock { get; set; }
        public int CategoryID { get; set; }

        public DateTime LastModified { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public NPart()
        {
            ClassName = this.GetType().FullName;
        }

        public override string IsValid()
        {
            string res = base.IsValid();
            if (string.IsNullOrEmpty(Currency)) res += "Currency can't be null or empty. ";
            if (string.IsNullOrEmpty(ClassName)) res += "ClassName can't be null or empty. ";
            if (QtyInStock < 0) res += "QtyInStock should be positive. ";
            if (CategoryID == 0) res += "CategoryID should be set. ";
            if (Price < 0) res += "QtyInStock should be positive. ";
            return res;
        }

        public virtual string ReturnOODetails()
        {
            return "";
        }
    }
    public class NEmptyPart : NPart
    {

    }
    public class NWirelesspart : NPart
    {
        public string WiFiStandard { get; set; }
        public override string IsValid()
        {
            return base.IsValid();
        }
        public override string ReturnOODetails()
        {
            return $"Wi-Fi Standard: {WiFiStandard}";
        }
    }

    public class NWiredPart : NPart
    {
        public string EthernetPortType { get; set; }
        public int NumberOfPorts { get; set; }
        public override string IsValid()
        {
            string res = base.IsValid();
            if (NumberOfPorts < 0) res += "NumberOfPorts should be positive. ";
            return res;
        }
        public override string ReturnOODetails()
        {
            return $"Number of ports: {NumberOfPorts}\r\nEthernet port type: {EthernetPortType}";
        }
    }

    public class NWiredWirelesspart : NPart
    {
        public string WiFiStandard { get; set; }
        public string EthernetPortType { get; set; }
        public int NumberOfPorts { get; set; }
        public override string IsValid()
        {
            string res = base.IsValid();
            if (NumberOfPorts < 0) res += "NumberOfPorts should be positive. ";
            return res;
        }
        public override string ReturnOODetails()
        {
            return $"Wi-Fi Standard: {WiFiStandard}\r\nNumber of ports: {NumberOfPorts}\r\nEthernet port type: {EthernetPortType}";
        }
    }

    public class Category : Model
    {
        public int id { get; set; } = -1;
        public string Categoryname { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Categoryname;
        }
        public override string IsValid()
        {
            string res = base.IsValid();
            if (string.IsNullOrEmpty(Categoryname)) res += "Categoryname can't be null or empty. ";
            return res;
        }
    }

    public class ClientOrder : Model
    {
        public int id { get; set; }
        public int PartsID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string ClientName { get; set; }
        public string ClientEMail { get; set; }
        public bool Proceeded { get; set; }

        [ExcludeFromInsertUpdate]
        public string Name { get; set; }
        [ExcludeFromInsertUpdate]
        public float Summ { get; set; }
        [ExcludeFromInsertUpdate]
        public string Currency { get; set; }
        public override string ToString()
        {
            return $"Order id #{id}";
        }

        public override string IsValid()
        {
            string res = base.IsValid();
            if (Quantity <= 0) res += "Quantity should be more than 0. ";
            return res;
        }

    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ExcludeFromInsertUpdate : System.Attribute { }
}
