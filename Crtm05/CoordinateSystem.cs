namespace Crtm05
{
    public abstract class CoordinateSystem
    {
        public double Latitude { get; }
        public double Longitude { get; }

        protected CoordinateSystem(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
