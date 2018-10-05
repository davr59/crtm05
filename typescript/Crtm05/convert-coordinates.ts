import { IParameters } from './iparameters';
import { ICoefficients } from './icoefficients';
import { Parameters } from './parameters';
import { Coefficients } from './coefficients';
import { Crtm05CoordinateSystem } from './ctrm05/crtm05-coordinate-system';
import { GeographicCoordinateSystem } from './geographic/geographic-coordinate-system';
import { NorthLambertCoordinateSystem } from './lambert/north-lambert-coordinate-system';
import { SouthLambertCoordinateSystem } from './lambert/south-lambert-coordinate-system';

export class ConvertCoordinates {
  static toGeographicFromCrtm05(
    coordinates: Crtm05CoordinateSystem,
    parameters: IParameters = new Parameters(),
    coefficients: ICoefficients = new Coefficients()
  ): GeographicCoordinateSystem {
    const deltaLatitude = coordinates.getLatitude() / 0.9999 - parameters.la;
    const deltaLongitude = (coordinates.getLongitude() - parameters.fe) / 0.9999;
    const deltaDegreesLatitude = this.deltaLatitude(
      deltaLatitude,
      deltaLongitude,
      coefficients.b10,
      coefficients.b20,
      coefficients.b02,
      coefficients.b30,
      coefficients.b12,
      coefficients.b40,
      coefficients.b22,
      coefficients.b04,
      coefficients.b50,
      coefficients.b32,
      coefficients.b14
    );
    const deltaDegreesLongitude = this.deltaLongitude(
      deltaLatitude,
      deltaLongitude,
      coefficients.b01,
      coefficients.b11,
      coefficients.b21,
      coefficients.b03,
      coefficients.b31,
      coefficients.b13,
      coefficients.b41,
      coefficients.b23,
      coefficients.b05
    );
    const latitude = deltaDegreesLatitude + parameters.latitudeOrigin;
    const longitude = deltaDegreesLongitude + parameters.longitudeOrigin;

    return new GeographicCoordinateSystem(latitude, longitude);
  }

  static toNorthLambertFromCrtm05(
    coordinates: Crtm05CoordinateSystem,
    coefficients: ICoefficients = new Coefficients()
  ): NorthLambertCoordinateSystem {
    const crtm98Latitude = this.crtmLatitude(
      coordinates.getLatitude(),
      coordinates.getLongitude(),
      coefficients.e0,
      coefficients.e1,
      coefficients.f1
    );
    const crtm98Longitude = this.crtmLongitude(
      coordinates.getLatitude(),
      coordinates.getLongitude(),
      coefficients.f0,
      coefficients.e1,
      coefficients.f1
    );
    const ctrm90Latitude = this.crtmLatitude(
      crtm98Latitude,
      crtm98Longitude,
      coefficients.m0,
      coefficients.m1,
      coefficients.n1
    );
    const ctrm90Longitude = this.crtmLongitude(
      crtm98Latitude,
      crtm98Longitude,
      coefficients.n0,
      coefficients.m1,
      coefficients.n1
    );
    const deltaLatitude = (ctrm90Latitude - 1156874.11) * 0.00001;
    const deltaLongitude = (ctrm90Longitude - 463736.66) * 0.00001;
    const latitude = this.fromDelta(
      deltaLatitude,
      deltaLongitude,
      coefficients.r00,
      coefficients.r10,
      coefficients.r01,
      coefficients.r20,
      coefficients.r11,
      coefficients.r02,
      coefficients.r30,
      0,
      coefficients.r12,
      0
    );
    const longitude = this.fromDelta(
      deltaLatitude,
      deltaLongitude,
      coefficients.s00,
      coefficients.s10,
      coefficients.s01,
      coefficients.s20,
      coefficients.s11,
      coefficients.s02,
      0,
      coefficients.s21,
      0,
      coefficients.s03
    );

    return new NorthLambertCoordinateSystem(latitude, longitude);
  }

  static toSouthLambertFromCrtm05(
    coordinates: Crtm05CoordinateSystem,
    coefficients: ICoefficients = new Coefficients()
  ): SouthLambertCoordinateSystem {
    const crtm98Latitude = this.crtmLatitude(
      coordinates.getLatitude(),
      coordinates.getLongitude(),
      coefficients.e0,
      coefficients.e1,
      coefficients.f1
    );
    const crtm98Longitude = this.crtmLongitude(
      coordinates.getLatitude(),
      coordinates.getLongitude(),
      coefficients.f0,
      coefficients.e1,
      coefficients.f1
    );
    const ctrm90Latitude = this.crtmLatitude(
      crtm98Latitude,
      crtm98Longitude,
      coefficients.m0,
      coefficients.m1,
      coefficients.n1
    );
    const ctrm90Longitude = this.crtmLongitude(
      crtm98Latitude,
      crtm98Longitude,
      coefficients.n0,
      coefficients.m1,
      coefficients.n1
    );
    const deltaLatitude = (ctrm90Latitude - 994727.07) * 0.00001;
    const deltaLongitude = (ctrm90Longitude - 536853.82) * 0.00001;
    const latitude = this.fromDelta(
      deltaLatitude,
      deltaLongitude,
      coefficients.t00,
      coefficients.t10,
      coefficients.t01,
      coefficients.t20,
      coefficients.t11,
      0,
      coefficients.t30,
      coefficients.t21,
      coefficients.t12,
      0
    );
    const longitude = this.fromDelta(
      deltaLatitude,
      deltaLongitude,
      coefficients.u00,
      coefficients.u10,
      coefficients.u01,
      coefficients.u20,
      coefficients.u11,
      coefficients.u02,
      0,
      coefficients.u21,
      0,
      coefficients.u03
    );

    return new SouthLambertCoordinateSystem(latitude, longitude);
  }

