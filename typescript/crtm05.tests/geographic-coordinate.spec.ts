import 'jasmine'
import { GeographicCoordinate } from '../crtm05/geographic/geographic-coordinate'

describe('geographic coordinate tests', () => {
  it('should convert to degrees, minutes, seconds correctly', () => {
    const geographicCoordinate = new GeographicCoordinate(10.5)

    expect(geographicCoordinate.getDegrees()).toBe(10)
    expect(geographicCoordinate.getMinutes()).toBe(30)
    expect(geographicCoordinate.getSeconds()).toBe(0)
  })

  it('should convert coordinate correctly', () => {
    const geographicCoordinate = new GeographicCoordinate(null, 10, 30, 0)

    expect(geographicCoordinate.getCoordinate()).toBe(10.5)
  })
})
