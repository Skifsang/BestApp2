using System;
using Xamarin.Forms;

namespace BestApp
{
    class MainPage : ContentPage
    {
        private readonly Entry DeskalertsUrl;
        private readonly Entry Username;
        private readonly Entry Password;
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

            layout.Children.Add(DeskalertsUrl = new Entry());

            layout.Children.Add(new Label
            {
                Text = "Enter publisher username:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            layout.Children.Add(Username = new Entry());

            layout.Children.Add(new Label
            {
                Text = "Enter publisher password:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            layout.Children.Add(Password = new Entry()
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

        }
    }
}
