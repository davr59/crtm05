import { CoordinateSystem } from '../coordinate-system';

export class NorthLambertCoordinateSystem extends CoordinateSystem {
  constructor(latitude: number, longitude: number) {
    super(latitude, longitude);
  }
}
