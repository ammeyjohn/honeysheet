import Vue from 'vue';
import axios from 'axios';
import router from './router'
import store from './store'
import iView from 'iview/dist/iview'

Vue.use(iView)

import ContractService from 'services/contract.services';

Vue.use(ContractService);

const vm = new Vue({
  el: '#app',
  router: router,
  store: store,
  components: { }
});

// Set axios global config
axios.defaults.baseURL = 'http://localhost:40587';
axios.defaults.headers.common['Content-Type'] = 'application/json;charset=UTF-8';