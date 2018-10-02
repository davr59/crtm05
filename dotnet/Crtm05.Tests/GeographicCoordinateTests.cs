using Crtm05.Geographic;
using Xunit;

namespace Crtm05.Tests
{
  public class GeographicCoordinateTests
  {
    [Fact]
    public void ToDegreesMinutesSeconds_Coordinate_Converted()
    {
      var geographicCoordinate = new GeographicCoordinate(10.5);

      Assert.Equal(10, geographicCoordinate.Degrees);
      Assert.Equal(30, geographicCoordinate.Minutes);
      Assert.Equal(0, geographicCoordinate.Seconds);
    }

    [Fact]
    public void ToCoordinate_DegreesMinutesSeconds_Converted()
    {
      var geographicCoordinate = new GeographicCoordinate(10, 30, 0);

      Assert.Equal(10.5, geographicCoordinate.Coordinate);
    }
  }
}
