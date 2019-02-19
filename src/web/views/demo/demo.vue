<template>
    <div id="demo1" class="row">
        <div class="col-md-6">
            <contract-select @change="contractSelectChanged"></contract-select>
            <span>{{result1}}</span>
        </div>
        <div class="col-md-6"></div>
    </div>
</template>

<script>

import ContractSelect from 'components/contract_select.vue'

export default {
    components: {
        ContractSelect
    },
    data() {
        return {
            result1: null
        }
    },
    methods: {
        contractSelectChanged(items) {
            this.result1 = items;
        }
    }
}
</script>

<style>
    #demo1 {
        margin: 20px;
    }
</style>
