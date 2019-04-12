using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SOSEnterpriseUnion.Models;
using SOSEnterpriseUnion.PageModels;

namespace SOSEnterpriseUnion.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class ConstructionSitePage : ContentPage
    {
        ConstructionSitePageModel PageModel;

        public ConstructionSitePage(ConstructionSitePageModel PageModel)
        {
            InitializeComponent();

            BindingContext = this.PageModel = PageModel;
        }

        public ConstructionSitePage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            PageModel = new ConstructionSitePageModel(item);
            BindingContext = PageModel;
        }
    }
}