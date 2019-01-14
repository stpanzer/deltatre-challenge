import Vue from 'vue'
import Router from 'vue-router'
import ProductList from './components/ProductList.vue'
import NewProduct from './components/NewProduct.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: ProductList
    },
    {
      path: '/products/new',
      name: 'newProduct',
      component: NewProduct
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue')
    }
  ]
})
