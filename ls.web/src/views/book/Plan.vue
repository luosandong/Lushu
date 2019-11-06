<template>
  <div id="plan">
    <div class="plan-item book-info">
      <h3>图书信息：</h3>
      <el-form ref="form" :model="book" label-width="80px">
        <el-form-item label="书名">
          <el-input v-model="book.name"></el-input>
        </el-form-item>
        <el-form-item label="作者">
          <el-input v-model="book.author"></el-input>
        </el-form-item>
        <el-form-item label="图书类型">
          <el-select v-model="book.categoryId" placeholder="请选择图书类型">
            <el-option
              v-for="bookCategory in bookCategories"
              :key="bookCategory.id"
              :label="bookCategory.name"
              :value="bookCategory.id"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="总页数">
          <el-input v-model="book.totalPages"></el-input>
        </el-form-item>
        <el-form-item label="出版社">
          <el-input v-model="book.press"></el-input>
        </el-form-item>
        <el-form-item label="出版日期">
          <el-col :span="24">
            <el-date-picker
              v-model="book.pubDate"
              type="date"
              placeholder="选择日期"
              style="width: 100%;"
            ></el-date-picker>
          </el-col>
        </el-form-item>
        <el-form-item label="单价">
          <el-input v-model="book.price"></el-input>
        </el-form-item>
        <el-form-item label="内容摘要">
          <el-input type="textarea" v-model="book.description"></el-input>
        </el-form-item>
      </el-form>
    </div>
    <div class="plan-item read-plan">
      <h3>阅读计划：</h3>
      <el-form ref="form" :model="plan" label-width="80px">
        <el-form-item label="计划名称">
          <el-input v-model="plan.planName"></el-input>
        </el-form-item>
        <el-form-item label="计划类型">
          <el-radio-group v-model="plan.planType" >
            <el-radio v-model="plan.planType" label="1">按天数计划</el-radio>
            <el-radio v-model="plan.planType" label="2">按页数计划</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item label="起止日期">
          <el-col :span="11">
            <el-date-picker
              type="date"
              v-model="plan.begintime"
              placeholder="选择日期"
              style="width: 100%;"
            ></el-date-picker>
          </el-col>
          <el-col class="line" :span="2">-</el-col>
          <el-col :span="11">
            <el-date-picker
              type="date"
              v-model="plan.planFinishtime"
              placeholder="选择日期"
              style="width: 100%;"
            ></el-date-picker>
          </el-col>
        </el-form-item>

        <el-form-item label="描述">
          <el-input type="textarea" v-model="plan.description"></el-input>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" @click="onSubmit">立即创建</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>
<script>
import { request } from "@/network/request.js";
export default {
  name: "plan",
  data() {
    return {
      bookCategories: [],
      book: {
        categoryId: "",
        name: "",
        author: "",
        pubDate: "",
        price: 0.0,
        description: "",
        totalPages: 0,
        press: ""
      },
      plan: {
        planName: "",
        begintime: "",
        planFinishtime: "",
        planType: 0,
        description: ""
      }
    };
  },
  created: function() {
    this.init();
  },
  methods: {
    init() {
      request("/bookservice/bookcategories")
        .then(res => {
          this.bookCategories = res.data;
          console.log(res);
        })
        .catch(err => {
          console.log(err);
        });
    },

    onSubmit() {
      let postData = {
        book: this.book, // JSON.parse(JSON.stringify(this.book)),
        plan: this.plan //JSON.parse(JSON.stringify(this.plan))
      };
      console.log(this.plan.planType);
      console.log(postData.plan);
      request({
        method: "post",
        url: "/bookservice/saveplan",
        data: JSON.stringify(postData)
      });
      
      //   let jstring = JSON.stringify( this.plan);
      //   let planObj = JSON.parse(jstring)
      //   console.log(planObj);
    }
  }
};
</script>
<style scoped>
#plan {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  flex-direction: row;
}
#plan h3 {
  font-family: "Helvetica Neue", Helvetica, "PingFang SC", "Hiragino Sans GB",
    "Microsoft YaHei", "微软雅黑", Arial, sans-serif;
  margin-bottom: 30px;
}

.plan-item {
  margin: 1px;
  flex: 1;
  flex-basis: 500px;
  align-self: flex-end;
}
.book-info {
  /* background-color:yellow; */
}
.read-plan {
  /* background-color:red; */
}
</style>