using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SOSEnterpriseUnion.Services;
using SOSEnterpriseUnion.Pages;
using SOSEnterpriseUnion.Models;

namespace SOSEnterpriseUnion
{
    public partial class App : Application
    {
        public static IDataStore<Gradiliste> DataStore;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
