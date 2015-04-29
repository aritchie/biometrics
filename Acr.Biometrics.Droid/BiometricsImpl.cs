using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.App;
using Com.Samsung.Android.Sdk;
using Com.Samsung.Android.Sdk.Pass;
using Java.Lang;


namespace Acr.Biometrics {

    public class BiometricsImpl : Java.Lang.Object, IBiometrics, IIdentifyListener, IRegisterListener {
        private readonly SpassFingerprint fingerprint;
        private TaskCompletionSource<bool> waitLock;

        public BiometricsImpl() {
            var spass = new Spass();

            try {
                spass.Initialize(Application.Context);
                if (spass.IsFeatureEnabled(Spass.DeviceFingerprint)) {
                    this.fingerprint = new SpassFingerprint(Application.Context);
                    this.IsAvailable = this.fingerprint.HasRegisteredFinger;
                }
            }
            catch (SsdkUnsupportedException ex) {
                Debug.WriteLine("Error Initializing: " + ex);
            }
            catch (UnsupportedOperationException ex) {
                Debug.WriteLine("Fingerprint Not Supported: " + ex);
            }
            catch (SecurityException ex) {
                Debug.WriteLine("Invalid App Permissions: " + ex);
                //<uses-permission android:name="com.samsung.android.providers.context.permission.WRITE_USE_APP_FEATURE_SURVEY" />
            }
        }


        public bool IsAvailable { get; private set; }


        public async Task<bool> Evaluate(string message) {
            if (!this.IsAvailable)
                return false;

            this.waitLock = new TaskCompletionSource<bool>();
            //this.fingerprint.StartIdentify(this);
            this.fingerprint.StartIdentifyWithDialog(Application.Context, this, true);
            var result = await this.waitLock.Task;
            this.waitLock = null;
            return result;
        }

        #region IIdentifyListener Members

        public void OnFinished(int responseCode) {
            var valid = (responseCode == SpassFingerprint.StatusAuthentificationSuccess);
            var name = GetResponseStatusName(responseCode);
            Debug.WriteLine("FingerPrint Response: " + name);
            if (this.waitLock != null)
                this.waitLock.TrySetResult(valid);
        }

        public void OnReady() {
        }

        public void OnStarted() {
        }

        #endregion

        #region IRegisterListener Members

        public void OnFinished() {
        }

        #endregion

        private static string GetResponseStatusName(int responseCode) {
			if (responseCode == SpassFingerprint.StatusAuthentificationSuccess)
				return "STATUS_AUTHENTIFICATION_SUCCESS";

			if (responseCode == SpassFingerprint.StatusAuthentificationPasswordSuccess)
				return "STATUS_AUTHENTIFICATION_PASSWORD_SUCCESS";

			if (responseCode == SpassFingerprint.StatusTimeoutFailed)
				return "STATUS_TIMEOUT";

			if (responseCode == SpassFingerprint.StatusTimeoutFailed)
				return "STATUS_SENSOR_ERROR";

			if (responseCode == SpassFingerprint.StatusSensorFailed)
				return "STATUS_USER_CANCELLED";

			if (responseCode == SpassFingerprint.StatusUserCancelled)
				return "STATUS_QUALITY_FAILED";

			if (responseCode == SpassFingerprint.StatusQualityFailed)
				return "STATUS_USER_CANCELLED_BY_TOUCH_OUTSIDE";

            return "STATUS_AUTHENTIFICATION_FAILED";
        }
    }
}