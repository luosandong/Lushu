<template>
  <div id="books">
    <div class="books-item" v-for="catagory in catagories " :key="catagory.id">
       <h3>{{catagory.name}}</h3>
       <hr>
       <div v-for="book in catagory.books" :key="book.name">
         <a href="">{{book.name}}</a>
       </div>
    </div>
  </div>
</template>
<script>
import { request } from "@/network/request.js";

export default {
  data() {
    return {
      catagories: [],
      books:[]
    };
  },
  created: function() {
    this.init();
  },
  methods: {
    init: function() {
      // let _this = this;
      request("/bookservice/bookcategories")
        .then(res => {
          this.catagories = res.data;
          console.log(res);
        })
        .catch(err => {
          console.log(err);
        });
    },
    getbooks() {
      // request("/bookservice/list")
      //   .then(res => {
      //     this.books = res;
      //     console.log(res);
      //   })
      //   .catch(err => {
      //     console.log(err);
      //   });
      //   request("/bookservice/list",(res)=>{
      //       console.log(res);
      //   },(error)=>{
      //       console.log(error);
      //   });
      //  request({baseConfig:"/bookservice/list",success:res=>{
      //       console.log(res);
      //   },error:(error)=>{
      //       console.log(error);
      //   }});
      //   axios({
      //     url: "/bookservice/list",
      //     method: "get",
      //     params:{
      //         id:'23'
      //     }
      //   }).then(res => {
      //     console.log(res);
      //     this.books = res.data;
      //   });
      //   //多个并发请求
      //   axios.all([axios(),axios()]).then(res=>{

      //   })

      //   //多个并发请求
      //   axios.all([axios(),axios()]).then((res1,res2)=>{

      //   })
    }
  }
};
</script>
<style scoped>
#books {
  display: flex;
  margin-top: 10px;
  flex-basis: 100%;
  flex-wrap: wrap;
  flex-direction: row;
  min-height: 700px;
}
.books-item {
  flex: 1;
  box-sizing: border-box;
  padding: 30px;
  /* background: #f8f8f8; */
  margin: 10px;
  flex-basis: 300px;
  /* width: 600px; */
  height: 300px;
}

hr {
  border-top: 1px solid #0072c6;
}
</style>