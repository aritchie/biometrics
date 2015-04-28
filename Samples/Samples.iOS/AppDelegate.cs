using System;
using Acr.Biometrics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


namespace Samples.iOS {

    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate {

        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            Forms.Init();
            Biometrics.Init();
            this.LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
