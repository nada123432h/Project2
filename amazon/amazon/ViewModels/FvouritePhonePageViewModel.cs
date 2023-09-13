using amazon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace amazon.ViewModels
{
  public  class FvouritePhonePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        itemPhoneModel _SelectedItem;
        public itemPhoneModel SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }

        ObservableCollection<itemPhoneModel> _ShoppingProducts2;
        public ObservableCollection<itemPhoneModel> ShoppingProducts2
        {

            get
            {
                return _ShoppingProducts2;
            }

            set
            {
                _ShoppingProducts2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ShoppingProducts2"));
            }
        }

        public ICommand Trash { get; set; } 
        
        ObservableCollection<itemPhoneModel> _FavouritePhoneProducts2;
        public ObservableCollection<itemPhoneModel> FavouritePhoneProducts2
        {

            get
            {
                return _FavouritePhoneProducts2;
            }

            set
            {
                _FavouritePhoneProducts2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FavouritePhoneProducts2"));
            }
        }
        itemPhoneModel _SelectedSwipeItem;
        public itemPhoneModel SelectedSwipeItem
        {
            get { return _SelectedSwipeItem; }
            set
            {
                _SelectedSwipeItem = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedSwipeItem"));
            }
        }
        async void OnClickTrash(itemPhoneModel item)
        {
            SelectedSwipeItem = item;
            if (SelectedSwipeItem != null)
            {

                if (FavouritePhoneProducts2.Any(SelectedSwipeItem => SelectedSwipeItem.Id == SelectedSwipeItem.Id))
                {
                    FavouritePhoneProducts2.Remove(SelectedSwipeItem);

                    // Serialize the FavouriteProducts list to JSON
                    var serializedData = JsonConvert.SerializeObject(FavouritePhoneProducts2);

                    // Save the serialized JSON data to Application.Current.Properties
                    Application.Current.Properties["FavouriteProducts"] = serializedData;
                    await Application.Current.SavePropertiesAsync();

                    // Show a message to indicate that the item is deleted
                    await App.Current.MainPage.DisplayAlert("Information", "Item is deleted", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Information", "Item is already deleted", "OK");
                }
            }

        }

        public FvouritePhonePageViewModel()
        {
            FavouritePhoneProducts2 = new ObservableCollection<itemPhoneModel>();
            Trash = new Command<itemPhoneModel>(OnClickTrash);
        }
    }

}
