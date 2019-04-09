using SOSEnterpriseUnion.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOSEnterpriseUnion.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPageModel LoginPageModel;

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = LoginPageModel = new LoginPageModel();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (LoginPageModel.IsPasswordValid(passwordEntry.Text))
            {
                var mainPage = new MainPage();
                await Navigation.PushModalAsync(mainPage);
            }
            else
            {
                await DisplayAlert("Greška", "Pogrešna lozinka!", "Ok");
            }
        }
    }
}