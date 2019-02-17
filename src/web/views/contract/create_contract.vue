<template>
    <div class="row">
        <div class="col-md-8">
            <div class="m-portlet">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon m--hide">
                                <i class="la la-gear"></i>
                            </span>
                            <h3 class="m-portlet__head-text"> 新建合同 </h3>
                        </div>
                    </div>
                </div>
                <!--begin::Form-->
                <form class="m-form m-form--label-align-right">
                    <div class="m-portlet__body">	
                        <div class="m-form__section m-form__section--first">
                            <div class="form-group m-form__group row">
                                <label class="col-lg-3 col-form-label">合同编号</label>
                                <div class="col-lg-9">
                                    <input class="form-control m-input" placeholder="请输入合同编号">
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-3 col-form-label">合同名称</label>
                                <div class="col-lg-9">
                                    <input class="form-control m-input" placeholder="请输入合同名称">
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-3 col-form-label">合同总额</label>
                                <div class="col-lg-9">
                                    <input class="form-control m-input" placeholder="请输入合同总金额">
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-3 col-form-label">签订日期</label>
                                <div class="col-lg-9">
                                    <input class="form-control m-input" placeholder="请输入合同签订日期">
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-3 col-form-label">销售经理</label>
                                <div class="col-lg-9">
                                    <input class="form-control m-input" placeholder="请输入或者选择销售经理">
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-3 col-form-label">客户名称</label>
                                <div class="col-lg-9">
                                    <input class="form-control m-input" placeholder="请输入客户名称">
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-lg-3 col-form-label">所属省份</label>
                                <div class="col-lg-9">
                                    <input class="form-control m-input" placeholder="请输入客户名称">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="m-portlet__foot m-portlet__foot--fit">
                        <div class="m-form__actions m-form__actions--solid m-form__actions--right">
                            <button type="submit" class="btn btn-accent">添加合同</button>
                            <button type="reset" class="btn btn-secondary">重置</button>
                        </div>
                    </div>
                </form>
                <!--end::Form-->
		        </div>
        </div>
        <div class="col-md-4">

            <div class="row">
                <div class="col-md-12">
                    <div class="m-portlet">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon m--hide">
                                    <i class="la la-gear"></i>
                                    </span>
                                    <h3 class="m-portlet__head-text">
                                        BOSS合同列表
                                    </h3>
                                </div>
                            </div>
                        </div>
                        <!--begin::Form-->
                        <form class="m-form">
                            <div class="m-portlet__body">	
                                <div class="m-form__section m-form__section--first">

                                </div>
                            </div>
                        </form>
                        <!--end::Form-->
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="m-portlet">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon m--hide">
                                    <i class="la la-gear"></i>
                                    </span>
                                    <h3 class="m-portlet__head-text">
                                        BOSS合同信息
                                    </h3>
                                </div>
                            </div>
                        </div>
                        <!--begin::Form-->
                        <form class="m-form">
                            <div class="m-portlet__body">	
                                <div class="m-form__section m-form__section--first">

                                </div>
                            </div>
                        </form>
                        <!--end::Form-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>

</style>
