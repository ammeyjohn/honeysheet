import axios from 'axios';
import Cookies from 'js-cookie';

// Cookie 30分钟超时
const in30Minutes = 1 / 48;

// 定时器句柄
let cancelHandle = null;

export default {
    install: function(Vue, options) {

        // 判断用户名和密码是否来自Cookie
        const fromMemory = (account) => {
            let memory = service.getMemory();
            return memory && account.UserName === memory.UserName && account.Password === memory.Password;
        };

        let service = {

            login(account) {
                return new Promise((resolve, reject) => {
                    var credential = {
                        "User": {
                            "Name": "袁杰",
                            "Account": "yuanjie",
                            "Title": "部门副经理",
                            "Department": "软件研发部",
                            "ManagerAccount": "CN=胡嘉宁,OU=公司员工,DC=shanghai3h,DC=com",
                            "Mobile": "13764417118",
                            "ExtensionNumber": "243",
                            "Email": "yuanjie@shanghai3h.com"
                        },
                        "LoginSuccess": true,
                        "LoginTime": "2019-02-23T14:23:18.3969945+08:00"
                    }
                    resolve(credential);
                    Cookies.set('credential', credential, { expires: in30Minutes });                        
                });
            },

            // 用户登录
            login1(account) {

                return axios.post('/auth/login', {
                    'UserName': account.UserName,
                    'Password': account.Password
                }).then(credential => {
                    if (credential) {                        
                        Cookies.set('credential', credential, { expires: in30Minutes });                        

                        // Set token to axios global config
                        // axios.defaults.headers.common['Token'] = ret.Token;
                        // axios.defaults.headers.common['AccountId'] = credential.AccountId;

                        return true;
                    }
                    return false;
                }, err => {
                    if (err.request.status === 401) {
                        return false;
                    }
                });
            },

            // 用户登出
            logout() {
                return new Promise((resolve) => {
                    Cookies.remove('credential');
                    resolve(true);
                });
            },

            // 确认当前用户是否已经授权
            hasLogin() {
                let credential = this.getCredential();
                return credential != null;
            },

            // 获取授权对象
            getCredential() {
                return Cookies.getJSON('credential');
            },

            // 判断当前用户是否包含指定角色
            // authorize(roles) {
            //     let credential = this.getCredential();
            //     if (credential) {
            //         return _intersection(credential.Roles, roles).length > 0;
            //     }
            //     return false;
            // },

            // 记住密码
            rememberPassword(account) {
                if(!fromMemory(account)) {
                    Cookies.set('memory', {
                        UserName: account.UserName,
                        Password: account.Password
                    }, {
                        expires: 100
                    });
                }
            },

            // 获取记住密码
            getMemory() {
                return Cookies.getJSON('memory');
            }
        };

        Vue.$AuthorizeService = service;
        Vue.prototype.$AuthorizeService = service;
        // Vue.mixin({
        //     methods: {
        //         authorize(roles) {
        //             return service.authorize(roles);
        //         }
        //     }
        // });
    }
}