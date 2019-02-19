import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [{
    path: '/',
    name: 'root',
    redirect: '/login'
  }, {
    path: '/login',
    name: 'Login',
    component: resolve => {
      require(['./views/login/login.vue'], resolve);
    },
  }, {
    path: '/app',
    name: 'App',
    component: resolve => {
      require(['./app/app.vue'], resolve);
    },
    children: [{
      path: '/invoice/search',
      name: 'InvoiceSearch',
      component: resolve => {
        require(['./views/invoice/invoice_search.vue'], resolve);
      }
    }, {
      path: '/invoice/create',
      name: 'CreateInvoice',
      component: resolve => {
        require(['./views/invoice/create_invoice.vue'], resolve);
      }
    }, {
      path: '/contract/create',
      name: 'CreateContract',
      component: resolve => {
        require(['./views/contract/create_contract.vue'], resolve);
      }
    }]
  }, {
    path: '/demo',
    name: 'Demo',
    component: resolve => {
      require(['./views/demo/demo.vue'], resolve);
    }
  }]
})