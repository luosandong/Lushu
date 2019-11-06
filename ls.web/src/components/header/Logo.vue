<template>
  <div id="logo">{{$store.state.website.baseInfo.productName}} </div>
</template>
<script>
export default {
  name: "lsLogo"
};
</script>
<style scoped>
#logo {
  vertical-align: middle;
  font-size: 1.5rem;
}
</style>