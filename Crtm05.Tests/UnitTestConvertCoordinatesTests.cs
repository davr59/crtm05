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
        public void ToGeographicFromCrtm05()
        {
            var latitude = 1105744;
            var longitude = 500000;

            var geographicCoordinateSystem = ConvertCoordinates.ToGeographic(new Crtm05CoordinateSystem(latitude, longitude));

            Assert.Equal(10, Math.Round(geographicCoordinateSystem.Latitude.Coordinate));
            Assert.Equal(9, geographicCoordinateSystem.Latitude.Degrees);
            Assert.Equal(59, geographicCoordinateSystem.Latitude.Minutes);
            Assert.Equal(60, Math.Round(geographicCoordinateSystem.Latitude.Seconds));

            Assert.Equal(-84, Math.Round(geographicCoordinateSystem.Longitude.Coordinate));
            Assert.Equal(-84, geographicCoordinateSystem.Longitude.Degrees);
            Assert.Equal(0, geographicCoordinateSystem.Longitude.Minutes);
            Assert.Equal(0, Math.Round(geographicCoordinateSystem.Longitude.Seconds));
        }

        [Fact]
        public void ToNorthLambertFromCrtm05()
        {
            var latitude = 1001163;
            var longitude = 463569;

            var northLambertCoordinateSystem = ConvertCoordinates.ToNorthLambert(new Crtm05CoordinateSystem(latitude, longitude));

            Assert.Equal(115744, Math.Round(northLambertCoordinateSystem.Latitude));

            Assert.Equal(500000, Math.Round(northLambertCoordinateSystem.Longitude));
        }

        [Fact]
        public void ToSouthLambertFromCrtm05()
        {
            var latitude = 782827;
            var longitude = 537035;

            var southLambertCoordinateSystem = ConvertCoordinates.ToSouthLambert(new Crtm05CoordinateSystem(latitude, longitude));

            Assert.Equal(115744, Math.Round(southLambertCoordinateSystem.Latitude));

            Assert.Equal(500000, Math.Round(southLambertCoordinateSystem.Longitude));
        }

        [Fact]
        public void ToCrtm05FromGeographicCoordinateSystem()
        {
            var latitude = 10;
            var longitude = -84;

            var crtm05CoordinateSystem = ConvertCoordinates.ToCrtm05(new GeographicCoordinateSystem(new GeographicCoordinate(latitude), new GeographicCoordinate(longitude)));

            Assert.Equal(1105744, Math.Round(crtm05CoordinateSystem.Latitude));

            Assert.Equal(500000, Math.Round(crtm05CoordinateSystem.Longitude));
        }

        [Fact]
        public void ToCrtm05FromNorthLambertCoordinateSystem()
        {
            var latitude = 115744;
            var longitude = 500000;

            var crtm05CoordinateSystem = ConvertCoordinates.ToCrtm05(new NorthLambertCoordinateSystem(latitude, longitude));

            Assert.Equal(1001163, Math.Round(crtm05CoordinateSystem.Latitude));

            Assert.Equal(463569, Math.Round(crtm05CoordinateSystem.Longitude));
        }

        [Fact]
        public void ToCrtm05FromSouthLambertCoordinateSystem()
        {
            var latitude = 115744;
            var longitude = 500000;

            var crtm05CoordinateSystem = ConvertCoordinates.ToCrtm05(new SouthLambertCoordinateSystem(latitude, longitude));

            Assert.Equal(782827, Math.Round(crtm05CoordinateSystem.Latitude));

            Assert.Equal(537035, Math.Round(crtm05CoordinateSystem.Longitude));
        }
    }
}
