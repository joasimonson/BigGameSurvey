import moment from 'moment';

export const formatDatetime = (date: string) => {
    return moment(date).format('DD/MM/YY HH:mm');
}