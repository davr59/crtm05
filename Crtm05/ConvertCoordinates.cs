using Crtm05.Ctrm05;
using Crtm05.Geographic;
using Crtm05.Lambert;

namespace Crtm05
{
    public static class ConvertCoordinates
    {
        public static GeographicCoordinateSystem ToGeographic(Crtm05CoordinateSystem coordinates)
        {
            return ToGeographic(coordinates, new Parameters(), new Coefficients());
        }

        public static GeographicCoordinateSystem ToGeographic(Crtm05CoordinateSystem coordinates, IParameters parameters, ICoefficients coefficients)
        {
            var deltaLatitude = coordinates.Latitude / 0.9999 - parameters.LA;
            var deltaLongitude = (coordinates.Longitude - parameters.FE) / 0.9999;
            var deltaDegreesLatitude =
                deltaLatitude * coefficients.B10 +
                deltaLatitude * deltaLatitude * coefficients.B20 +
                deltaLongitude * deltaLongitude * coefficients.B02 +
                deltaLatitude * deltaLatitude * deltaLatitude * coefficients.B30 +
                deltaLatitude * deltaLongitude * deltaLongitude * coefficients.B12 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * coefficients.B40 +
                deltaLatitude * deltaLatitude * deltaLongitude * deltaLongitude * coefficients.B22 +
                deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficients.B04 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * coefficients.B50 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLongitude * deltaLongitude * coefficients.B32 +
                deltaLatitude * deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficients.B14;
            var deltaDegreesLongitude =
                deltaLongitude * coefficients.B01 +
                deltaLatitude * deltaLongitude * coefficients.B11 +
                deltaLatitude * deltaLatitude * deltaLongitude * coefficients.B21 +
                deltaLongitude * deltaLongitude * deltaLongitude * coefficients.B03 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLongitude * coefficients.B31 +
                deltaLatitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficients.B13 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * deltaLongitude * coefficients.B41 +
                deltaLatitude * deltaLatitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficients.B23 +
                deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficients.B05;
            var latitude = deltaDegreesLatitude + parameters.LatitudeOrigin;
            var longitude = deltaDegreesLongitude + parameters.LongitudeOrigin;

            return new GeographicCoordinateSystem(new GeographicCoordinate(latitude), new GeographicCoordinate(longitude));
        }

        public static NorthLambertCoordinateSystem ToNorthLambert(Crtm05CoordinateSystem coordinates)
        {
            return ToNorthLambert(coordinates, new Coefficients());
        }

        public static NorthLambertCoordinateSystem ToNorthLambert(Crtm05CoordinateSystem coordinates, ICoefficients coefficients)
        {
            var crtm98Latitude = Crtm98Latitude(coordinates.Latitude, coordinates.Longitude, coefficients);
            var crtm98Longitude = Crtm98Longitude(coordinates.Latitude, coordinates.Longitude, coefficients);
            var ctrm90Latitude = Crtm90Latitude(crtm98Latitude, crtm98Longitude, coefficients);
            var ctrm90Longitude = Crtm90Longitude(crtm98Latitude, crtm98Longitude, coefficients);
            var deltaLatitude = (ctrm90Latitude - 1156874.11) * 0.00001;
            var deltaLongitude = (ctrm90Longitude - 463736.66) * 0.00001;
            var latitude = coefficients.R00 + coefficients.R10 * deltaLatitude + coefficients.R01 * deltaLongitude +
                                       coefficients.R20 * deltaLatitude * deltaLatitude + coefficients.R11 * deltaLatitude * deltaLongitude +
                                       coefficients.R02 * deltaLongitude * deltaLongitude + coefficients.R30 * deltaLatitude * deltaLatitude * deltaLatitude +
                                       coefficients.R12 * deltaLatitude * deltaLongitude * deltaLongitude;
            var longitude = coefficients.S00 + deltaLatitude * coefficients.S10 + coefficients.S01 * deltaLongitude +
                                        coefficients.S20 * deltaLatitude * deltaLatitude + coefficients.S11 * deltaLatitude * deltaLongitude +
                                        coefficients.S02 * deltaLongitude * deltaLongitude + coefficients.S21 * deltaLatitude * deltaLatitude + deltaLongitude +
                                        coefficients.S03 * deltaLongitude * deltaLongitude * deltaLongitude;

            return new NorthLambertCoordinateSystem(latitude, longitude);
        }

        public static SouthLambertCoordinateSystem ToSouthLambert(Crtm05CoordinateSystem coordinates)
        {
            return ToSouthLambert(coordinates, new Coefficients());
        }

        public static SouthLambertCoordinateSystem ToSouthLambert(Crtm05CoordinateSystem coordinates, ICoefficients coefficients)
        {
            var crtm98Latitude = Crtm98Latitude(coordinates.Latitude, coordinates.Longitude, coefficients);
            var crtm98Longitude = Crtm98Longitude(coordinates.Latitude, coordinates.Longitude, coefficients);
            var ctrm90Latitude = Crtm90Latitude(crtm98Latitude, crtm98Longitude, coefficients);
            var ctrm90Longitude = Crtm90Longitude(crtm98Latitude, crtm98Longitude, coefficients);
            var deltaLatitude = (ctrm90Latitude - 994727.07) * 0.00001;
            var deltaLongitude = (ctrm90Longitude - 536853.82) * 0.00001;
            var latitude = coefficients.T00 + coefficients.T10 * deltaLatitude + coefficients.T01 * deltaLongitude +
                                       coefficients.T20 * deltaLatitude * deltaLatitude + coefficients.T11 * deltaLatitude * deltaLongitude +
                                       coefficients.T30 * deltaLatitude * deltaLatitude * deltaLatitude + coefficients.T21 * deltaLatitude * deltaLatitude * deltaLongitude +
                                       coefficients.T12 * deltaLatitude * deltaLongitude * deltaLongitude;
            var longitude = coefficients.U00 + coefficients.U10 * deltaLatitude + coefficients.U01 * deltaLongitude +
                                        coefficients.U20 * deltaLatitude * deltaLatitude + coefficients.U11 * deltaLatitude * deltaLongitude +
                                        coefficients.U02 * deltaLongitude * deltaLongitude + coefficients.U21 * deltaLongitude * deltaLatitude * deltaLatitude +
                                        coefficients.U03 * deltaLongitude * deltaLongitude * deltaLongitude;

            return new SouthLambertCoordinateSystem(latitude, longitude);
        }

