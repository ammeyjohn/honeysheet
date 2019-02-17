import Vue from 'vue';
import router from './router'
import store from './store'
import iView from 'iview/dist/iview'

Vue.use(iView)

const vm = new Vue({
  el: '#app',
  router: router,
  store: store,
  components: { }
});