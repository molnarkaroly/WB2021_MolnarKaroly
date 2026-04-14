import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../components/HomeView.vue'
import UserList from '../components/UserList.vue'
import AddTask from '../components/AdTask.vue'

const routes = [
    { path: '/', component: HomeView },
    { path: '/users', component: UserList },
    { path: '/newtask', component: AddTask },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router