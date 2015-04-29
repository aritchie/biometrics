using System;


namespace Acr.Biometrics {

    public static class Biometrics {

        private static readonly Lazy<IBiometrics> instanceInit = new Lazy<IBiometrics>(() => {
#if __PLATFORM__
            return new BiometricsImpl();
#else
            throw new ArgumentException("No platform plugin found.  Did you install the nuget package in your app project as well?");
#endif
        }, false);


        private static IBiometrics customInstance;
        public static IBiometrics Instance {
            get { return customInstance ?? instanceInit.Value; }
            set { customInstance = value; }
        }
    }
}
