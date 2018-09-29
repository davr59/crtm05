const _latitudeOrigin: number = 10;
const _longitudeOrigin: number = -84;
const _la: number = 1105854.83321889;
const _fe: number = 500000;
const _rho: number = Math.PI / 180;

class Parameters implements IParameters {
  latitudeOrigin: number = _latitudeOrigin;
  longitudeOrigin: number = _longitudeOrigin;
  la: number = _la;
  fe: number = _fe;
  rho: number = _rho;
}
