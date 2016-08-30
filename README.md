### Console 

为需要不间断运行(nohup)命令行程序提供的托盘程序

#### 环境
C#/.NET framework 4.0

#### 配置
配置文件为**config.json**,与程序同目录,或者可以以命令行启动程序并指定配置文件

**cmd** 启动程序
**args** 程序参数
完整的配置文件如下:
``` json
[
	{
		"cmd": "ping",
		"args": "www.baidu.com -t"
	},
	{
		"cmd": "python2",
		"args": "./drcom.py"
	},
	{
		"cmd": "node",
		"args": "./test.js"
	}
]
```

#### 未来更新
1. 随手写的代码, 很糟糕的风格@_@
2. 测试时,对于python脚本未能显示输出
3. 在程序输出较快速时, UI主线程可能会卡死
4. 需要添加对单个命令的停止/开始等操作
5. 优化内存占用

#### LICENSE
MIT
