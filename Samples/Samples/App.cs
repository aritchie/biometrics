using System;
using System.Diagnostics;
using Acr.Biometrics;
using Xamarin.Forms;


namespace Samples {

    public class App : Application {

        //<uses-permission android:name="com.samsung.android.providers.context.permission.WRITE_USE_APP_FEATURE_SURVEY" />
        public App() {
            this.MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
						new Button {
							Text = Biometrics.Instance.IsAvailable
                                ? "Biometrics Available"
                                : "Service Not Available",
                            Command = new Command(async () => {
                                if (!Biometrics.Instance.IsAvailable)
                                    return;

                                var result = await Biometrics.Instance.Evaluate("Testing Biometrics");
                                Debug.WriteLine("Result: " + result);
                            })
						}
					}
                }
            };
        }
    }
}
