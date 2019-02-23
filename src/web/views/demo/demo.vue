<template>
    <div>
        <div id="demo1" class="row">
            <div class="col-md-6">
                <contract-select @change="contractSelectChanged"></contract-select>
                <span>{{result1}}</span>
            </div>
            <div class="col-md-6"></div>
        </div>
        <div id="demo2" class="row">
            <div class="col-md-12">
                <invoice-condition></invoice-condition>
            </div>
        </div>
        <div id="demo3" class="row">
            <div class="col-md-6">
                <user-detail></user-detail>
            </div>
            <div class="col-md-6"></div>
        </div>
    </div>
</template>

<script>

import ContractSelect from 'views/contract/contract_select.vue'
import InvoiceCondition from 'views/invoice/invoice_condition.vue'
import UserDetail from 'components/user_detail.vue'

export default {
    components: {
        ContractSelect,
        InvoiceCondition,
        UserDetail
    },
    data() {
        return {
            result1: []
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
    #demo1, #demo2 {
        margin: 20px;
    }
</style>
