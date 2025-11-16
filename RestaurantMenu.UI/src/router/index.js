import { createRouter, createWebHistory } from 'vue-router'
import MenuList from '../components/MenuList.vue'
import AddMenuItem from '../components/AddMenuItem.vue'

const routes = [
    { path: '/', component: MenuList},
    { path: '/add', component: AddMenuItem}
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router