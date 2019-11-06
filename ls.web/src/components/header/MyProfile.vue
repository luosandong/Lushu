<template>
  <div>
    <span class="btn-item">登录</span>
    <span class="btn-item radius">
      <i>&nbsp;</i>
    </span>
    <span class="btn-item">关于</span>
  </div>
</template>
<script>
export default {
  name: "MyProfile"
};
</script>
<style scoped>
.radius{
    width: 3px;
    height: 3px;
    color: #000000;
    background-color:#000;
    border-radius: 50px;
    line-height: 3px;
    cursor: auto;
}
.btn-item {
  display: inline-block;
  font-size: 12px;
  margin: 2px;
  padding: 2px;
  cursor: pointer;
  color: #000000;
}
.btn-item:hover {
  color: #00a4ff;
}
</style>