namespace Crtm05
{
    public abstract class CoordinateSystem
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        protected CoordinateSystem(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
