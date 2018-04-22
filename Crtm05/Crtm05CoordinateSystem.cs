using System;

namespace Crtm05
{
    public class Crtm05CoordinateSystem
    {
        double crtm05Latitude;
        double crtm05Longitude;

        public double Crtm05Latitude
        {
            get
            {
                return crtm05Latitude;
            }
            set
            {
                crtm05Latitude = value;
                UpdateGeographicCoordinates();
            }
        }
        public double Crtm05Longitude
        {
            get
            {
                return crtm05Longitude;
            }
            set
            {
                crtm05Longitude = value;
                UpdateGeographicCoordinates();
            }
        }
        public GeographicCoordinateSystem GeographicCoordinateSystem { get; }
        public ICrtm05CoordinateSystemOptions Options { get; }

        double GeographicDeltaDegreesLatitude => GeographicCoordinateSystem.Latitude.Coordinate - Options.LatitudeOrigin;
        double GeographicDeltaDegreesLongitude => GeographicCoordinateSystem.Longitude.Coordinate - Options.LongitudeOrigin;
        double GeographicDeltaRadiansLatitude => GeographicDeltaDegreesLatitude * Math.PI / 180;
        double GeographicDeltaRadiansLongitude => GeographicDeltaDegreesLongitude * Math.PI / 180;
        double GeographicDeltaLatitude =>
            GeographicDeltaRadiansLatitude * Options.A10 + GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * Options.A20 +
            GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A02 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * Options.A30 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A12 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * Options.A40 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A22 +
            GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A04 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * Options.A50 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A32 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A14;
        double GeographicDeltaLongitude =>
            GeographicDeltaRadiansLongitude * Options.A01 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * Options.A11 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * Options.A21 +
            GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A03 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * Options.A31 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A13 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * Options.A41 +
            GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLatitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A23 +
            GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * GeographicDeltaRadiansLongitude * Options.A05;

        public Crtm05CoordinateSystem(GeographicCoordinateSystem geographicCoordinateSystem)
        {
            GeographicCoordinateSystem = geographicCoordinateSystem;
            Options = new Crtm05CoordinateSystemOptions();

            crtm05Latitude = (Options.LA + GeographicDeltaLatitude) * 0.9999;
            crtm05Longitude = Options.FE + GeographicDeltaLongitude * 0.9999;
        }

        public Crtm05CoordinateSystem(GeographicCoordinateSystem geographicCoordinateSystem, ICrtm05CoordinateSystemOptions options)
        {
            GeographicCoordinateSystem = geographicCoordinateSystem;
            Options = options;

            crtm05Latitude = (Options.LA + GeographicDeltaLatitude) * 0.9999;
            crtm05Longitude = Options.FE + GeographicDeltaLongitude * 0.9999;
        }

        public Crtm05CoordinateSystem(double crtm05Latitude, double crtm05Longitude)
        {
            GeographicCoordinateSystem = new GeographicCoordinateSystem(new GeographicCoordinate(0), new GeographicCoordinate(0));
            Options = new Crtm05CoordinateSystemOptions();

            this.crtm05Latitude = crtm05Latitude;
            this.crtm05Longitude = crtm05Longitude;
            UpdateGeographicCoordinates();
        }

        public Crtm05CoordinateSystem(double crtm05Latitude, double crtm05Longitude, ICrtm05CoordinateSystemOptions options)
        {
            GeographicCoordinateSystem = new GeographicCoordinateSystem(new GeographicCoordinate(0), new GeographicCoordinate(0));
            Options = options;

            this.crtm05Latitude = crtm05Latitude;
            this.crtm05Longitude = crtm05Longitude;
            UpdateGeographicCoordinates();
        }

        void UpdateGeographicCoordinates()
        {
            var crtm05DeltaLatitude = crtm05Latitude / 0.9999 - Options.LA;
            var crtm05DeltaLongitude = (crtm05Longitude - Options.FE) / 0.9999;
            var crtm05DeltaDegreesLatitude =
                crtm05DeltaLatitude * Options.B10 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * Options.B20 +
                crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B02 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * Options.B30 +
                crtm05DeltaLatitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B12 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * Options.B40 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B22 +
                crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B04 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * Options.B50 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B32 +
                crtm05DeltaLatitude * crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B14;
            var crtm05DeltaDegreesLongitude =
                crtm05DeltaLongitude * Options.B01 +
                crtm05DeltaLatitude * crtm05DeltaLongitude * Options.B11 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLongitude * Options.B21 +
                crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B03 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLongitude * Options.B31 +
                crtm05DeltaLatitude * crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B13 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLongitude * Options.B41 +
                crtm05DeltaLatitude * crtm05DeltaLatitude * crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B23 +
                crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * crtm05DeltaLongitude * Options.B05;

            GeographicCoordinateSystem.Latitude.Coordinate = crtm05DeltaDegreesLatitude + Options.LatitudeOrigin;
            GeographicCoordinateSystem.Longitude.Coordinate = crtm05DeltaDegreesLongitude + Options.LongitudeOrigin;
        }
    }
}
