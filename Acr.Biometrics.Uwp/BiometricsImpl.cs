using System;
using System.Threading.Tasks;
using Windows.Security.Credentials.UI;


namespace Acr.Biometrics {

    public class BiometricsImpl : IBiometrics {

        public async Task<bool> IsAvailable() {
            var uc = await UserConsentVerifier.CheckAvailabilityAsync();
            return (uc == UserConsentVerifierAvailability.Available);
        }


        public async Task<bool> Evaluate(string message) {
            var result = await UserConsentVerifier.RequestVerificationAsync(message);
            return (result == UserConsentVerificationResult.Verified);
        }
    }
}
