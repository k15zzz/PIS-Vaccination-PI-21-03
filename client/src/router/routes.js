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
        path: '/organization-registry',
        name: 'organizationRegistry',
        component: () => import('./../pages/OrganizationRegistryPage.vue'),
        meta: {
            middleware: [
                auth
            ]
        },
    },
    {
        path: '/animal-registry',
        name: 'animalRegistry',
        component: () => import('./../pages/AnimalRegistryPage.vue'),
        meta: {
            middleware: [
                auth
            ]
        },
    },
    {
        path: '/contact-registry',
        name: 'contactRegistry',
        component: () => import('./../pages/ContactRegistryPage.vue'),
        meta: {
            middleware: [
                auth
            ]
        },
    },
    
    {
        path: '/:pathMatch(.*)*',
        redirect: "/"
    }
]