using amazon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace amazon.ViewModels
{
    public class ItemDetailsViewModel : INotifyPropertyChanged
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

        ObservableCollection<itemPhoneModel> _ShoppingProductsPhone;
        public ObservableCollection<itemPhoneModel> ShoppingProductsPhone
        {

            get
            {
                return _ShoppingProductsPhone;
            }

            set
            {
                _ShoppingProductsPhone = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ShoppingProductsPhone"));
            }
        }
        itemPhoneModel _SelectedItemPhone;
        public itemPhoneModel SelectedItemPhone
        {
            get
            {
                return _SelectedItemPhone;
            }
            set
            {
                _SelectedItemPhone = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedItemPhone"));
            }
        }
        items _SelectedItem2;
        public items SelectedItem2
        {
            get
            {
                return _SelectedItem2;
            }
            set
            {
                _SelectedItem2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem2"));
            }
        }
       


        public ICommand selectFavbutton { get; set; }
        public ICommand SelectButtonCommand { get; }
        public ICommand selectbutton { get; set; }
        public ICommand selectFavbuttonPhone { get; set; }
        public ICommand ClearFavoriteProductsCommand { get; set; }
        public ItemDetailsViewModel()
        {
            ShoppingProductsPhone = new ObservableCollection<itemPhoneModel>();
            FavouritePhoneProducts2 = new ObservableCollection<itemPhoneModel>();
            selectbutton = new Command(OnSelectButtonCommandPhone);//phone
          
            FavouriteProducts2 = new ObservableCollection<items>
            {
                // Initialize your favourite products collection here
            };
            ShoppingProducts2 = new ObservableCollection<items>
            {
                // Initialize your favourite products collection here
            };
            // ItemsInCartCount = 0;


            ClearFavoriteProductsCommand = new Command(OnClearFavoriteProducts);
            selectFavbutton = new Command(OnselectFavbutton);
            selectFavbuttonPhone = new Command(OnselectFavbuttonPhones);
            SelectButtonCommand = new Command(OnSelectButtonCommand);//lap

            if (Application.Current.Properties.TryGetValue("FavouriteProducts", out object serializedData2) && serializedData2 is string jsonData2)
            {
                FavouritePhoneProducts2 = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData2);
            }
            else
            {
                FavouritePhoneProducts2 = new ObservableCollection<itemPhoneModel>();
            }
            if (Application.Current.Properties.TryGetValue("FavouriteShoppingDataLap", out object serializedData) && serializedData is string jsonData)
            {
                FavouriteProducts2 = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData);
            }
            else
            {
                FavouriteProducts2 = new ObservableCollection<items>();
            }
            //if (Application.Current.Properties.TryGetValue("ShoppingDataLapadd", out object serializedData3) && serializedData is string jsonData3)
            //{
            //    ShoppingProducts2 = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData3);
            //}
            //else
            //{
            //    ShoppingProducts2 = new ObservableCollection<items>();
            //}

            //if (Application.Current.Properties.TryGetValue("ShoppingDataPhones", out object serializedData4) && serializedData2 is string jsonData4)//shoppingphone
            //{
            //    ShoppingProductsPhone = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData4);
            //}
            //else
            //{
            //    ShoppingProductsPhone = new ObservableCollection<itemPhoneModel>();
            //}

            // ItemsInCartCount = ShoppingProducts2.Count()+ShoppingProductsPhone.Count();
        }
        private void UpdateSharedDataSource(ObservableCollection<items> itemsList)
        {
            var serializedData = JsonConvert.SerializeObject(itemsList);
            Application.Current.Properties["SharedShoppingData"] = serializedData;
            Application.Current.SavePropertiesAsync();
        }
        public event PropertyChangedEventHandler PropertyChanged;
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
        public void OnClearFavoriteProducts()
        {


            // Clear the existing items in the ShoppingProducts2 collection
            ShoppingProducts2.Clear();

            // Serialize the empty collection to JSON
            var serializedData = JsonConvert.SerializeObject(ShoppingProducts2);

            // Update the Application properties with the new serialized JSON data
            Application.Current.Properties["FavouriteShoppingData"] = serializedData;

            // Save the properties asynchronously
            Application.Current.SavePropertiesAsync();




        }

        public async void OnselectFavbutton()
        {
            if (SelectedItem != null)
            {

                // Check if the item is already in the FavouriteProducts list based on its unique property (e.g., ProductId)
                if (!FavouriteProducts2.Any(item => item.ItemId == SelectedItem.ItemId))
                {
                    SelectedItem.IsFavourite = true;
                    FavouriteProducts2.Add(SelectedItem);
                    // Serialize the FavouriteProducts list to JSON
                    var serializedData = JsonConvert.SerializeObject(FavouriteProducts2);

                    // Save the serialized JSON data to Application.Current.Properties
                    Application.Current.Properties["FavouriteShoppingDataLap"] = serializedData;
                    await Application.Current.SavePropertiesAsync();

                    var page = new Views.favPage();
                    FvouritePageViewModel oFvouritePageViewModel = new FvouritePageViewModel();
                    oFvouritePageViewModel.FavouriteProducts2 = FavouriteProducts2; // Set the favorite products list
                    oFvouritePageViewModel.SelectedItem = SelectedItem;
                    page.BindingContext = oFvouritePageViewModel;

                    await App.Current.MainPage.Navigation.PushAsync(page);
                }
                else
                {
                    // Show an alert if the item is already in the FavouriteProducts list
                    await App.Current.MainPage.DisplayAlert("Information", "Item is already in the favorites list.", "OK");
                }
            }
        }

        public async void OnSelectButtonCommand()
        {
            await App.Current.MainPage.DisplayAlert("Information", "Done, Go To Cart Shopping", "Ok");

            // Increment the cart count
            SelectedItem.IsFavourite = true;

            // Load existing data
            if (Application.Current.Properties.TryGetValue("SharedShoppingData", out object serializedData) && serializedData is string jsonData)
            {
                ShoppingProducts2 = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData);
            }

            // Add the new item
            ShoppingProducts2.Add(SelectedItem);
            ItemsInCartCount++;

            // Serialize the updated shopping cart data to JSON
            var updatedSerializedData = JsonConvert.SerializeObject(ShoppingProducts2);

            // Update the Application properties with the new serialized JSON data
            Application.Current.Properties["SharedShoppingData"] = updatedSerializedData;

            // Save the properties asynchronously
            await Application.Current.SavePropertiesAsync();

            // Navigate to the shopping cart page
            var page = new Views.ShoppingCart();
            FvouritePageViewModel OShoppingProducts2 = new FvouritePageViewModel();
            OShoppingProducts2.ShoppingProducts2 = ShoppingProducts2; // Set the favorite products list
            OShoppingProducts2.SelectedItem = SelectedItem;
            page.BindingContext = OShoppingProducts2;

            //    await App.Current.MainPage.Navigation.PushAsync(page);
        }


        public async void OnSelectButtonCommandPhone()
        {
            ItemsInCartCount++;
            await App.Current.MainPage.DisplayAlert("Information", "Done, Go To Cart Shopping", "Ok");

            // Increment the cart count
            SelectedItemPhone.IsFavourite = true;

            // Load existing data
            if (Application.Current.Properties.TryGetValue("ShoppingDataPhones", out object serializedData) && serializedData is string jsonData)
            {
                ShoppingProductsPhone = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData);
            }

            // Add the new item
            ShoppingProductsPhone.Add(SelectedItemPhone);

            // Serialize the updated data to JSON
            var updatedSerializedData = JsonConvert.SerializeObject(ShoppingProductsPhone);

            // Update the Application properties with the new serialized JSON data
            Application.Current.Properties["ShoppingDataPhones"] = updatedSerializedData;

            // Save the properties asynchronously
            await Application.Current.SavePropertiesAsync();

            // Navigate to the shopping cart page
            var page = new Views.ShoppingCart();
            FvouritePhonePageViewModel OShoppingProducts2 = new FvouritePhonePageViewModel();
            OShoppingProducts2.ShoppingProducts2 = ShoppingProductsPhone; // Set the favorite products list
            OShoppingProducts2.SelectedItem = SelectedItemPhone;
            page.BindingContext = OShoppingProducts2;

            //   App.Current.MainPage.Navigation.PushAsync(page);
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

                if (ShoppingProducts2.Any(SelectedSwipeItem => SelectedSwipeItem.ItemId == SelectedSwipeItem.ItemId))
                {
                    ShoppingProducts2.Remove(SelectedSwipeItem);

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
          
        
       

            //ShoppingProducts2.Clear();

            //        // Deserialize the shopping cart data from the JSON string
            //        ShoppingProducts2 = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData2);

            //        // Optionally, you can also clear the serialized data by assigning an empty JSON string to jsonData2
            //        jsonData2 = JsonConvert.SerializeObject(new ObservableCollection<items>());

            //        // Save the updated empty collection to the Application properties
            //        Application.Current.Properties["FavouriteShoppingData"] = jsonData2;
            //         Application.Current.SavePropertiesAsync();
        }
        public async void OnselectFavbuttonPhones()
        {
            if (SelectedItemPhone != null)
            {

                // Check if the item is already in the FavouriteProducts list based on its unique property (e.g., ProductId)
                if (!FavouritePhoneProducts2.Any(i => i.Id == SelectedItemPhone.Id))
                {
                    SelectedItemPhone.IsFavourite = true;
                    FavouritePhoneProducts2.Add(SelectedItemPhone);
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
    }
}
