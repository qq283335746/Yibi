
服务注册参考：https://www.consul.io/api/agent/service.html
健康检查参考：https://www.consul.io/api/health.html

Service - Agent HTTP API:
https://www.consul.io/api/agent/service.html

consul-examples:
https://github.com/JoergM/consul-examples

服务发现系统consul-HTTP API:
https://blog.csdn.net/u010246789/article/details/51871051

如何用Consul打造弹性可扩展的PaaS平台(包含consul中文介绍)
http://www.techweb.com.cn/network/system/2016-01-28/2270190.shtml

consule服务注册和发现 安装 部署：
https://blog.51cto.com/kkkkkk/1914469

服务注册发现consul之一：consul介绍、安装、及功能介绍（包含启动参数）
https://www.cnblogs.com/duanxz/p/7053301.html

How to setup Consul Cluster on Ubuntu 18.04 / Ubuntu 16.04 LTS：
https://computingforgeeks.com/how-to-install-consul-cluster-18-04-lts/

Consul 使用手册（感觉比较全了）：
https://blog.csdn.net/liuzhuchen/article/details/81913562

Consul TTL模式：
https://www.cnblogs.com/duanxz/p/9662862.html



其中，check是用来做服务的健康检查的，可以有多个，也可以没有，支持多种方式的检查。check定义在配置文件中，或运行时通过HTTP接口添加。Check是通过HTTP与节点保持一致。
有五种check方法：
check必须是script或者TTL类型的，如果是script类型，则script和interval变量必须被提供，如果是TTL类型，则ttl变量必须被提供
script是consul主动去检查服务的健康状况，ttl是服务主动向consul报告自己的健康状况。
以下是几种配置方式
Check必须是Script、HTTP、TCP、TTL四种类型中的一种。
Script类型需要提供Script脚本和interval变量。
HTTP类型必须提供http和Interval字段。
TCP类型需要提供tcp和Interval字段，
TTL类型秩序提供ttl。
Check的name字段是自动通过service:<service-id>生成，如果有多个service，则由service:<service-id>:<num>生成。