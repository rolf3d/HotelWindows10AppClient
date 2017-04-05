using HotelWindoes10App.Commen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelWindoes10App.Persistency
{
    public class PersistencyService
    {

        // server url
        const string serverUrl = "http://hotelwsrolf.azurewebsites.net";


        //Lav en ny event og smid den op i tabellen.
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
                        MessageDialogHelper.Show("Ny gæst blev oprettet", e.Name);
                    }

                }
                catch (Exception ef)
                {
                    MessageDialogHelper.Show("Der er sket en fejl, Du er i AddGuest metoden", ef.Message);
                }

            }



        }

        public static ObservableCollection<Guest> LoadGuestsAsync()
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/guests";

               
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var guestliste = response.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;
                        return guestliste;
                    }
                    return null;

                
                
                
            }

        }
        


    }
}
