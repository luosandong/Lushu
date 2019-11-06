import Vue from 'vue'
import Vuex from 'vuex'
import {
    INCREMENT
} from "@/store/mutations-types.js";
import mutation from "@/store/mutations.js";
import muduleA from "@/store/modules/moduleA.js";
import websiteBasiInfo from "@/store/modules/webSiteBaseinfoModule.js";
//1. 安装插件
Vue.use(Vuex)

//2创建对象
const store = new Vuex.Store({
    state: {
        email: 'luo_sd@yeah.net',
        accessCount: 0,
        host:'http://localhost:3484/'
    },
    mutations:mutation,
    actions: {
        //做异步操作
        asyncDecrement(context, payload) {
            // setTimeout(() => {
            //     context.commit(INCREMENT);
            //     console.log(payload.data);
            //     payload.success();
            // }, 1000);
            return new Promise((resolve, reject) => {
                setTimeout(() => {
                    context.commit(INCREMENT);
                    //console.log(payload.data);
                    resolve('Success');
                }, 1000);
            })
        }
    },
    getters: {
        //计算属性 第一个参数为state 第二个为 vuex的getters
        menus(state, getters) {

        },
        //特殊需要传递其它参数
        getMenus(state) {
            return function (age) {
                return state.accessCount + age;
            }
        }
    },
    modules:{
        website:websiteBasiInfo,
        a: muduleA
    }
})



//导出模块
export default store