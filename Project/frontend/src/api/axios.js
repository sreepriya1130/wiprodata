import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7190/api",}); // your ASP.NET backend URL
  api.interceptors.request.use((config) => {
    const token = localStorage.getItem("token"); // JWT saved after login
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default api;
