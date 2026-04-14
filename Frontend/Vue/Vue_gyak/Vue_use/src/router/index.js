import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../components/HomeView.vue'
import UserList from '../components/UserList.vue'
import AddTask from '../components/AdTask.vue'
import PhotoList from '../components/PhotoList.vue'

const routes = [
    { path: '/', component: HomeView },
    { path: '/users', component: UserList },
    { path: '/newtask', component: AddTask },
    { path: '/photos', component: PhotoList },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router