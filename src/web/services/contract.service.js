import axios from 'axios';

export default {
    install: function(Vue, options) {

        let service = {

            // 根据条件查询合同名称和编码列表
            GetContractHeaderList(query) {
                return axios.post('/api/contracts/simple', {
                    Value: query
                });
            }

        }

        Vue.prototype.$ContractService = service;
    }
}