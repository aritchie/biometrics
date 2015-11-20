using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Hardware.Fingerprints;
using Android.OS;
using Java.Lang;


namespace Acr.Biometrics {

    //<uses-permission android:name="android.permission.USE_FINGERPRINT" />
    public class MarshmallowBiometricsImpl : FingerprintManager.AuthenticationCallback, IBiometrics {
        readonly FingerprintManager scanner;
        TaskCompletionSource<bool> scanEval;


        public MarshmallowBiometricsImpl() {
            this.scanner = (FingerprintManager)Application.Context.GetSystemService(Context.FingerprintService);
        }


        public virtual Task<bool> IsAvailable() {
            return Task.FromResult(
				this.scanner.IsHardwareDetected &&
                this.scanner.HasEnrolledFingerprints
            );
        }


        public virtual async Task<bool> Evaluate(string message) {
            if (this.scanEval != null)
                return false;

            this.scanEval = new TaskCompletionSource<bool>();
            this.scanner.Authenticate(null, new CancellationSignal(), FingerprintAuthenticationFlags.None, this, null);
            return await this.scanEval.Task;
        }


        public override void OnAuthenticationError(FingerprintState errorCode, ICharSequence errString) {
            base.OnAuthenticationError(errorCode, errString);
            this.scanEval.TrySetException(new ApplicationException(""));
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
/*
using System;
using Android.Content;
using Javax.Crypto;
using Java.Security;
using Java.Lang;
using Android.Views.InputMethods;
using Android.App;
using Android.Hardware.Fingerprints;
using Android.Security.Keystore;
using Android.Preferences;

namespace FingerprintDialog
{
	public class FingerprintModule
	{
		public Context Context { get; set; }

		public FingerprintModule (Context context)
		{
			Context = context;
		}

		public FingerprintManager ProvidesFingerprintManager (Context context)
		{
			return (FingerprintManager)context.GetSystemService ("FingerprintManager");
		}

		public KeyguardManager ProvidesKeyguardManager (Context context)
		{
			return (KeyguardManager)context.GetSystemService ("keyguard");
		}

		public KeyStore ProvidesKeystore ()
		{
			try {
				return KeyStore.GetInstance ("AndroidKeyStore");
			} catch (KeyStoreException e) {
				throw new RuntimeException ("Failed to get an instance of KeyStore", e);
			}
		}

		public KeyGenerator ProvidesKeyGenerator ()
		{
			try {
				return KeyGenerator.GetInstance (KeyProperties.KeyAlgorithmAes, "AndroidKeyStore");
			} catch (NoSuchAlgorithmException e) {
				throw new RuntimeException ("Failed to get an instance of KeyGenerator", e);
			} catch (NoSuchProviderException e) {
				throw new RuntimeException ("Failed to get an instance of KeyGenerator", e);
			}
		}

		public Cipher ProvidesCipher (KeyStore keyStore)
		{
			try {
				return Cipher.GetInstance (KeyProperties.KeyAlgorithmAes + "/"
					+ KeyProperties.BlockModeCbc + "/"
					+ KeyProperties.EncryptionPaddingPkcs7);
			} catch (NoSuchAlgorithmException e) {
				throw new RuntimeException ("Failed to get an instance of Cipher", e);
			} catch (NoSuchPaddingException e) {
				throw new RuntimeException ("Failed to get an instance of Cipher", e);
			}
		}

		public InputMethodManager ProvidesInputMethodManager (Context context)
		{
			return (InputMethodManager)context.GetSystemService (Context.InputMethodService);
		}

		public ISharedPreferences ProvidesSharedPreferences (Context context)
		{
			return PreferenceManager.GetDefaultSharedPreferences (context);
		}
	}
}
*/