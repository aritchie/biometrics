using System;
using System.Threading.Tasks;


namespace Acr.Biometrics {

    public interface IBiometrics {

        bool IsAvailable { get; }
        Task<bool> Evaluate(string message);
    }
}
