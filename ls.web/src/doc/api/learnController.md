# LearnNote API

## 获取所有笔记

api 地址

api/learn/notes

请求方法 ：get

参数 ：无

返回数据 ：

```json
{
  "code": 200,
  "data": [
    {
      "id": "7c4d1445-92b8-4445-88a2-590551c170f7",
      "bookId": "4ce8adaf-5ca5-47de-a31d-e7efe70bcf86",
      "authorId": "88888",
      "authorName": "Admin",
      "subject": "认识JavaScript",
      "noteContent": "<p>JavaScript是一种专为网页交互设计的脚本语言，由下列三个不同部分组成：</p><ul><li>ECMAScript，由ECMA-262定义，提供核心语言功能；</li><li>文档对象模型（DOM），提供访问和操作网页内容的方法和接口；</li><li>浏览器对象模型（BOM），提供与浏览器交互的方法和接口；</li></ul><p>&nbsp; &nbsp; JavaScript的这三个组成部分，在当前主要浏览器中都得到了不同程序的支持。其中所有浏览器对ECMAScript第三版的支持大体上都还不错，而对ECMAScript5的支持程度越来越高。但对DOM的支持则彼此相差比较多。对已经正式纳入HTML5标准的BOM来说，尽管浏览器都实现了某些众所周知的共同特性，但其它特性还是会因浏览器而异。</p><p><br></p><p><span style=\"font-weight: bold;\">补充</span>：JavaScript除了专为网页交互外，还能运行在Google的Node环境，比如NPM都依赖JavaScript实现。Node是JavaScript除浏览器外的另一个运行环境。</p>",
      "noteTime": "2019-10-29T10:12:50",
      "starCount": 330,
      "summary": "JavaScript是一种专为网页交互设计的脚本语言，由下列三个不同部分组成：JavaScript的这三个组成部分，在当前主要浏览器中都得到了不同程序的支持。其中所有浏览器对ECMAScript第三版的支持大体上都还不错，而对ECMAScript5的支持程度越来越高。但对DOM的支持则彼此相差比较多。对已经正式纳入HTML5标准的BOM来说，尽管浏览器都实现了某些众所周知的共同特性，但其它特性还是会因浏览器而异,JavaScript除了专为网页交互外，还能运行在Google的Node环境，比如NPM都依赖JavaScript实现。Node是JavaScript除浏览器外的另一个运行环境",
      "opposeCount": 2,
      "tags": "JavaScript,前端",
      "readCount": 0,
      "wordCount": 0
    },
    {
      "id": "c7e9ee62-3b15-4961-8ce1-d5fd4702bff9",
      "bookId": "6138beec-9516-4eb3-9921-a1e970ca4914",
      "authorId": "88888",
      "authorName": "Admin",
      "subject": "阅读《听宝宝说话》写在前面",
      "noteContent": "<p></p><p>最近发现宝宝特别的胆小，任何场合都不敢去尝试，让我开始怀疑我的宝宝是否心理有些不正常，通过各种途径有人推荐了这本书，所以我需要来阅读这本书，并帮助宝宝找回自信，希望能坚持下去。</p>",
      "noteTime": "2019-11-04T12:09:46",
      "starCount": 32,
      "summary": "最近发现宝宝特别的胆小，任何场合都不敢去尝试，让我开始怀疑我的宝宝是否心理有些不正常，通过各种途径有人推荐了这本书，所以我需要来阅读这本书，并帮助宝宝找回自信，希望能坚持下去。",
      "opposeCount": 0,
      "tags": "幼儿教育,心理学,宝宝",
      "readCount": 0,
      "wordCount": 0
    }
  ],
  "error": ""
}
```

返回值说明:

- code 参照 API 文档首页说明
- info 参照 API 文档首页说明
- data 登录成功的用户信息
- bookId 书籍 id
- authorId 作者 id
- authorName 作者
- subject 标题
- noteContent 笔记内容
- noteTime 时间
- starCount 推荐数
- summary 摘要
- opposeCount 踩掉数
- tags 标签分类
- readCount 阅读数
- wordCount 字数

报错返回:

- 参照 API 文档首页的“code 对应码说明”

## 根据 ID 获取单个笔记详情

api 地址:

api/learn/note

请求方法: POST

请求数据：

```json
{
  "noteId": "123213214"
}
```

字段说明:

- noteId 笔记 ID

返回数据:

```json
{
  "code": 200,
  "data": {
    "id": "7c4d1445-92b8-4445-88a2-590551c170f7",
    "bookId": "4ce8adaf-5ca5-47de-a31d-e7efe70bcf86",
    "authorId": "88888",
    "authorName": "Admin",
    "subject": "认识JavaScript",
    "noteContent": "<p>JavaScript是一种专为网页交互设计的脚本语言，由下列三个不同部分组成：</p><ul><li>ECMAScript，由ECMA-262定义，提供核心语言功能；</li><li>文档对象模型（DOM），提供访问和操作网页内容的方法和接口；</li><li>浏览器对象模型（BOM），提供与浏览器交互的方法和接口；</li></ul><p>&nbsp; &nbsp; JavaScript的这三个组成部分，在当前主要浏览器中都得到了不同程序的支持。其中所有浏览器对ECMAScript第三版的支持大体上都还不错，而对ECMAScript5的支持程度越来越高。但对DOM的支持则彼此相差比较多。对已经正式纳入HTML5标准的BOM来说，尽管浏览器都实现了某些众所周知的共同特性，但其它特性还是会因浏览器而异。</p><p><br></p><p><span style=\"font-weight: bold;\">补充</span>：JavaScript除了专为网页交互外，还能运行在Google的Node环境，比如NPM都依赖JavaScript实现。Node是JavaScript除浏览器外的另一个运行环境。</p>",
    "noteTime": "2019-10-29T10:12:50",
    "starCount": 330,
    "summary": "JavaScript是一种专为网页交互设计的脚本语言，由下列三个不同部分组成：JavaScript的这三个组成部分，在当前主要浏览器中都得到了不同程序的支持。其中所有浏览器对ECMAScript第三版的支持大体上都还不错，而对ECMAScript5的支持程度越来越高。但对DOM的支持则彼此相差比较多。对已经正式纳入HTML5标准的BOM来说，尽管浏览器都实现了某些众所周知的共同特性，但其它特性还是会因浏览器而异,JavaScript除了专为网页交互外，还能运行在Google的Node环境，比如NPM都依赖JavaScript实现。Node是JavaScript除浏览器外的另一个运行环境",
    "opposeCount": 2,
    "tags": "JavaScript,前端",
    "readCount": 0,
    "wordCount": 0
  },
  "error": ""
}
```

返回值说明:

- code 参照 API 文档首页说明
- info 参照 API 文档首页说明
- data 登录成功的用户信息
- bookId 书籍 id
- authorId 作者 id
- authorName 作者
- subject 标题
- noteContent 笔记内容
- noteTime 时间
- starCount 推荐数
- summary 摘要
- opposeCount 踩掉数
- tags 标签分类
- readCount 阅读数
- wordCount 字数

报错返回:

- 参照 API 文档首页的“code 对应码说明”

## 增加阅读数

api 地址:

api/learn/addreadcount

请求方法: POST

请求数据：

```json
{
  "noteId": "000849"
}
```

参数说明:

- noteId 笔记 ID

返回数据:

```json
{
  "code": 200,
  "info": "请求(或处理)成功",
  "data": true
}
```

返回值说明:

- data true 表示保存成功

报错返回:

- 参照 API 文档首页的“code 对应码说明”
