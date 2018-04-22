namespace Crtm05
{
    public interface ICrtm05CoordinateSystemOptions
    {
        double LatitudeOrigin { get; }
        double LongitudeOrigin { get; }

        double A { get; }
        double B { get; }
        double E2 { get; }
        double EP2 { get; }
        double Start { get; }
        double N { get; }
        double T { get; }
        double ETA2 { get; }

        double AA { get; }
        double BB { get; }
        double CC { get; }
        double DD { get; }
        double EE { get; }
        double FF { get; }

        double A10 { get; }
        double A01 { get; }
        double A20 { get; }
        double A11 { get; }
        double A02 { get; }
        double A30 { get; }
        double A03 { get; }
        double A21 { get; }
        double A12 { get; }
        double A14 { get; }
        double A40 { get; }
        double A13 { get; }
        double A04 { get; }
        double A31 { get; }
        double A22 { get; }
        double A50 { get; }
        double A41 { get; }
        double A32 { get; }
        double A23 { get; }
        double A05 { get; }

        double B10 { get; }
        double B01 { get; }
        double B11 { get; }
        double B20 { get; }
        double B02 { get; }
        double B30 { get; }
        double B21 { get; }
        double B03 { get; }
        double B12 { get; }
        double B05 { get; }
        double B40 { get; }
        double B31 { get; }
        double B22 { get; }
        double B13 { get; }
        double B04 { get; }
        double B50 { get; }
        double B41 { get; }
        double B32 { get; }
        double B23 { get; }
        double B14 { get; }

        double LA { get; }
        double FE { get; }
    }
}
