//import './assets/main.css'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap'

import './assets/style.css'

import router from './router'

import axios from 'axios'

import { createApp } from 'vue'
import App from './App.vue'

axios.defaults.baseURL = 'http://127.0.0.1:8000/api';

createApp(App)
    .use(router)
    .mount('#app')
