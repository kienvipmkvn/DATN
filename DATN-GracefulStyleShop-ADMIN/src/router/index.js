import {createRouter,createWebHistory } from 'vue-router'

import routes from '@/router/routes'

const router = createRouter({
    history : createWebHistory(process.env.VUE_APP_PUBLIC_PATH),
    routes,
    
})

export default router;