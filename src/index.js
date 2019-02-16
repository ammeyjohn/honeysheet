import Vue from 'vue';
import router from './router'
import store from './store'
import iView from 'iview/dist/iview'

Vue.use(iView)

new Vue({
    router,
    store,
  }).$mount('#app')