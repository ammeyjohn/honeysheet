import axios from 'axios';

export default {
    install: function(Vue, options) {

        let service = {

            // 根据条件查询合同名称和编码列表
            GetContractNameList(query) {
                return axios.post('/api/contracts/name', {
                    Value: query
                });
            },

            // 根据条件获取合同列表
            GetContractList(condition) {
                return axios.post('/api/contracts');
            }

        }

        Vue.prototype.$ContractService = service;
    }
}