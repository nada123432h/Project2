using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace amazon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : Controls.CustomPage
    {
        public LoginPage()
        {
            InitializeComponent();
          // txtemailname.TextChanged += OnEmailTextChanged;

        }
        //private void OnEmailTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (e.NewTextValue.Contains("@") && e.NewTextValue.Contains("."))
        //    {
        //        // Change the color of the Entry control to red
        //        txtemailname.TextColor = Color.Default;
        //    }
        //    else
        //    {
        //        // Set the default text color if the conditions are not met
        //        txtemailname.TextColor = Color.Red;
        //      //  Navigation.PushAsync(new Views.RegisterPage());
        //    }
        //}



        //async private void Button_Clicked(object sender, EventArgs e)
        //{
        // //   bool isValid = txtemail.Text.Contains("@") && txtemail.Text.Contains(".");


        //    if (string.IsNullOrEmpty(txtemail.Text) )
        //    {
        //        await DisplayAlert("information", "please enter user name", "ok");
        //        return;
        //    }


        //    if (string.IsNullOrEmpty(txtpas.Text))
        //    {
        //        await DisplayAlert("information", "please enter password", "ok");
        //        return;
        //    }



        //    await Navigation.PushAsync(new MainPage());
        //}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Views.Register());
        }
    }
}