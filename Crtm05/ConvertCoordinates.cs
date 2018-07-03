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
            var deltaDegreesLatitude = DeltaLatitude(deltaLatitude, deltaLongitude, coefficients.B10, coefficients.B20, coefficients.B02, coefficients.B30, coefficients.B12, coefficients.B40, coefficients.B22, coefficients.B04, coefficients.B50, coefficients.B32, coefficients.B14);
            var deltaDegreesLongitude = DeltaLongitude(deltaLatitude, deltaLongitude, coefficients.B01, coefficients.B11, coefficients.B21, coefficients.B03, coefficients.B31, coefficients.B13, coefficients.B41, coefficients.B23, coefficients.B05);
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
            var crtm98Latitude = CrtmLatitude(coordinates.Latitude, coordinates.Longitude, coefficients.E0, coefficients.E1, coefficients.F1);
            var crtm98Longitude = CrtmLongitude(coordinates.Latitude, coordinates.Longitude, coefficients.F0, coefficients.E1, coefficients.F1);
            var ctrm90Latitude = CrtmLatitude(crtm98Latitude, crtm98Longitude, coefficients.M0, coefficients.M1, coefficients.N1);
            var ctrm90Longitude = CrtmLongitude(crtm98Latitude, crtm98Longitude, coefficients.N0, coefficients.M1, coefficients.N1);
            var deltaLatitude = (ctrm90Latitude - 1156874.11) * 0.00001;
            var deltaLongitude = (ctrm90Longitude - 463736.66) * 0.00001;
            var latitude = FromDelta(deltaLatitude, deltaLongitude, coefficients.R00, coefficients.R10, coefficients.R01, coefficients.R20, coefficients.R11, coefficients.R02, coefficients.R30, 0, coefficients.R12, 0);
            var longitude = FromDelta(deltaLatitude, deltaLongitude, coefficients.S00, coefficients.S10, coefficients.S01, coefficients.S20, coefficients.S11, coefficients.S02, 0, coefficients.S21, 0, coefficients.S03);

            return new NorthLambertCoordinateSystem(latitude, longitude);
        }

        public static SouthLambertCoordinateSystem ToSouthLambert(Crtm05CoordinateSystem coordinates)
        {
            return ToSouthLambert(coordinates, new Coefficients());
        }

        public static SouthLambertCoordinateSystem ToSouthLambert(Crtm05CoordinateSystem coordinates, ICoefficients coefficients)
        {
            var crtm98Latitude = CrtmLatitude(coordinates.Latitude, coordinates.Longitude, coefficients.E0, coefficients.E1, coefficients.F1);
            var crtm98Longitude = CrtmLongitude(coordinates.Latitude, coordinates.Longitude, coefficients.F0, coefficients.E1, coefficients.F1);
            var ctrm90Latitude = CrtmLatitude(crtm98Latitude, crtm98Longitude, coefficients.M0, coefficients.M1, coefficients.N1);
            var ctrm90Longitude = CrtmLongitude(crtm98Latitude, crtm98Longitude, coefficients.N0, coefficients.M1, coefficients.N1);
            var deltaLatitude = (ctrm90Latitude - 994727.07) * 0.00001;
            var deltaLongitude = (ctrm90Longitude - 536853.82) * 0.00001;
            var latitude = FromDelta(deltaLatitude, deltaLongitude, coefficients.T00, coefficients.T10, coefficients.T01, coefficients.T20, coefficients.T11, 0, coefficients.T30, coefficients.T21, coefficients.T12, 0);
            var longitude = FromDelta(deltaLatitude, deltaLongitude, coefficients.U00, coefficients.U10, coefficients.U01, coefficients.U20, coefficients.U11, coefficients.U02, 0, coefficients.U21, 0, coefficients.U03);

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
            var deltaLatitude = DeltaLatitude(deltaRadiansLatitude, deltaRadiansLongitude, coefficients.A10, coefficients.A20, coefficients.A02, coefficients.A30, coefficients.A12, coefficients.A40, coefficients.A22, coefficients.A04, coefficients.A50, coefficients.A32, coefficients.A14);
            var deltaLongitude = DeltaLongitude(deltaRadiansLatitude, deltaRadiansLongitude, coefficients.A01, coefficients.A11, coefficients.A21, coefficients.A03, coefficients.A31, coefficients.A13, coefficients.A41, coefficients.A23, coefficients.A05);
            var latitude = (parameters.LA + deltaLatitude) * 0.9999;
            var longitude = parameters.FE + deltaLongitude * 0.9999;

            return new Crtm05CoordinateSystem(latitude, longitude);
        }

        public static Crtm05CoordinateSystem ToCrtm05(NorthLambertCoordinateSystem coordinates)
        {
            return ToCrtm05(coordinates, new Coefficients());
        }

        public static Crtm05CoordinateSystem ToCrtm05(NorthLambertCoordinateSystem coordinates, ICoefficients coefficients)
        {
            var deltaLatitude = (coordinates.Latitude - 271820.52) * 0.00001;
            var deltaLongitude = (coordinates.Longitude - 500000) * 0.00001;
            var crtm90Latitude = FromDelta(deltaLatitude, deltaLongitude, coefficients.AA00, coefficients.AA10, coefficients.AA01, coefficients.AA20, coefficients.AA11, 0, coefficients.AA30, coefficients.AA21, coefficients.AA12, coefficients.AA03);
            var crtm90Longitude = FromDelta(deltaLatitude, deltaLongitude, coefficients.BB00, coefficients.BB10, coefficients.BB01, coefficients.BB20, 0, coefficients.BB02, 0, coefficients.BB21, coefficients.BB12, coefficients.BB03);
            var crtm98Latitude = CrtmLatitude(crtm90Latitude, crtm90Longitude, coefficients.MM0, coefficients.MM1, coefficients.NN1);
            var crtm98Longitude = CrtmLongitude(crtm90Latitude, crtm90Longitude, coefficients.NN0, coefficients.MM1, coefficients.NN1);
            var latitude = CrtmLatitude(crtm98Latitude, crtm98Longitude, coefficients.EE0, coefficients.EE1, coefficients.FF1);
            var longitude = CrtmLongitude(crtm98Latitude, crtm98Longitude, coefficients.FF0, coefficients.EE1, coefficients.FF1);

            return new Crtm05CoordinateSystem(latitude, longitude);
        }

        public static Crtm05CoordinateSystem ToCrtm05(SouthLambertCoordinateSystem coordinates)
        {
            return ToCrtm05(coordinates, new Coefficients());
        }

        public static Crtm05CoordinateSystem ToCrtm05(SouthLambertCoordinateSystem coordinates, ICoefficients coefficients)
        {
            var deltaLatitude = (coordinates.Latitude - 327987.44) * 0.00001;
            var deltaLongitude = (coordinates.Longitude - 500000) * 0.00001;
            var crtm90Latitude = FromDelta(deltaLatitude, deltaLongitude, coefficients.C00, coefficients.C10, coefficients.C01, coefficients.C20, coefficients.C11, 0, coefficients.C30, coefficients.C21, coefficients.C12, coefficients.C03);
            var crtm90Longitude = FromDelta(deltaLatitude, deltaLongitude, coefficients.D00, coefficients.D10, coefficients.D01, coefficients.D20, 0, coefficients.D02, 0, coefficients.D21, coefficients.D12, coefficients.D03);
            var crtm98Latitude = CrtmLatitude(crtm90Latitude, crtm90Longitude, coefficients.MM0, coefficients.MM1, coefficients.NN1);
            var crtm98Longitude = CrtmLongitude(crtm90Latitude, crtm90Longitude, coefficients.NN0, coefficients.MM1, coefficients.NN1);
            var latitude = CrtmLatitude(crtm98Latitude, crtm98Longitude, coefficients.EE0, coefficients.EE1, coefficients.FF1);
            var longitude = CrtmLongitude(crtm98Latitude, crtm98Longitude, coefficients.FF0, coefficients.EE1, coefficients.FF1);

            return new Crtm05CoordinateSystem(latitude, longitude);
        }

        static double DeltaLatitude(double deltaLatitude, double deltaLongitude, double coefficient1, double coefficient2, double coefficient3, double coefficient4, double coefficient5, double coefficient6, double coefficient7, double coefficient8, double coefficient9, double coefficient10, double coefficient11)
        {
            return deltaLatitude * coefficient1 +
                deltaLatitude * deltaLatitude * coefficient2 +
                deltaLongitude * deltaLongitude * coefficient3 +
                deltaLatitude * deltaLatitude * deltaLatitude * coefficient4 +
                deltaLatitude * deltaLongitude * deltaLongitude * coefficient5 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * coefficient6 +
                deltaLatitude * deltaLatitude * deltaLongitude * deltaLongitude * coefficient7 +
                deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficient8 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * coefficient9 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLongitude * deltaLongitude * coefficient10 +
                deltaLatitude * deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficient11;
        }

        static double DeltaLongitude(double deltaLatitude, double deltaLongitude, double coefficient1, double coefficient2, double coefficient3, double coefficient4, double coefficient5, double coefficient6, double coefficient7, double coefficient8, double coefficient9)
        {
            return deltaLongitude * coefficient1 +
                deltaLatitude * deltaLongitude * coefficient2 +
                deltaLatitude * deltaLatitude * deltaLongitude * coefficient3 +
                deltaLongitude * deltaLongitude * deltaLongitude * coefficient4 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * coefficient5 +
                deltaLatitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficient6 +
                deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * deltaLongitude * coefficient7 +
                deltaLatitude * deltaLatitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficient8 +
                deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficient9;
        }

        static double FromDelta(double deltaLatitude, double deltaLongitude, double coefficient1, double coefficient2, double coefficient3, double coefficient4, double coefficient5, double coefficient6, double coefficient7, double coefficient8, double coefficient9, double coefficient10)
        {
            return coefficient1 +
                coefficient2 * deltaLatitude +
                coefficient3 * deltaLongitude +
                coefficient4 * deltaLatitude * deltaLatitude +
                coefficient5 * deltaLatitude * deltaLongitude +
                coefficient6 * deltaLongitude * deltaLongitude +
                coefficient7 * deltaLatitude * deltaLatitude * deltaLatitude +
                coefficient8 * deltaLatitude * deltaLatitude * deltaLongitude +
                coefficient9 * deltaLatitude * deltaLongitude * deltaLongitude +
                coefficient10 * deltaLongitude * deltaLongitude * deltaLongitude;
        }

        static double CrtmLatitude(double crtmLatitude, double crtmLongitude, double coefficient1, double coefficient2, double coefficient3)
        {
            return CrtmLongitude(crtmLongitude, crtmLatitude, coefficient1, coefficient2, -1 * coefficient3);
        }

        static double CrtmLongitude(double crtmLatitude, double crtmLongitude, double coefficient1, double coefficient2, double coefficient3)
        {
            return coefficient1 + coefficient2 * crtmLongitude + coefficient3 * crtmLatitude;
        }
    }
}
