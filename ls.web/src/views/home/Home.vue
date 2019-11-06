<template>
  <div class="container">
    <banner-Carousel class="banner"></banner-Carousel>
    <div class="home-main">
      <div class="home-main-content">
        <ls-notes v-for="note in notes" :key="note.id" :note="note" />
        <!-- <ls-article></ls-article> -->
      </div>
      <div class="home-main-aside">
        <ls-aside></ls-aside>
      </div>
    </div>
  </div>
</template>

<script>
import bannerCarousel from "@/components/baseframe/BannerCarousel.vue";
import lsArticle from "@/views/home/components/Article.vue";
import lsAside from "@/views/home/components/Aside.vue";
import lsNotes from "@/views/home/components/Notes.vue";
import {request} from "@/network/request.js";
export default {
  name: "home",
  data() {
    return {
      notes:[]
    };
  },
  components: { bannerCarousel, lsArticle, lsAside, lsNotes },
  created() {
    this.init();
  },
  methods: {
    init() {
       request("/learn/notes")
                .then(res => {
                  console.log(res);
                  this.notes = res.data;
                })
                .catch(err => {
                    console.log(err);
                });
    }
  }
};
</script>
<style lang="less" scoped>
// @import url("./css/home.css");
.container {
}
.banner {
  border-bottom: 1px dotted #8c8b8b;
}
.home-main {
  display: flex;
}
.home-main-content {
  flex: 1;
}
.home-main-aside {
  flex: 0, 0, 40%;
}
</style>
