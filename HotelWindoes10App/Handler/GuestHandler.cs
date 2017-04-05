using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelWindoes10App.Commen;
using HotelWindoes10App.Model;
using HotelWindoes10App.Persistency;
using HotelWindoes10App.ViewModel;

namespace HotelWindoes10App.Handler
{
    public class GuestHandler
    {
        

        public GuestViewModel GuestViewModel { get; set; }
        

        public GuestHandler(GuestViewModel guestViewModel)
        {
            this.GuestViewModel = guestViewModel;
            
        }
        
        
    }
}
