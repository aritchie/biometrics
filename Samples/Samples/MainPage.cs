using System;
using Acr.Biometrics;
using Xamarin.Forms;


namespace Samples {

    public class MainPage : ContentPage {
        readonly Button btnTest;


        public MainPage() {
            this.btnTest = new Button {
                Command = new Command(async () => {
                    var result = await Biometrics.Instance.Evaluate("Testing Biometrics");
                    this.btnTest.Text = result ? "SUCCESS" : "FAILED";
                })
            };

            this.Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                Children = { this.btnTest }
            };
        }


        protected override async void OnAppearing() {
            base.OnAppearing();
            var flag = await Biometrics.Instance.IsAvailable();
            this.btnTest.Text = flag ? "Biometrics Available" : "Service Not Available";
        }
    }
}
