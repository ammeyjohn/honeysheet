<template>
    <div>
        <div class="row">
            <div class="col-lg-12">
                <div class="m-portlet m-portlet--accent m-portlet--head-solid-bg m-portlet--head-sm" m-portlet="true" id="m_portlet_tools_1">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <span class="m-portlet__head-icon">
                                    <i class="flaticon-placeholder-2"></i>
                                </span>
                                <h3 class="m-portlet__head-text">
                                    Action Tools
                                </h3>
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
                    <div class="m-portlet__body">

                    </div>
                    <div class="m-portlet__foot">
                        <div class="row">
                            <div class="col-md-12 m--align-right">
                                <button type="submit" class="btn btn-primary">Submit</button>
                                <span class="m--margin-left-10">or <a href="#" class="m-link m--font-bold">Cancel</a></span>
                            </div>           
                        </div>             
                    </div>
                </div>               
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <Table width="100%" height="650" border :columns="columns2" :data="data4"></Table>
            </div>
        </div>        
    </div>
</template>

<script>

export default {
    data () {
        return {
            columns2: [
                { title: '项目编号', key: 'PrjCode',  width: 100, fixed: 'left' },
                { title: '项目名称', key: 'PrjName',  width: 250, fixed: 'left' },
                { title: '项目总额', key: 'PrjAmount',  width: 100 },
                { title: '付款日', key: 'PrjAmount',  width: 100 },
                { title: '金额', key: 'PrjAmount',  width: 100 },
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
            ]
        }
    },
    mounted() {
        var portlet = new mPortlet('m_portlet_tools_1');
    }
}
</script>

<style>

</style>
