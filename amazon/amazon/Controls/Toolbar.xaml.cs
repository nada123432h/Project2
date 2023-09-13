using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace amazon.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Toolbar : ContentView
    {
        public event EventHandler<string> menueclick;
        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(ContentView), "", propertyChanged: OnEventNameChanged);

        string _Title;
        public string Title
        {
            get {
                return (string)base.GetValue(TitleProperty);
            }
            set {
                base.SetValue(TitleProperty, value);

            } 
        }


        bool _Hasmenu;
        public bool Hasmenu
        {
            get
            {
                return _Hasmenu;
            }
            set
            {
                _Hasmenu = value; 
                var fontsource = new FontImageSource();
                fontsource.FontFamily = "FontIconSolid";
                fontsource.Color = Color.FromHex("#394867");

                if (!value)
                     fontsource.Glyph = "";
                else
                    fontsource.Glyph = "";
                
                imgMenu.Source = fontsource;
               

            }
        }
        public Toolbar()
        {
          
        InitializeComponent();

        }
        static void OnEventNameChanged(BindableObject bindable, object oldvalue,object newvalue)
        {
            if (newvalue == null)
                return;
            var tlbal = bindable as Toolbar;
            tlbal.lblTitle.Text=newvalue.ToString();
        }
        public static readonly BindableProperty ItemsInCartCountProperty = BindableProperty.Create(
       nameof(ItemsInCartCount), typeof(int), typeof(Toolbar), default(int));

        public int ItemsInCartCount
        {
            get { return (int)GetValue(ItemsInCartCountProperty); }
            set { SetValue(ItemsInCartCountProperty, value); }
        }

        public static readonly BindableProperty HasItemsInCartProperty = BindableProperty.Create(
        nameof(HasItemsInCart), typeof(bool), typeof(Toolbar), default(bool));

        public bool HasItemsInCart
        {
            get { return (bool)GetValue(HasItemsInCartProperty); }
            set { SetValue(HasItemsInCartProperty, value); }
        }
        private async void imgMenu_Clicked(object sender, EventArgs e)
        {
            if (!Hasmenu)
             await   Navigation.PopAsync();
            else
             menueclick?.Invoke(this,"ali");
        }
    }
}