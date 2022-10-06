import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'
import { RouteGaurd } from '../assets/javascript/Authenticate'

const router = createRouter({
    history: createWebHistory(
        import.meta.env.BASE_URL),
    routes: [{
            path: '/',
            name: 'login',
            component: LoginView
        },
        {
            path: '/login',
            name: 'login2',
            component: LoginView
        },
        {
            path: '/home',
            name: 'home',
            beforeEnter: (to, from, next) => {
                if(!RouteGaurd()){
                    next({name: 'login'});
                    return false
                }
                else{
                    next();
                }
            },
            component: () => import ('../views/HomeView.vue')
        },
        {
            path: '/account',
            name: 'account',
            beforeEnter: (to, from, next) => {
                if(!RouteGaurd()){
                    next({name: 'login'});
                    return false
                }
                else{
                    next();
                }
            },
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