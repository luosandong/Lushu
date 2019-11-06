<template>
  <div id="app">
    <div class="bg"></div>

    <div class="container">
      <div class="top">
        <ls-header></ls-header>
      </div>
       
      <div class="main">
       
        <div class="main-cotent">
          <router-view></router-view>
        </div>
      </div>
      <div class="footer">
        <ls-footer></ls-footer>
      </div>
    </div>
  </div>
</template>
<script>

import lsHeader from "@/components/header/Header.vue";
import lsMainContent from "@/components/baseframe/MainContent.vue";
import lsFooter from "@/components/footer/Footer.vue";
export default {
  components: {
    lsHeader,
    lsMainContent,
    lsFooter
  },
  created: function() {
    //console.log("finished");
    this.$store.dispatch("getBaseInfo").then(res => {
      
    });
  }
};
</script>

<style>
@import url("./assets/css/base.css");
@import url("./assets/css/app.css");
</style>
