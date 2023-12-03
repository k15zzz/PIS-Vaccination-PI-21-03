import guest from './middleware/guest';
import auth from './middleware/auth';
import log from "./middleware/logs.js";

export const routes  = [
    {
        path: '/',
        name: 'index',
        component: () => import('./../pages/IndexPage.vue'),
        meta: {
            middleware: [
                auth,
                log
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
                auth,
                log
            ]
        },
    },
    {
        path: '/organization-registry/create',
        name: 'organizationCreate',
        component: () => import('./../pages/OrganizationPage.vue'),
        meta: {
            mode: "create",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/organization-registry/:id/read',
        name: 'organizationRead',
        component: () => import('./../pages/OrganizationPage.vue'),
        meta: {
            mode: "read",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/organization-registry/:id/update',
        name: 'organizationUpdate',
        component: () => import('./../pages/OrganizationPage.vue'),
        meta: {
            mode: "update",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/organization-registry/:id/delete',
        name: 'organizationDelete',
        component: () => import('./../pages/OrganizationPage.vue'),
        meta: {
            mode: "delete",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/animal-registry',
        name: 'animalRegistry',
        component: () => import('./../pages/AnimalRegistryPage.vue'),
        meta: {
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/animal-registry/create',
        name: 'animalCreate',
        component: () => import('./../pages/AnimalPage.vue'),
        meta: {
            mode: "create",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/animal-registry/:id/read',
        name: 'animalRead',
        component: () => import('./../pages/AnimalPage.vue'),
        meta: {
            mode: "read",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/animal-registry/:id/update',
        name: 'animalUpdate',
        component: () => import('./../pages/AnimalPage.vue'),
        meta: {
            mode: "update",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/animal-registry/:id/delete',
        name: 'animalDelete',
        component: () => import('./../pages/AnimalPage.vue'),
        meta: {
            mode: "delete",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/contact-registry',
        name: 'contactRegistry',
        component: () => import('./../pages/ContactRegistryPage.vue'),
        meta: {
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/contact-registry/create',
        name: 'contactCreate',
        component: () => import('./../pages/ContactPage.vue'),
        meta: {
            mode: "create",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/contact-registry/:id/read',
        name: 'contractRead',
        component: () => import('./../pages/ContactPage.vue'),
        meta: {
            mode: "read",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/contact-registry/:id/update',
        name: 'contractUpdate',
        component: () => import('./../pages/ContactPage.vue'),
        meta: {
            mode: "update",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/contact-registry/:id/delete',
        name: 'contractDelete',
        component: () => import('./../pages/ContactPage.vue'),
        meta: {
            mode: "delete",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/vaccination-registry',
        name: 'vaccinationRegistry',
        component: () => import('./../pages/VaccinationRegistryPage.vue'),
        meta: {
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/vaccination-registry/create',
        name: 'vaccinationCreate',
        component: () => import('./../pages/VaccinationPage.vue'),
        meta: {
            mode: "create",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/vaccination-registry/:id/read',
        name: 'vaccinationRead',
        component: () => import('./../pages/VaccinationPage.vue'),
        meta: {
            mode: "read",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/vaccination-registry/:id/update',
        name: 'vaccinationUpdate',
        component: () => import('./../pages/VaccinationPage.vue'),
        meta: {
            mode: "update",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/vaccination-registry/:id/delete',
        name: 'vaccinationDelete',
        component: () => import('./../pages/VaccinationPage.vue'),
        meta: {
            mode: "delete",
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/report',
        name: 'report',
        component: () => import('./../pages/ReportPage.vue'),
        meta: {
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/logs-registry',
        name: 'logsRegistry',
        component: () => import('./../pages/LogRegistryPage.vue'),
        meta: {
            middleware: [
                auth,
                log
            ]
        },
    },
    {
        path: '/:pathMatch(.*)*',
        redirect: "/"
    }
]