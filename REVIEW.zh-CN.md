# PKM 插件检查与修复（2026-09-05）

对象为 WangPluginPkm 插件源码，目标框架 net10.0-windows，PKHeX.Core 26.8.26。

## 本轮修复

| 问题 | 原因与修改 | 验证 |
| --- | --- | --- |
| 深色模式下部分页面仍是浅色，控件样式不一致 | 14 个插件窗体改用 PluginForm，跟随宿主 Application.IsDarkModeEnabled。处理写死的中性背景、文字、页签和动态新增控件，统一输入框与按钮边框，保留语义色。高对比度模式下不覆盖宿主主题。 | 深浅主题回归；在 PKHeX 中打开 RNG 页；设置页视觉检查 |
| 设置页控件拥挤，图片与关于文字重叠 | 原图片和 RichTextBox 同处 (3,126)，设置区高度仅 104。改为设置／关于页签、表格布局、独立图片区域和可调整大小的窗口。 | 实际打开两个页签，确认没有重叠 |
| 数据库四个招式选择框联动 | 相同 DataSource 数组在同一 BindingContext 中共享当前位置。普通招式及遗传招式各选择框使用独立数组。 | PK8/PB8/PA8 下逐一设置 4 个不同选择值并检查 |
| 第八世代数据库转换崩溃 | 将 PB8、PA8 等第八世代对象强转 PK8。导入面板和转换路径改读 PKM.StatAlignment。 | 三种格式的 convertpktolpk 性格转换通过；导入面板路径代码检查 |
| 网页队伍导入跨线程访问控件 | Task.Run 内调用 Import，继而 PopulateFields/ReloadSlots。改为后台获取数据、await 后回到 UI 线程导入；屏蔽重复点击；失败不再落入成功提示；窗口关闭后不再更新控件。 | 编译及调用链检查，未连接实际队伍服务做端到端导入 |
| 设置保存失败缺少处理 | 处理 IO/权限异常并显示失败原因；保存成功提供反馈。 | 编译及异常处理路径检查，未更改用户实际配置 |

## 验证方式

```powershell
dotnet build WangPluginPkm/WangPluginPkm.csproj -c Release --no-restore
dotnet run --project tests/PluginRegression -c Release -- --dark
dotnet run --project tests/PluginRegression -c Release -- --light
```

最终构建：0 警告、0 错误。深色 13 项、浅色 11 项检查通过。
直接启动 tests/PluginRegression/bin/Release/net10.0-windows/PluginRegression.exe 可预览深色设置页。

宿主测试使用 tests/Host/bin 下的隔离副本和空白存档，成功加载新插件并打开 RNG 窗口。用户原安装目录中的插件 DLL 未替换，真实存档未修改。

## 构建产物与使用

新版 DLL：WangPluginPkm/bin/Release/net10.0-windows/WangPluginPkm.dll。
关闭正式 PKHeX、备份原插件后，用此 DLL 替换 Plugins/WangPluginPkm.dll，保留原 libz3.dll 和其他资源。
主题跟随 PKHeX；在宿主设置中开启 DarkMode 并重启后生效，不引入插件独立主题开关。

## 范围与后续检查

本次是 UI 与上述明确功能问题的修复，未重做所有窗口布局，也未覆盖全部插件功能。
未完整测试 Google/HOME 等联网服务、AutoMod 合法化、真实存档批量覆写和长时间并行 RNG 搜索。
仍值得单独处理：SuperDataBase 图片异步加载没有选择版本校验，旧请求可能覆盖新选择，且替换图片时未释放旧图像；本轮未修改此路径。
