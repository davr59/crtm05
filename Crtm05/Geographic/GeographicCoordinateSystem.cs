namespace Crtm05.Geographic
{
    public class GeographicCoordinateSystem
    {
        public GeographicCoordinate Latitude { get; }
        public GeographicCoordinate Longitude { get; }

        public GeographicCoordinateSystem(GeographicCoordinate latitude, GeographicCoordinate longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
