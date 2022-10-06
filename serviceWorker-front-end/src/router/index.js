import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'

const router = createRouter({
    history: createWebHistory(
        import.meta.env.BASE_URL),
    routes: [{
            path: '/',
            name: 'login',
            component: LoginView
        },
        {
            path: '/home',
            name: 'home',
            component: () => import ('../views/HomeView.vue')
        },
        {
            path: '/account',
            name: 'account',
            // route level code-splitting
            // this generates a separate chunk (About.[hash].js) for this route
            // which is lazy-loaded when the route is visited.
            component: () =>
                import ('../views/AccountView.vue')
        },
        {
            path: '/error',
            name: 'error',
            component: () =>
                import ('../views/ErrorView.vue')
        }
    ]
})

export default router