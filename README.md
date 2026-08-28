Unity‑AR‑Inspect‑Task
AR 园区巡检实操作业原型，基于 Unity AR‑Foundation + Go + React‑TS
项目简介
本项目为园区 AR 巡检作业原型系统，实现移动端 AR 环境下园区设备巡检交互。
客户端：Unity + AR‑Foundation，实现空间识别、设备标记、巡检交互
后端服务：Go 提供业务接口，处理巡检数据、设备信息
Web 管理端：React‑TS，用于查看巡检记录、设备台账、任务管理
适合作为课程作业、AR 工程原型演示。
技术栈
客户端：Unity 、AR‑Foundation、C#
后端：Golang
Web 前端：React + TypeScript
版本管理：Git（Gitee / GitHub 双仓）
目录结构
plaintext
unity-client/        # Unity AR客户端工程
├─ Assets/           # AR资源、脚本、场景
└─ ProjectSettings/
A1_shturl            # 开发日志
.gitignore
README.md
运行说明
Unity AR 客户端
使用 Unity 打开 unity-client 文件夹
导入 AR‑Foundation 相关依赖包
部署到支持 AR‑Core/AR‑Kit 的移动设备
运行，识别平面，加载园区巡检交互
后端 & Web 管理端
启动 Go 后端服务
启动 React 前端，访问管理后台页面
查看巡检任务、设备数据