<template>
    <div id="contract_search">
        <div class="row">
            <div class="col-md-12">
                <contract-condition @change="contractConditionChanged"></contract-condition>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <Table width="100%" height="650" border :columns="columns" :data="contracts">
                    <template slot-scope="{ row }" slot="state">
                        {{ row.State }}
                    </template>
                    <template slot-scope="{ row }" slot="amount">
                        {{ row.ContractAmount | currency }}
                    </template>
                    <template slot-scope="{ row }" slot="department">
                        {{ row.Department.DepartmentName }}
                    </template>
                    <template slot-scope="{ row }" slot="salesman">
                        <user-profile :user="row"></user-profile>
                        <!-- {{ row.Salesman ? row.Salesman.Name : "" }} -->
                    </template>
                    <template slot-scope="{ row }" slot="dateOfSign">
                        {{ row.DateOfSign | date }}
                    </template>
                </Table>
                <Page :total="pageCount" :current="pageIndex" :page-size="pageSize" :page-size-opts="[10, 20, 50, 100]" show-sizer 
                    @on-change="pageIndexChanged" @on-page-size-change="pageSizeChanged" style="margin-top:5px"/>                
            </div>
        </div>
    </div>
</template>

<script>

import moment from 'moment'
import ContractCondition from './contract_condition.vue'
import UserProfile from 'components/user_profile.vue'

const formatStr = 'YYYY-MM-DD';

export default {
    components: {
        ContractCondition,
        UserProfile
    },
    data() {
        return {
            columns: [
                { title: '状态', width: 100, fixed: 'left', slot: 'state' },
                { title: '合同编号', key: 'ContractCode',  width: 100, fixed: 'left' },
                { title: '合同名称', key: 'ContractName',  fixed: 'left' },
                { title: '合同金额', width: 120, slot: 'amount' },
                { title: '签订日期', width: 150, slot: 'dateOfSign' },
                { title: '客户名称', key: 'Custom',  width: 250 },
                { title: '所属部门', width: 150, slot: 'department' },
                { title: '销售经理', width: 150, slot: 'salesman' }
            ], 
            condition: {                
                dateOfSign0: moment().startOf('year').format(formatStr),
                dateOfSign1: moment().endOf('year').format(formatStr)
            },         
            pageCount: 0,
            pageIndex: 1,
            pageSize: 20,
            contracts: []
        }
    },
    mounted() {
        this.query(this.condition);
    },
    methods: {

        query(condition) {
            if (!condition) {
                condition = {};
            }
            Promise.all([
                this.$ContractService.QueryContractCount(condition),
                this.$ContractService.QueryContractList(condition, this.pageSize, this.pageIndex)
            ]).then(ret => {
                this.pageCount = ret[0];
                this.contracts = ret[1];
            });
        },

        pageIndexChanged(pageIndex) {
            this.pageIndex = pageIndex;
            this.query(this.condition);
        },

        pageSizeChanged(pageSize) {
            this.pageSize = pageSize;
            this.query(this.condition);
        },

        contractConditionChanged(condition) {
            this.condition = condition;
            this.query(condition);
        }
    }
}
</script>

<style>

</style>
