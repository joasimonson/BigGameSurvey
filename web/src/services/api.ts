import axios from 'axios';
import { getConfig } from '../config';

const api = axios.create({
    baseURL: getConfig("URL_API"),
});

export default api;