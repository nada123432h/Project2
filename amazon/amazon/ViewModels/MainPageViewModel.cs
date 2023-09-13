using amazon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using amazon.Views;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;
using System.Collections.Specialized;

namespace amazon.ViewModels

{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Models.items> _lstModel;
        public ObservableCollection<Models.items> lstModel
        {
            get
            {
                return _lstModel;
            }
            set
            {
                _lstModel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("lstModel"));
            }
        }
        ObservableCollection<Models.items> _lstFilterModel;
        public ObservableCollection<Models.items> lstFilterModel
        {
            get
            {
                return _lstFilterModel;
            }
            set
            {
                _lstFilterModel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("lstFilterModel"));
            }
        }
        ObservableCollection<items> _ClearFavoriteProducts;
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
        public ObservableCollection<Models.items> ClearFavoriteProducts
        {
            get
            {
                return _ClearFavoriteProducts;
            }
            set
            {
                _ClearFavoriteProducts = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ClearFavoriteProducts"));
            }
        }
        ObservableCollection<Models.ItemModel> _lstSlider;
        public ObservableCollection<Models.ItemModel> lstSlider
        {
            get
            {
                return _lstSlider;
            }
            set
            {
                _lstSlider = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("lstSlider"));
            }
        }

        ObservableCollection<Models.itemPhoneModel> _lstmodel2;
        public ObservableCollection<Models.itemPhoneModel> lstmodel2
        {
            get
            {
                return _lstmodel2;
            }
            set
            {
                _lstmodel2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("lstmodel2"));
            }
        }
        items _SharedShoppingProducts2;
        public static ObservableCollection<items> SharedShoppingProducts2 { get; set; }

      
        ObservableCollection<Models.itemPhoneModel> _lstFiltermodel2;
        public ObservableCollection<Models.itemPhoneModel> lstFiltermodel2
        {
            get
            {
                return _lstFiltermodel2;
            }
            set
            {
                _lstFiltermodel2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("lstmodel2"));
            }
        }
        ObservableCollection<items> _ShoppingProducts2;
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
        itemPhoneModel _SelectedItem2;
        public itemPhoneModel SelectedItem2
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
        public ICommand SelectItem { get; set; }
        public ICommand SelectItem2 { get; set; }
        public ICommand ClearFavoriteProductsCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand selectFavbutton { get; set; }
        public ICommand DisplayFavoriteProductsCommand { get; set; }
        public ICommand DisplayFavoritePhoneProductsCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand SearchWithText { get; set; }
        public ICommand Trash { get; set; }
        public ICommand TrashPhone { get; set; }
        public ICommand DisplayFavoritePhoneProductsCommandShoppiong { get; set; }

        public MainPageViewModel()
        {
            //  ShoppingProducts2 = new ObservableCollection<items>();
            //  ShoppingProductsPhone = new ObservableCollection<itemPhoneModel>();
            //  ShoppingProducts2.CollectionChanged += OnShoppingProducts2CollectionChanged;
            //  ShoppingProductsPhone.CollectionChanged += OnShoppingProductsPhoneCollectionChanged;

            //UpdateItemsInCartCount();
            //  ItemsInCartCount = new int();
            ShoppingProductsPhone = new ObservableCollection<itemPhoneModel>();
           
            ClearFavoriteProducts = new ObservableCollection<items>();
            ShoppingProducts2 = new ObservableCollection<items>();
            FavouritePhoneProducts2 = new ObservableCollection<itemPhoneModel>();
            FavouriteProducts2 = new ObservableCollection<items>();
            ;               //   selectFavbutton = new Command(OnselectFavbutton);
            clsSlider oclsSlider = new clsSlider();
            lstSlider = oclsSlider.LoaItems();
            loadData();
            loadData2();
            DisplayFavoriteProductsCommand = new Command(OnDisplayFavoriteProducts);
            DisplayFavoritePhoneProductsCommand = new Command(OnDisplayFavoritePhoneProductsCommand);
            SelectItem = new Command<items>(OnSelectItem);
            SelectItem2 = new Command<itemPhoneModel>(OnSelectItem2);
            LogoutCommand = new Command(OnLogoutCommand);
            NextCommand = new Command(OnNextCommand);
            SearchWithText = new Command(OnSearchWithText);
            DisplayFavoritePhoneProductsCommandShoppiong = new Command(OnDisplayFavoritePhoneProductsCommandShoppiong);
            
            if (Application.Current.Properties.TryGetValue("SharedShoppingData", out object serializedData) && serializedData is string jsonData)
            {
               // OnClickTrash(SelectedSwipeItem);
                ShoppingProducts2 = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData);
            }
            else
            {
                ShoppingProducts2 = new ObservableCollection<items>();
            }


            if (Application.Current.Properties.TryGetValue("ShoppingDataPhones", out object serializedData2) && serializedData2 is string jsonData2)
            {
                ShoppingProductsPhone = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData2);
            }
            else
            {
                ShoppingProductsPhone = new ObservableCollection<itemPhoneModel>();
            }

            ItemsInCartCount = ShoppingProducts2.Count() + ShoppingProductsPhone.Count();
            ClearFavoriteProductsCommand = new Command(OnClearFavoriteProducts);
            Trash = new Command<items>(OnClickTrash);
            TrashPhone = new Command<itemPhoneModel>(OnTrashPhone);



        }
        private void UpdateSharedDataSource(ObservableCollection<items> itemsList)
        {
            var serializedData = JsonConvert.SerializeObject(itemsList);
            Application.Current.Properties["SharedShoppingData"] = serializedData;
            Application.Current.SavePropertiesAsync();
        }




        string _SearchTerm;
        public string SearchTerm
        {
            get
            {
                return _SearchTerm;
            }
            set
            {
                _SearchTerm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SearchTerm"));
            }
        }

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
        async void OnSelectItem(items model)
        {
            SelectedItem = model;
            var page = new Views.ItemDetails();
            ItemDetailsViewModel oItemDetailsViewModel = new ItemDetailsViewModel();
            oItemDetailsViewModel.SelectedItem = model;
            page.BindingContext = oItemDetailsViewModel;
            await App.Current.MainPage.Navigation.PushAsync(page);
        }
        async void OnSelectItem2(itemPhoneModel model2)
        {
            SelectedItem2 = model2;
            var page = new Views.ItemDetailsPhone();
            ItemDetailsViewModel oItemPhoneDetailsViewModel = new ItemDetailsViewModel();
            oItemPhoneDetailsViewModel.SelectedItemPhone = model2;
            page.BindingContext = oItemPhoneDetailsViewModel;
            await App.Current.MainPage.Navigation.PushAsync(page);

            // ItemsInCartCount = ShoppingProducts2.Count();

        }

        async Task LoadFavouriteProducts()
        {
            if (Application.Current.Properties.TryGetValue("FavouriteShoppingDataLap", out object serializedData) && serializedData is string jsonData)
            {
                FavouriteProducts2 = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData);
            }
            else
            {
                FavouriteProducts2 = new ObservableCollection<items>();
            }
        }
        async Task LoadFavouritePhoneProducts()
        {
            if (Application.Current.Properties.TryGetValue("FavouriteProducts", out object serializedData) && serializedData is string jsonData)
            {
                FavouritePhoneProducts2 = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData);
            }
            else
            {
                FavouritePhoneProducts2 = new ObservableCollection<itemPhoneModel>();
            }
        }


        async Task LoadFavouritePhoneProductsShopping()
        {
            if (Application.Current.Properties.TryGetValue("SharedShoppingData", out object serializedData3) && serializedData3 is string jsonData3)
            {
                ShoppingProducts2 = JsonConvert.DeserializeObject<ObservableCollection<items>>(jsonData3);
        
            }
            else
            {
                ShoppingProducts2 = new ObservableCollection<items>();
            }
        } //shopping
        async Task LoadFavouritePhoneProductsShoppingmain() //shopping
        {
            if (Application.Current.Properties.TryGetValue("ShoppingDataPhones", out object serializedData2) && serializedData2 is string jsonData2)
            {
                ShoppingProductsPhone = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData2);
            }
            else
            {
                ShoppingProductsPhone = new ObservableCollection<itemPhoneModel>();
            }
        }
        async void OnClickTrash(items item)
        {
            SelectedSwipeItem = item;
            if (SelectedSwipeItem != null)
            {

                if (ShoppingProducts2.Any(i => i.ItemId == SelectedSwipeItem.ItemId))
                {

                    ShoppingProducts2.Remove(SelectedSwipeItem);
                     UpdateSharedDataSource(ShoppingProducts2);
                    // Serialize the FavouriteProducts list to JSON
                    var serializedData = JsonConvert.SerializeObject(FavouriteProducts2);
                
                    // Save the serialized JSON data to Application.Current.Properties

                    Application.Current.Properties["ShoppingDataLapadd"] = serializedData;
                    await Application.Current.SavePropertiesAsync();

                    // Show a message to indicate that the item is deleted
                    await App.Current.MainPage.DisplayAlert("Information", "Item is deleted", "OK");
                    ItemsInCartCount--;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Information", "Item is already deleted", "OK");
                }
            }
        }
        public async void OnDisplayFavoriteProducts() //lap fav
        {
           
                await LoadFavouriteProducts();


                var page = new Views.favPage();
                page.BindingContext = this; // Set the view model as the binding context to automatically display the data in the page
                await App.Current.MainPage.Navigation.PushAsync(page);
            
         

        }
        public async void OnDisplayFavoritePhoneProductsCommand()
        {

            await LoadFavouritePhoneProducts();
            var page = new Views.FvouritePage();
            page.BindingContext = this; // Set the view model as the binding context to automatically display the data in the page
            await App.Current.MainPage.Navigation.PushAsync(page);


        }
        public async void OnDisplayFavoritePhoneProductsCommandShoppiong()
        {
            await LoadFavouritePhoneProductsShopping();
            await LoadFavouritePhoneProductsShoppingmain();
            ItemsInCartCount = ShoppingProducts2.Count() + ShoppingProductsPhone.Count();
            var page = new Views.ShoppingCart();
            page.BindingContext = this; // Set the view model as the binding context to automatically display the data in the page
            await App.Current.MainPage.Navigation.PushAsync(page);
        }


        public void OnClearFavoriteProducts()
        {
            if (Application.Current.Properties.TryGetValue("FavouriteShoppingDataShoes", out object serializedData2) && serializedData2 is string jsonData2)
            {
                // ShoppingProducts2.Clear();
                ShoppingProductsPhone.Clear();

                // Deserialize the shopping cart data from the JSON string
                ShoppingProductsPhone = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(jsonData2);

                // Optionally, you can also clear the serialized data by assigning an empty JSON string to jsonData2
                jsonData2 = JsonConvert.SerializeObject(new ObservableCollection<itemPhoneModel>());

                // Save the updated empty collection to the Application properties
                Application.Current.Properties["FavouriteShoppingDataShoes"] = jsonData2;
                Application.Current.SavePropertiesAsync();
            }
        }

        async void OnLogoutCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.LoginPage());

        }

        async void loadData()
        {
            string json = await Helpers.Utility.CallWebApi("/api/item");
            lstModel = JsonConvert.DeserializeObject<ObservableCollection<items>>(json);


        }
        async void loadData2()
        {
            string json = await Helpers.Utility.CallWebApi("/api/s");
            lstmodel2 = JsonConvert.DeserializeObject<ObservableCollection<itemPhoneModel>>(json);


        }
        async void OnNextCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.ShoesCategory());
        }
        async void OnSearchWithText()
        {

            if (string.IsNullOrEmpty(SearchTerm))
            {
                lstFilterModel = new ObservableCollection<items>(lstModel);
                // lstFiltermodel2 = new ObservableCollection<itemPhoneModel>(lstmodel2);
                return;
            }
            lstFilterModel = new ObservableCollection<items>(lstModel.Where(a => a.ItemName.Contains(SearchTerm)));
            //lstFiltermodel2 = new ObservableCollection<itemPhoneModel>(lstFiltermodel2.Where(a => a.ItemName.Contains(SearchTerm)));

        }
        itemPhoneModel _SelectedSwipeItemPhone;
        public itemPhoneModel SelectedSwipeItemPhone
        {
            get { return _SelectedSwipeItemPhone; }
            set
            {
                _SelectedSwipeItemPhone = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedSwipeItemPhone"));
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
        
        async void OnTrashPhone(itemPhoneModel item)
        {
            SelectedSwipeItemPhone = item;
            if (SelectedSwipeItemPhone != null)
            {

                if (ShoppingProductsPhone.Any(SelectedSwipeItemPhone => SelectedSwipeItemPhone.Id == SelectedSwipeItemPhone.Id))
                {
                    ShoppingProductsPhone.Remove(SelectedSwipeItemPhone);

                    // Serialize the FavouriteProducts list to JSON
                    var serializedData = JsonConvert.SerializeObject(ShoppingProductsPhone);

                    // Save the serialized JSON data to Application.Current.Properties
                    Application.Current.Properties["ShoppingDataPhones"] = serializedData;
                    await Application.Current.SavePropertiesAsync();

                    // Show a message to indicate that the item is deleted
                    await App.Current.MainPage.DisplayAlert("Information", "Item is deleted", "OK");
                    ItemsInCartCount--;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Information", "Item is already deleted", "OK");
                }
            }
        }

    }
}
