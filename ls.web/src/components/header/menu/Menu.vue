<template>
  <div id="ls-menu">
    <slot></slot>
  </div>
</template>
<script>
export default {
  name: "lsMenu"
};
</script>
<style scoped>
#ls-menu {
  display: flex;
  flex-direction: row;
  justify-content: left;
  align-items: center;
  box-sizing: border-box;
}
</style>