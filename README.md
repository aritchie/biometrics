ACR Biometrics (Fingerprint Sensor) For Xamarin (iOS & Android)
===

Make sure to include the nuget package in your app projects as well as your shared/PCL library

For Android only, please add the following to your AndroidManifest.xml

    <uses-permission android:name="com.samsung.android.providers.context.permission.WRITE_USE_APP_FEATURE_SURVEY" />

And then in your shared/PCL library, simply check if the sensor is available:

    if (Biometrics.Instance.IsAvailable) {
        var success = await Biometrics.Instance.Evaluate("Your custom message");
        if (success) {
            ...
        }
    }

NOTE: Currently, fingerprint sensors only work with Samsung enabled devices

Android Binding for Samsung Pass courtesy of (Shane Raiteri)
https://github.com/sraiteri/Xamarin-Samsung-Pass