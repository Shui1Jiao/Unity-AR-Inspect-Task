# Unity‑AR 园区巡检原型
>实操作业原型：Unity AR放置标记上报问题 → Go后端持久化存储 → React‑TS管理后台查看、修改问题状态。

## 📋技术栈
- Unity：Unity LTS，C#，AR Foundation / ARCore（安卓真机AR平面检测）
- 后端：Golang，SQLite（数据持久化，重启数据不丢失）
- 前端管理端：React + TypeScript
- 数据存储：SQLite 文件数据库

## 📁项目目录结构
ar‑inspect‑repo
├─ unity‑client/        # Unity 移动端源码
├─ go‑server/           # Go 后端服务源码
├─ react‑admin/         # React+TS 管理后台
├─ AI_LOG.md            # AI 使用记录（作业要求）
└─ README.md            # 本说明文档


## ✨已完成功能
### Unity移动端
1. AR Foundation识别真实环境水平平面；点击平面放置标记物体；
2. 表单填写巡检问题：title(必填)、description、priority(low/medium/high)；
3. 收集标记世界坐标，HTTP POST上报Go后端；提交成功/失败UI提示；
4. UI交互防误触：点击输入框/按钮不会触发AR放置标记；

### Go后端
1. `/api/health` 健康检查接口；
2. `/api/issues` POST：接收上报巡检问题，参数校验；自动生成ID，status默认`open`；
3. `/api/issues` GET：获取全部问题列表；
4. `/api/issues/:id` PATCH：修改问题状态（open / in_progress / resolved）；
5. SQLite持久化存储，服务重启数据保留；开启CORS允许浏览器跨域访问；

### React管理端
1. 请求后端获取巡检问题列表；展示标题、优先级、状态；
2. 下拉修改问题处理状态，调用后端更新；
3. 后端服务不可用时页面输出错误提示，不会白屏。

## ❌未完成 / 已知问题
>1. Unity未实现历史标记重新加载；
>2. 无登录权限模块；
>3. 仅支持安卓ARCore真机，iOS未适配。

## 🚀启动步骤
### 1. Go后端
```bash
cd go‑server
go run main.go
