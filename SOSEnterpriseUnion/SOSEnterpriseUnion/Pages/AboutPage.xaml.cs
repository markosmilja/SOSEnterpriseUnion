using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOSEnterpriseUnion.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            var emailGestureRecognizer = new TapGestureRecognizer();
            emailGestureRecognizer.Tapped += async (s, e) => {
                try
                {
                    var label = (Label)s;
                    var message = new EmailMessage
                    {
                        Subject = "Naslov",
                        Body = "",
                        To = new List<string>() { label.Text },
                        //Cc = ccRecipients,
                        //Bcc = bccRecipients
                    };
                    await Email.ComposeAsync(message);
                }
                catch (FeatureNotSupportedException fbsEx)
                {
                    // Email is not supported on this device
                }
                catch (Exception ex)
                {
                    // Some other exception occurred
                }
            };
            emailLabelGojko.GestureRecognizers.Add(emailGestureRecognizer);
            emailLabelOffice.GestureRecognizers.Add(emailGestureRecognizer);

            var phoneGestureRecognizer = new TapGestureRecognizer();
            phoneGestureRecognizer.Tapped += (s, e) => {
                try
                {
                    PhoneDialer.Open(phoneLabel.Text.Replace(" ", string.Empty));
                }
                catch (ArgumentNullException anEx)
                {
                    // Number was null or white space
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Phone Dialer is not supported on this device.
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            };
            phoneLabel.GestureRecognizers.Add(phoneGestureRecognizer);
        }
    }
}