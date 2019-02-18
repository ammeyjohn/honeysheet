<template>
    <div>
        <div class="row">
            <div class="col-lg-12">
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
                                <label class="col-lg-2 col-form-label">项目名称</label>
                                <div class="col-lg-4">
                                    <input type="email" class="form-control m-input" placeholder="请输入完整或部分项目名称或者项目编号">
                                </div>
                                <label class="col-lg-2 col-form-label">所属部门</label>
                                <div class="col-lg-4">
                                    <input type="email" class="form-control m-input" placeholder="请选择部门名称">
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-2 col-form-label">付款日期</label>
                                <div class="col-lg-4">
                                    <DatePicker :value="value2" format="yyyy/MM/dd" type="daterange" placement="bottom-end" size="large" placeholder="请选择付款日查询范围" style="width: 100%"></DatePicker>
                                </div>
                                <label class="col-lg-2 col-form-label">开票日期</label>
                                <div class="col-lg-4">
                                    <DatePicker :value="value2" format="yyyy/MM/dd" type="daterange" placement="bottom-end" size="large" placeholder="请选择付款日查询范围" style="width: 100%"></DatePicker>
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-2 col-form-label">开票内容</label>
                                <div class="col-lg-4">
                                    <input type="email" class="form-control m-input" placeholder="请输入开票内容">
                                </div>
                                <label class="col-lg-2 col-form-label">发票种类</label>
                                <div class="col-lg-4">
                                    <Select v-model="model4" size="large" clearable multiple style="width:100%">
                                        <Option v-for="item in cityList" :value="item.value" :key="item.value">{{ item.label }}</Option>
                                    </Select>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__foot m-portlet__foot--fit">
                            <div class="m-form__actions m-form__actions--solid m-form__actions--right">
                                <button type="submit" class="btn btn-accent">查询</button>
                                <button type="reset" class="btn btn-secondary">重置</button>
                            </div>
                        </div>
                    </form>
                </div>               
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <Table width="100%" height="650" border :columns="columns2" :data="data4">
                    <template slot-scope="{ row }" slot="name">
                        <Poptip trigger="hover" title="Title" content="content" placement="bottom" style="z-index: 10000;">
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

export default {
    data () {
        return {
            model4: null,
            value2: null,
            columns2: [
                { title: '项目名称', key: 'PrjName',  width: 250, fixed: 'left', slot: 'name' },
                { title: '项目总额', key: 'PrjAmount',  width: 100 },
                { title: '付款日', key: 'PrjAmount',  width: 100 },
                { title: '金额', key: 'PrjAmount',  width: 100, slot: 'name' },
                { title: '款到日期', key: 'A',  width: 100 },
                { title: '款到金额', key: 'B',  width: 100 },
                { title: '款到合计', key: 'C',  width: 100 },
                { title: '开票日期', key: 'D',  width: 100 },
                { title: '发票种类', key: 'E',  width: 100 },
                { title: '开票金额', key: 'F',  width: 100 },
                { title: '开票合计', key: 'G',  width: 100 },
                { title: '开票内容', key: 'H',  width: 100 },
                {
                    title: 'Action',
                    key: 'action',
                    fixed: 'right',
                    width: 120,
                    render: (h, params) => {
                        return h('div', [
                            h('Button', {
                                props: {
                                    type: 'text',
                                    size: 'small'
                                }
                            }, '详细'),
                            h('Button', {
                                props: {
                                    type: 'text',
                                    size: 'small'
                                }
                            }, '编辑')
                        ]);
                    }
                }
            ],
            data4: [
                {
                    PrjCode: '18H1018-1',
                    PrjName: '普陀区长征镇网格 大屏更换',
                    PrjAmount: 140000.00
                },
                {
                    PrjCode: '18H1018-1',
                    PrjName: '普陀区长征镇网格 大屏更换',
                    PrjAmount: 140000.00
                },                
            ],
            cityList: [
                {
                    value: 'New York',
                    label: 'New York'
                },
                {
                    value: 'London',
                    label: 'London'
                },
                {
                    value: 'Sydney',
                    label: 'Sydney'
                },
                {
                    value: 'Ottawa',
                    label: 'Ottawa'
                },
                {
                    value: 'Paris',
                    label: 'Paris'
                },
                {
                    value: 'Canberra',
                    label: 'Canberra'
                }
            ],
        }
    },
    mounted() {
        var portlet = new mPortlet('m_portlet_tools_1');
    }
}
</script>

<style>

</style>
