using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelWindoes10App.Commen;
using HotelWindoes10App.Persistency;

namespace HotelWindoes10App.Model
{
    public class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        public static Singleton Instance
        {
            get { return _instance; }
        }

        public  ObservableCollection<Guest> Guests { get; set; }

        
        public Singleton()
        {
            Guests = new ObservableCollection<Guest>();
            HentAlleGaester();
        }

        public async void HentAlleGaester()
        {
            try
            {
                
                Guests = PersistencyService.LoadGuestsAsync();
                

            }
            catch (Exception e)
            {
                await Task.Delay(2000);
                MessageDialogHelper.Show("Der skete en fejl, Du er i Singleton der peger på LoadGuestsAsync", e.Message);
            }
        }


    }
}
