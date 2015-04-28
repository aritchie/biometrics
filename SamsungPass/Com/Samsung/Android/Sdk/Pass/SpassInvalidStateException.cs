using System;
using Android.Runtime;

namespace Com.Samsung.Android.Sdk.Pass
{
    [Register (SpassInvalidStateException.JniName, DoNotGenerateAcw=true)]
	public class SpassInvalidStateException : Java.Lang.IllegalStateException
    {
        public const string JniName = "com/samsung/android/sdk/pass/SpassInvalidStateException";

        #region JavaObject
        static readonly IntPtr _classRef = JNIEnv.FindClass (JniName);

        static IntPtr _constructor;

        [Register (".ctor", "(Ljava/lang/String;I)V", "")]
        public SpassInvalidStateException (string message, int errorType) : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
        {
            if (Handle != IntPtr.Zero)
                return;

            //Create Android Callable Wrapper for derived type
            if (GetType () != typeof (SpassInvalidStateException)) 
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

        public SpassInvalidStateException (IntPtr handle, JniHandleOwnership transfer)
            : base (handle, transfer)
        {
        }

        protected override Type ThresholdType {
            get { return typeof (SpassInvalidStateException); }
        }

        protected override IntPtr ThresholdClass {
            get { return _classRef; }
        }
        #endregion

        #region Static Methods/Fields
        static IntPtr _statusOperationDenied;
        public static int StatusOperationDenied 
        {
            get {
                if (_statusOperationDenied == IntPtr.Zero)
                    _statusOperationDenied = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_OPERATION_DENIED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusOperationDenied);
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

