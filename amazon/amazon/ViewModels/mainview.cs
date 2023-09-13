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

namespace amazon.ViewModels
{
    public class mainview : INotifyPropertyChanged
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

      public  mainview()
        {
            clsSlider oclsSlider = new clsSlider();
            lstSlider = oclsSlider.LoaItems();
            loadData();
        }
        async void loadData()
        {
            string json = await Helpers.Utility.CallWebApi("/api/item");
            lstModel = JsonConvert.DeserializeObject<ObservableCollection<items>>(json);


        }
    }
}
