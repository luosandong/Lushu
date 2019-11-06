<template>
  <div class="learn">
    <h3>写笔记</h3>
    <el-form :model="noteForm" :rules="rules" ref="notes" label-width="100px" class="demo-ruleForm">
      <el-form-item label="图书信息" prop="bookId">
        <el-select v-model="noteForm.bookId" placeholder="该笔记属于哪本书">
          <el-option v-for="book in books" :key="book.id" :label="book.name" :value="book.id"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="标题" prop="subject">
        <el-input v-model="noteForm.subject"></el-input>
      </el-form-item>
      <el-form-item label="内容">
        <div id="editor">
          <p>
            
          </p>
        </div>
      </el-form-item>
      <el-form-item label="标签" prop="tags">
        <el-input v-model="noteForm.tags"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="submitForm('notes')">立即创建</el-button>
        <el-button @click="resetForm('notes')">重置</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>
<script>
import E from "wangeditor";
import globalConfig from '@/config/config.js';
import { request } from "@/network/request.js";
export default {
  name: "learn",
  data() {
    return {
      books: [],
      noteForm: {
        subject: "",
        bookId: "",
        noteContent: "",
        tags:'',
        summary:"",
        wordCount:0
      },
      rules: {
        subject: [
          { required: true, message: "请输入标题", trigger: "blur" },
          { min: 3, max: 30, message: "长度在 3 到 5 个字符", trigger: "blur" }
        ],
        bookId: [{ required: true, message: "请选择一本书", trigger: "change" }]
      },
      editor: null,
      editorContent: "<h1>Hello</h1>"
    };
  },
  mounted() {
    this.editor = new E("#editor"); // 编辑器的事件，每次改变会获取其html内容
    this.editor.customConfig.onchange = html => {
      this.noteForm.noteContent = html;
      this.noteForm.summary = this.editor.txt.text();
      this.noteForm.wordCount = this.noteForm.summary.length;
      // this.catchData(this.editorContent); // 把这个html通过catchData的方法传入父组件 };
    };
    this.editor.customConfig.menus = [
      // 菜单配置
      "head", // 标题
      "bold", // 粗体
      "fontSize", // 字号
      "fontName", // 字体
      "italic", // 斜体
      "underline", // 下划线
      "strikeThrough", // 删除线
      "foreColor", // 文字颜色
      "backColor", // 背景颜色
      "link", // 插入链接
      "list", // 列表
      "justify", // 对齐方式
      "quote", // 引用
      "emoticon", // 表情
      "image", // 插入图片
      "table", // 表格
      "code", // 插入代码
      "undo", // 撤销
      "redo" // 重复
    ];
    this.editor.customConfig.zIndex = 100;
    this.uploadImgServerConfig(this.editor);
    this.editor.create(); // 创建富文本实例作者：
  },
  created: function() {
    this.init();
  },
  methods: {
    init() {
      request("/bookservice/list")
        .then(res => {
          this.books = res.data;
          console.log(res);
        })
        .catch(err => {
          console.log(err);
        });
    },
    submitForm(formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          request({
            url: "/learn/savenote",
            method: "post",
            data: JSON.stringify(this.noteForm)
          })
            .then(res => {
              console.log(res);
            })
            .catch(err => {
              console.log(err);
            });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    uploadImgServerConfig(editor) {
      editor.customConfig.uploadImgServer =
        globalConfig.host+"/learn/uploadimg"; // 上传图片到服务器
      // 3M
      editor.customConfig.uploadImgMaxSize = 3 * 1024 * 1024;
      // 限制一次最多上传 5 张图片
      editor.customConfig.uploadImgMaxLength = 1;
      // 自定义文件名
      editor.customConfig.uploadFileName = "editor_img";
      // 将 timeout 时间改为 3s
      editor.customConfig.uploadImgTimeout = 50000;

      editor.customConfig.uploadImgHooks = {
        before: function(xhr, editor, files) {
          // 图片上传之前触发
          // xhr 是 XMLHttpRequst 对象，editor 是编辑器对象，files 是选择的图片文件
          // 如果返回的结果是 {prevent: true, msg: 'xxxx'} 则表示用户放弃上传
          // return {
          //     prevent: true,
          //     msg: '放弃上传'
          // }
          // alert("前奏");
        },
        success: function(xhr, editor, result) {
          // 图片上传并返回结果，图片插入成功之后触发
          // xhr 是 XMLHttpRequst 对象，editor 是编辑器对象，result 是服务器端返回的结果
          // var url = result.data.url;
          // alert(JSON.stringify(url));
          // editor.txt.append(url);
          console.log(result);
        },
        fail: function(xhr, editor, result) {
          // 图片上传并返回结果，但图片插入错误时触发
          // xhr 是 XMLHttpRequst 对象，editor 是编辑器对象，result 是服务器端返回的结果
          alert("失败");
        },
        error: function(xhr, editor) {
          // 图片上传出错时触发
          // xhr 是 XMLHttpRequst 对象，editor 是编辑器对象
          // alert("错误");
        },
        // 如果服务器端返回的不是 {errno:0, data: [...]} 这种格式，可使用该配置
        // （但是，服务器端返回的必须是一个 JSON 格式字符串！！！否则会报错）
        customInsert: function(insertImg, result, editor) {
          // 图片上传并返回结果，自定义插入图片的事件（而不是编辑器自动插入图片！！！）
          // insertImg 是插入图片的函数，editor 是编辑器对象，result 是服务器端返回的结果
          // 举例：假如上传图片成功后，服务器端返回的是 {url:'....'} 这种格式，即可这样插入图片：
          var url = result.data.url;
          insertImg(url);
          // result 必须是一个 JSON 格式字符串！！！否则报错
        }
      };
    }
  }
};
</script>