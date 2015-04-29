using System;
using System.Threading.Tasks;
using Foundation;
using LocalAuthentication;


namespace Acr.Biometrics {

    public class BiometricsImpl : IBiometrics {
		private readonly LAContext context;


		public BiometricsImpl() {
			this.context = new LAContext();
			NSError _;
			this.IsAvailable = this.context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out _);
		}


		public bool IsAvailable { get; private set; }


		public async Task<bool> Evaluate(string message) {
			if (!this.IsAvailable)
				return false;

			var result = await this.context.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, message);
			return result.Item1;
		}
    }
}
