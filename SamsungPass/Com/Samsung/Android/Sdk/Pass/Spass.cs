using System;
using Android.Runtime;
using Android.Content;

namespace Com.Samsung.Android.Sdk.Pass
{
    [Register (Spass.JniName, DoNotGenerateAcw=true)]
    public class Spass : Java.Lang.Object
    {
        public const string JniName = "com/samsung/android/sdk/pass/Spass";

        #region JavaObject
        static readonly IntPtr _classRef = JNIEnv.FindClass (JniName);

        static IntPtr _constructor;

        [Register (".ctor", "()V", "")]
        public Spass () : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
        {
            if (Handle != IntPtr.Zero)
                return;

            //Create Android Callable Wrapper for derived type
            if (GetType () != typeof (Spass)) 
            {
                SetHandle (JNIEnv.CreateInstance (GetType (), "()V"), JniHandleOwnership.TransferLocalRef);
                return;
            }
                
            //Create the Handle from the constructor
            if (_constructor == IntPtr.Zero)
                _constructor = JNIEnv.GetMethodID (_classRef, "<init>", "()V");
            SetHandle (JNIEnv.NewObject (_classRef, _constructor), JniHandleOwnership.TransferLocalRef);
        }

        public Spass (IntPtr handle, JniHandleOwnership transfer)
            : base (handle, transfer)
        {
        }

        protected override Type ThresholdType {
            get { return typeof (Spass); }
        }

        protected override IntPtr ThresholdClass {
            get { return _classRef; }
        }
        #endregion

        #region Static Methods/Fields
        static IntPtr _deviceFingerprint;
        public static int DeviceFingerprint 
        {
            get {
                if (_deviceFingerprint == IntPtr.Zero)
                    _deviceFingerprint = JNIEnv.GetStaticFieldID(_classRef,
                        "DEVICE_FINGERPRINT", "I");

                return JNIEnv.GetStaticIntField(_classRef, _deviceFingerprint);
            }
        }

        static IntPtr _deviceFingerprintCustomizedDialog;
        public static int DeviceFingerprintCustomizedDialog 
        {
            get {
                if (_deviceFingerprintCustomizedDialog == IntPtr.Zero)
                    _deviceFingerprintCustomizedDialog = JNIEnv.GetStaticFieldID(_classRef,
                        "DEVICE_FINGERPRINT_CUSTOMIZED_DIALOG", "I");

                return JNIEnv.GetStaticIntField(_classRef, _deviceFingerprintCustomizedDialog);
            }
        }

        static IntPtr _deviceFingerprintFingerIndex;
        public static int DeviceFingerprintFingerIndex 
        {
            get {
                if (_deviceFingerprintFingerIndex == IntPtr.Zero)
                    _deviceFingerprintFingerIndex = JNIEnv.GetStaticFieldID(_classRef,
                        "DEVICE_FINGERPRINT_FINGER_INDEX", "I");

                return JNIEnv.GetStaticIntField(_classRef, _deviceFingerprintFingerIndex);
            }
        }
                   
        static IntPtr _deviceFingerprintUniqueId;
        public static int DeviceFingerprintUniqueId 
        {
            get {
                if (_deviceFingerprintUniqueId == IntPtr.Zero)
                    _deviceFingerprintUniqueId = JNIEnv.GetStaticFieldID(_classRef,
                        "DEVICE_FINGERPRINT_UNIQUE_ID", "I");

                return JNIEnv.GetStaticIntField(_classRef, _deviceFingerprintUniqueId);
            }
        }

        #endregion

        #region Instance Methods/Fields
        IntPtr _versionCode;
        public int VersionCode
        {
            get 
            { 
                if (_versionCode == IntPtr.Zero)
                    _versionCode = JNIEnv.GetMethodID (_classRef, "getVersionCode", "()I");

                return JNIEnv.CallIntMethod(Handle, _versionCode);
            }
        }

        IntPtr _versionName;
        public string VersionName
        {
            get 
            { 
                if (_versionName == IntPtr.Zero)
                    _versionName = JNIEnv.GetMethodID (_classRef, "getVersionName", "()Ljava/lang/String;");

                var resultPtr = JNIEnv.CallObjectMethod(Handle, _versionName);
				return new Java.Lang.Object(resultPtr, JniHandleOwnership.TransferLocalRef).JavaCast<Java.Lang.String>().ToString();
            }
        }

        IntPtr _initialize;
		[Java.Interop.Export (Throws = new [] {
			typeof (SsdkUnsupportedException)})]
		public void Initialize(Context context)
        {
            if (_initialize == IntPtr.Zero)
                _initialize = JNIEnv.GetMethodID (_classRef, "initialize", "(Landroid/content/Context;)V");

			try {
				JNIEnv.CallVoidMethod(Handle, _initialize, new JValue(context));
			} catch (Java.Lang.Exception e) {
				//TODO: Workaround until Java exception is cast to the C# exception
				if (e.Class.Name.Equals ("com.samsung.android.sdk.SsdkUnsupportedException"))
					throw new SsdkUnsupportedException (e.Handle, JniHandleOwnership.DoNotTransfer);

				throw e;
			}
        }

        IntPtr _isFeatureEnabled;
        public bool IsFeatureEnabled(int feature)
        {
            if (_isFeatureEnabled == IntPtr.Zero)
                _isFeatureEnabled = JNIEnv.GetMethodID (_classRef, "isFeatureEnabled", "(I)Z");

            return JNIEnv.CallBooleanMethod(Handle, _isFeatureEnabled, new JValue(feature));
        }
        #endregion
    }
}

