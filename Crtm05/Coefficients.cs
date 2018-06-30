namespace Crtm05
{
    public class Coefficients : ICoefficients
    {
        const double a10 = 6337358;
        const double a01 = 6281873;
        const double a20 = 10883;
        const double a11 = -1100471;
        const double a02 = 545418;
        const double a30 = 19956;
        const double a03 = 990475;
        const double a21 = -3122430;
        const double a12 = 2997671.141;
        const double a14 = 1110311.476;
        const double a40 = -3675.842;
        const double a13 = -894370.419;
        const double a04 = 221627.399;
        const double a31 = 172656.502;
        const double a22 = -1085654.527;
        const double a50 = 0;
        const double a41 = 261744.701;
        const double a32 = -1998031.096;
        const double a23 = -2333314.547;
        const double a05 = 218688.67;

        const double b10 = 0.00000904095657;
        const double b01 = 0.00000912081175;
        const double b11 = 0.000000000000252124228;
        const double b20 = -0.00000000000000245028794;
        const double b02 = -0.000000000000124958406;
        const double b30 = -0.000000000000000000000707576864;
        const double b21 = 0.000000000000000000119781993;
        const double b03 = -0.0000000000000000000399273311;
        const double b12 = -0.000000000000000000115211344;
        const double b05 = 0.000000000000000000000000000000000270578632;
        const double b40 = 0.0000000000000000000000000000199430268;
        const double b31 = 0.00000000000000000000000000536306764;
        const double b22 = -0.00000000000000000000000000305593944;
        const double b13 = -0.00000000000000000000000000536306764;
        const double b04 = 0.00000000000000000000000000130468139;
        const double b50 = 0;
        const double b41 = 0.00000000000000000000000000000000135289316;
        const double b32 = -0.00000000000000000000000000000000101931619;
        const double b23 = -0.00000000000000000000000000000000270578632;
        const double b14 = 0.0000000000000000000000000000000012306633;

        const double e0 = 0.179913184;
        const double f0 = 149.644487588;
        const double e1 = 0.99969990521;
        const double f1 = 0.00000034731;
        const double m0 = -7.75237044;
        const double n0 = -3.525688428;
        const double m1 = 0.99999913361;
        const double n1 = 0.00000000018;

        const double r00 = 271820.52;
        const double r10 = 100035.73;
        const double r01 = 105.26;
        const double r20 = -0.03;
        const double r11 = 8.97;
        const double r02 = 0.02;
        const double r30 = 4.13;
        const double r12 = -12.38;

        const double s00 = 500000;
        const double s10 = -105.25;
        const double s01 = 100035.72;
        const double s20 = -4.48;
        const double s11 = -0.06;
        const double s02 = 4.49;
        const double s21 = 12.37;
        const double s03 = -4.13;

        const double t00 = 327987.44;
        const double t10 = 100035.74;
        const double t01 = -91.39;
        const double t20 = -0.01;
        const double t11 = -9.13;
        const double t21 = -0.02;
        const double t30 = 4.12;
        const double t12 = -12.38;

        const double u00 = 500000;
        const double u10 = 91.38;
        const double u01 = 100035.72;
        const double u20 = 4.57;
        const double u11 = -0.04;
        const double u02 = -4.57;
        const double u21 = 12.39;
        const double u03 = -4.13;


        public double A10 => a10;
        public double A01 => a01;
        public double A20 => a20;
        public double A11 => a11;
        public double A02 => a02;
        public double A30 => a30;
        public double A03 => a03;
        public double A21 => a21;
        public double A12 => a12;
        public double A14 => a14;
        public double A40 => a40;
        public double A13 => a13;
        public double A04 => a04;
        public double A31 => a31;
        public double A22 => a22;
        public double A50 => a50;
        public double A41 => a41;
        public double A32 => a32;
        public double A23 => a23;
        public double A05 => a05;

        public double B10 => b10;
        public double B01 => b01;
        public double B11 => b11;
        public double B20 => b20;
        public double B02 => b02;
        public double B30 => b30;
        public double B21 => b21;
        public double B03 => b03;
        public double B12 => b12;
        public double B05 => b05;
        public double B40 => b40;
        public double B31 => b31;
        public double B22 => b22;
        public double B13 => b13;
        public double B04 => b04;
        public double B50 => b50;
        public double B41 => b41;
        public double B32 => b32;
        public double B23 => b23;
        public double B14 => b14;

        public double E0 => e0;
        public double F0 => f0;
        public double E1 => e1;
        public double F1 => f1;
        public double M0 => m0;
        public double N0 => n0;
        public double M1 => m1;
        public double N1 => n1;

        public double R00 => r00;
        public double R10 => r10;
        public double R01 => r01;
        public double R20 => r20;
        public double R11 => r11;
        public double R02 => r02;
        public double R30 => r30;
        public double R12 => r12;

        public double S00 => s00;
        public double S10 => s10;
        public double S01 => s01;
        public double S20 => s20;
        public double S11 => s11;
        public double S02 => s02;
        public double S21 => s21;
        public double S03 => s03;

        public double T00 => t00;
        public double T10 => t10;
        public double T01 => t01;
        public double T20 => t20;
        public double T11 => t11;
        public double T21 => t21;
        public double T30 => t30;
        public double T12 => t12;

        public double U00 => u00;
        public double U10 => u10;
        public double U01 => u01;
        public double U20 => u20;
        public double U11 => u11;
        public double U02 => u02;
        public double U21 => u21;
        public double U03 => u03;
    }
}
