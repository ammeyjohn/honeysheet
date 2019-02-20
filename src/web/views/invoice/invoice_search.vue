<template>
    <div>
        <div class="row">
            <div class="col-lg-12">
                <invoice-condition></invoice-condition>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <Table width="100%" height="650" border :columns="columns" :data="contracts">
                    <template slot-scope="{ row }" slot="name">
                        <Poptip trigger="hover" title="Title" content="content" placement="bottom">
                            <strong>{{ row.PrjName }}</strong>
                            <div slot="content">
                                <table>                                  
                                    <tbody>
                                        <tr>
                                            <td>合同编号</td>
                                            <td>18H1018</td>
                                        </tr>
                                        <tr>
                                            <td>合同名称</td>
                                            <td>普陀区长征镇网格 大屏更换</td>
                                        </tr>
                                        <tr>
                                            <td>签订日期</td>
                                            <td>2018-12-05</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>                            
                        </Poptip>
                    </template>
                </Table>
            </div>
        </div>        
    </div>
</template>

<script>

import InvoiceCondition from './invoice_condition.vue'

export default {
    components: {
        InvoiceCondition
    },
    data () {
        return {
            columns: [
                { title: '项目名称', key: 'PrjName',  width: 300, fixed: 'left', slot: 'name' }
            ],
            contracts: []
        }
    }
}
</script>

<style>

</style>
