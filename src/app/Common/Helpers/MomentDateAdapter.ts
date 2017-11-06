import { DateAdapter } from '@angular/material';
import { Moment } from 'moment';
import * as moment from 'moment';

export class MomentDateAdapter extends DateAdapter<Moment> {

    parse(value: any, parseFormat: any): Moment {
        return moment(value, parseFormat);
    }

    getYear(date: Moment): number {
        return date.year();
    }
    getMonth(date: Moment): number {
        return date.month();
    }
    getDate(date: Moment): number {
        return date.date();
    }
    getDayOfWeek(date: Moment): number {
        return date.week();
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
        const days: string[] = [];

        for (let i = 1; i <= daytotal; i++) {
            days.push(i.toString());
        }

        return days;
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
    getYearName(date: Moment): string {
        return date.format('yyyy');
    }
    getFirstDayOfWeek(): number {
        return moment().weekday();
    }
    getNumDaysInMonth(date: Moment): number {
        return date.daysInMonth();
    }
    clone(date: Moment): Moment {
        return date.clone();
    }
    createDate(year: number, month: number, date: number): Moment {
        return moment(date).month(month).year(year);
    }
    today(): Moment {
        return moment(new Date());
    }
    format(date: Moment, displayFormat: any): string {
        return date.format(displayFormat);
    }
    addCalendarYears(date: Moment, years: number): Moment {
        return date.add(years, 'year');
    }
    addCalendarMonths(date: Moment, months: number): Moment {
        return date.add(months, 'month');
    }
    addCalendarDays(date: Moment, days: number): Moment {
        return date.add(days, 'day');
    }
    toIso8601(date: Moment): string {
        return date.toISOString();
    }
    fromIso8601(iso8601String: string): Moment {
        return moment(iso8601String);
    }
    isDateInstance(obj: any): boolean {
       return moment(obj).isValid();
    }
    isValid(date: Moment): boolean {
        return date.isValid();
    }

    // Implementation for remaining abstract methods of DateAdapter.
}
