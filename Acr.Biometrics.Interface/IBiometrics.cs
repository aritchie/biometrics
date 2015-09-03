using System;
using System.Threading.Tasks;


namespace Acr.Biometrics {

    public interface IBiometrics {

        Task<bool> IsAvailable();
        Task<bool> Evaluate(string message);
    }
}
