import Vue from 'vue'
import ElementUI from 'element-ui'; //导入ElementUI 插件
import axios from 'axios'
// import 'normalize.css/normalize.css';
import 'element-ui/lib/theme-chalk/index.css';
import App from './App.vue'
import router from './router'
import store from './store'

Vue.config.productionTip = false
Vue.axios=axios;
Vue.use(ElementUI); //使用ElementUI 插件

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
