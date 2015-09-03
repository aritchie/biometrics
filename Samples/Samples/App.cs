using System;
using Xamarin.Forms;


namespace Samples {

    public class App : Application {

        //<uses-permission android:name="com.samsung.android.providers.context.permission.WRITE_USE_APP_FEATURE_SURVEY" />
        public App() {
            this.MainPage = new MainPage();
        }
    }
}
