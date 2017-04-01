using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace HotelWindoes10App
{
    public class Guest
    {
        public int Guest_No { get; set; }

       
        public string Name { get; set; }

        public string Address { get; set; }

        public Guest(int nummer,string name,string address)
        {
            this.Guest_No = nummer;
            this.Name = name;
            this.Address = address;
        }

        //public override string ToString()
        //{
        //    return string.Format("Gæst nummer : {0}  Gæst navn : {1} Gæst Adresse : {2}", Guest_No,Name,Address);
        //}

        public override string ToString()
        {
            return string.Format("Guest No : {0} Name : {1} Address: {2}", Guest_No, Name, Address);
        }
    }
}
