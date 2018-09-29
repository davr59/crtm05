namespace Crtm05.Geographic
{
    public class GeographicCoordinateSystem : CoordinateSystem
    {
        public new double Latitude
        {
            get => latitudeCoordinate.Coordinate;
            set { latitudeCoordinate.Coordinate = value; }
        }

        public int LatitudeDegrees
        {
            get => latitudeCoordinate.Degrees;
            set { latitudeCoordinate.Degrees = value; }
        }

        public int LatitudeMinutes
        {
            get => latitudeCoordinate.Minutes;
            set { latitudeCoordinate.Minutes = value; }
        }

        public double LatitudeSeconds
        {
            get => latitudeCoordinate.Seconds;
            set { latitudeCoordinate.Seconds = value; }
        }

        public new double Longitude
        {
            get => longitudeCoordinate.Coordinate;
            set { longitudeCoordinate.Coordinate = value; }
        }

        public int LongitudeDegrees
        {
            get => longitudeCoordinate.Degrees;
            set { longitudeCoordinate.Degrees = value; }
        }

        public int LongitudeMinutes
        {
            get => longitudeCoordinate.Minutes;
            set { longitudeCoordinate.Minutes = value; }
        }

        public double LongitudeSeconds
        {
            get => longitudeCoordinate.Seconds;
            set { longitudeCoordinate.Seconds = value; }
        }

        public GeographicCoordinateSystem(double latitude, double longitude) : base(latitude, longitude)
        {
            latitudeCoordinate = new GeographicCoordinate(latitude);
            longitudeCoordinate = new GeographicCoordinate(longitude);
        }

        GeographicCoordinate latitudeCoordinate;
        GeographicCoordinate longitudeCoordinate;
    }
}
