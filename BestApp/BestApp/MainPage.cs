using System;
using System.Net.Http;
using System.Reflection;
using Xamarin.Forms;

namespace BestApp
{
    class MainPage : ContentPage
    {
        private readonly Entry DeskalertsUrlEntry;
        private readonly Entry UsernameEntry;
        private readonly Entry PasswordEntry;
        private readonly Label DeskAlertsUrlError;
        private readonly Label UsernameError;
        private readonly Label PasswordError;
        private readonly Button LoginButton;

        public MainPage()
        {
            Padding = new Thickness(20, 20, 20, 20);

            var layout = new StackLayout{
                Spacing = 15
            };

            layout.Children.Add(new Label
            {
                Text = "Enter Deskalerts server adress:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            layout.Children.Add(DeskAlertsUrlError = new Label
            {
                IsVisible = false,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            });

            layout.Children.Add(DeskalertsUrlEntry = new Entry());

            layout.Children.Add(new Label
            {
                Text = "Enter publisher username:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            layout.Children.Add(UsernameError = new Label
            {
                IsVisible = false,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            });

            layout.Children.Add(UsernameEntry = new Entry());

            layout.Children.Add(new Label
            {
                Text = "Enter publisher password:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            layout.Children.Add(PasswordError = new Label
            {
                IsVisible = false,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            });

            layout.Children.Add(PasswordEntry = new Entry()
            {
                IsPassword = true
            });

            layout.Children.Add(LoginButton = new Button
            {
                Text = "Login"
            });

            LoginButton.Clicked += OnLogin;

            Content = layout;
        }

        private void OnLogin(object sender, EventArgs e) 
        {
            ResetValidation();

            var isValidationErrorOccured = false;
            var deskalertsUrl = new Uri("http://blank.com");
            
            if (DeskalertsUrlEntry.Text == null ||
                !Uri.TryCreate(DeskalertsUrlEntry.Text, UriKind.Absolute, out deskalertsUrl) &&
                (deskalertsUrl.Scheme == Uri.UriSchemeHttp || deskalertsUrl.Scheme == Uri.UriSchemeHttps))
            {
                DeskalertsUrlEntry.BackgroundColor = Color.Red;
                DeskAlertsUrlError.Text = "Sorry, we can't recognize it as valid URL, please try again :(";
                DeskAlertsUrlError.IsVisible = true;
                isValidationErrorOccured = true;
            }

            if (UsernameEntry.Text == null || 
                UsernameEntry.Text.Length == 0)
            {
                UsernameEntry.BackgroundColor = Color.Red;
                UsernameError.Text = "Sorry, you should enter username, please try again :(";
                UsernameError.IsVisible = true;
                isValidationErrorOccured = true;
            }

            if (PasswordEntry.Text == null || 
                PasswordEntry.Text.Length == 0)
            {
                PasswordEntry.BackgroundColor = Color.Red;
                PasswordError.Text = "Sorry, you should enter password, please try again :(";
                PasswordError.IsVisible = true;
                isValidationErrorOccured = true;
            }

            if(isValidationErrorOccured)
            {
                return;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = deskalertsUrl;

                var message = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,

                };

                client.SendAsync(message);
            }
        }

        private void ResetValidation()
        {
            DeskalertsUrlEntry.BackgroundColor = Color.White;
            DeskAlertsUrlError.Text = "";
            DeskAlertsUrlError.IsVisible = false;

            UsernameError.BackgroundColor = Color.White;
            UsernameError.Text = "";
            UsernameError.IsVisible = false;

            PasswordError.BackgroundColor = Color.White;
            PasswordError.Text = "";
            PasswordError.IsVisible = false;
        }
    }
}
