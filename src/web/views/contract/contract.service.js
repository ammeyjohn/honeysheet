import axios from 'axios';

export default {
    install: function(Vue, options) {

        let service = {

            // 根据条件查询合同名称和编码列表
            GetContractNameList(query) {
                return axios.post('/contract/name', {
                    Value: query
                });
            },

            // 根据条件获取合同数量
            QueryContractCount(condition) {
                return axios.post('/contract/query/count', condition);
            },

            // 根据条件获取合同列表
            QueryContractList(condition, pageSize, pageIndex) {
                return axios.post(`/contract/query/${pageIndex}?pageSize=${pageSize}`, condition);
            }

        }

        Vue.prototype.$ContractService = service;
    }
}