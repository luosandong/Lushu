<template>
  <div class="note-detail">
    <div class="cell detail-content">
      <h5>{{note.subject}}</h5>
      <!-- <h4>{{this.$route.query.noteId}}</h4> -->
      <div class="note-info">
        <span>{{note.noteTime}}</span>
        字数
        <span>{{note.wordCount}}</span>
        阅读
        <span>{{note.readCount}}</span>
      </div>
      <div class="line"></div>

      <div class="note-content" v-html="note.noteContent"></div>
      <div class="tags">
        <span>标签:</span>
        <a class="tag" v-for="tag in noteTags" :key="tag">{{tag}}</a>
      </div>
      <div class="line"></div>
      <div class="approve-oppose">
        <el-row>
          <el-button
            :disabled="voted"
            type="primary"
            @click.once="approve()"
          >{{"推荐 "+ note.starCount}}</el-button>
          <el-button
            :disabled="voted"
            type="warning"
            @click.once="oppose()"
          >{{"反对 "+note.opposeCount}}</el-button>
        </el-row>
      </div>
      <!-- <div class="line"></div> -->
      <div class="comments">
        <h5>评论列表</h5>
        <div class="line"></div>
        <div class="feedbackItem" v-for="(comment,index) in comments" :key="comment.id">
          <div class="feedbackListSubtitle">
            <!-- <div class="feedbackManage">
              &nbsp;&nbsp;
              <span class="comment_actions">
                <a>回复</a>
                <a>引用</a>
              </span>
            </div>-->
            <!-- Title -->
            <a href="#4412770" class="layer">#{{index+1}}楼</a>&nbsp;
            <a name="4412770" id="comment_anchor_4412770"></a>
            <span v-show="index==0" class="louzhu">[楼主]&nbsp;</span>
            <!-- PostDate -->
            <span class="comment_date">{{comment.submitTime}}</span>&nbsp;
            <!--NameLink-->
            <span>{{comment.commentatorName}}</span>
            <div class="feedbackCon">
              <div class="blog_comment_body">{{comment.commentMessage}}</div>
              <div class="comment_vote">
                <span class="comment_error" style="color: red"></span>
                <a href="javascript:void(0);">支持(0)</a>
                <a href="javascript:void(0);">反对(0)</a>
              </div>
            </div>
          </div>
        </div>

        <div class="comment-text">
          <textarea v-model="commentMessage" rows="2" placeholder="在此处评论"></textarea>
        </div>
        <div class="buttons">
          <el-button type="primary" @click="submitComment()">提交评论</el-button>
        </div>
        <div class="line"></div>
      </div>
    </div>
    <div class="cell detail-aside">
      <div class="title">
        <h5>相关笔记</h5>
      </div>
      <div class="line"></div>
      <div class="aside-item" v-for="(note,index) in outherNotes" :key="note.id">
        <a target="_blank" :href="'/learn/note/detail?noteId='+note.id">
          <span>{{index+1}}</span>
          .&nbsp;{{note.subject}}
        </a>
      </div>
    </div>
  </div>
</template>
<script>
import { request } from "@/network/request.js";
export default {
  data() {
    return {
      note: {},
      commentMessage: "",
      outherNotes: [],
      comments: [],
      voted: false
    };
  },
  computed: {
    noteTags() {
      if (this.note.tags) {
        let tagAry = this.note.tags.split(",");
        return tagAry;
      }
      return null;
    }
  },
  created() {
    this.query_noteId = this.$route.query.noteId;
    this.load();
  },
  methods: {
    load() {
      let postData = {
        noteId: this.$route.query.noteId
      };
      request({
        url: "/learn/note",
        method: "post",
        data: JSON.stringify(postData)
      })
        .then(res => {
          this.note = res.data;
          this.getComments();
          //阅读数累加
          this.addreadcount();
          this.getNoteByBookId();
        })
        .catch(err => {
          console.log(err);
        });
    },
    addreadcount() {
      request({
        url: "/learn/addreadcount",
        method: "post",
        data: JSON.stringify({
          noteId: this.note.id
        })
      }).then(res => {});
    },
    submitComment() {
      if (this.commentMessage === "") return;
      request({
        url: "/learn/submitnotecomment",
        method: "post",
        data: JSON.stringify({
          commentMessage: this.commentMessage,
          parentCommentId: "",
          learnNoteId: this.note.id
        })
      }).then(res => {
        if (res.data) {
          this.commentMessage = "";
          this.getComments();
        }
      });
    },
    getComments() {
      request({
        url: "/learn/getComments",
        method: "post",
        data: JSON.stringify({ noteId: this.note.id })
      }).then(res => {
        this.comments = res.data;
      });
    },
    approve() {
      request({
        url: "/learn/noteApprove",
        method: "post",
        data: JSON.stringify({
          noteId: this.note.id
        })
      }).then(res => {
        this.note.starCount += 1;
        this.voted = true;
      });
    },
    oppose() {
      request({
        url: "/learn/noteOppose",
        method: "post",
        data: JSON.stringify({
          noteId: this.note.id
        })
      }).then(res => {
        this.note.opposeCount += 1;
        this.voted = true;
      });
    },
    getNoteByBookId() {
      request({
        url: "/learn/noteByBookId",
        method: "post",
        data: JSON.stringify({ bookId: this.note.bookId })
      }).then(res => {
        this.outherNotes = res.data;
      });
    },
    goNote(noteId) {
      console.log(noteId);
      //this.query_noteId = noteId
      // let params = {
      //   path: "/learn/note/detail",
      //   query: { noteId: noteId }
      // };
      // this.$router.push(params);
      this.load();
    }
  }
};
</script>
<style scoped>
@import url("./css/detail.css");
</style>