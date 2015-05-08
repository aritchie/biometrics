using System;
using System.Threading.Tasks;


namespace Acr.Biometrics {

    public class VoidBiometricImpl : IBiometrics {

        public bool IsAvailable {
            get { return false; }
        }


        public async Task<bool> Evaluate(string message) {
            return false;
        }
    }
}
