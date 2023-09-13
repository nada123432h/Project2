using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using amazon.Models;
using Newtonsoft.Json;
using amazon.ViewModels;

namespace amazon.Views
{


    public partial class MainPage : ContentPage
    {
       // List<items> lstModel = new List<items>();

        public MainPage()
        {
        
            InitializeComponent();
            iconbrand.Source = new FontImageSource
            {
                Glyph = "", // Glyph for the sun icon (replace this with the correct glyph for the sun in your font)
                FontFamily = "FontIconBrand",
                Color = Color.White

            };
            icon.Source = new FontImageSource
            {
                Glyph = "", // Glyph for the sun icon (replace this with the correct glyph for the sun in your font)
                FontFamily = "FontIconSolid",
                Color = Color.FromHex("#001C30")
            };
            iconshop.Source = new FontImageSource
            {
                FontFamily = "FontIconSolid",
                Color = Color.FromHex("#394867"),
                Glyph = ""

            };
            iconlogout.Source = new FontImageSource
            {
                FontFamily = "FontIconSolid",
                Color = Color.FromHex("#394867"),
                Glyph = ""

            };
            iconphone.Source = new FontImageSource
            {
                FontFamily = "FontIconSolid",
                Color = Color.FromHex("#394867"),
                Glyph = ""

            };
            iconlap.Source = new FontImageSource
            {
                FontFamily = "FontIconSolid",
                Color = Color.FromHex("#394867"),
                Glyph = ""

            };
            App.ChangeTheme(2);


            //  clsSlider oclsSlider = new clsSlider();

            //slider.ItemsSource = oclsSlider.LoaItems();
            //  loadData();
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Views.Item_Page());

        //}

        private void Toolbar_menueclick(object sender, string e)
        {

            navigationDrawer.IsOpen = true;
        }
        public bool isSunIcon = false;
      
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
          
                if (isSunIcon)
                {
                iconbrand.Source = new FontImageSource
                {
                    Glyph = "", // Glyph for the sun icon (replace this with the correct glyph for the sun in your font)
                    FontFamily = "FontIconBrand",
                    Color = Color.FromHex("#606C5D")

                };
                // Change to the moon icon
                iconlogout.Source = new FontImageSource
                {
                    FontFamily = "FontIconSolid",
                    Color = Color.White,
                    Glyph = ""

                };
                icon.Source = new FontImageSource
                    {
                        Glyph = "", // Glyph for the moon icon (replace this with the correct glyph for the moon in your font)
                        FontFamily = "FontIconSolid",
                        
                        Color = Color.Orange

                    };
                iconphone.Source = new FontImageSource
                {
                    FontFamily = "FontIconSolid",
                    Color = Color.White,
                    Glyph = ""

                };
                iconlap.Source = new FontImageSource
                {
                    FontFamily = "FontIconSolid",
                    Color = Color.White,
                    Glyph = ""

                };
                iconshop.Source = new FontImageSource
                {
                    FontFamily = "FontIconSolid",
                    Color = Color.White,
                    Glyph = ""

                };

                App.ChangeTheme(1);

                    isSunIcon = false;
                }
                else
                {
                iconshop.Source = new FontImageSource
                {
                    FontFamily = "FontIconSolid",
                    Color = Color.FromHex("#394867"),
                    Glyph = ""

                };
                iconlogout.Source = new FontImageSource
                {
                    FontFamily = "FontIconSolid",
                    Color = Color.FromHex("#394867"),
                    Glyph = ""

                };
                iconphone.Source = new FontImageSource
                {
                    FontFamily = "FontIconSolid",
                    Color = Color.FromHex("#394867"),
                    Glyph = ""

                };
                iconlap.Source = new FontImageSource
                {
                    FontFamily = "FontIconSolid",
                    Color = Color.FromHex("#394867"),
                    Glyph = ""

                };
                iconbrand.Source = new FontImageSource
                {
                    Glyph = "", // Glyph for the sun icon (replace this with the correct glyph for the sun in your font)
                    FontFamily = "FontIconBrand",
                    Color = Color.White

                };
                // Change to the sun icon
                icon.Source = new FontImageSource
                    {
                        Glyph = "", // Glyph for the sun icon (replace this with the correct glyph for the sun in your font)
                        FontFamily = "FontIconSolid",
                        Color = Color.FromHex("#001C30")
                    };
                    App.ChangeTheme(2);
                    isSunIcon = true;
                }
        }
        //async void loadData()
        //{
        //    string json = await Helpers.Utility.CallWebApi("/api/item");
        //    lstModel = JsonConvert.DeserializeObject<List<items>>(json);
        //    colItems.ItemsSource = lstModel;

        //}
    }
}