  static ToCrtm05FromGeographic(
    coordinates: GeographicCoordinateSystem,
    parameters: IParameters = new Parameters(),
    coefficients: ICoefficients = new Coefficients()
  ): Crtm05CoordinateSystem {
    const deltaDegreesLatitude = coordinates.getLatitude() - parameters.latitudeOrigin;
    const deltaDegreesLongitude = coordinates.getLongitude() - parameters.longitudeOrigin;
    const deltaRadiansLatitude = deltaDegreesLatitude * parameters.rho;
    const deltaRadiansLongitude = deltaDegreesLongitude * parameters.rho;
    const deltaLatitude = this.deltaLatitude(
      deltaRadiansLatitude,
      deltaRadiansLongitude,
      coefficients.a10,
      coefficients.a20,
      coefficients.a02,
      coefficients.a30,
      coefficients.a12,
      coefficients.a40,
      coefficients.a22,
      coefficients.a04,
      coefficients.a50,
      coefficients.a32,
      coefficients.a14
    );
    const deltaLongitude = this.deltaLongitude(
      deltaRadiansLatitude,
      deltaRadiansLongitude,
      coefficients.a01,
      coefficients.a11,
      coefficients.a21,
      coefficients.a03,
      coefficients.a31,
      coefficients.a13,
      coefficients.a41,
      coefficients.a23,
      coefficients.a05
    );
    const latitude = (parameters.la + deltaLatitude) * 0.9999;
    const longitude = parameters.fe + deltaLongitude * 0.9999;

    return new Crtm05CoordinateSystem(latitude, longitude);
  }

  static toCrtm05FromNorthLambert(
    coordinates: NorthLambertCoordinateSystem,
    coefficients: ICoefficients = new Coefficients()
  ): Crtm05CoordinateSystem {
    const deltaLatitude = (coordinates.getLatitude() - 271820.52) * 0.00001;
    const deltaLongitude = (coordinates.getLongitude() - 500000) * 0.00001;
    const crtm90Latitude = this.fromDelta(
      deltaLatitude,
      deltaLongitude,
      coefficients.aa00,
      coefficients.aa10,
      coefficients.aa01,
      coefficients.aa20,
      coefficients.aa11,
      0,
      coefficients.aa30,
      coefficients.aa21,
      coefficients.aa12,
      coefficients.aa03
    );
    const crtm90Longitude = this.fromDelta(
      deltaLatitude,
      deltaLongitude,
      coefficients.bb00,
      coefficients.bb10,
      coefficients.bb01,
      coefficients.bb20,
      0,
      coefficients.bb02,
      0,
      coefficients.bb21,
      coefficients.bb12,
      coefficients.bb03
    );
    const crtm98Latitude = this.crtmLatitude(
      crtm90Latitude,
      crtm90Longitude,
      coefficients.mm0,
      coefficients.mm1,
      coefficients.nn1
    );
    const crtm98Longitude = this.crtmLongitude(
      crtm90Latitude,
      crtm90Longitude,
      coefficients.nn0,
      coefficients.mm1,
      coefficients.nn1
    );
    const latitude = this.crtmLatitude(
      crtm98Latitude,
      crtm98Longitude,
      coefficients.ee0,
      coefficients.ee1,
      coefficients.ff1
    );
    const longitude = this.crtmLongitude(
      crtm98Latitude,
      crtm98Longitude,
      coefficients.ff0,
      coefficients.ee1,
      coefficients.ff1
    );

    return new Crtm05CoordinateSystem(latitude, longitude);
  }

