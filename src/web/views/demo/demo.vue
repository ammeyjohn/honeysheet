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
                <user-profile :user="user"></user-profile>
            </div>
            <div class="col-md-6"></div>
        </div>
    </div>
</template>

<script>

import ContractSelect from 'views/contract/contract_select.vue'
import InvoiceCondition from 'views/invoice/invoice_condition.vue'
import UserProfile from 'components/user_profile.vue'

export default {
    components: {
        ContractSelect,
        InvoiceCondition,
        UserProfile
    },
    data() {
        return {
            result1: [],
            user: {
                "Name": "袁杰",
                "Account": "yuanjie",
                "Title": "部门副经理",
                "Department": "软件研发部",
                "ManagerAccount": "CN=胡嘉宁,OU=公司员工,DC=shanghai3h,DC=com",
                "Mobile": "13764417118",
                "ExtensionNumber": "243",
                "Email": "yuanjie@shanghai3h.com"
            }
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
