ACR Biometrics (Fingerprint Sensor) For Xamarin and Windows
===

## Setup

Make sure to include the nuget package in your app projects as well as your shared/PCL library

For Android only, please add the following to your AndroidManifest.xml

    <uses-permission android:name="com.samsung.android.providers.context.permission.WRITE_USE_APP_FEATURE_SURVEY" />

## Usage

In your shared/PCL library, simply check if the sensor is available:

    if (await Biometrics.Instance.IsAvailable()) {
        var success = await Biometrics.Instance.Evaluate("Your custom message");
        if (success) {
            ...
        }
    }

## Support

* Windows 10 (UWP)
* iOS 8+
* Android - Currently, fingerprint sensors only work with Samsung enabled devices

## Thanks

Android Binding for Samsung Pass courtesy of (Shane Raiteri)
https://github.com/sraiteri/Xamarin-Samsung-Pass