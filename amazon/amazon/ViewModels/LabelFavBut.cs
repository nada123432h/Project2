using amazon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace amazon.ViewModels
{
 public   class LabelFavBut: INotifyPropertyChanged
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
        public ICommand selectFavbutton { get; set; }
        public LabelFavBut()
        {
            FavouriteProducts = new ObservableCollection<items>
            {
                // Initialize your favourite products collection here
            };

            SelectedFavouriteProducts = new ObservableCollection<items>();

 
            selectFavbutton = new Command(OnselectFavbutton);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<items> _FavouriteProducts;
        public ObservableCollection<items> FavouriteProducts
        {

            get
            {
                return _FavouriteProducts;
            }

            set
            {
                _FavouriteProducts = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FavouriteProducts"));
            }
        }
       public async void OnselectFavbutton()
        {
            if (SelectedItem != null && !FavouriteProducts.Contains(SelectedItem))
            {
                SelectedItem.IsFavourite = true;
                FavouriteProducts.Add(SelectedItem);

                var page = new Views.FvouritePage();
                FvouritePageViewModel oFvouritePageViewModel = new FvouritePageViewModel();
                oFvouritePageViewModel.FavouriteProducts2 = FavouriteProducts; // تعيين القائمة المفضلة
                oFvouritePageViewModel.SelectedItem = SelectedItem;
                page.BindingContext = oFvouritePageViewModel;

                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }


        ObservableCollection<items> _SelectedFavouriteProducts;

        public ObservableCollection<items> SelectedFavouriteProducts
        {
            get
            {
                return _SelectedFavouriteProducts;
            }

            set
            {
                _SelectedFavouriteProducts = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedFavouriteProducts"));
            }
        }

        public ICommand AddToFavouritesCommand { get; private set; }

  
      
    }
}
