<template>
    <li class="m-nav__item m-topbar__user-profile m-topbar__user-profile--img  m-dropdown m-dropdown--medium m-dropdown--arrow m-dropdown--header-bg-fill m-dropdown--align-right m-dropdown--mobile-full-width m-dropdown--skin-light"
    m-dropdown-toggle="click">
        <a href="#" class="m-nav__link m-dropdown__toggle">
            <span class="m-topbar__userpic">
                <img src="../assets/metronic/images/users/user4.jpg" class="m--img-rounded m--marginless" alt="" />
            </span>
            <span class="m-topbar__username m--hide">Nick</span>
        </a>
        <div class="m-dropdown__wrapper">
            <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust"></span>
            <div class="m-dropdown__inner">
                <div class="m-dropdown__header m--align-center m-dropdown__profile">
                    <div class="m-card-user m-card-user--skin-dark">
                        <div class="m-card-user__pic">
                            <img src="../assets/metronic/images/users/user4.jpg" class="m--img-rounded m--marginless" alt="" />
                        </div>
                        <div class="m-card-user__details">
                            <span class="m-card-user__name m--font-weight-500">{{user.Name}} ({{user.Title}})</span>
                            <span class="m-card-user__email m--font-weight-300">分机号: {{user.ExtensionNumber}}</span>
                            <a href="" class="m-card-user__email m--font-weight-300 m-link">{{user.Email}}</a>
                        </div>
                    </div>
                </div>
                <div class="m-dropdown__body">
                    <div class="m-dropdown__content">
                        <ul class="m-nav m-nav--skin-light">
                            <li class="m-nav__item">
                                <router-link to="/login" class="btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder">登出</router-link>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </li>    
</template>

<script>
import 'metronic/js/framework/components/general/dropdown'
export default {
    data() {
        return {
            user: {}
        }        
    },
    mounted() {
        var cred = this.$AuthorizeService.getCredential();
        if (cred != null) {
            this.user = cred.User;
        }
    }
}
</script>

<style>

</style>
