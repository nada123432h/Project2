using amazon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace amazon.ViewModels
{
    public class FvouritePageViewModel : INotifyPropertyChanged
    {


        items _SelectedItem;
        public items SelectedItem
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
        ObservableCollection<items> _ShoppingProducts2;
        public ObservableCollection<items> ShoppingProducts2
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
        public ICommand ClearFavoriteProductsCommand { get; set; }
        ObservableCollection<items> _FavouriteProducts2;
        public ObservableCollection<items> FavouriteProducts2
        {

            get
            {
                return _FavouriteProducts2;
            }

            set
            {
                _FavouriteProducts2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FavouriteProducts2"));
            }
        }

        public FvouritePageViewModel()
        {
           
            FavouriteProducts2 = new ObservableCollection<items>();
            Trash = new Command<items>(OnClickTrash);
            ClearFavoriteProductsCommand = new Command(OnClearFavoriteProducts);
        }
        async Task LoadFavouritePhoneProducts()
        {
            if (Application.Current.Properties.TryGetValue("FavouriteProductsData", out object serializedData) && serializedData is string jsonData)
            {
                FavouriteProducts2.Clear(); // Clear the existing items before adding the deserialized items

                var deserializedProducts = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData);

                // Add the deserialized items to the FavouriteProducts2 collection
                foreach (var item in deserializedProducts)
                {
                    FavouriteProducts2.Remove(item);
                }
            }
        }
        items _SelectedSwipeItem;
        public items SelectedSwipeItem
        {
            get { return _SelectedSwipeItem; }
            set
            {
                _SelectedSwipeItem = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedSwipeItem"));
            }
        }
        async void OnClickTrash(items item)
        {
            SelectedSwipeItem = item;
            if (SelectedSwipeItem != null)
            {
               
                if (FavouriteProducts2.Any(SelectedSwipeItem => SelectedSwipeItem.ItemId == SelectedSwipeItem.ItemId))
                {
                    FavouriteProducts2.Remove(SelectedSwipeItem);

                    // Serialize the FavouriteProducts list to JSON
                    var serializedData = JsonConvert.SerializeObject(FavouriteProducts2);

                    // Save the serialized JSON data to Application.Current.Properties
                    Application.Current.Properties["FavouriteShoppingDataLap"] = serializedData;
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

        void OnClearFavoriteProducts()
        {
            if (Application.Current.Properties.TryGetValue("FavouriteProductsData", out object serializedData) && serializedData is string jsonData)
            {
                FavouriteProducts2.Clear(); // Clear the existing items before adding the deserialized items

                var deserializedProducts = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData);

                // Add the deserialized items to the FavouriteProducts2 collection
                foreach (var item in deserializedProducts)
                {
                    FavouriteProducts2.Remove(item);
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
