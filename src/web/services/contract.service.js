import axios from 'axios';

export default {
    install: function(Vue, options) {

        let service = {

            // 根据条件查询合同名称和编码列表
            GetContractSimpleList(condition) {
                return axios.post('/api/contracts/simple', condition);
            }

        }

        Vue.prototype.$ContractService = service;
    }
}