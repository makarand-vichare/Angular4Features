export class AppConstants {
  static get SWAPIUrl(): string { return 'https://swapi.co/api'; }
  static get AuthAPIUrl(): string { return 'http://localhost:8888'; }
  static get RandomDistance(): number { return 1000000; }
}

export const MOMENT_FORMATS = {
  parse: {
   // dateInput: {month: 'short', year: 'numeric', day: 'numeric'}
     dateInput: 'LL',
  },
  display: {
      dateInput: 'DD/MM/YYYY',
      monthYearLabel: 'MMM YYYY',
      shortDate: 'DD/MM/YYYY',
      // See DateFormats for other required formats.
  },
};
