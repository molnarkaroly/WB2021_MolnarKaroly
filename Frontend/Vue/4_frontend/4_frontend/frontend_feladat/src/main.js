import 'bootstrap/dist/css/bootstrap.min.css'
import './assets/main.css'

import { createApp } from 'vue'
import axios from 'axios'
import App from './App.vue'
import router from './router'

axios.defaults.baseURL = 'http://localhost:5000'

const app = createApp(App)
app.use(router)
app.mount('#app')
