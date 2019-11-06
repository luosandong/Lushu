<template>
  <div class="ls-aside">
    <div class="aside">
      <div class="aside-item">
        <h2 class="title">最新图书</h2>
      </div>
      <hr />
      <div class="aside-item">
        <ul>
          <li v-for="book in books" :key="book.id">
            <a href="">{{book.name}}</a>
          </li>         
        </ul>
      </div>
    </div>
    <div class="aside">
      <div class="aside-item">
        <h2 class="title">最新笔记</h2>
      </div>
      <hr>
      <div class="aside-item">
        <ul>
          <li v-for="note in notes" :key="note.id">
            <a href="">{{note.subject}}</a>
            </li>         
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
import { request } from "@/network/request.js";
export default {
  name: "lsAside",data(){
    return {
      books:[],
      notes:[]
    };
  },mounted(){
    request({url:'/learn/notes',method:'get'}).then(res=>{
      this.notes = res.data;
    });
    request("/bookservice/list")
        .then(res => {
          this.books = res.data;
        })
        .catch(err => {
          console.log(err);
        });
  }
};
</script>
<style scoped>
ul,
li {
  list-style: none;
  line-height: 2em;
}
hr {
  border-top: 1px dotted #8c8b8b;
}
.ls-aside {
  padding: 0px;
}
.aside {
  display: flex;
  flex-direction: column;
  /* background-color: #f8f8f8; */
  border: 0px solid #8c8b8b;
  border-radius: 5px;
  padding: 10px;
  margin: 30px 5px;
}
.aside-item {
  flex: 1;
  margin: 5px;
}
.title {
  font-size: 1.3em;
}
</style>