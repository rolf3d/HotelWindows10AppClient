using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using HotelWindoes10App.Commen;
using HotelWindoes10App.Persistency;

namespace HotelWindoes10App.Model
{
    public class GuestCatalogSingleton
    {
        // server url
        const string serverUrl = "http://hotelwsrolf.azurewebsites.net";

        public PersistencyService ps;

        private ObservableCollection<Guest> guests;

        public ObservableCollection<Guest> Guests
        {
            get { return guests; }
            set { guests = value; }
        }

        private ObservableCollection<Guest> slettetGuests;

        public ObservableCollection<Guest> SlettetGuests
        {
            get { return slettetGuests; }
            set { slettetGuests = value; }
        }


        private static GuestCatalogSingleton instance;

        public static GuestCatalogSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GuestCatalogSingleton();
                }

                return instance;
            }
        }


        public GuestCatalogSingleton()
        {
            Guests = new ObservableCollection<Guest>();
            SlettetGuests = new ObservableCollection<Guest>();
            ps = new PersistencyService();
            //deletedev = new PersistencyServiceDeletet();
            // Kan bruges som test date, for at se om listview er bindet rigtigt.
            //Event minEvent = new Event(01, "Fest", "Mega Stor Fest", "Her", new DateTime(2016, 05, 25));
            //Events.Add(minEvent);

            LoadGuestsAsync();

        }

        // Lav en ny event og smid den op i tabellen.
        public void AddGuest(Guest e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = client.PostAsJsonAsync<Guest>("api/guests", e).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        this.Guests.Add(e);
                        //PersistencyService.SaveEventsAsJsonAsync(Guests);
                        MessageDialogHelper.Show("Ny gæst blev oprettet", e.Name);

                    }

                }
                catch (Exception ef)
                {

                    MessageDialogHelper.Show("Der er sket en fejl ", ef.Message);
                }

            }



        }

        public void RemoveGuest(Guest e)
        {
            SlettetGuests.Add(e);
            Guests.Remove(e);

            //PersistencyService.SaveEventsAsJsonAsync(Events);
            //PersistencyServiceDeletet.SaveEventsAsJsonAsync(SlettetEvents);

        }
        
        public async void LoadGuestsAsync()
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/guests";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var guestliste = response.Content.ReadAsAsync<List<Guest>>().Result;
                        foreach (var ev in guestliste)
                        {
                            Guests.Add(ev);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageDialogHelper.Show("Der skete en fejl", ex.Message);

                }
            }

        }
    }
}
