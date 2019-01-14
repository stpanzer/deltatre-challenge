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
    }
  ]
})
