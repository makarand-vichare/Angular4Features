import { DateAdapter } from '@angular/material';
import * as moment from 'moment';

export class MomentDateAdapter extends DateAdapter<moment.Moment> {

    parse(value: any, parseFormat: any): moment.Moment {
        return moment(value, parseFormat);
    }

    getYear(date: moment.Moment): number {
        return date.year();
    }
    getMonth(date: moment.Moment): number {
        return date.month();
    }
    getDate(date: moment.Moment): number {
        return date.date();
    }
    getDayOfWeek(date: moment.Moment): number {
        return date.day();
    }
    getMonthNames(style: 'long' | 'short' | 'narrow'): string[] {
       let months = moment.months();
        switch (style) {
            case 'long':
            {
                // default
                break;
            }
            case 'short':
            {
                months = moment.monthsShort();
                break;
            }
            case 'narrow':
            {
                months = moment.monthsShort();
                break;
            }
        }
        return months;
    }
    getDateNames(): string[] {
        const daytotal = moment().daysInMonth();
        const dates: string[] = [];

        for (let i = 1; i <= 31; i++) {
            const date = this.createDate(moment().year(), 0, i ).format('D');
            dates.push(date);
        }

        return dates;
    }
    getDayOfWeekNames(style: 'long' | 'short' | 'narrow'): string[] {
        let weekdays = moment.weekdays();
        switch (style) {
            case 'long':
            {
                // default
                break;
            }
            case 'short':
            {
                weekdays = moment.weekdaysShort();
                break;
            }
            case 'narrow':
            {
                weekdays = moment.weekdaysMin();
                break;
            }
        }
        return weekdays;
    }
    getYearName(date: moment.Moment): string {
        return date.format('YYYY');
    }
    getFirstDayOfWeek(): number {
        return moment.localeData().firstDayOfWeek();
    }
    getNumDaysInMonth(date: moment.Moment): number {
        return date.daysInMonth();
    }
    clone(date: moment.Moment): moment.Moment {
        return date.clone();
    }
    createDate(year: number, month: number, date: number): moment.Moment {
        if (month < 0 || month > 11) {
            throw Error(`Invalid month index "${month}". Month index has to be between 0 and 11.`);
          }

          if (date < 1) {
            throw Error(`Invalid date "${date}". Date has to be greater than 0.`);
          }

          const result = moment({year, month, date});

          // If the result isn't valid, the date must have been out of bounds for this month.
          if (!result.isValid()) {
            throw Error(`Invalid date "${date}" for month with index "${month}".`);
          }

          return result;
    }
    today(): moment.Moment {
        return moment(new Date());
    }
    format(date: moment.Moment, displayFormat: any): string {
        return date.format(displayFormat);
    }
    addCalendarYears(date: moment.Moment, years: number): moment.Moment {
        return date.add(years, 'year');
    }
    addCalendarMonths(date: moment.Moment, months: number): moment.Moment {
        return date.add(months, 'month');
    }
    addCalendarDays(date: moment.Moment, days: number): moment.Moment {
        return date.add(days, 'day');
    }
    toIso8601(date: moment.Moment): string {
        return date.toISOString();
    }
    fromIso8601(iso8601String: string): moment.Moment {
        return moment(iso8601String);
    }
    isDateInstance(obj: any): boolean {
       return moment(obj).isValid();
    }
    isValid(date: moment.Moment): boolean {
        return date.isValid();
    }
}
