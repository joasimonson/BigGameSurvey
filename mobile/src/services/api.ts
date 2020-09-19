import axios from 'axios';

const api = axios.create({
    baseURL: 'https://38b15b21a4b4.ngrok.io/api/'
});

export default api;