<template>
    <div class="m--skin- m-header--fixed m-header--fixed-mobile m-aside-left--enabled m-aside-left--skin-dark m-aside-left--fixed m-aside-left--offcanvas m-footer--push m-aside--offcanvas-default">
        <div class="m-grid m-grid--hor m-grid--root m-page">
            <div class="m-grid__item m-grid__item--fluid m-grid m-grid--hor m-login m-login--signin m-login--2 m-login-2--skin-1 login_bg" id="m_login" style="height:100vh;">
                <div class="m-grid__item m-grid__item--fluid m-login__wrapper">
                    <div class="m-login__container">
                        <div class="m-login__logo">
                            <a href="#">
                                <img src="../../assets/metronic/images/logos/logo-1.png">
                            </a>
                        </div>
                        <div class="m-login__signin">
                            <div class="m-login__head">
                                <h3 class="m-login__title">用户登录</h3>
                            </div>
                            <form class="m-login__form m-form">
                                <div v-if="!isSuccess" class="m-alert m-alert--outline alert alert-danger alert-dismissible animated fadeIn" role="alert">			
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"></button>			
                                    <span>用户登录失败！请输入正确的用户名和密码，然后重试。</span>		
                                </div>                                
                                <div class="form-group m-form__group">
                                    <input v-model="loginInfo.UserName" class="form-control m-input" type="text" placeholder="请输入域用户名" name="account" autocomplete="off">                                    
                                </div>
                                <div class="form-group m-form__group">
                                    <input v-model="loginInfo.Password" class="form-control m-input m-login__form-input--last" type="password" placeholder="请输入域登录密码" name="password">
                                </div>
                                <div class="row m-login__form-sub">
                                    <div class="col m--align-left m-login__form-left">
                                        <label class="m-checkbox  m-checkbox--light">
                                            <input type="checkbox" v-model="isMemory" name="remember"> 记住密码
                                            <span></span>
                                        </label>
                                    </div>
                                </div>
                                <div class="m-login__form-action">
                                    <button type="button" class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air m-login__btn m-login__btn--primary" style="font-size: 18px;" @click="Login()">登 录</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

export default {
    data() {
        return {
            loginInfo: {
                UserName: null,
                Password: null
            },
            isMemory: false,
            isSuccess: true
        }
    },   
    mounted() {
        var memory = this.$AuthorizeService.getMemory();
        if (memory) {
            this.loginInfo = memory;
            this.isMemory = true;
        }
    },
    methods: {
        Login() {

            this.isSuccess = true;                                

            if (this.loginInfo.UserName == null || this.loginInfo.Password == null) {
                this.isSuccess = false;
                return;
            }

            if (this.loginInfo.UserName.trim() == '' || this.loginInfo.Password.trim() == '') {
                this.isSuccess = false;
                return;
            }

            let _that = this;
            this.$AuthorizeService.login(this.loginInfo)
                .then(isSuccess => {
                    if (isSuccess) {                        
                        _that.$router.replace({name: 'ContractSearch'}); 

                        // 记住密码
                        if (_that.isMemory) {
                            _that.$AuthorizeService.rememberPassword(_that.loginInfo);
                        }
                    } else {
                        this.isSuccess = false;
                    }
                });            
        },
    }
}
</script>

<style>
.login_bg {
    background-image: url(../../assets/metronic/images/bg/bg-1.jpg);
}
</style>
