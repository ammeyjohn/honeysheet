<template>
    <div class="m-portlet m-portlet--accent m-portlet--head-solid-bg m-portlet--head-sm" m-portlet="true" id="m_portlet_tools_1">
        <div class="m-portlet__head">
            <div class="m-portlet__head-caption">
                <div class="m-portlet__head-title">
                    <span class="m-portlet__head-icon">
                        <i class="flaticon-search"></i>
                    </span>
                    <h3 class="m-portlet__head-text"> 查询条件 </h3>
                </div>
            </div>
            <div class="m-portlet__head-tools">
                <ul class="m-portlet__nav">
                    <li class="m-portlet__nav-item">
                        <a href="#" m-portlet-tool="toggle" class="m-portlet__nav-link m-portlet__nav-link--icon"><i class="la la-angle-down"></i></a>
                    </li>
                </ul>
            </div>
        </div>
        <form class="m-form m-form--fit m-form--label-align-right">
            <div class="m-portlet__body">	
                <div class="form-group m-form__group row"> 
                    <label class="col-lg-2 col-form-label">合同名称</label>
                    <div class="col-lg-4">
                        <contract-select @change="contractSelectChanged"></contract-select>
                    </div>
                    <label class="col-lg-2 col-form-label">签订日期</label>
                    <div class="col-lg-4">
                        <DatePicker v-model="dateOfSignRange" format="yyyy年MM月dd日" :options="dateOfSignOption" type="daterange" placement="bottom-end" size="large" placeholder="请选择合同签订日期查询范围" style="width: 100%"></DatePicker>
                    </div>
                </div>
                <div class="form-group m-form__group row">
                    <label class="col-lg-2 col-form-label">合同金额</label>
                    <div class="col-lg-4">
                        <InputNumber :min="0" v-model="condition.AmountRange0" style="width: 48%"></InputNumber>
                        -
                        <InputNumber :min="0" v-model="condition.AmountRange1" style="width: 48%"></InputNumber>
                    </div>
                    <label class="col-lg-2 col-form-label">销售经理</label>
                    <div class="col-lg-4">

                    </div>
                </div>
                <div class="form-group m-form__group row">
                    <label class="col-lg-2 col-form-label">所属部门</label>
                    <div class="col-lg-4">
                    </div>
                    <label class="col-lg-2 col-form-label">所属省份</label>
                    <div class="col-lg-4">
                    </div>
                </div>
            </div>
            <div class="m-portlet__foot m-portlet__foot--fit">
                <div class="m-form__actions m-form__actions--solid m-form__actions--right">
                    <button type="submit" class="btn btn-accent" @click="search()">查询</button>
                    <button type="reset" class="btn btn-secondary">重置</button>
                </div>
            </div>
        </form>
    </div>  
</template>

<script>

import { GetDataRangeShortcuts } from '../../utils'
import ContractSelect from 'components/contract_select.vue'

export default {
    components: {
        ContractSelect
    },
    data() {
        return {
            condition: {
                ContractIds: [],
                DateOfSign0: null,
                DateOfSign1: null,
                AmountRange0: null,
                AmountRange1: null
            },
            dateOfSignRange: null,
            dateOfSignOption: {
                shortcuts: GetDataRangeShortcuts()
            }
        }
    },
    mounted() {
        var portlet = new mPortlet('m_portlet_tools_1');
    },
    methods: {
        search() {
            console.log(this.dateOfSignRange);
        },

        contractSelectChanged(items) {
            this.condition.ContractIds = items;
        }
    }
}
</script>

<style>
#m_portlet_tools_1 .row:not(:last-child) {
    margin-bottom: -25px;
}
</style>
