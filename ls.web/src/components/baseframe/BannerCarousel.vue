<template>
  <div class="carousel-container">
    <el-carousel :interval="5000" arrow="always" indicator-position="outside" height="220px">
      <el-carousel-item v-for="item in imagesbox" :key="item.id">
        <h1>{{item.title}}</h1>
        <p>{{item.content}}</p>
      </el-carousel-item>
    </el-carousel>
  </div>
</template>
<script>
export default {
  name: "bannerCarousel",
  data() {
    return {
      imagesbox: [
        {
          id: 1,
          title: "读书的乐趣",
          content:
            "读书使人充实，讨论使人机智，笔记使人准确，读史使人明智，读诗使人灵秀，数学使人周密，科学使人深刻，伦理使人庄重，逻辑修辞使人善辩。凡有所学，皆成性格。 —— 培根"
        },
        {
          id: 2,
          title: "读书何所求?将以通事理",
          content:
            "文人作文，农人掘锄，本是平平常常的，若照相之际，文人偏要装做粗人，玩什么“荷锄带笠图”；农夫则在柳下捧一本书，装作“深柳读书图”之类，就要令人肉麻。 —— 鲁迅"
        },
        {
          id: 3,
          title: "读书的乐趣",
          content:
            "读书使人充实，讨论使人机智，笔记使人准确，读史使人明智，读诗使人灵秀，数学使人周密，科学使人深刻，伦理使人庄重，逻辑修辞使人善辩。凡有所学，皆成性格。 —— 培根"
        },
        {
          id: 4,
          title: "读书的乐趣",
          content:
            "读书使人充实，讨论使人机智，笔记使人准确，读史使人明智，读诗使人灵秀，数学使人周密，科学使人深刻，伦理使人庄重，逻辑修辞使人善辩。凡有所学，皆成性格。 —— 培根"
        },
        {
          id: 5,
          title: "读书的乐趣",
          content:
            "读书使人充实，讨论使人机智，笔记使人准确，读史使人明智，读诗使人灵秀，数学使人周密，科学使人深刻，伦理使人庄重，逻辑修辞使人善辩。凡有所学，皆成性格。 —— 培根"
        },
        {
          id: 6,
          title: "读书的乐趣",
          content:
            "读书使人充实，讨论使人机智，笔记使人准确，读史使人明智，读诗使人灵秀，数学使人周密，科学使人深刻，伦理使人庄重，逻辑修辞使人善辩。凡有所学，皆成性格。 —— 培根"
        }
      ]
    };
  }
};
</script>
<style scoped>
.carousel-container p {
  padding: 0 80px;
  line-height: 30px;
  z-index: 1 !important;
}
.el-carousel {
  /* width: 80%; */
  margin: 0 auto;
}
h1 {
  text-align: center;
}
</style>