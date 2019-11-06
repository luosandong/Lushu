<template>
  <div id="article">
    <div class="ls-article" v-for="article in articles" :key="article.id">
      <h3 class="article-title">{{article.name}}</h3>
      <p class="article-meta">
        <slot name="author">作者</slot>&nbsp;
        <time>{{article.time}}</time> &nbsp;
        <a class="btn-item">{{article.author}}</a>
      </p>
      <p>{{article.press}}</p>
      <p class="text-indent">{{article.description}}</p>
      <p class="btns">
        <a class="btn-item">详细</a>
        <a class="btn-item">评论</a>
      </p>
    </div>
  </div>
</template>
<script>
import { request } from "@/network/request.js";
export default {
  name: "lsArticle",
  data() {
    return {
      articles: []
    };
  },
  created(){
    this.init();
  },
  methods:{
    init(){
 request("/bookservice/list")
        .then(res => {
          this.articles = res.data;
          console.log(res);
        })
        .catch(err => {
          console.log(err);
        });
    }
  }
};
</script>
<style scoped>
.ls-article {
  margin: 20px;
  margin-bottom: 2rem;
  border-bottom: 1px solid #dee2e6;
  padding-bottom: 0.8rem;
  font-size: 1.2rem;
}
.ls-article h2.article-title {
  font-size: 2rem;
  margin-bottom: 0;
  letter-spacing: -2px;
}
.ls-article p {
  font-size: 1rem;
  padding: 0 10px;
  line-height: 2rem;
}
.ls-article p.article-meta {
  margin-bottom: 10px;
  color: #ccc;
  font-size: 0.8rem;
}
.text-indent {
  text-indent: 2rem;
}

.btn-item {
  display: inline-block;
  font-size: 12px;
  margin: 2px;
  padding: 2px;
  cursor: pointer;
  color: #00a4ff;
}
.btn-item:hover {
  color: #ba4525;
}

.btns {
  margin-top: 10px;
}
</style>