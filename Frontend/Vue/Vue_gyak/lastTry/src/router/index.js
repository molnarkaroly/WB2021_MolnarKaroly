import { createRouter, createWebHistory } from 'vue-router'
import OpenPage from '../components/OpenPage.vue'
import tasks from '../components/Tasks.vue'


const routes = [
    { path: '/', component: OpenPage },        // nyitóoldal
    { path: '/tasks', component: tasks },        // nyitóoldal
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router