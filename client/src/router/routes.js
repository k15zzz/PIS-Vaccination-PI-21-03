import guest from './middleware/guest';
import auth from './middleware/auth';

export const routes  = [
    {
        path: '/',
        name: 'index',
        component: () => import('./../pages/IndexPage.vue'),
        meta: {
            middleware: [
                auth
            ]
        },
    },
    {
        path: '/auth',
        name: 'auth',
        component: () => import('./../pages/AuthPage.vue'),
        meta: {
            middleware: [
                guest
            ]
        },
    },
    
    {
        path: '/:pathMatch(.*)*',
        redirect: "/"
    }
]