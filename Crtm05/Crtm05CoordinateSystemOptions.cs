using System;

namespace Crtm05
{
    public class Crtm05CoordinateSystemOptions : ICrtm05CoordinateSystemOptions
    {
        const double latitudeOrigin = 10;
        const double longitudeOrigin = -84;

        const double a = 6378137;
        const double b = 6356752.3142;
        const double e2 = (a * a - b * b) / (a * a);
        const double ep2 = (a * a - b * b) / (b * b);
        const double start = latitudeOrigin / (180 / Math.PI);

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
        const double b11 = 2.52124228E-13;
        const double b20 = -2.45028794E-15;
        const double b02 = -1.24958406E-13;
        const double b30 = -7.07576864E-22;
        const double b21 = 1.19781993E-19;
        const double b03 = -3.99273311E-20;
        const double b12 = -1.15211344E-19;
        const double b05 = 2.70578632E-34;
        const double b40 = 1.99430268E-29;
        const double b31 = 5.36306764E-27;
        const double b22 = -3.05593944E-27;
        const double b13 = -5.36306764E-27;
        const double b04 = 1.30468139E-27;
        const double b50 = 0;
        const double b41 = 1.35289316E-33;
        const double b32 = -1.01931619E-33;
        const double b23 = -2.70578632E-33;
        const double b14 = 1.2306633E-33;

        public double LatitudeOrigin => latitudeOrigin;
        public double LongitudeOrigin => longitudeOrigin;

        public double A => a;
        public double B => b;
        public double E2 => e2;
        public double EP2 => ep2;
        public double Start => start;
        public double N => A / Math.Sqrt(1 - E2 * Math.Pow(Math.Sin(Start), 2));
        public double T => Math.Tan(Start);
        public double ETA2 => EP2 * Math.Pow(Math.Cos(Start), 2);

        public double AA => 1 + 0.75 * E2 + 45.0 / 64 * E2 * E2 + 175.0 / 256 * E2 * E2 * E2 + 11025.0 / 16384 * E2 * E2 * E2 * E2 + 43659.0 / 65536 * E2 * E2 * E2 * E2 * E2;
        public double BB => 0.75 * E2 + 15.0 / 16 * E2 * E2 + 525.0 / 512 * E2 * E2 * E2 + 2205.0 / 2048 * E2 * E2 * E2 * E2 + 72765.0 / 65536 * E2 * E2 * E2 * E2 * E2;
        public double CC => 15.0 / 64 * E2 * E2 + 105.0 / 256 * E2 * E2 * E2 + 2205.0 / 4096 * E2 * E2 * E2 * E2 + 10395.0 / 16384 * E2 * E2 * E2 * E2 * E2;
        public double DD => 35.0 / 512 * E2 * E2 * E2 + 315.0 / 2048 * E2 * E2 * E2 * E2 + 31185.0 / 131072 * E2 * E2 * E2 * E2 * E2;
        public double EE => 315.0 / 16384 * E2 * E2 * E2 * E2 + 3465.0 / 65536 * E2 * E2 * E2 * E2 * E2;
        public double FF => 693.0 / 131072 * E2 * E2 * E2 * E2 * E2;

        public double A10 => N * (1 - ETA2 + ETA2 * ETA2 - ETA2 * ETA2 * ETA2);
        public double A01 => N * Math.Cos(start);
        public double A20 => 1.5 * N * T * (ETA2 - 2 * ETA2 * ETA2);
        public double A11 => N * Math.Cos(Start) * T * (-1 + ETA2 - ETA2 * ETA2);
        public double A02 => 0.5 * N * Math.Cos(Start) * Math.Cos(Start) * T;
        public double A30 => 0.5 * N * ETA2 * (1 - ETA2 * ETA2 - 2 * ETA2 + 7 * ETA2 * T * T);
        public double A03 => N / 6 * Math.Cos(Start) * Math.Cos(Start) * Math.Cos(Start) * (1 - T * T + ETA2);
        public double A21 => 0.5 * N * Math.Cos(Start) * (-1 + ETA2 - 3 * ETA2 * T * T - ETA2 * ETA2 + 6 * ETA2 * ETA2 * T * T);

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
    }
}
