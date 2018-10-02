import 'jasmine'
import { ConvertCoordinates } from '../crtm05/convert-coordinates'
import { Crtm05CoordinateSystem } from '../crtm05/ctrm05/crtm05-coordinate-system'
import { GeographicCoordinateSystem } from '../crtm05/geographic/geographic-coordinate-system'

describe('convert coordinates tests', () => {
  it('should convert to geographic from crtm05 correctly', () => {
    var geographicCoordinateSystem = ConvertCoordinates.toGeographicFromCrtm05(
      new Crtm05CoordinateSystem(1105744, 500000)
    )

    expect(Math.round(geographicCoordinateSystem.latitudeCoordinate.getCoordinate())).toBe(10)
    expect(geographicCoordinateSystem.latitudeCoordinate.getDegrees()).toBe(9)
    expect(geographicCoordinateSystem.latitudeCoordinate.getMinutes()).toBe(59)
    expect(Math.round(geographicCoordinateSystem.latitudeCoordinate.getSeconds())).toBe(60)

    expect(Math.round(geographicCoordinateSystem.longitudeCoordinate.getCoordinate())).toBe(-84)
    expect(geographicCoordinateSystem.longitudeCoordinate.getDegrees()).toBe(-84)
    expect(geographicCoordinateSystem.longitudeCoordinate.getMinutes()).toBe(0)
    expect(Math.round(geographicCoordinateSystem.longitudeCoordinate.getSeconds())).toBe(0)
  })

  it('should convert to north lambert from crtm05 correctly', () => {
    var northLambertCoordinateSystem = ConvertCoordinates.toNorthLambertFromCrtm05(
      new Crtm05CoordinateSystem(1001163, 463569)
    )

    expect(Math.round(northLambertCoordinateSystem.getLatitude())).toBe(115744)
    expect(Math.round(northLambertCoordinateSystem.getLongitude())).toBe(500000)
  })

  it('should convert to south lambert from crtm05 correctly', () => {
    var southLambertCoordinateSystem = ConvertCoordinates.toSouthLambertFromCrtm05(
      new Crtm05CoordinateSystem(782827, 537035)
    )

    expect(Math.round(southLambertCoordinateSystem.getLatitude())).toBe(115744)
    expect(Math.round(southLambertCoordinateSystem.getLongitude())).toBe(500000)
  })

  it('should convert to crtm05 from geographic correctly', () => {
    var crtm05CoordinateSystem = ConvertCoordinates.ToCrtm05FromGeographic(
      new GeographicCoordinateSystem(10, -84)
    )

    expect(Math.round(crtm05CoordinateSystem.getLatitude())).toBe(1105744)
    expect(Math.round(crtm05CoordinateSystem.getLongitude())).toBe(500000)
  })

  it('should convert to crtm05 from north lambert correctly', () => {
    var crtm05CoordinateSystem = ConvertCoordinates.toCrtm05FromNorthLambert(
      new GeographicCoordinateSystem(115744, 500000)
    )

    expect(Math.round(crtm05CoordinateSystem.getLatitude())).toBe(1001163)
    expect(Math.round(crtm05CoordinateSystem.getLongitude())).toBe(463569)
  })

  it('should convert to crtm05 from south lambert correctly', () => {
    var crtm05CoordinateSystem = ConvertCoordinates.toCrtm05FromSouthLambert(
      new GeographicCoordinateSystem(115744, 500000)
    )

    expect(Math.round(crtm05CoordinateSystem.getLatitude())).toBe(782827)
    expect(Math.round(crtm05CoordinateSystem.getLongitude())).toBe(537035)
  })
})
