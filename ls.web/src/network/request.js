import axios from 'axios';
import globalConfig from '@/config/config.js';
/*
拦截器 发送前 和响应前 拦截
*/
export function request(config) {
    //1.创建实例
    const instance = axios.create({
        baseURL: globalConfig.host,
        timeout: 5000,
        headers: {
            "Content-Type": "application/json"
        }
    });
    //2. 创建拦截器
    //axios.interceptors
    instance.interceptors.request.use((config) => {
        //console.log('请求前拦截')
        /*
        1、处理验证参数是否正常
        2. 显示load图标
        */
        //console.log(config);
        return config;
    }, err => {
        console.log('发送请求发生错误')
    });
    //2.1 响应拦截
    instance.interceptors.response.use(res => {
        //console.log('响应拦截')
        return res.data;
    });
    //3.发送网络请求
    return instance(config);
}
// export function request(config) {
//     return new Promise((resove, reject) => {
//         //创建实例
//         const instance = axios.create({
//             baseURL: "http://localhost:3484/api",
//             timeout: 5000,
//             headers: {
//                 "Content-Type": "application/json"
//             }
//         });

//         //发送网络请求
//         instance(config).then((res) => {
//             resove(res);
//         }).catch(err => {
//             reject(err);
//         });
//     });


// }
// export function request(config){
//     //创建实例
//     const instance = axios.create({
//         baseURL:"http://localhost:3484/api",
//         timeout:5000,
//         headers:{
//             "Content-Type":"application/json"
//         }
//     });
//     //发送网络请求
//     instance(config.baseConfig).then((res)=>{
//         config.success(res);
//     }).catch(err=>{
//         config.error(err);
//     });

// }

// export function request(config,success,error){
//     //创建实例
//     const instance = axios.create({
//         baseURL:"http://localhost:3484/api",
//         timeout:5000,
//         headers:{
//             "Content-Type":"application/json"
//         }
//     });
//     //发送网络请求
//     instance(config).then((res)=>{
//         success(res);
//     }).catch(err=>{
//         error(err);
//     });

// }