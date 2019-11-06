<template>
  <div class="tab-bar-item" @click="itemClick">
    <div v-if="!isActive">
      <slot name="item-icon"></slot>
    </div>
    <div v-else>
      <slot name="item-icon-active"></slot>
    </div>

    <div :class="!isActive?'active':''">
      <slot name="item-text"></slot>
    </div>
  </div>
</template>
<script>
export default {
  name: "tabBarItem",
  props:{
      route:String
  },
  data(){
      return {
          isActive:true
      }
  },
  computed:{
    //   isActive(){
    //       return false;
    //   }
  },
  methods:{
      itemClick(){
          this.$router.replace(this.route);
      }
  }
};
</script>
<style scoped>
.tab-bar-item {
  flex: 1;
  text-align: center;
  font-size: 14px;
  margin-top: 3px;
}
.tab-bar-item img {
  width: 24px;
  height: 24px;
  vertical-align: middle;
  margin-bottom: 2px;
}

.active {
  color: red;
}
</style>