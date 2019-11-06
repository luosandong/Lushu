<template>
  <div class="notes">
    <div class="notes-left notes-cell">
      <div class="notes-star">{{note.starCount}}</div>
      <div class="notes-low">推荐</div>
    </div>
    <div class="notes-right notes-cell">
      <div class="right-top">
        <h3>
          <a @click="detail()">{{note.subject}}</a>
        </h3>
      </div>
      <div class="right-content">{{note.summary}}</div>
      <div class="right-bottom">
        <span>{{note.authorName}}</span>
        <span>发布于</span>
        <span>{{note.noteTime}}</span>
        <span>
          <a @click="detail()">评论({{note.commentCount}})</a>
        </span>
        <span>
          <a @click="detail()">阅读({{note.readCount}})</a>
        </span>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    note: Object
  },
  methods: {
    detail() {
      let params = {
        path: "/learn/note/detail",
        query: { noteId: this.note.id }
      };
      this.$router.push(params);
      //this.$router.push("/learn/note/detail",query);
    }
  },
  created() {
    //console.log(this.note);
  }
};
</script>
<style scoped>
a {
  color: rgb(16, 92, 182);
  cursor: pointer;
}
.notes {
  display: flex;

  border-bottom: 1px dotted #8c8b8b;
  margin: 50px 0;
}

.notes-cell {
  flex: 1;
}
.notes-left {
  flex: 0 0 5%;
}
.notes-left div {
  height: 30px;
  line-height: 30px;
  text-align: center;
}
.notes-star {
  background-color: #e4e7ed;
  /* color:red; */
}
.notes-low {
  background-color: #f2f6fc;
}
.notes-right {
  /* flex: 0 0 100%; */
  margin-left: 5px;
  font-size: 14px;
  /* background-color: #fff; */
}
.right-top {
  padding-left: 5px;
}
.right-content {
  font-size: 1em;
  text-indent: 2rem;
  padding: 5px;
}
.right-bottom span {
  font-size: 12px;
  display: inline-block;
  margin: 0 5px;
}
</style>