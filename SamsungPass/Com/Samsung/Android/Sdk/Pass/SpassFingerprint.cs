using System;
using Android.Runtime;
using Android.Content;
using Android.Util;
using Java.Util;
using System.Collections.Generic;

namespace Com.Samsung.Android.Sdk.Pass
{
    #region SpassFingerprint
    [Register (SpassFingerprint.JniName, DoNotGenerateAcw=true)]
    public class SpassFingerprint : Java.Lang.Object
    {
        public const string JniName = "com/samsung/android/sdk/pass/SpassFingerprint";

        #region JavaObject
        static readonly IntPtr _classRef = JNIEnv.FindClass (JniName);

        static IntPtr _constructor;         
        [Register (".ctor", "(Landroid/content/Context;)V", "")]
        public SpassFingerprint (Context context) : base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
        {
            if (Handle != IntPtr.Zero)
                return;

            //Create Android Callable Wrapper for derived type
            if (GetType () != typeof (SpassFingerprint)) 
            {
                SetHandle (JNIEnv.CreateInstance (GetType (), "(Landroid/content/Context;)V", new JValue(context)),
                    JniHandleOwnership.TransferLocalRef);
                return;
            }

            //Create the Handle from the constructor
            if (_constructor == IntPtr.Zero)
                _constructor = JNIEnv.GetMethodID (_classRef, "<init>", "(Landroid/content/Context;)V");
            SetHandle (JNIEnv.NewObject (_classRef, _constructor, new JValue(context)), 
                JniHandleOwnership.TransferLocalRef);
        }

        public SpassFingerprint (IntPtr handle, JniHandleOwnership transfer)
            : base (handle, transfer)
        {
        }

        protected override Type ThresholdType {
            get { return typeof (SpassFingerprint); }
        }

        protected override IntPtr ThresholdClass {
            get { return _classRef; }
        }
        #endregion

        #region Static Methods/Fields
        static IntPtr _statusAuthentificationFailed;
        public static int StatusAuthentificationFailed 
        {
            get {
                if (_statusAuthentificationFailed == IntPtr.Zero)
                    _statusAuthentificationFailed = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_AUTHENTIFICATION_FAILED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusAuthentificationFailed);
            }
        }

        static IntPtr _statusAuthentificationPasswordSuccess;
        public static int StatusAuthentificationPasswordSuccess 
        {
            get {
                if (_statusAuthentificationPasswordSuccess == IntPtr.Zero)
                    _statusAuthentificationPasswordSuccess = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_AUTHENTIFICATION_PASSWORD_SUCCESS", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusAuthentificationPasswordSuccess);
            }
        }

        static IntPtr _statusAuthentificationSuccess;
        public static int StatusAuthentificationSuccess 
        {
            get {
                if (_statusAuthentificationSuccess == IntPtr.Zero)
                    _statusAuthentificationSuccess = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_AUTHENTIFICATION_SUCCESS", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusAuthentificationSuccess);
            }
        }
            
