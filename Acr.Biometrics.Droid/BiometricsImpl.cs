using System;
using System.Threading.Tasks;


namespace Acr.Biometrics {

    public class BiometricsImpl : IBiometrics {
        readonly IBiometrics impl;


        public BiometricsImpl() {
            // if 6
            this.impl = new MarshmallowBiometricsImpl();

            // else samsung
        }


        public Task<bool> IsAvailable() {
            return this.impl.IsAvailable();
        }


        public Task<bool> Evaluate(string message) {
            return this.impl.Evaluate(message);
        }
    }
}