export class Functions {
    static toPounds(kg: number): number {
        return Number((kg * 2.20462).toFixed(1));
    }

    static toKilograms(lbs: number): number {
        return Number((lbs / 2.20462).toFixed(2));
    }

    static toInches(cm: number): number {
        return Number((cm / 2.54).toFixed(1));
    }

    static toCentimeters(inch: number): number {
        return Number((inch * 2.54).toFixed(1));
    }
}