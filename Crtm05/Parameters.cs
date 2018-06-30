using System;

namespace Crtm05
{
    public class Parameters : IParameters
    {
        const double latitudeOrigin = 10;
        const double longitudeOrigin = -84;
        const double la = 1105855;
        const double fe = 500000;
        const double rho = Math.PI / 180;

        public double LatitudeOrigin => latitudeOrigin;
        public double LongitudeOrigin => longitudeOrigin;
        public double LA => la;
        public double FE => fe;
        public double Rho => rho;
    }
}
