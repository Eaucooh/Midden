---
title: README
date: 2022-04-12 18:56:37
permalink: /pages/dev/
categories: 
  - std
tags: 
  - 
---

<a id="markdown-markdown-header-目录" name="markdown-header-目录"></a>
# 目录
<!-- TOC -->

- [目录](#markdown-header-目录)
- [什么是 WDO-Script](#markdown-header-什么是-wdo-script)
- [基础对象](#markdown-header-基础对象)
- [基础规定](#markdown-header-基础规定)
    - [关于标识符](#markdown-header-关于标识符)
    - [关于表达式](#markdown-header-关于表达式)
    - [关于语句](#markdown-header-关于语句)

<!-- /TOC -->

<a id="markdown-markdown-header-什么是-wdo-script" name="markdown-header-什么是-wdo-script"></a>
# 什么是 WDO-Script
WDO-Script 是一个简洁的脚本语言, 混合解释和编译型, 提供跨平台的统一能力, 支持面向对象的设计模式



<a id="markdown-markdown-header-基础对象" name="markdown-header-基础对象"></a>
# 基础对象
WDO-Script 规定了一种基础类, 即 `Object` 类, 所有类均默认派生自此类

同时规定了几种主要类, 分别是 `Number` , `String` , `List` , `Expression` , `Action`

即数字类, 字符串类, 列表类, 表达式类, 行动语句类

<a id="markdown-markdown-header-基础规定" name="markdown-header-基础规定"></a>
# 基础规定
<a id="markdown-markdown-header-关于标识符" name="markdown-header-关于标识符"></a>
## 关于标识符
所有的`变量名`, `常量名`, `函数名`, `方法名`, `命名空间`, `类名`, `接口名`等都属于标识符

标识符允许包含大小写英文字母, 数字, 下划线以及 Utf-8 编码中文字符, 但是不能以数字开头且不能包含空格, 纯数字也是不允许的

以下是识别标识符的正则表达式
```regex
\n* *([a-zA-Z_\u4e00-\u9fa5]+[a-zA-Z_0-9\u4e00-\u9fa5]+) *
```

<a id="markdown-markdown-header-关于表达式" name="markdown-header-关于表达式"></a>
## 关于表达式
表达式的基类型是 Expression 类型, 每一个表达式其实是一颗表达式数

每个表达式有左表达式, 右表达式, 而当前表达式的值由左右表达式和运算符决定

一旦建立一个合法的表达式树即可层层递归求解顶层表达式的值

<a id="markdown-markdown-header-关于语句" name="markdown-header-关于语句"></a>
## 关于语句
WDO-Script 优先识别语句

包括:
* `Action.Declare`: 声明语句
* `Action.Assign`: 赋值语句
* `Action.FuncCall`: 函数调用语句

每个语句以 `;` 结束, 不能省略



