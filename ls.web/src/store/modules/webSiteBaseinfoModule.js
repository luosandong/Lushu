import Vue from 'vue'
import {
    request
} from "@/network/request.js";
export default {
    state: {
        baseInfo: {}
    },
    mutations: {

    },
    actions: {
        //context store上下文
        getBaseInfo(context) {
            request("/website/info")
                .then(res => {
                    Vue.set(context.state, "baseInfo", res)
                })
                .catch(err => {
                    console.log(err);
                });
        }
    },
    getters: {}

}