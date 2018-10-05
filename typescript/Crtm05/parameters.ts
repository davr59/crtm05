import { IParameters } from './iparameters';

const _latitudeOrigin = 10;
const _longitudeOrigin = -84;
const _la = 1105854.83321889;
const _fe = 500000;
const _rho: number = Math.PI / 180;

export class Parameters implements IParameters {
  latitudeOrigin: number = _latitudeOrigin;
  longitudeOrigin: number = _longitudeOrigin;
  la: number = _la;
  fe: number = _fe;
  rho: number = _rho;
}
