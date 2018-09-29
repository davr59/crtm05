using Crtm05.Geographic;
using Xunit;

namespace Crtm05.Tests
{
    public class GeographicCoordinateTests
    {
        [Fact]
        public void ToDegreesMinutesSeconds_Coordinate_Converted()
        {
            var coordinate = 10.5;

            var geographicCoordinate = new GeographicCoordinate(coordinate);

            Assert.Equal(10, geographicCoordinate.Degrees);
            Assert.Equal(30, geographicCoordinate.Minutes);
            Assert.Equal(0, geographicCoordinate.Seconds);
        }

        [Fact]
        public void ToCoordinate_DegreesMinutesSeconds_Converted()
        {
            var degrees = 10;
            var minutes = 30;
            var seconds = 0;

            var geographicCoordinate = new GeographicCoordinate(degrees, minutes, seconds);

            Assert.Equal(10.5, geographicCoordinate.Coordinate);
        }
    }
}
