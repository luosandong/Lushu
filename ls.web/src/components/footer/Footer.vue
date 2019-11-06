<template>
  <div id="footer">
    <div class="footer-item">&nbsp;</div>
    <div class="footer-item website-about">
      <h3>网站相关</h3>
      <p>
        <a href>意见反馈</a>
      </p>
      <p>
        <a href>新增图书</a>
      </p>
      <p>
        <a href>站长统计</a>
      </p>
    </div>
    <div class="footer-item website-info">
      <h3>网站信息</h3>
      <p>{{$store.state.website.baseInfo.icp}}</p>
    </div>
    <div class="footer-item website-contact">
      <h3>联系方式</h3>
      <p>联系人：{{$store.state.website.baseInfo.contact}}</p>
      <p>E-mail: {{$store.state.email}}</p>
      <p>地址: {{$store.state.website.baseInfo.address}}</p>
    </div>
    <div class="footer-item">&nbsp;</div>
    <!-- <div class="footer-info">
      <a href="#">回到顶部</a>
    </div>-->
    <div class="mobile-footer-container">
      <div class="float-left">
        <tab-bar>
          <tab-bar-item route="/">
            <img slot="item-icon" src="@/assets/img/tabbar/home24x24.png" />
            <img slot="item-icon-active" src="@/assets/img/tabbar/home24x24.png" />
            <div slot="item-text">主页</div>
          </tab-bar-item>
          <tab-bar-item route="/book/category">
            <img slot="item-icon" src="@/assets/img/tabbar/category24x24.png" />
            <img slot="item-icon-active" src="@/assets/img/tabbar/category24x24.png" />
            <div slot="item-text">分类</div>
          </tab-bar-item>
          <tab-bar-item route="/book/plan">
            <img slot="item-icon" src="@/assets/img/tabbar/plan24x24.png" />
            <img slot="item-icon-active" src="@/assets/img/tabbar/category24x24.png" />

            <div slot="item-text">计划</div>
          </tab-bar-item>
          <tab-bar-item route="/profile">
            <img slot="item-icon" src="@/assets/img/tabbar/more24x24.png" />
            <img slot="item-icon-active" src="@/assets/img/tabbar/category24x24.png" />

            <div slot="item-text">更多</div>
          </tab-bar-item>
        </tab-bar>
      </div>
    </div>
  </div>
</template>
<script>
import tabBar from "@/components/tabbar/TabBar.vue";
import tabBarItem from "@/components/tabbar/TabBarItem.vue";

export default {
  name: "lsFooter",
  components: {
    tabBar,
    tabBarItem
  }
};
</script>
<style scoped>
#footer {
  display: flex;
  justify-content: space-around;
  width: 80%;
  margin:0 auto;
  height: 100%;
  /* background-color: black; */
}
#footer h3 {
  font-size: 0.8em;
  text-align: left;
}
#footer p {
  margin: 0;
  padding: 0;
  font-size: 14px;
  text-align: left;
}
.footer-item {
  margin-top: 10px;
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  vertical-align: middle;
}
.website-about {
  /* background-color: brown; */
  flex-direction: column;
  align-self: auto;
}

.website-info {
  /* background-color: yellow; */
  flex-direction: column;
}

.website-contact {
  /* background-color: blue; */
  flex-direction: column;
}

.mobile-footer-container {
  display: none;
}

@media (max-width: 600px), (max-width: 336px) {
  .mobile-footer-container {
    display: none;
  }
}
</style>