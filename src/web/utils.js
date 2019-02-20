import moment from 'moment'

// 获取日期范围组件的快捷配置
export function GetDataRangeShortcuts() {
    const formatStr = 'YYYY-MM-DD';
    return [{
            text: '今日',
            value() {
                const start = moment().startOf('day').format(formatStr);
                const end = start;
                return [start, end];
            }
        }, {
            text: '昨日',
            value() {
                const start = moment().startOf('day').subtract(1, 'day').format(formatStr);
                const end = start;
                return [start, end];
            }
        }, {
            text: '本周',
            value() {
                const start = moment().startOf('week').format(formatStr);
                const end = moment().startOf('week').add(6, 'day').format(formatStr);
                return [start, end];
            }
        },
        {
            text: '上周',
            value() {
                const end = moment().startOf('week').format(formatStr);
                const start = moment(end).subtract(6, 'day').format(formatStr);
                return [start, end];
            }
        }, {
            text: '本月',
            value() {
                const start = moment().startOf('month').format(formatStr);
                const end = moment().endOf('month').format(formatStr);
                return [start, end];
            }
        }, {
            text: '上月',
            value() {
                const end = moment().startOf('month').subtract(1, 'day').format(formatStr);
                const start = moment(end).startOf('month').format(formatStr);
                return [start, end];
            }
        }, {
            text: '今年',
            value() {
                const start = moment().startOf('year').format(formatStr);
                const end = moment().endOf('year').format(formatStr);
                return [start, end];
            }
        }, {
            text: '去年',
            value() {
                const end = moment().startOf('year').subtract(1, 'day').format(formatStr);
                const start = moment(end).startOf('year').format(formatStr);
                return [start, end];
            }
        }
    ]
}