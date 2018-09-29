class GeographicCoordinateSystem extends CoordinateSystem {
  latitudeCoordinate: GeographicCoordinate;
  longitudeCoordinate: GeographicCoordinate;

  constructor(latitude: number, longitude: number) {
    super(latitude, longitude);
    this.latitudeCoordinate = new GeographicCoordinate(latitude);
    this.longitudeCoordinate = new GeographicCoordinate(longitude);
  }
}
