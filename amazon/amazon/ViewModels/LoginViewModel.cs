using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace amazon.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        
        string _txtemail;
        public string txtemail
        {
            get
            {
                return _txtemail;
            }
            set
            {
                _txtemail = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("txtemail"));
               
            }
        }
        private Color _emailTextColor = Color.Default;
        public Color EmailTextColor
        {
            get { return _emailTextColor; }
            set
            {
                _emailTextColor = value;
             if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("txtemail"));
            }
        }
        string _txtpas;
        public string txtpas
        {
            get
            {
                return _txtpas;
            }
            set
            {

                _txtpas = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("txtpas"));
            }
        }
     

        public LoginViewModel()
        {
            Save = new Command(Onsave);
            
            //  oclsUser = new clsUser();

        }
     
        public ICommand Save { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        async void Onsave()
        {
            // bool isValid = txtemail.ToString().Contains("@") && txtemail.ToString().Contains(".");
            if (string.IsNullOrEmpty(txtemail))
            {
                await App.Current.MainPage.DisplayAlert("information", "please enter user name", "ok");
                return;
            }

            if (string.IsNullOrEmpty(txtpas))
            {
                await App.Current.MainPage.DisplayAlert("information", "please enter password", "ok");
                return;


                // Retrieve the emailEntry using FindByName inside the method
                

               
            }
            UpdateEmailTextColor();
            if (EmailTextColor == Color.Red)
            {
                // Invalid email format, display an alert or handle as needed
                await App.Current.MainPage.DisplayAlert("Information", "Invalid email format", "OK");
                return;
            }

            await App.Current.MainPage.Navigation.PushAsync(new Views. MainPage());

        }
        private void UpdateEmailTextColor()
        {
            if (txtemail.Contains("@") && txtemail.Contains("."))
            {
                EmailTextColor = Color.Default; // Change the color of the Entry control to the default color
            }
            else
            {
                EmailTextColor = Color.Red; // Set the text color to red if the email is not valid
            }
        }

    }
}
