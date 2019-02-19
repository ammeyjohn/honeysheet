<template>
    <Select
        placeholder="请输入完整或者部分的合同编号和合同名称"
        v-model="selected"
        multiple
        filterable
        remote
        :remote-method="remoteMethod"
        :loading="loading"
        @on-change="selectChanged">
        <Option v-for="option in contracts" :value="option.contractId" :key="option.contractId">({{option.contractCode}}) {{option.contractName}}</Option>
    </Select>    
</template>

<script>

let timerHandler = null

export default {
    data() {
        return {
            selected: [],
            contracts: [],
            loading: false
        }
    },
    methods: {
        remoteMethod(query) {
            if (query !== '') {
                this.loading = true;
                
                // Cancel previous timer
                if (timerHandler != null) {
                    clearTimeout(timerHandler);
                    timerHandler = null;
                }
                timerHandler = setTimeout(() => {
                    this.$ContractService.GetContractHeaderList(query)
                        .then(ret => {
                            this.loading = false;
                            if (ret) {
                                this.contracts = ret;
                            }
                            timerHandler = null;
                        });
                }, 500);
                
            } else {
                this.contracts = [];
            }            
        },

        selectChanged(val) {
            this.$emit('change', val);
        },
    }
}
</script>

<style>

</style>
