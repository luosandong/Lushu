<template>
  <div id="ls-search-box">
    <span class="search-item">
      <el-input placeholder="输入关键字查询笔记" ></el-input>
    </span>
    <span class="search-item">
      <el-button @click="search()" icon="el-icon-search">搜索</el-button>
    </span>
    <span class="search-item btn-write">
      <el-button type="primary" @click="write()">写笔记</el-button>
    </span>
  </div>
</template>
<script>
import { INCREMENT } from "@/store/mutations-types.js";
export default {
  name: "SearchBox",
  methods: {
    search() {
      //this.$store.commit(INCREMENT);
    },
    write() {
      this.$router.push('/learn');
      //this.$store.commit("incrementCount", 5);
      //this.add();
      //调用异步方法
      // this.$store.dispatch("asyncDecrement",{
      //   data:{key:'java',category:'程序'},
      //   success: () => {
      //   console.log("success");
      // }
      // });
      //this.$store.dispatch('asyncDecrement',{data:{key:'java',category:'程序'}}).then((res)=>{
        // console.log('返回结果')
        // console.log(res);
      //})
    },
    //特殊的提交调用
    add() {
      this.$store.commit({
        type: "customeAdd",
        obj: {
          name: "zhangsan",
          age: 19
        }
      });
    }
  }
};
</script>
<style scoped>
#ls-search-box {
  display: flex;
  flex-direction: row;
  justify-content: left;
  align-items: center;
  box-sizing: border-box;
}

.search-item {
  display: inline-block;
  margin: 0 10px;
}
@media (max-width: 600px), (max-width: 336px) {
  .btn-write {
    display: none;
  }
}
</style>