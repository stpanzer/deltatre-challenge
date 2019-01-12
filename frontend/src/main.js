import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueCurrencyFilter from 'vue-currency-filter'

Vue.config.productionTip = false

Vue.use(VueCurrencyFilter,
  {
    symbol: '$',
    thousandsSeparator: ',',
    fractionCount: 2,
    fractionSeparator: '.',
    symbolPosition: 'front'
  })

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
