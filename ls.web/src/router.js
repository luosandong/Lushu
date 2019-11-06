import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/home/Home.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [{
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/book/category',
      name: 'bookCategory',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('./views/book/Category.vue')
    },
    {
      path: '/book/plan',
      name: 'aaa',
      component: () => import('./views/book/Plan.vue')
    },
    {
      path:'/learn',
      name:'learn',
      component:()=>import('./views/learnNotes/Learn.vue')
    },
    {
      path:'/learn/note/detail',
      name:'noteDetail',
      component:()=>import('./views/learnNotes/Detail.vue')
    }
  ]
})