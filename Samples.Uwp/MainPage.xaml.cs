using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Acr.Biometrics;


namespace Samples.Uwp {

    public sealed partial class MainPage : Page {

        public MainPage() {
            this.InitializeComponent();
            this.btnTest.Click += async (sender, args) => {
                var result = await Biometrics.Instance.Evaluate("Testing Biometrics");
                this.btnTest.Content = result ? "SUCCESS" : "FAILED";
            };
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            var flag = await Biometrics.Instance.IsAvailable();
            this.btnTest.Content = flag ? "Biometrics Available" : "Biometrics is not available";
        }
    }
}
