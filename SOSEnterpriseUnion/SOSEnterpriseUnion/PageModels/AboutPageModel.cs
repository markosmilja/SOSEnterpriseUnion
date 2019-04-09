using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace SOSEnterpriseUnion.PageModels
{
    public class AboutPageModel : BasePageModel
    {
        public AboutPageModel() : base()
        {
            Title = "Kontakt";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}