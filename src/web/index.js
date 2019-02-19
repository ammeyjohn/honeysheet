import Vue from 'vue';
import axios from 'axios';
import router from './router'
import store from './store'
import iView from 'iview/dist/iview'

Vue.use(iView)

import ContractService from './services/contract.service';

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

// axios response interceptor
axios.interceptors
    .response.use(function(response) {
        if (response.status == 200 && response.data) {
            return Promise.resolve(response.data);
        }
        return response;
    }, function(error) {
        // if (error.response) {
        //     if (error.response.status === 401) {

        //     } else if (error.response.status === 404) {

        //     } else if (error.response.status === 500) {

        //     } else {
        //         router.replace({ name: '500' });
        //     }
        // } else {
        //     router.replace({ name: '500' });
        // }
        return Promise.reject(error);
    });