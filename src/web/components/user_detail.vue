<template>
<Poptip trigger="hover" title="Title" width="400">
    <span>{{user.Name}}<span>
    <div class="mt-element-list" slot="content">
        <div class="mt-list-head list-simple ext-1 font-white bg-green-sharp">
            <div class="list-head-title-container">
                <h3 class="list-title">{{user.Name}}</h3>
            </div>
        </div>
        <div class="mt-list-container list-simple ext-1">
            <ul>
                <li class="mt-list-item">
                    <div class="list-icon-container"> 部门 </div>
                    <div class="list-item-content"> {{ user.Department }} </div>
                </li>
                <li class="mt-list-item">
                    <div class="list-icon-container"> 职位 </div>
                    <div class="list-item-content"> {{ user.Title }} </div>
                </li>
                <li class="mt-list-item">
                    <div class="list-icon-container"> 分机号 </div>
                    <div class="list-item-content"> {{ user.ExtensionNumber }} </div>
                </li>
                <li class="mt-list-item">
                    <div class="list-icon-container"> 手机号码 </div>
                    <div class="list-item-content"> {{ user.Mobile }} </div>
                </li>
                <li class="mt-list-item">
                    <div class="list-icon-container"> 电子邮件 </div>
                    <div class="list-item-content"> <a :href="`mailto:${user.Email}`"> {{user.Email}} </a> </div>
                </li>
            </ul>
        </div>
    </div>
</Poptip>
</template>

<script>


export default {
    data() {
        return {
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
    }
}
</script>

<style>

</style>
