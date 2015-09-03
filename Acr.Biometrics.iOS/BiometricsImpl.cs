using System;
using System.Threading.Tasks;
using Foundation;
using LocalAuthentication;


namespace Acr.Biometrics {

    public class BiometricsImpl : IBiometrics {
		readonly LAContext context;
        readonly Lazy<bool> available;


		public BiometricsImpl() {
			this.context = new LAContext();
            this.available = new Lazy<bool>(() => {
    			NSError _;
	    		return this.context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out _);
            });
		}


        public Task<bool> IsAvailable() {
            return Task.FromResult(this.available.Value);
        }


		public async Task<bool> Evaluate(string message) {
			if (!this.available.Value)
				return false;

			var result = await this.context.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, message);
			return result.Item1;
		}
    }
}
