(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-f96c4a86"],{"156f":function(t,n,o){},"16f4":function(t,n,o){"use strict";o.r(n);var e=function(){var t=this,n=t.$createElement,o=t._self._c||n;return o("div",{attrs:{id:"books"}},t._l(t.catagories,(function(n){return o("div",{key:n.id,staticClass:"books-item"},[o("h3",[t._v(t._s(n.name))]),o("hr"),t._l(n.books,(function(n){return o("div",{key:n.name},[o("a",{attrs:{href:""}},[t._v(t._s(n.name))])])}))],2)})),0)},c=[],i=o("1bab"),a={data:function(){return{catagories:[],books:[]}},created:function(){this.init()},methods:{init:function(){var t=this;Object(i["a"])("/bookservice/bookcategories").then((function(n){t.catagories=n.data,console.log(n)})).catch((function(t){console.log(t)}))},getbooks:function(){}}},s=a,r=(o("c363"),o("2877")),u=Object(r["a"])(s,e,c,!1,null,"07783e75",null);n["default"]=u.exports},c363:function(t,n,o){"use strict";var e=o("156f"),c=o.n(e);c.a}}]);
//# sourceMappingURL=chunk-f96c4a86.f8383b5f.js.map