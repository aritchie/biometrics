using System;


namespace Acr.Biometrics {

    public static class Biometrics {
        public static IBiometrics Instance { get; set; }

#if __PLATFORM__

        public static void Init() {
            if (Instance == null)
                Instance = new BiometricsImpl();
        }
#else

        [Obsolete("ERROR: You are calling the PCL version of Init")]
        public static void Init() {
            throw new ArgumentException("You are calling the PCL version of Init");
        }
#endif
    }
}
