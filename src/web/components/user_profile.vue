<template>
    <Poptip id="user_profile" trigger="hover" :title="user.Name" width="400">
        <span>{{user.Name}}</span>
        <table class="table table-bordered m-table" slot="content">
            <tbody>
                <tr>
                    <td>职位</td>
                    <td>{{user.Title}}</td>
                </tr>
                <tr>
                    <td>部门</td>
                    <td>{{user.Department}}</td>
                </tr>
                <tr>
                    <td>分机</td>
                    <td>{{user.ExtensionNumber}}</td>
                </tr>
                <tr>
                    <td>移动电话</td>
                    <td>{{user.Mobile}}</td>
                </tr>
                <tr>
                    <td>电子邮件</td>
                    <td>{{user.Email}}</td>
                </tr>
            </tbody>
        </table>
    </Poptip>
</template>

<script>


export default {
    props: {
        user: {
            type: Object
        }
    },
    data() {
        return {
        }
    }
}
</script>

<style>
#user_profile span {
    font-size: 16px;
}

#user_profile td {
    font-size: 16px;
}
</style>
