//import './assets/main.css'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap'

import './assets/style.css'

import router from './router'

import axios from 'axios'

import { createApp } from 'vue'
import App from './App.vue'

createApp(App)
    .use(router)
    .use(axios)
    .mount('#app')
