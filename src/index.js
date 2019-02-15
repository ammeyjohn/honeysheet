import Vue from 'vue';
import router from './router'
import store from './store'
import App from './app/app.vue'
import iView from 'iview/dist/iview'

Vue.use(iView)

new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app')