        public static Crtm05CoordinateSystem ToCrtm05(GeographicCoordinateSystem coordinates)
        {
            return ToCrtm05(coordinates, new Parameters(), new Coefficients());
        }

        public static Crtm05CoordinateSystem ToCrtm05(GeographicCoordinateSystem coordinates, IParameters parameters, ICoefficients coefficients)
        {
            var deltaDegreesLatitude = coordinates.Latitude.Coordinate - parameters.LatitudeOrigin;
            var deltaDegreesLongitude = coordinates.Longitude.Coordinate - parameters.LongitudeOrigin;
            var deltaRadiansLatitude = deltaDegreesLatitude * parameters.Rho;
            var deltaRadiansLongitude = deltaDegreesLongitude * parameters.Rho;
            var deltaLatitude = deltaRadiansLatitude * coefficients.A10 + deltaRadiansLatitude * deltaRadiansLatitude * coefficients.A20 +
                                                                      deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A02 +
                                                                      deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * coefficients.A30 +
                                                                      deltaRadiansLatitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A12 +
                                                                      deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * coefficients.A40 +
                                                                      deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A22 +
                                                                      deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A04 +
                                                                      deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * coefficients.A50 +
                                                                      deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A32 +
                                                                      deltaRadiansLatitude * deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A14;
            var deltaLongitude = deltaRadiansLongitude * coefficients.A01 +
                                                                        deltaRadiansLatitude * deltaRadiansLongitude * coefficients.A11 +
                                                                        deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLongitude * coefficients.A21 +
                                                                        deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A03 +
                                                                        deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLongitude * coefficients.A31 +
                                                                        deltaRadiansLatitude * deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A13 +
                                                                        deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLongitude * coefficients.A41 +
                                                                        deltaRadiansLatitude * deltaRadiansLatitude * deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A23 +
                                                                        deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * deltaRadiansLongitude * coefficients.A05;
            var latitude = (parameters.LA + deltaLatitude) * 0.9999;
            var longitude = parameters.FE + deltaLongitude * 0.9999;

            return new Crtm05CoordinateSystem(latitude, longitude);
        }

        public static Crtm05CoordinateSystem ToCrtm05(NorthLambertCoordinateSystem coordinates)
        {
            return ToCrtm05(coordinates, new Parameters(), new Coefficients());
        }

        public static Crtm05CoordinateSystem ToCrtm05(NorthLambertCoordinateSystem coordinates, IParameters parameters, ICoefficients coefficients)
        {
            var deltaLatitude = (coordinates.Latitude - 271820.52) * 0.00001;
            var deltaLongitude = (coordinates.Longitude - 500000) * 0.00001;
            var crtm90Latitude = 0.0;
            var crtm90Longitude = 0.0;
            var crtm98Latitude = 0.0;
            var crtm98Longitude = 0.0;
            var latitude = 0.0;
            var longitude = 0.0;

            return new Crtm05CoordinateSystem(latitude, longitude);
        }

        public static Crtm05CoordinateSystem ToCrtm05(SouthLambertCoordinateSystem coordinates)
        {
            return ToCrtm05(coordinates, new Parameters(), new Coefficients());
        }

        public static Crtm05CoordinateSystem ToCrtm05(SouthLambertCoordinateSystem coordinates, IParameters parameters, ICoefficients coefficients)
        {
            var deltaLatitude = (coordinates.Latitude - 327987.44) * 0.00001;
            var deltaLongitude = (coordinates.Longitude - 500000) * 0.00001;
            var crtm90Latitude = 0.0;
            var crtm90Longitude = 0.0;
            var crtm98Latitude = 0.0;
            var crtm98Longitude = 0.0;
            var latitude = 0.0;
            var longitude = 0.0;

            return new Crtm05CoordinateSystem(latitude, longitude);
        }


        static double Crtm98Latitude(double latitude, double longitude, ICoefficients coefficients)
        {
            return coefficients.E0 +
                               coefficients.E1 * latitude -
                               coefficients.F1 * longitude;
        }

        static double Crtm98Longitude(double latitude, double longitude, ICoefficients coefficients)
        {
            return coefficients.F0 +
                               coefficients.E1 * longitude +
                               coefficients.F1 * latitude;
        }

        static double Crtm90Latitude(double crtm98Latitude, double ctrm98Longitude, ICoefficients coefficients)
        {
            return coefficients.M0 +
                               coefficients.M1 * crtm98Latitude -
                               coefficients.N1 * ctrm98Longitude;
        }

        static double Crtm90Longitude(double crtm98Latitude, double ctrm98Longitude, ICoefficients coefficients)
        {
            return coefficients.N0 +
                               coefficients.M1 * ctrm98Longitude +
                               coefficients.N1 * crtm98Latitude;
        }
    }
}
