using Xunit;
using Crtm05.Geographic;
using System;
using Crtm05.Lambert;
using Crtm05.Ctrm05;

namespace Crtm05.Tests
{
    public class UnitTestConvertCoordinatesTests
    {
        [Fact]
        public void ToGeographic_Crtm05CoordinateSystem_Converted()
        {
            var latitude = 1105744;
            var longitude = 500000;

            var geographicCoordinateSystem = ConvertCoordinates.ToGeographic(new Crtm05CoordinateSystem(latitude, longitude));

            Assert.Equal(10, Math.Round(geographicCoordinateSystem.Latitude));
            Assert.Equal(9, geographicCoordinateSystem.LatitudeDegrees);
            Assert.Equal(59, geographicCoordinateSystem.LatitudeMinutes);
            Assert.Equal(60, Math.Round(geographicCoordinateSystem.LatitudeSeconds));

            Assert.Equal(-84, Math.Round(geographicCoordinateSystem.Longitude));
            Assert.Equal(-84, geographicCoordinateSystem.LongitudeDegrees);
            Assert.Equal(0, geographicCoordinateSystem.LongitudeMinutes);
            Assert.Equal(0, Math.Round(geographicCoordinateSystem.LongitudeSeconds));
        }

        [Fact]
        public void ToNorthLambert_Crtm05CoordinateSystem_Converted()
        {
            var latitude = 1001163;
            var longitude = 463569;

            var northLambertCoordinateSystem = ConvertCoordinates.ToNorthLambert(new Crtm05CoordinateSystem(latitude, longitude));

            Assert.Equal(115744, Math.Round(northLambertCoordinateSystem.Latitude));

            Assert.Equal(500000, Math.Round(northLambertCoordinateSystem.Longitude));
        }

        [Fact]
        public void ToSouthLambert_Crtm05CoordinateSystem_Converted()
        {
            var latitude = 782827;
            var longitude = 537035;

            var southLambertCoordinateSystem = ConvertCoordinates.ToSouthLambert(new Crtm05CoordinateSystem(latitude, longitude));

            Assert.Equal(115744, Math.Round(southLambertCoordinateSystem.Latitude));

            Assert.Equal(500000, Math.Round(southLambertCoordinateSystem.Longitude));
        }

        [Fact]
        public void ToCrtm05_GeographicCoordinateSystem_Converted()
        {
            var latitude = 10;
            var longitude = -84;

            var crtm05CoordinateSystem = ConvertCoordinates.ToCrtm05(new GeographicCoordinateSystem(latitude, longitude));

            Assert.Equal(1105744, Math.Round(crtm05CoordinateSystem.Latitude));

            Assert.Equal(500000, Math.Round(crtm05CoordinateSystem.Longitude));
        }

        [Fact]
        public void ToCrtm05_NorthLambertCoordinateSystem_Converted()
        {
            var latitude = 115744;
            var longitude = 500000;

            var crtm05CoordinateSystem = ConvertCoordinates.ToCrtm05(new NorthLambertCoordinateSystem(latitude, longitude));

            Assert.Equal(1001163, Math.Round(crtm05CoordinateSystem.Latitude));

            Assert.Equal(463569, Math.Round(crtm05CoordinateSystem.Longitude));
        }

        [Fact]
        public void ToCrtm05_SouthLambertCoordinateSystem_Converted()
        {
            var latitude = 115744;
            var longitude = 500000;

            var crtm05CoordinateSystem = ConvertCoordinates.ToCrtm05(new SouthLambertCoordinateSystem(latitude, longitude));

            Assert.Equal(782827, Math.Round(crtm05CoordinateSystem.Latitude));

            Assert.Equal(537035, Math.Round(crtm05CoordinateSystem.Longitude));
        }
    }
}
