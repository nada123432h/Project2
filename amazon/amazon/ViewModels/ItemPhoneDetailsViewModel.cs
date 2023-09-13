using amazon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Linq;
using Xamarin.Forms;

namespace amazon.ViewModels
{
    public class ItemPhoneDetailsViewModel : INotifyPropertyChanged
    {
        itemPhoneModel _SelectedItemPhones;
        public itemPhoneModel SelectedItemPhones
        {
            get
            {
                return _SelectedItemPhones;
            }
            set
            {
                _SelectedItemPhones = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedItemPhones"));
            }
        }
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
        public int _itemsInCartCount;
        public int ItemsInCartCount
        {
            get { return _itemsInCartCount; }
            set
            {
                _itemsInCartCount = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemsInCartCount"));
            }
        }

        public ICommand Trash { get; set; }
        public ICommand selectFavbutton { get; set; }
        public ICommand selectbutton { get; set; }
        public ICommand ClearFavoriteProductsCommand { get; set; }

        public ItemPhoneDetailsViewModel()
        {
         
            ShoppingProducts2 = new ObservableCollection<itemPhoneModel>();
         ClearFavoriteProductsCommand = new Command(OnClearFavoriteProducts);
            selectbutton = new Command(OnSelectButtonCommand);
            FavouritePhoneProducts2 = new ObservableCollection<itemPhoneModel>
            {
                // Initialize your favourite products collection here
            };

            selectFavbutton = new Command(OnselectFavbuttonPhones);
            if (Application.Current.Properties.TryGetValue("FavouriteProducts", out object serializedData) && serializedData is string jsonData)
            {
                FavouritePhoneProducts2 = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData);
            }
            else
            {
                FavouritePhoneProducts2 = new ObservableCollection<itemPhoneModel>();
            }
            if (Application.Current.Properties.TryGetValue("FavouriteShoppingDataShoes", out object serializedData2) && serializedData is string jsonData2)
            {
                ShoppingProducts2 = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData2);
            }
            else
            {
                ShoppingProducts2 = new ObservableCollection<itemPhoneModel>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<items> ClearFavoriteProducts
        {

            get
            {
                return ClearFavoriteProducts;
            }

            set
            {
                ClearFavoriteProducts = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ClearFavoriteProducts"));
            }
        }


        public async void OnselectFavbuttonPhones()
        {
            if (SelectedItemPhones != null)
            {

                // Check if the item is already in the FavouriteProducts list based on its unique property (e.g., ProductId)
                if (!FavouritePhoneProducts2.Any(item => item.Id == SelectedItemPhones.Id))
                {
                    SelectedItemPhones.IsFavourite = true;
                    FavouritePhoneProducts2.Add(SelectedItemPhones);
                    // Serialize the FavouriteProducts list to JSON
                    var serializedData = JsonConvert.SerializeObject(FavouritePhoneProducts2);

                    // Save the serialized JSON data to Application.Current.Properties
                    Application.Current.Properties["FavouriteProducts"] = serializedData;
                    await Application.Current.SavePropertiesAsync();

                    var page = new Views.FvouritePage();
                    FvouritePhonePageViewModel oFvouritePhonePageViewModel = new FvouritePhonePageViewModel();
                    oFvouritePhonePageViewModel.FavouritePhoneProducts2 = FavouritePhoneProducts2; // Set the favorite products list
                    oFvouritePhonePageViewModel.SelectedItem = SelectedItemPhones;
                    page.BindingContext = oFvouritePhonePageViewModel;

                    await App.Current.MainPage.Navigation.PushAsync(page);
                }
                else
                {
                    // Show an alert if the item is already in the FavouriteProducts list
                    await App.Current.MainPage.DisplayAlert("Information", "Item is already in the favorites list.", "OK");
                }
            }
        }

        void OnClearFavoriteProducts()
        {
            FavouritePhoneProducts2.Clear();
            var serializedData = JsonConvert.SerializeObject(FavouritePhoneProducts2);

            // Save the serialized JSON data to Application.Current.Properties
            Application.Current.Properties["FavouriteProductsData"] = serializedData;
            Application.Current.SavePropertiesAsync();
        }

        public void OnSelectButtonCommand()
        {
            // Increment the cart count
            SelectedItemPhones.IsFavourite = true;

            // Serialize the empty collection to JSON
            ShoppingProducts2.Add(SelectedItemPhones);
            var serializedData2 = JsonConvert.SerializeObject(ShoppingProducts2);
            // Update the Application properties with the new serialized JSON data
            Application.Current.Properties["FavouriteShoppingDataShoes"] = serializedData2;

            // Save the properties asynchronously
            Application.Current.SavePropertiesAsync();

            // Serialize the FavouriteProducts list to JSON


            var page = new Views.ShoppingCartPhone();
            FvouritePhonePageViewModel OShoppingProducts2 = new FvouritePhonePageViewModel();
            OShoppingProducts2.ShoppingProducts2 = ShoppingProducts2; // Set the favorite products list
            OShoppingProducts2.SelectedItem = SelectedItemPhones;
            page.BindingContext = OShoppingProducts2;

            App.Current.MainPage.Navigation.PushAsync(page);

          //  ItemsInCartCount++;
        }
        

        }

    }

    