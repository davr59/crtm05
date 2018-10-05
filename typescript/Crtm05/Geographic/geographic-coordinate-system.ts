import { CoordinateSystem } from '../coordinate-system';
import { GeographicCoordinate } from './geographic-coordinate';

export class GeographicCoordinateSystem extends CoordinateSystem {
  latitudeCoordinate: GeographicCoordinate;
  longitudeCoordinate: GeographicCoordinate;

  constructor(latitude: number, longitude: number) {
    super(latitude, longitude);
    this.latitudeCoordinate = new GeographicCoordinate(latitude);
    this.longitudeCoordinate = new GeographicCoordinate(longitude);
  }

  getLatitude(): number {
    return this.latitudeCoordinate.getCoordinate();
  }

  getLongitude(): number {
    return this.longitudeCoordinate.getCoordinate();
  }

  setLatitude(latitude: number) {
    this.latitudeCoordinate.setCoordinate(latitude);
  }

  setLongitude(longitude: number) {
    this.longitudeCoordinate.setCoordinate(longitude);
  }
}
