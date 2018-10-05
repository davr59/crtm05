import { ICoefficients } from './icoefficients';

const _a10 = 6337358;
const _a01 = 6281873;
const _a20 = 10883;
const _a11 = -1100471;
const _a02 = 545418;
const _a30 = 19956;
const _a03 = 990475;
const _a21 = -3122430;
const _a12 = 2997671.141;
const _a14 = 1110311.476;
const _a40 = -3675.842;
const _a13 = -894370.419;
const _a04 = 221627.399;
const _a31 = 172656.502;
const _a22 = -1085654.527;
const _a50 = 0;
const _a41 = 261744.701;
const _a32 = -1998031.096;
const _a23 = -2333314.547;
const _a05 = 218688.67;

const _b10 = 0.00000904095657;
const _b01 = 0.00000912081175;
const _b11 = 0.000000000000252124228;
const _b20 = -0.00000000000000245028794;
const _b02 = -0.000000000000124958406;
const _b30 = -0.000000000000000000000707576864;
const _b21 = 0.000000000000000000119781993;
const _b03 = -0.0000000000000000000399273311;
const _b12 = -0.000000000000000000115211344;
const _b05 = 0.000000000000000000000000000000000270578632;
const _b40 = 0.0000000000000000000000000000199430268;
const _b31 = 0.00000000000000000000000000536306764;
const _b22 = -0.00000000000000000000000000305593944;
const _b13 = -0.00000000000000000000000000536306764;
const _b04 = 0.00000000000000000000000000130468139;
const _b50 = 0;
const _b41 = 0.00000000000000000000000000000000135289316;
const _b32 = -0.00000000000000000000000000000000101931619;
const _b23 = -0.00000000000000000000000000000000270578632;
const _b14 = 0.0000000000000000000000000000000012306633;

const _e0 = 0.179913184;
const _f0 = 149.644487588;
const _e1 = 0.99969990521;
const _f1 = 0.00000034731;

const _m0 = 7.75237044;
const _n0 = 3.525688428;
const _m1 = 0.99999913361;
const _n1 = 0.00000000018;

const _r00 = 271820.52;
const _r10 = 100035.73;
const _r01 = 105.26;
const _r20 = -0.03;
const _r11 = 8.97;
const _r02 = 0.02;
const _r30 = 4.13;
const _r12 = -12.38;

const _s00 = 500000;
const _s10 = -105.25;
const _s01 = 100035.72;
const _s20 = -4.48;
const _s11 = -0.06;
const _s02 = 4.49;
const _s21 = 12.37;
const _s03 = -4.13;

const _t00 = 327987.44;
const _t10 = 100035.74;
const _t01 = -91.39;
const _t20 = -0.01;
const _t11 = -9.13;
const _t21 = -0.02;
const _t30 = 4.12;
const _t12 = -12.38;

const _u00 = 500000;
const _u10 = 91.38;
const _u01 = 100035.72;
const _u20 = 4.57;
const _u11 = -0.04;
const _u02 = -4.57;
const _u21 = 12.39;
const _u03 = -4.13;

const _aa00 = 1156874.11;
const _aa10 = 99964.18;
const _aa01 = -105.22;
const _aa20 = -0.01;
const _aa11 = -8.97;
const _aa30 = -4.15;
const _aa21 = 0.03;
const _aa12 = 12.37;
const _aa03 = 0;

const _bb00 = 463736.66;
const _bb10 = 105.19;
const _bb01 = 99964.19;
const _bb20 = 4.49;
const _bb02 = -4.49;
const _bb21 = -12.39;
const _bb12 = 0.03;
const _bb03 = 4.12;

const _ee0 = -0.179913184;
const _ff0 = -149.644487588;
const _ee1 = 1.00030018487392;
const _ff1 = -0.00000034731;

const _mm0 = -7.75237044;
const _nn0 = -3.525688428;
const _mm1 = 1.00000086639075;
const _nn1 = -0.00000000018;

