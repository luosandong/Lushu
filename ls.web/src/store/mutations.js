import {
    INCREMENT
} from "@/store/mutations-types.js";
export default {
    //increment 相当于事件签名  方法体相当于回调函数
    [INCREMENT](state) {
        state.accessCount++;
    },
    decrement(state) {
        state.accessCount--;
    },
    incrementCount(state, count) {
        return this.state.accessCount += count;
    },
    customeAdd(state, payload) {
        //console.log(payload.obj)
        Vue.set(state, "pro", "zhangsan") // 动态添加属性 需要实现响应式时候要通过set函数  
        Vue.delete(state, "pro", "zhangsan") // 动态添加属性 需要实现响应式时候要通过set函数  
    }
}