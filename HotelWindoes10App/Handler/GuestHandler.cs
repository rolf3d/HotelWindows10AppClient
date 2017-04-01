using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelWindoes10App.Commen;
using HotelWindoes10App.ViewModel;

namespace HotelWindoes10App.Handler
{
    public class GuestHandler
    {
        public GuestViewModel GuestViewModel { get; set; }



        public GuestHandler(GuestViewModel guestViewModel)
        {
            GuestViewModel = guestViewModel;
        }

        public void CreateGuest()
        {
            try
            {
                if (GuestViewModel.Name != null)
                {
                    Guest newGuest = new Guest
                (
                    GuestViewModel.Guest_No,
                    GuestViewModel.Name,
                    GuestViewModel.Address
                );

                    GuestViewModel.GuestCatalogSingleton.AddGuest(newGuest);
                }
                else
                {
                    throw new ArgumentException("En ny gæst blev ikke oprettet!");
                }
            }
            catch (Exception ex)
            {

                MessageDialogHelper.Show("'Når man opretter en ny gæst skal alle felterne udfyldes!", ex.Message);
            }
        }

        public async void DeleteGuest()
        {
            GuestViewModel.GuestCatalogSingleton.RemoveGuest(GuestViewModel.SelectedGuest);
        }
        
    }
}
