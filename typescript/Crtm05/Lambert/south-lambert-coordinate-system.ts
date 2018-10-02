import { CoordinateSystem } from '../coordinate-system';

export class SouthLambertCoordinateSystem extends CoordinateSystem {
  constructor(latitude: number, longitude: number) {
    super(latitude, longitude);
  }
}
