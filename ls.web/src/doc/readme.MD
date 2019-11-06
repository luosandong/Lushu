# API 文档说明

## 目录

- [学习笔记] API](./api/learnController.md)

## 接口文档说明

### 接口示例

- 地址 https://localhost:{port}/api/{controller}/{action}

> 除标记为匿名接口外，全部需要为非匿名

### 消息头 Header 说明

> 所有 api 在请求时都应该设置以下 Header 值,中文字符需要 urlencode

- Content-Type application/json

### 返回数据结构示例

```json
{
  "code": 200,
  "info": "请求正常",
  "data": true
}
```

结构说明:

- code 代表当次请求所响应后的消息代码
- info 代表响应消息的描述信息
- data 代表返回正常数据

code 对应码说明：

- 200 请求(或处理)成功
- 5000 系统内部错误
- 5001 Header 参数错误
- 5002 参数错误
