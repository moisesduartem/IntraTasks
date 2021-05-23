import axios from 'axios';

export const api = axios.create({
  baseURL: 'https://intratasksapi.azurewebsites.net',
  withCredentials: false,
  headers: {
    'Access-Control-Allow-Origin': '*',
  },
});
