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
   public class ShoesCategoryViewModel: INotifyPropertyChanged
    {
        ObservableCollection<Models.ShoesModel> _lstmodel2;
        public ICommand SelectItem { get; set; }
        public ICommand Dicard { get; set; }
        public ICommand PostService { get; set; }
        public ICommand RequestService { get; set; }
        public ShoesCategoryViewModel()
        {
            SelectItem2 = new ShoesModel();
         
            PostService = new Command(OnPostService);
           loadData2();
            lstmodel2 = new ObservableCollection<Models.ShoesModel>();
            
            SelectItem = new Command<Models.ShoesModel>(OnSelectItem);
            RequestService = new Command<ShoesModel>(OnRequestService);
            Dicard = new Command(OnDicard);
            RequestModel oRequestModel = new RequestModel();
            Data = new RequestModel();
        }
        ShoesModel _SelectItem2;
       public ShoesModel SelectItem2
        {
            get
            {
                return _SelectItem2;
            }
            set
            {
                _SelectItem2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectItem2"));
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
        async void OnSelectItem(ShoesModel model)
        {
            SelectItem2 = model;

            var page = new Views.SelectPopUp();
            page.BindingContext = this;

            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(page);
        }


        public ObservableCollection<Models.ShoesModel> lstmodel2
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
        async void loadData2()
        {
            string json = await Helpers.Utility.CallWebApi("/api/Sho");
            lstmodel2 = JsonConvert.DeserializeObject<ObservableCollection<Models.ShoesModel>>(json);


        }
        async void OnDicard()
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }


        RequestModel _Data;
        public RequestModel Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Data"));
            }
        }


        async void OnRequestService(ShoesModel model)
        {
            model = SelectItem2;

            var page = new Views.RequsetPage();
            page.BindingContext = this;
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            await App.Current.MainPage.Navigation.PushAsync(page); //page not new views.page
        }
        int _Qty;
        public int Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Qty"));
            }
        }
        string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Address"));
            }
        }
        async void OnPostService()
        {


            Data.Id = 9;
            string result = await Helpers.Utility.PostData("api/Request", JsonConvert.SerializeObject(Data));
            
        }




        public event PropertyChangedEventHandler PropertyChanged;
    }

}
