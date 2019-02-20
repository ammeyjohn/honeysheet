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
    </div>
</template>

<script>

import ContractSelect from 'components/contract_select.vue'
import InvoiceCondition from 'views/invoice/invoice_condition.vue'

export default {
    components: {
        ContractSelect,
        InvoiceCondition
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
