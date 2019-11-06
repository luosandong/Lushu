<template>
  <div :class="isActive?'active':'menu-item'" @click="itemClick">
    <slot name="menu-item-text"></slot>
    <!-- <div v-if="!isActive">
      <slot name="item-icon"></slot>
    </div>
    <div v-else>
      <slot name="item-icon-active"></slot>
    </div>

    <div :class="!isActive?'active':''">
      <slot name="item-text"></slot>
    </div>-->
  </div>
</template>
<script>
export default {
  name: "menuItem",
  props: {
    route: String
  },
  data() {
    return {
      // currentRoute='/'
    };
  },
  computed: {
    isActive() {
      return this.$route.path === this.route;
    }
  },
  methods: {
    itemClick() {
      if (this.$route.path === this.route) return;
      this.$router.push(this.route);
      // this.$router.replace(this.route);
    }
  }
};
</script>
<style scoped>
.menu-item {
  text-align: center;
  font-size: 1.2rem;
  padding: 5px;
  margin: 0 10px;
  cursor: pointer;
  border-bottom: 2px solid #fff;
  color: #ba4525;
}

.menu-item:hover {
  font-size: 1.2rem;
  border-bottom: 2px solid sienna;
  font-weight: bold;
}

.active {
  text-align: center;
  font-size: 1.2rem;
  padding: 5px;
  margin: 0 10px;
  cursor: pointer;
  font-weight: bold;
  color: #ba4525;
  border-bottom: 2px solid #ba4525;
}
</style>