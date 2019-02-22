import './vendors'
import Vue from 'vue';
import axios from 'axios';
import iView from 'iview/dist/iview'
import router from './router'
import store from './store'
import moment from 'moment'
import numeral from 'numeral'

Vue.use(iView)

import AuthorizeService from './services/authorize.service';
import ContractService from './views/contract/contract.service';

Vue.use(AuthorizeService);
Vue.use(ContractService);

Vue.filter('currency', function(value) {
    return numeral(value).format('$0,0.00');
});

Vue.filter('date', function(value) {
    return moment(value).format('LL');
})

const vm = new Vue({
  el: '#app',
  router: router,
  store: store,
  components: { }
});

// Set axios global config
axios.defaults.baseURL = 'http://localhost:3903/api';
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