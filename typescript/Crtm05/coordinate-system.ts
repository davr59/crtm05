export abstract class CoordinateSystem {
  protected constructor(private latitude: number, private longitude: number) {}

  public getLatitude(): number {
    return this.latitude;
  }

  public getLongitude(): number {
    return this.longitude;
  }

  public setLatitude(latitude: number) {
    this.latitude = latitude;
  }

  public setLongitude(longitude: number) {
    this.longitude = longitude;
  }
}
