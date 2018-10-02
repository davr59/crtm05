export class GeographicCoordinate {
  private coordinate: number
  private degrees: number
  private minutes: number
  private seconds: number

  constructor (coordinate?: number, degrees?: number, minutes?: number, seconds?: number) {
    if (coordinate) {
      this.coordinate = coordinate
      this.updateDegreesMinutesSeconds()
    } else {
      this.degrees = degrees
      this.minutes = minutes
      this.seconds = seconds
      this.updateCoordinate()
    }
  }

  getCoordinate (): number {
    return this.coordinate
  }

  setCoordinate (coordinate: number) {
    this.coordinate = coordinate
    this.updateDegreesMinutesSeconds()
  }

  getDegrees (): number {
    return this.degrees
  }

  setDegrees (degrees: number) {
    this.degrees = degrees
    this.updateCoordinate()
  }

  getMinutes (): number {
    return this.minutes
  }

  setMinutes (minutes: number) {
    this.minutes = minutes
    this.updateCoordinate()
  }

  getSeconds (): number {
    return this.seconds
  }

  setSeconds (seconds: number) {
    this.seconds = seconds
    this.updateCoordinate()
  }

  private updateDegreesMinutesSeconds () {
    this.degrees = Math.floor(this.coordinate)
    this.minutes = Math.floor((this.coordinate - this.degrees) * 60)
    this.seconds = (this.coordinate - this.degrees - this.minutes / 60) * 3600
  }

  private updateCoordinate () {
    this.coordinate = this.degrees + this.minutes / 60 + this.seconds / 3600
  }
}
