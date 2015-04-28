using System;
using Android.Runtime;

namespace Com.Samsung.Android.Sdk
{
	[Register (SsdkUnsupportedException.JniName, DoNotGenerateAcw=true)]
	public class SsdkUnsupportedException : Java.Lang.Exception
    {
        public const string JniName = "com/samsung/android/sdk/SsdkUnsupportedException";

        #region JavaObject
        static readonly IntPtr _classRef = JNIEnv.FindClass (JniName);

        static IntPtr _constructor;

        [Register (".ctor", "(Ljava/lang/String;I)V", "")]
        public SsdkUnsupportedException (string message, int errorType) : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
        {
            if (Handle != IntPtr.Zero)
                return;

            //Create Android Callable Wrapper for derived type
            if (GetType () != typeof (SsdkUnsupportedException)) 
            {
                SetHandle (JNIEnv.CreateInstance (GetType (), "(Ljava/lang/String;I)V"), JniHandleOwnership.TransferLocalRef);
                return;
            }

            //Create the Handle from the constructor
            if (_constructor == IntPtr.Zero)
                _constructor = JNIEnv.GetMethodID (_classRef, "<init>", "(Ljava/lang/String;I)V");
            SetHandle (JNIEnv.NewObject (_classRef, _constructor, new JValue(new Java.Lang.String(message)), 
                new JValue(errorType)), JniHandleOwnership.TransferLocalRef);
        }

        public SsdkUnsupportedException (IntPtr handle, JniHandleOwnership transfer)
            : base (handle, transfer)
        {
        }

        protected override Type ThresholdType {
            get { return typeof (SsdkUnsupportedException); }
        }

        protected override IntPtr ThresholdClass {
            get { return _classRef; }
        }
        #endregion

        #region Static Methods/Fields
        static IntPtr _deviceNotSupported;
        public static int DeviceNotSupported 
        {
            get {
                if (_deviceNotSupported == IntPtr.Zero)
                    _deviceNotSupported = JNIEnv.GetStaticFieldID(_classRef,
                        "DEVICE_NOT_SUPPORTED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _deviceNotSupported);
            }
        }

        static IntPtr _libraryNotInstalled;
        public static int LibraryNotInstalled 
        {
            get {
                if (_libraryNotInstalled == IntPtr.Zero)
                    _libraryNotInstalled = JNIEnv.GetStaticFieldID(_classRef,
                        "LIBRARY_NOT_INSTALLED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _libraryNotInstalled);
            }
        }

        static IntPtr _libraryUpdateIsRecommended;
        public static int LibraryUpdateIsRecommended 
        {
            get {
                if (_libraryUpdateIsRecommended == IntPtr.Zero)
                    _libraryUpdateIsRecommended = JNIEnv.GetStaticFieldID(_classRef,
                        "LIBRARY_UPDATE_IS_RECOMMENDED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _libraryUpdateIsRecommended);
            }
        }

        static IntPtr _libraryUpdateIsRequired;
        public static int LibraryUpdateIsRequired
        {
            get {
                if (_libraryUpdateIsRequired == IntPtr.Zero)
                    _libraryUpdateIsRequired = JNIEnv.GetStaticFieldID(_classRef,
                        "LIBRARY_UPDATE_IS_REQUIRED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _libraryUpdateIsRequired);
            }
        }

        static IntPtr _vendorNotSupported;
        public static int VendorNotSupported
        {
            get {
                if (_vendorNotSupported == IntPtr.Zero)
                    _vendorNotSupported = JNIEnv.GetStaticFieldID(_classRef,
                        "VENDOR_NOT_SUPPORTED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _vendorNotSupported);
            }
        }
        #endregion

        #region Instance Methods/Fields
        IntPtr _type;
        public int Type
        {
            get 
            { 
                if (_type == IntPtr.Zero)
                    _type = JNIEnv.GetMethodID (_classRef, "getType", "()I");

                return JNIEnv.CallIntMethod(Handle, _type);
            }
        }
        #endregion
    }
}

