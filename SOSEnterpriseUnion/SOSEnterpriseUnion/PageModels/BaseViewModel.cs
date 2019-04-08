using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SOSEnterpriseUnion.Models;
using SOSEnterpriseUnion.Services;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

namespace SOSEnterpriseUnion.PageModels
{
    public class BasePageModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> StringCollection = new ObservableCollection<string>();
        public Dictionary<string, Dictionary<string, int>> StringIndexDictionary = new Dictionary<string, Dictionary<string, int>>();

        public List<string> Languages = new List<string>() { Serbian, Engish };
        public string SelectedLanguage;
        public string SelectedLangugeSettings = "Language";

        #region Languages

        public const string Serbian = "Srpski";
        public const string Engish = "English";
        public const string German = "Deutsch";

        #endregion

        #region Strings

        public static string LoginUsername = "LoginUsername";
        public static string LoginPassword = "LoginPassword";
        public static string LoginButton = "LoginButton";

        #endregion

        public BasePageModel()
        {
            foreach (var language in Languages)
                StringIndexDictionary.Add(language, new Dictionary<string, int>());

            AddStringToCollection(Serbian, LoginPassword, "Upišite lozinku:");
            AddStringToCollection(Serbian, LoginButton, "Prijavite se");

            AddStringToCollection(Engish, LoginPassword, "Password:");
            AddStringToCollection(Engish, LoginButton, "Login");

            SelectedLanguage = Preferences.Get(SelectedLangugeSettings, Serbian);
            LoadLangunage(SelectedLanguage);
        }

        public void LoadLangunage(string language)
        {
            StringCollection.Clear();
            foreach (var keyValue in StringIndexDictionary[language])
                StringCollection.Insert(keyValue.Value, keyValue.Key);
        }

        public void AddStringToCollection(string language, string key, string value)
        {
            StringIndexDictionary[language].Add(key, StringIndexDictionary[language].Count);
        }

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
