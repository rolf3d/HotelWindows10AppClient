using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelWindoes10App.Commen;
using HotelWindoes10App.Model;

namespace HotelWindoes10App.ViewModel
{
    public class GuestViewModel : INotifyPropertyChanged
    {
        public GuestCatalogSingleton GuestCatalogSingleton { get; set; }

        private int guest_No;

        public int Guest_No
        {
            get { return guest_No; }
            set { guest_No = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        private Guest selectedGuest;

        public Guest SelectedGuest
        {
            get { return selectedGuest; }
            set
            {
                selectedGuest = value;
                OnPropertyChanged();
            }
        }


        private ICommand createGuestCommand;

        public ICommand CreateGuestCommand
        {
            get { return createGuestCommand; }
            set { createGuestCommand = value; }
        }

        private ICommand deleteGuestCommand;

        public ICommand DeleteGuestCommand
        {
            get { return deleteGuestCommand; }
            set
            {
                deleteGuestCommand = value;
            }
        }

        private ICommand restoreGuestCommand;

        public ICommand RestoreGuestCommand
        {
            get { return restoreGuestCommand; }
            set { restoreGuestCommand = value; }
        }

       

        public Handler.GuestHandler GuestHandler { get; set; }



        public bool IsEventEmpty()
        {

            if (GuestCatalogSingleton.Instance.Guests.Count > 0 && GuestCatalogSingleton.Instance.Guests.Contains(SelectedGuest))
            {
                return true;
            }
            return false;

        }



        public GuestViewModel()
        {
           

            GuestHandler = new Handler.GuestHandler(this);

            createGuestCommand = new RelayCommand(GuestHandler.CreateGuest, null);
            //deleteGuestCommand = new RelayCommand(GuestHandler.DeleteGuest, IsEventEmpty);


            GuestCatalogSingleton = GuestCatalogSingleton.Instance;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
