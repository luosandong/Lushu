<template>
  <div id="ls-header">
    <div class="item logo">
      <ls-logo></ls-logo>
    </div>
    <div class="item menus">
      <ls-menu>
        <ls-menu-item route="/">
          <div slot="menu-item-text">阅读笔记</div>
        </ls-menu-item>
        <ls-menu-item route="/book/category">
          <div slot="menu-item-text">图书库</div>
        </ls-menu-item>
        <ls-menu-item route="/book/plan">
          <div slot="menu-item-text">阅读计划</div>
        </ls-menu-item>
        <!-- <ls-menu-item route="/profile">
          <div slot="menu-item-text">下载</div>
        </ls-menu-item> -->
      </ls-menu>
    </div>
    <div class="item search">
      <searchbox />
    </div>
    <div class="item profile">
      <my-profile></my-profile>
    </div>
  </div>
</template>
<script>
import lsLogo from "@/components/header/Logo.vue";
import searchbox from "@/components/header/SearchBox.vue";
import lsMenu from "@/components/header/menu/Menu.vue";
import lsMenuItem from "@/components/header/menu/MenuItem.vue";
import myProfile from "@/components/header/MyProfile.vue";
export default {
  name: "lsHeader",
  components: {
    lsLogo,
    lsMenu,
    lsMenuItem,
    searchbox,
    myProfile
  },
  data() {
    return {

    };
  }
};
</script>
<style scoped>
#ls-header {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  display: flex;
  z-index: 999;
  height: 60px;
  border-bottom: 1px solid #e7e7e7 !important;
}

.item {
  /* background: red; */
  flex: 1;
  /* margin: 1px; */
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #fff;
}

.logo {
  background-color: #fff;
  flex-grow: 2;
  color: #ba4525;
}

.menus {
  justify-content: flex-start;
  background-color: #fff;
  flex-grow: 3;
}
.search {
  justify-content: flex-end;
  flex-grow: 3;
  background-color: #fff;
}

@media (max-width: 600px), (max-width: 336px) {
  .profile,
  .search,
  .menus {
    display: none;
  }
  #ls-header {
    flex-direction: column;
    height: 60px;
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    z-index: 9999;
  }
  /* .profile {

    } */
}
</style>