const _c00 = 994727.07;
const _c10 = 99964.19;
const _c01 = 91.33;
const _c20 = 0;
const _c11 = 9.12;
const _c30 = -4.12;
const _c21 = -0.03;
const _c12 = 12.37;
const _c03 = 0.01;

const _d00 = 536853.82;
const _d10 = -91.32;
const _d01 = 99964.21;
const _d20 = -4.56;
const _d02 = 4.56;
const _d21 = -12.36;
const _d12 = -0.03;
const _d03 = 4.12;

export class Coefficients implements ICoefficients {
  a10: number = _a10;
  a01: number = _a01;
  a20: number = _a20;
  a11: number = _a11;
  a02: number = _a02;
  a30: number = _a30;
  a03: number = _a03;
  a21: number = _a21;
  a12: number = _a12;
  a14: number = _a14;
  a40: number = _a40;
  a13: number = _a13;
  a04: number = _a04;
  a31: number = _a31;
  a22: number = _a22;
  a50: number = _a50;
  a41: number = _a41;
  a32: number = _a32;
  a23: number = _a23;
  a05: number = _a05;

  b10: number = _b10;
  b01: number = _b01;
  b11: number = _b11;
  b20: number = _b20;
  b02: number = _b02;
  b30: number = _b30;
  b21: number = _b21;
  b03: number = _b03;
  b12: number = _b12;
  b05: number = _b05;
  b40: number = _b40;
  b31: number = _b31;
  b22: number = _b22;
  b13: number = _b13;
  b04: number = _b04;
  b50: number = _b50;
  b41: number = _b41;
  b32: number = _b32;
  b23: number = _b23;
  b14: number = _b14;

  e0: number = _e0;
  f0: number = _f0;
  e1: number = _e1;
  f1: number = _f1;

  m0: number = _m0;
  n0: number = _n0;
  m1: number = _m1;
  n1: number = _n1;

  r00: number = _r00;
  r10: number = _r10;
  r01: number = _r01;
  r20: number = _r20;
  r11: number = _r11;
  r02: number = _r02;
  r30: number = _r30;
  r12: number = _r12;

  s00: number = _s00;
  s10: number = _s10;
  s01: number = _s01;
  s20: number = _s20;
  s11: number = _s11;
  s02: number = _s02;
  s21: number = _s21;
  s03: number = _s03;

  t00: number = _t00;
  t10: number = _t10;
  t01: number = _t01;
  t20: number = _t20;
  t11: number = _t11;
  t21: number = _t21;
  t30: number = _t30;
  t12: number = _t12;

  u00: number = _u00;
  u10: number = _u10;
  u01: number = _u01;
  u20: number = _u20;
  u11: number = _u11;
  u02: number = _u02;
  u21: number = _u21;
  u03: number = _u03;

  aa00: number = _aa00;
  aa10: number = _aa10;
  aa01: number = _aa01;
  aa20: number = _aa20;
  aa11: number = _aa11;
  aa30: number = _aa30;
  aa21: number = _aa21;
  aa12: number = _aa12;
  aa03: number = _aa03;

  bb00: number = _bb00;
  bb10: number = _bb10;
  bb01: number = _bb01;
  bb20: number = _bb20;
  bb02: number = _bb02;
  bb21: number = _bb21;
  bb12: number = _bb12;
  bb03: number = _bb03;

  ee0: number = _ee0;
  ff0: number = _ff0;
  ee1: number = _ee1;
  ff1: number = _ff1;

  mm0: number = _mm0;
  nn0: number = _nn0;
  mm1: number = _mm1;
  nn1: number = _nn1;

  c00: number = _c00;
  c10: number = _c10;
  c01: number = _c01;
  c20: number = _c20;
  c11: number = _c11;
  c30: number = _c30;
  c21: number = _c21;
  c12: number = _c12;
  c03: number = _c03;

  d00: number = _d00;
  d10: number = _d10;
  d01: number = _d01;
  d20: number = _d20;
  d02: number = _d02;
  d21: number = _d21;
  d12: number = _d12;
  d03: number = _d03;
}
