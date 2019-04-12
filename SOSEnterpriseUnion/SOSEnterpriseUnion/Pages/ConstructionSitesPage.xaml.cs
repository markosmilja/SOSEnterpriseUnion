using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SOSEnterpriseUnion.Models;
using SOSEnterpriseUnion.Pages;
using SOSEnterpriseUnion.PageModels;

namespace SOSEnterpriseUnion.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class ConstructionSitesPage : ContentPage
    {
        ConstructionSitesPageModel PageModel;
        private bool loggingIn = false;

        public ConstructionSitesPage()
        {
            InitializeComponent();

            BindingContext = PageModel = new ConstructionSitesPageModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ConstructionSitePage(new ConstructionSitePageModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!loggingIn)
            {
                loggingIn = true;
                if (!BasePageModel.IsLoggedIn)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
                    BasePageModel.IsLoggedIn = true;
                }
            }

            if (PageModel.Items.Count == 0)
                PageModel.LoadItemsCommand.Execute(null);
        }
    }
}