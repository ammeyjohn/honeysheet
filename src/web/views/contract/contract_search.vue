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
                        {{ row.state }}
                    </template>
                    <template slot-scope="{ row }" slot="amount">
                        {{ row.contractAmount | currency }}
                    </template>
                    <template slot-scope="{ row }" slot="department">
                        {{ row.department.departmentName }}
                    </template>
                    <template slot-scope="{ row }" slot="dateOfSign">
                        {{ row.dateOfSign | date }}
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

const formatStr = 'YYYY-MM-DD';

export default {
    components: {
        ContractCondition
    },
    data() {
        return {
            columns: [
                { title: '章台', width: 100, fixed: 'left', slot: 'state' },
                { title: '合同编号', key: 'contractCode',  width: 100, fixed: 'left' },
                { title: '合同名称', key: 'contractName',  fixed: 'left' },
                { title: '合同金额', width: 100, slot: 'amount' },
                { title: '签订日期', width: 150, slot: 'dateOfSign' },
                { title: '客户名称', key: 'custom',  width: 250 },
                { title: '所属部门', width: 100, slot: 'department' },
                { title: '销售经理', key: 'salesman',  width: 150 }
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