        static IntPtr _statusSensorFailed;
        public static int StatusSensorFailed 
        {
            get {
                if (_statusSensorFailed == IntPtr.Zero)
                    _statusSensorFailed = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_SENSOR_FAILED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusSensorFailed);
            }
        }

        static IntPtr _statusQualityFailed;
        public static int StatusQualityFailed 
        {
            get {
                if (_statusQualityFailed == IntPtr.Zero)
                    _statusQualityFailed = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_QUALITY_FAILED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusQualityFailed);
            }
        }

        static IntPtr _statusTimeoutFailed;
        public static int StatusTimeoutFailed 
        {
            get {
                if (_statusTimeoutFailed == IntPtr.Zero)
                    _statusTimeoutFailed = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_TIMEOUT_FAILED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusTimeoutFailed);
            }
        }

        static IntPtr _statusUserCancelled;
        public static int StatusUserCancelled 
        {
            get {
                if (_statusUserCancelled == IntPtr.Zero)
                    _statusUserCancelled = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_USER_CANCELLED", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusUserCancelled);
            }
        }

        static IntPtr _statusUserCancelledByTouchOutside;
        public static int StatusUserCancelledByTouchOutside 
        {
            get {
                if (_statusUserCancelledByTouchOutside == IntPtr.Zero)
                    _statusUserCancelledByTouchOutside = JNIEnv.GetStaticFieldID(_classRef,
                        "STATUS_USER_CANCELLED_BY_TOUCH_OUTSIDE", "I");

                return JNIEnv.GetStaticIntField(_classRef, _statusUserCancelledByTouchOutside);
            }
        }                 
        #endregion

        #region Instance Methods/Fields

        IntPtr _cancelIdentify;
        public void CancelIdentify()
        {
            if (_cancelIdentify == IntPtr.Zero)
                _cancelIdentify = JNIEnv.GetMethodID (_classRef, "cancelIdentify", "()V");

            JNIEnv.CallVoidMethod(Handle, _cancelIdentify);
        }

        IntPtr _identifiedFingerprintIndex;
        public int IdentifiedFingerprintIndex
        {
            get {
                if (_identifiedFingerprintIndex == IntPtr.Zero)
                    _identifiedFingerprintIndex = JNIEnv.GetMethodID(_classRef, "getIdentifiedFingerprintIndex", "()I");

                return JNIEnv.CallIntMethod(Handle, _identifiedFingerprintIndex);
            }
        }

        IntPtr _registeredFingerprintName;
		public IList<string> RegisteredFingerprintName
        {
            get {
                if (_registeredFingerprintName == IntPtr.Zero)
                    _registeredFingerprintName = JNIEnv.GetMethodID(_classRef, "getRegisteredFingerprintName", "()Landroid/util/SparseArray;");

                var resultPtr = JNIEnv.CallObjectMethod(Handle, _registeredFingerprintName);
				SparseArray sparseArray = new Java.Lang.Object (resultPtr, JniHandleOwnership.TransferLocalRef).JavaCast<SparseArray>();
				return new List<string> (sparseArray.ToArray<string> ());
            }
        }

        IntPtr _registeredFingerprintUniqueId;
		public IList<string> RegisteredFingerprintUniqueId
        {
            get {
                if (_registeredFingerprintUniqueId == IntPtr.Zero)
                    _registeredFingerprintUniqueId = JNIEnv.GetMethodID(_classRef, "getRegisteredFingerprintUniqueID", "()Landroid/util/SparseArray;");

				var resultPtr = JNIEnv.CallObjectMethod(Handle, _registeredFingerprintUniqueId);
				SparseArray sparseArray = new Java.Lang.Object (resultPtr, JniHandleOwnership.TransferLocalRef).JavaCast<SparseArray>();
				return new List<string> (sparseArray.ToArray<string> ());
            }
        }
            
        IntPtr _hasRegisteredFinger;
        public bool HasRegisteredFinger
        {
            get 
            { 
                if (_hasRegisteredFinger == IntPtr.Zero)
                    _hasRegisteredFinger = JNIEnv.GetMethodID (_classRef, "hasRegisteredFinger", "()Z");

                return JNIEnv.CallBooleanMethod(Handle, _hasRegisteredFinger);
            }
        }

        IntPtr _registerFinger;
        public void RegisteredFinger(Context context, IRegisterListener listener)
        {
            if (_registerFinger == IntPtr.Zero)
                _registerFinger = JNIEnv.GetMethodID (_classRef, "registerFinger", 
                    "(Landroid/content/Context;Lcom/samsung/android/sdk/pass/SpassFingerprint$RegisterListener;)V");

            JNIEnv.CallVoidMethod(Handle, _registerFinger, new JValue(context), new JValue(listener));
        }

        IntPtr _setCanceledOnTouchOutside;
        public void SetCanceledOnTouchOutside(bool cancel)
        {
            if (_setCanceledOnTouchOutside == IntPtr.Zero)
                _setCanceledOnTouchOutside = JNIEnv.GetMethodID (_classRef, "setCanceledOnTouchOutside", 
                    "(Z)V");

            JNIEnv.CallBooleanMethod(Handle, _setCanceledOnTouchOutside, new JValue(cancel));
        }

        IntPtr _setDialogBgTransparency;
        public void SetDialogBgTransparency(int transparency)
        {
            if (_setDialogBgTransparency == IntPtr.Zero)
                _setDialogBgTransparency = JNIEnv.GetMethodID(_classRef, "setDialogBgTransparency", "(I)V");

            JNIEnv.CallVoidMethod(Handle, _setDialogBgTransparency, new JValue(transparency));
        }

        IntPtr _setDialogIcon;
        public void SetDialogIcon(string iconName)
        {
            if (_setDialogIcon == IntPtr.Zero)
                _setDialogIcon = JNIEnv.GetMethodID(_classRef, "setDialogIcon", "(Ljava/lang/String;)V");

            JNIEnv.CallVoidMethod(Handle, _setDialogIcon, new JValue(new Java.Lang.String(iconName)));
        }

        IntPtr _setDialogTitle;
        public void SetDialogTitle(string titleText, int titleColor)
        {
            if (_setDialogTitle == IntPtr.Zero)
                _setDialogTitle = JNIEnv.GetMethodID(_classRef, "setDialogTitle", "(Ljava/lang/String;I)V");

            JNIEnv.CallVoidMethod(Handle, _setDialogTitle, new JValue(new Java.Lang.String(titleText)), new JValue(titleColor));
        }

        IntPtr _setIntendedFingerprintIndex;
        public void SetIntendedFingerprintIndex(ArrayList requestedIndex)
        {
            if (_setIntendedFingerprintIndex == IntPtr.Zero)
                _setIntendedFingerprintIndex = JNIEnv.GetMethodID(_classRef, "setIntendedFingerprintIndex", "(Ljava/util/ArrayList;)V");

            JNIEnv.CallVoidMethod(Handle, _setIntendedFingerprintIndex, new JValue(requestedIndex));
        }

        IntPtr _startIdentify;
		[Java.Interop.Export (Throws = new [] {
			typeof (SpassInvalidStateException)})]
        public void StartIdentify(IIdentifyListener listener)
        {
            if (_startIdentify == IntPtr.Zero)
                _startIdentify = JNIEnv.GetMethodID (_classRef, "startIdentify", "(Lcom/samsung/android/sdk/pass/SpassFingerprint$IdentifyListener;)V");

			try {
				JNIEnv.CallVoidMethod(Handle, _startIdentify, new JValue(listener));
			} catch (Java.Lang.Exception e) {
				//TODO: Workaround until Java exception is cast to the C# exception
				if (e.Class.Name.Equals ("com.samsung.android.sdk.pass.SpassInvalidStateException")) {
					throw new SpassInvalidStateException (e.Handle, JniHandleOwnership.DoNotTransfer);
				}
				throw e;
			}
        }

        IntPtr _startIdentifyWithDialog;
        public void StartIdentifyWithDialog(Context context, IIdentifyListener listener, bool enablePassword)
        {
            if (_startIdentifyWithDialog == IntPtr.Zero)
                _startIdentifyWithDialog = JNIEnv.GetMethodID (_classRef, "startIdentifyWithDialog", "(Landroid/content/Context;Lcom/samsung/android/sdk/pass/SpassFingerprint$IdentifyListener;Z)V");

            JNIEnv.CallVoidMethod(Handle, _startIdentifyWithDialog, new JValue(context), new JValue(listener), new JValue(enablePassword));
        }
        #endregion
    }
    #endregion

    #region SpassFingerprint.IdentifyListener

    [Register (IIdentifyListenerInvoker.JniName, DoNotGenerateAcw=true)]
    public interface IIdentifyListener : IJavaObject {
        [Register ("onFinished", "(I)V", "GetOnFinishedHandler:Com.Samsung.Android.Sdk.Pass.IIdentifyListenerInvoker, SamsungPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
        void OnFinished (int responseCode);

        [Register ("onReady", "()V", "GetOnReadyHandler:Com.Samsung.Android.Sdk.Pass.IIdentifyListenerInvoker, SamsungPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
        void OnReady ();

        [Register ("onStarted", "()V", "GetOnStartedHandler:Com.Samsung.Android.Sdk.Pass.IIdentifyListenerInvoker, SamsungPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
        void OnStarted ();
    }

    class IIdentifyListenerInvoker : Java.Lang.Object, IIdentifyListener {

        public const string JniName = "com/samsung/android/sdk/pass/SpassFingerprint$IdentifyListener";

        IntPtr _instanceClassRef;

        public IIdentifyListenerInvoker (IntPtr handle, JniHandleOwnership transfer)
            : base (handle, transfer)
        {
            IntPtr lref = JNIEnv.GetObjectClass (Handle);
            _instanceClassRef = JNIEnv.NewGlobalRef (lref);
            JNIEnv.DeleteLocalRef (lref);
        }

        protected override void Dispose (bool disposing)
        {
            if (_instanceClassRef != IntPtr.Zero)
                JNIEnv.DeleteGlobalRef (_instanceClassRef);
            _instanceClassRef = IntPtr.Zero;
            base.Dispose (disposing);
        }

        protected override Type ThresholdType {
            get {return typeof (IIdentifyListenerInvoker);}
        }

        protected override IntPtr ThresholdClass {
            get {return _instanceClassRef;}
        }

        public static IIdentifyListener GetObject (IntPtr handle, JniHandleOwnership transfer)
        {
            return new IIdentifyListenerInvoker (handle, transfer);
        }

        #region InterfaceMethods
        IntPtr _onFinished;
        static Delegate _onFinishedCallback;

        public void OnFinished(int responseCode)
        {
            if (_onFinished == IntPtr.Zero)
                _onFinished = JNIEnv.GetMethodID (_instanceClassRef, "onFinished", "(I)V");
            JNIEnv.CallVoidMethod (Handle, _onFinished,
                new JValue (responseCode));
        }

        #pragma warning disable 0169
        static Delegate GetOnFinishedHandler ()
        {
            if (_onFinishedCallback == null)
                _onFinishedCallback = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) InvokeOnFinished);
            return _onFinishedCallback;
        }

        static void InvokeOnFinished (IntPtr jnienv, IntPtr lrefThis, int resultCode)
        {
            IIdentifyListener __this = Java.Lang.Object.GetObject<IIdentifyListener>(lrefThis, JniHandleOwnership.DoNotTransfer);
            __this.OnFinished(resultCode);
        }
        #pragma warning restore 0169

        IntPtr _onReady;
        static Delegate _onReadyCallback;
        public void OnReady()
        {
            if (_onReady == IntPtr.Zero)
                _onReady = JNIEnv.GetMethodID (_instanceClassRef, "onReady", "()V");
            JNIEnv.CallVoidMethod (Handle, _onReady);
        }

        #pragma warning disable 0169
        static Delegate GetOnReadyHandler ()
        {
            if (_onReadyCallback == null)
                _onReadyCallback = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) InvokeOnReady);
            return _onReadyCallback;
        }

        static void InvokeOnReady (IntPtr jnienv, IntPtr lrefThis)
        {
            IIdentifyListener __this = Java.Lang.Object.GetObject<IIdentifyListener>(lrefThis, JniHandleOwnership.DoNotTransfer);
            __this.OnReady();
        }
        #pragma warning restore 0169

        IntPtr _onStarted;
        static Delegate _onStartedCallback;

        public void OnStarted()
        {
            if (_onStarted == IntPtr.Zero)
                _onStarted = JNIEnv.GetMethodID (_instanceClassRef, "onStarted", "()V");
            JNIEnv.CallVoidMethod (Handle, _onStarted);
        }
         
        #pragma warning disable 0169
        static Delegate GetOnStartedHandler ()
        {
            if (_onStartedCallback == null)
                _onStartedCallback = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) InvokeOnStarted);
            return _onStartedCallback;
        }

        static void InvokeOnStarted (IntPtr jnienv, IntPtr lrefThis)
        {
            var __this = Java.Lang.Object.GetObject<IIdentifyListener>(lrefThis, JniHandleOwnership.DoNotTransfer);
            __this.OnStarted();
        }
        #pragma warning restore 0169
        #endregion
    }

    #endregion

    #region SpassFingerprint.RegisterListener
    [Register (IRegisterListenerInvoker.JniName, DoNotGenerateAcw=true)]
    public interface IRegisterListener : IJavaObject {
        [Register ("onFinished", "()V", "GetOnFinishedHandler:Com.Samsung.Android.Sdk.Pass.IRegisterListenerInvoker, SamsungPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
        void OnFinished ();
    }

    class IRegisterListenerInvoker : Java.Lang.Object, IRegisterListener {

        public const string JniName = "com/samsung/android/sdk/pass/SpassFingerprint$RegisterListener";

        IntPtr _instanceClassRef;

        public IRegisterListenerInvoker (IntPtr handle, JniHandleOwnership transfer)
            : base (handle, transfer)
        {
            IntPtr lref = JNIEnv.GetObjectClass (Handle);
            _instanceClassRef = JNIEnv.NewGlobalRef (lref);
            JNIEnv.DeleteLocalRef (lref);
        }

        protected override void Dispose (bool disposing)
        {
            if (_instanceClassRef != IntPtr.Zero)
                JNIEnv.DeleteGlobalRef (_instanceClassRef);
            _instanceClassRef = IntPtr.Zero;
            base.Dispose (disposing);
        }

        protected override Type ThresholdType {
            get {return typeof (IRegisterListenerInvoker);}
        }

        protected override IntPtr ThresholdClass {
            get {return _instanceClassRef;}
        }

        public static IRegisterListenerInvoker GetObject (IntPtr handle, JniHandleOwnership transfer)
        {
            return new IRegisterListenerInvoker (handle, transfer);
        }

        #region Interface Methods
        IntPtr _onFinished;
        static Delegate _onFinishedCallback;
        public void OnFinished()
        {
            if (_onFinished == IntPtr.Zero)
                _onFinished = JNIEnv.GetMethodID (_instanceClassRef, "onFinished", "()V");
            JNIEnv.CallVoidMethod (Handle, _onFinished);
        }

        #pragma warning disable 0169
        static Delegate GetOnFinishedHandler ()
        {
            if (_onFinishedCallback == null)
                _onFinishedCallback = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) InvokeOnFinished);
            return _onFinishedCallback;
        }

        static void InvokeOnFinished (IntPtr jnienv, IntPtr lrefThis, int resultCode)
        {
			var __this = Java.Lang.Object.GetObject<IRegisterListener>(lrefThis, JniHandleOwnership.DoNotTransfer);
            __this.OnFinished();
        }
        #pragma warning restore 0169
        #endregion
    }
    #endregion
}

