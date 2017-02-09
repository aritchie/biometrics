# This library is no longer supported. Please use https://www.nuget.org/packages/Plugin.Fingerprint/

ACR Biometrics (Fingerprint Sensor) For Xamarin and Windows
===

## Setup

Make sure to include the nuget package in your app projects as well as your shared/PCL library

For Android support, you need to add the following to your AndroidManifest.xml:

    <uses-permission android:name="com.samsung.android.providers.context.permission.WRITE_USE_APP_FEATURE_SURVEY" />
    <uses-permission android:name="android.permission.USE_FINGERPRINT" />

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
* Android - Marshmallow and Samsung Support

## Thanks

Android Binding for Samsung Pass courtesy of (Shane Raiteri)
https://github.com/sraiteri/Xamarin-Samsung-Pass