  static toCrtm05FromSouthLambert(
    coordinates: SouthLambertCoordinateSystem,
    coefficients: ICoefficients = new Coefficients()
  ): Crtm05CoordinateSystem {
    const deltaLatitude = (coordinates.getLatitude() - 327987.44) * 0.00001;
    const deltaLongitude = (coordinates.getLongitude() - 500000) * 0.00001;
    const crtm90Latitude = this.fromDelta(
      deltaLatitude,
      deltaLongitude,
      coefficients.c00,
      coefficients.c10,
      coefficients.c01,
      coefficients.c20,
      coefficients.c11,
      0,
      coefficients.c30,
      coefficients.c21,
      coefficients.c12,
      coefficients.c03
    );
    const crtm90Longitude = this.fromDelta(
      deltaLatitude,
      deltaLongitude,
      coefficients.d00,
      coefficients.d10,
      coefficients.d01,
      coefficients.d20,
      0,
      coefficients.d02,
      0,
      coefficients.d21,
      coefficients.d12,
      coefficients.d03
    );
    const crtm98Latitude = this.crtmLatitude(
      crtm90Latitude,
      crtm90Longitude,
      coefficients.mm0,
      coefficients.mm1,
      coefficients.nn1
    );
    const crtm98Longitude = this.crtmLongitude(
      crtm90Latitude,
      crtm90Longitude,
      coefficients.nn0,
      coefficients.mm1,
      coefficients.nn1
    );
    const latitude = this.crtmLatitude(
      crtm98Latitude,
      crtm98Longitude,
      coefficients.ee0,
      coefficients.ee1,
      coefficients.ff1
    );
    const longitude = this.crtmLongitude(
      crtm98Latitude,
      crtm98Longitude,
      coefficients.ff0,
      coefficients.ee1,
      coefficients.ff1
    );

    return new Crtm05CoordinateSystem(latitude, longitude);
  }

  private static deltaLatitude(
    deltaLatitude: number,
    deltaLongitude: number,
    coefficient1: number,
    coefficient2: number,
    coefficient3: number,
    coefficient4: number,
    coefficient5: number,
    coefficient6: number,
    coefficient7: number,
    coefficient8: number,
    coefficient9: number,
    coefficient10: number,
    coefficient11: number
  ): number {
    return (
      deltaLatitude * coefficient1 +
      deltaLatitude * deltaLatitude * coefficient2 +
      deltaLongitude * deltaLongitude * coefficient3 +
      deltaLatitude * deltaLatitude * deltaLatitude * coefficient4 +
      deltaLatitude * deltaLongitude * deltaLongitude * coefficient5 +
      deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * coefficient6 +
      deltaLatitude * deltaLatitude * deltaLongitude * deltaLongitude * coefficient7 +
      deltaLongitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficient8 +
      deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * coefficient9 +
      deltaLatitude *
        deltaLatitude *
        deltaLatitude *
        deltaLongitude *
        deltaLongitude *
        coefficient10 +
      deltaLatitude *
        deltaLongitude *
        deltaLongitude *
        deltaLongitude *
        deltaLongitude *
        coefficient11
    );
  }

  private static deltaLongitude(
    deltaLatitude: number,
    deltaLongitude: number,
    coefficient1: number,
    coefficient2: number,
    coefficient3: number,
    coefficient4: number,
    coefficient5: number,
    coefficient6: number,
    coefficient7: number,
    coefficient8: number,
    coefficient9: number
  ): number {
    return (
      deltaLongitude * coefficient1 +
      deltaLatitude * deltaLongitude * coefficient2 +
      deltaLatitude * deltaLatitude * deltaLongitude * coefficient3 +
      deltaLongitude * deltaLongitude * deltaLongitude * coefficient4 +
      deltaLatitude * deltaLatitude * deltaLatitude * deltaLatitude * coefficient5 +
      deltaLatitude * deltaLongitude * deltaLongitude * deltaLongitude * coefficient6 +
      deltaLatitude *
        deltaLatitude *
        deltaLatitude *
        deltaLatitude *
        deltaLongitude *
        coefficient7 +
      deltaLatitude *
        deltaLatitude *
        deltaLongitude *
        deltaLongitude *
        deltaLongitude *
        coefficient8 +
      deltaLongitude *
        deltaLongitude *
        deltaLongitude *
        deltaLongitude *
        deltaLongitude *
        coefficient9
    );
  }

  private static fromDelta(
    deltaLatitude: number,
    deltaLongitude: number,
    coefficient1: number,
    coefficient2: number,
    coefficient3: number,
    coefficient4: number,
    coefficient5: number,
    coefficient6: number,
    coefficient7: number,
    coefficient8: number,
    coefficient9: number,
    coefficient10: number
  ): number {
    return (
      coefficient1 +
      coefficient2 * deltaLatitude +
      coefficient3 * deltaLongitude +
      coefficient4 * deltaLatitude * deltaLatitude +
      coefficient5 * deltaLatitude * deltaLongitude +
      coefficient6 * deltaLongitude * deltaLongitude +
      coefficient7 * deltaLatitude * deltaLatitude * deltaLatitude +
      coefficient8 * deltaLatitude * deltaLatitude * deltaLongitude +
      coefficient9 * deltaLatitude * deltaLongitude * deltaLongitude +
      coefficient10 * deltaLongitude * deltaLongitude * deltaLongitude
    );
  }

  private static crtmLatitude(
    crtmLatitude: number,
    crtmLongitude: number,
    coefficient1: number,
    coefficient2: number,
    coefficient3: number
  ): number {
    return this.crtmLongitude(
      crtmLongitude,
      crtmLatitude,
      coefficient1,
      coefficient2,
      -1 * coefficient3
    );
  }

  private static crtmLongitude(
    crtmLatitude: number,
    crtmLongitude: number,
    coefficient1: number,
    coefficient2,
    coefficient3: number
  ): number {
    return coefficient1 + coefficient2 * crtmLongitude + coefficient3 * crtmLatitude;
  }
}
