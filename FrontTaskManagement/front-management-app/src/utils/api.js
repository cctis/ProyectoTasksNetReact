import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7227/',
});

const token = 'mi_token_secreto'; 

// Se Agrega un interceptor para las solicitudes
api.interceptors.request.use((config) => {
  
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
}, (error) => {
  return Promise.reject(error);
});

export default api;
