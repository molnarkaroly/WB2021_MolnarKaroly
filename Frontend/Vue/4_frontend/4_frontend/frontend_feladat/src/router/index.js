import { createRouter, createWebHistory } from 'vue-router'
import OpenPage from '../components/OpenPage.vue'
import Offers from '../components/Offers.vue'
import NewAd from '../components/NewAd.vue'

const routes = [
    { path: '/', component: OpenPage },
    { path: '/offers', component: Offers },
    { path: '/newad', component: NewAd }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
