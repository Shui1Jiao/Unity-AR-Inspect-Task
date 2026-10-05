# Unity AR 园区巡检原型

> 用手机 AR 在真实环境里放置巡检标记、填写问题并上报的移动端原型。
>
> **仓库范围说明：本仓库仅包含 Unity AR 客户端（`unity-client/`）。** 原规划中的 Go 后端与 React 管理端尚未提交到本仓库。

## 项目做什么

巡检人员用手机对着场地扫描 → 识别出水平平面 → 点击放置一个标记球 → 在弹出的表单里填写问题 → 标记与问题位置一一绑定。目的是把「巡检发现问题」从纸笔记录变成带着空间坐标的结构化数据。

## 技术栈

- **客户端**：Unity LTS + C#，AR Foundation / ARCore（Android 真机平面检测）
- **数据**：标记的世界坐标由 `ARMarkerPlacer` 采集，随表单一并记录

## 目录结构

```text
Unity-AR-Inspect-Task/
├── unity-client/
│   ├── Assets/
│   │   ├── Scripts/
│   │   │   ├── ARMarkerPlacer.cs      # 平面射线检测 + 标记放置
│   │   │   └── ReportUIManager.cs     # 上报表单 UI
│   │   ├── AVAilabilityChecker.cs     # AR 能力可用性检查
│   │   ├── SceneJump.cs / SceneSwitcher.cs   # 场景切换
│   │   ├── CloseForm.cs / JumpBtn.cs         # 表单与按钮交互
│   │   ├── VirtualPlace.cs / TestDemo.cs
│   │   ├── Scenes/                    # 场景文件
│   │   └── Plugins/Android/           # AndroidManifest 等
│   ├── Packages/manifest.json         # AR Foundation 等包依赖
│   └── ProjectSettings/               # Unity 项目设置（版本见 ProjectVersion.txt）
├── AI_LOG.md                          # 开发过程与排错记录
└── README.md
```

## 已完成功能

1. **平面识别**：AR Foundation 检测真实环境的水平平面（`TrackableType.PlaneWithinPolygon`）。
2. **点击放置标记**：射线检测命中平面后放置标记物体；已有标记时移动到新的命中位置，而不是重复实例化。
3. **上报表单**：点击标记弹出表单，包含标题、描述、优先级（low / medium / high）三个字段。
4. **坐标采集**：提交时读取标记的世界坐标，与表单内容一起记录。
5. **交互防误触**：点击输入框、按钮不会穿透到 AR 层触发新的标记放置。
6. **AR 可用性检查与场景切换**：设备不支持 AR 时给出提示；含场景跳转逻辑。

## 运行步骤

1. Unity Hub 打开 `unity-client/` 目录（Unity 版本见 `unity-client/ProjectSettings/ProjectVersion.txt`）。
2. 在 Player Settings 中切到 Android 平台，确认已安装 **AR Foundation** 与 **ARCore XR Plugin**（见 `Packages/manifest.json`）。
3. 构建到支持 ARCore 的 Android 真机运行，首次启动需授予相机权限。
4. 说明：AR 平面检测在真机才有意义，Unity 编辑器内的设备模拟器只能验证 UI 与场景逻辑。

## 已知限制

- **表单提交当前只做本地提示**：`ReportUIManager.OnSubmit()` 读取表单与实际坐标后写入提示文本，**尚未接入网络层**，数据不会上传到服务端。
- Go 后端与 React 管理端不在本仓库中。
- 不支持历史标记重新加载，退出应用后标记丢失。
- 无登录 / 权限模块。
- 仅适配 Android + ARCore，iOS（ARKit）未适配。
- `ReportUIManager.cs` 内的中文字符串存在编码问题（显示为乱码），建议统一另存为 UTF-8。

## 后续计划

1. 抽出网络层，把表单与坐标 POST 到后端服务。
2. 后端持久化 + 管理端查看/修改问题状态。
3. 启动时按服务端数据重建历史标记。
4. 补齐 iOS ARKit 适配。

## 开发记录

`AI_LOG.md` 记录了开发过程中几个真实卡点与排查过程（组件丢失、场景跳转后 Inspector 赋值失效等）及其验证方式。
