using System;
using System.Threading.Tasks;


namespace Acr.Biometrics {

    public class BiometricsImpl : IBiometrics {
        IBiometrics impl;


        public async Task<bool> IsAvailable() {
            var bio = await this.GetAvailableImpl();
            var result = await bio.IsAvailable();
            return result;
        }


        public async Task<bool> Evaluate(string message) {
            var bio = await this.GetAvailableImpl();
            var result = await bio.Evaluate(message);
            return result;
        }


        protected virtual async Task<IBiometrics> GetAvailableImpl() {
            if (this.impl != null)
                return this.impl;

            IBiometrics bio = new MarshmallowBiometricsImpl();
            var result = await bio.IsAvailable();
            if (!result) {
                bio = new SamsungBiometricsImpl();
                result = await bio.IsAvailable();
                if (!result)
                    bio = new VoidBiometricImpl();
            }
            this.impl = bio;
            return this.impl;
        }
    }
}