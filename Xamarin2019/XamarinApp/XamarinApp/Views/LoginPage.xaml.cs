using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.Views.Menu;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            LBLUser.TextColor = Constants.MainTextColor;
            LBLPass.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            App.StartCheckIfInternet(lbl_NoInternet, this);

            // kad korisnik završi tipkanje korisnickog imena
            EnUser.Completed += (s, e) => ENPass.Focus();
            ENPass.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            User u = new User(EnUser.Text, ENPass.Text);
            if (u.CheckInformation())
            {
                await DisplayAlert("Information", "Success", "OK");
                //var result = await App.RestService.Login(u); // Naći/napraviti server!!!
                var result = new Token();
                if (result != null) {
                    //App.UserDatabase.SaveUser(u);
                    //App.TokenDatabase.SaveToken(result);
                    if (Device.RuntimePlatform == Device.Android) {
                        // Device.OS = TargetPlatform.Android je obsolete
                        Application.Current.MainPage = new NavigationPage(new MasterDetail());
                    }
                }
            }
            else
                await DisplayAlert("Information", "Login Failed", "OK");
        }
    }
}