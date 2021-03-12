import { Customer } from './customer';
import { Guid } from 'guid-typescript';

export const CUSTOMERS: Customer[] = [
  { id: Guid.create(), firstName: 'John', surName: 'Smith' },
  { id: Guid.create(), firstName: 'John2', surName: 'Smith' },
  { id: Guid.create(), firstName: 'John3', surName: 'Smith2' },
  { id: Guid.create(), firstName: 'John4', surName: 'Smith' },
  { id: Guid.create(), firstName: 'John5', surName: 'Smith' },
  { id: Guid.create(), firstName: 'John6', surName: 'Smith' },
  { id: Guid.create(), firstName: 'John7', surName: 'Smith' },
  { id: Guid.create(), firstName: 'John8', surName: 'Smith' },
  { id: Guid.create(), firstName: 'John9', surName: 'Smith' },
  { id: Guid.create(), firstName: 'John10', surName: 'Smith' }
];