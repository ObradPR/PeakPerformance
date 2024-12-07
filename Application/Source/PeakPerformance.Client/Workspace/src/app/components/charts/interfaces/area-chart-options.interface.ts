export interface IAreaChartOptions {
    xField: string,
    yField: string,
    yFieldDefaultValue: number,
    height: number,
    showToolbar: boolean
    xType: 'category' | 'datetime' | 'numeric'
}