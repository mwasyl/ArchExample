import { Trip } from './trip';
import { Guid } from 'guid-typescript';

export const TRIPS: Trip[] = [
  { id: Guid.parse('f4bda814-ce8c-8fc9-a9e8-1152658c2eea'), destination: 'Lodz' },
  { id: Guid.parse('09cc4f79-fbfb-f51d-5967-8cf3d4d825f5'), destination: 'Warsaw' },
  { id: Guid.parse('3db4bf06-7fbc-ee92-330c-cd93d4d6b49c'), destination: 'Kielce' },
  { id: Guid.parse('237a18d3-894c-a2a8-415e-798f732d57c8'), destination: 'Lublin' },
  { id: Guid.parse('8ae08ff4-7a9b-9455-5ce0-c8b34d2add74'), destination: 'Rzeszów' },
  { id: Guid.parse('3a2a851b-7993-0651-e20d-62ba701b12fe'), destination: 'Kraków' },
  { id: Guid.parse('eeb193d6-81d4-d106-48cc-17f1fb1f52b4'), destination: 'Gdynia' },
  { id: Guid.parse('9c089103-abb2-1a8b-2537-e16ae60b67f0'), destination: 'Poznań' },
  { id: Guid.parse('fab2aaba-2eba-67dc-f168-ccdb4a85e262'), destination: 'Siedlce' },
  { id: Guid.parse('aa58a46a-9841-20a2-151c-0bbbc353737b'), destination: 'Sopot' }
];