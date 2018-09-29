namespace Crtm05
{
    public interface ICoefficients
    {
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

        double E0 { get; }
        double F0 { get; }
        double E1 { get; }
        double F1 { get; }

        double M0 { get; }
        double N0 { get; }
        double M1 { get; }
        double N1 { get; }

        double R00 { get; }
        double R10 { get; }
        double R01 { get; }
        double R20 { get; }
        double R11 { get; }
        double R02 { get; }
        double R30 { get; }
        double R12 { get; }

        double S00 { get; }
        double S10 { get; }
        double S01 { get; }
        double S20 { get; }
        double S11 { get; }
        double S02 { get; }
        double S21 { get; }
        double S03 { get; }

        double T00 { get; }
        double T10 { get; }
        double T01 { get; }
        double T20 { get; }
        double T11 { get; }
        double T21 { get; }
        double T30 { get; }
        double T12 { get; }

        double U00 { get; }
        double U10 { get; }
        double U01 { get; }
        double U20 { get; }
        double U11 { get; }
        double U02 { get; }
        double U21 { get; }
        double U03 { get; }

        double AA00 { get; }
        double AA10 { get; }
        double AA01 { get; }
        double AA20 { get; }
        double AA11 { get; }
        double AA30 { get; }
        double AA21 { get; }
        double AA12 { get; }

        double AA03 { get; }
        double BB00 { get; }
        double BB10 { get; }
        double BB01 { get; }
        double BB20 { get; }
        double BB02 { get; }
        double BB21 { get; }
        double BB12 { get; }
        double BB03 { get; }

        double EE0 { get; }
        double FF0 { get; }
        double EE1 { get; }
        double FF1 { get; }

        double MM0 { get; }
        double NN0 { get; }
        double MM1 { get; }
        double NN1 { get; }

        double C00 { get; }
        double C10 { get; }
        double C01 { get; }
        double C20 { get; }
        double C11 { get; }
        double C30 { get; }
        double C21 { get; }
        double C12 { get; }
        double C03 { get; }

        double D00 { get; }
        double D10 { get; }
        double D01 { get; }
        double D20 { get; }
        double D02 { get; }
        double D21 { get; }
        double D12 { get; }
        double D03 { get; }
    }
}
