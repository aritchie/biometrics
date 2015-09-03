using System;
using System.Threading.Tasks;


namespace Acr.Biometrics {

    public class VoidBiometricImpl : IBiometrics {

        public Task<bool> IsAvailable() {
            return Task.FromResult(false);
        }


        public Task<bool> Evaluate(string message) {
            return Task.FromResult(false);
        }
    }
}
