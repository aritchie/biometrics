ACR Biometrics (Fingerprint Sensor) For Xamarin (iOS & Android)
===

Make sure to initialize in your platform (Main activity or AppDelegate):

    Biometrics.Init();

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