using System;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Hardware.Fingerprints;
using Android.OS;
using Java.Lang;


namespace Acr.Biometrics {

    //<uses-permission android:name="android.permission.USE_FINGERPRINT" />
    public class MarshmallowBiometricsImpl : FingerprintManager.AuthenticationCallback, IBiometrics {
        readonly FingerprintManager scanner;
        readonly bool available;
        TaskCompletionSource<bool> scanEval;



        public MarshmallowBiometricsImpl() {
            this.scanner = (FingerprintManager)Application.Context.GetSystemService(Context.FingerprintService);
            if (Build.VERSION.SdkInt < BuildVersionCodes.M)
                this.available = false;

            else if (!this.scanner.IsHardwareDetected)
                this.available = false;

            else if (Application.Context.CheckCallingOrSelfPermission(Manifest.Permission.UseFingerprint) != Permission.Granted)
                this.available = false;

            else if (!this.scanner.HasEnrolledFingerprints)
                this.available = false;

            else
                this.available = true;
        }


        public Task<bool> IsAvailable() {
            return Task.FromResult(this.available);
        }


        public async Task<bool> Evaluate(string message) {
            if (!this.available)
                return false;

            this.scanEval = new TaskCompletionSource<bool>();
            this.scanner.Authenticate(null, new CancellationSignal(), FingerprintAuthenticationFlags.None, this, null);
            var result = await this.scanEval.Task;
            this.scanEval = null;

            return result;
        }



        public override void OnAuthenticationError(FingerprintState errorCode, ICharSequence errString) {
            base.OnAuthenticationError(errorCode, errString);
            this.scanEval.TrySetResult(false);
        }


        public override void OnAuthenticationFailed() {
            base.OnAuthenticationFailed();
            this.scanEval.TrySetResult(false);
        }


        public override void OnAuthenticationSucceeded(FingerprintManager.AuthenticationResult result) {
            base.OnAuthenticationSucceeded(result);
            this.scanEval.TrySetResult(true);
        }
    }
}