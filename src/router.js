import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [{
    path: '/',
    name: 'root',
    redirect: '/invoice/search'
  }, {    
    path: '/invoice/search',
    name: 'InvoiceSearch',
    component: resolve => {
      require(['./views/invoice/invoice_search.vue'], resolve);
    }
  }]
})