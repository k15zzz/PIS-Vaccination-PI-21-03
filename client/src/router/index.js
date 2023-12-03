import {createRouter, createWebHistory} from 'vue-router'
import {routes} from "./routes";
import middlewarePipeline from './middlewarePipeline';
import {JwtResponseModel} from "../models/JwtResponseModel.js";
import {PermissionService} from "../services/PermissionService.js";
// localStorage.clear();
let isAuth = await PermissionService.isAuth();
let jwt = JwtResponseModel.getJwtResponse();

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: routes
})

router.beforeEach((to, from, next) => {
  if (!to.meta.middleware) {
    return next()
  }
  const middleware = to.meta.middleware
  const context = {
    to,
    from,
    next,
    jwt,
    isAuth
  }
  return middleware[0]({
    ...context,
    next: middlewarePipeline(context, middleware, 1)
  })
});

export default router
