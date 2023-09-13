using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using amazon.Models;
using amazon.Views;
using Xamarin.Forms;
using Newtonsoft.Json;
using amazon.Helpers;
using System.Threading.Tasks;

namespace amazon.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {


   


        DataModels _DataModels;
        public DataModels DataModels
        {
            get
            {
                return _DataModels;
            }
            set
            {
                _DataModels = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DataModels"));
            }
        }





        private string _SelectedCountry;

        public string SelectedCountry
        {
            get => _SelectedCountry;
            set
            {
                if (_SelectedCountry != value)
                {
                    _SelectedCountry = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedCountry"));
                }
            }
        }



        public ICommand RadioButtonCommand { get; set; }
        
        public ICommand Register { get; set; }

        public RegisterViewModel()
        {

            RadioButtonCommand = new Command<string>(OnRadioButtonCommand);
          
            Register = new Command(OnRegister);
            DataModels = new DataModels();
        }

       

        async void OnRadioButtonCommand(string value)
        {
            DataModels.Gender = value;
            //string result = await Helpers.Utility.PostData("/api/Data",
            //   JsonConvert.SerializeObject(DataModels));
        }
        void OnSelectPicker( string value)
        {
          value=  SelectedCountry ;
          
        }


        async void OnRegister()
        {
            DataModels.Country = SelectedCountry;
            string result = await Helpers.Utility.PostData("/api/Data",
              JsonConvert.SerializeObject(DataModels));
        }



        public event PropertyChangedEventHandler PropertyChanged;


    }
}
