<template>
  <div id="content">
    <router-view /> 
  </div>
</template>
<script>
export default {
  name: "main-content"
};
</script>
<style scoped>
.test {
  width: 1000px;
}
#content {
  margin-top: 10px;
  flex-basis: 100%;
  display: flex;
  /* background-color:gray; */
  /* flex-direction: column; */
  justify-content: space-between;
  /* flex-flow: row nowrap; */
  /* flex-wrap: wrap-reverse */
}
.content-aside {
  /* flex-grow: 1;   */
  background-color: red;
  width: 200px;
}
.left-aside {
  order: 1;
  background-color: #0072c6;
}
.content-main {
  order: 2;
  flex: 1;
  background-color: yellow;
}
.right-aside {
  order: 3;
}
@media (max-width: 800px) {
  #content {
    margin-top: 60px;
    display: flex;
    /* flex-direction: column; */
    justify-content: space-between;
    flex-flow: column wrap;
    /* flex-wrap: wrap-reverse */
  }
.content-aside {
  flex-grow: 1;  
  width: 100%;
  background-color: red;
}
  .left-aside {
    order: 2;
  }
  .content-main {
    order: 1;
    flex-grow: 2;
    background-color: yellow;
  }
  .right-aside {
    order: 3;
  }
}
</style>