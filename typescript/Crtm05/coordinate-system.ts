abstract class CoordinateSystem {
  protected constructor(private latitude: number, private longitude: number) {}

  getLatitude(): number {
    return this.latitude;
  }

  getLongitude(): number {
    return this.longitude;
  }

  setLatitude(latitude: number) {
    this.latitude = latitude;
  }

  setLongitude(longitude: number) {
    this.longitude = longitude;
  }
}
