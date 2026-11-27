# WangPluginPkm · 超王插件PKM

WangPluginPkm 是用于 Windows 版 PKHeX 的宝可梦存档编辑插件。你可以在同一个存档里研究一只宝可梦的随机数（RNG）、按地区图鉴整理盒子，或在「超级数据库」中筛选一批宝可梦文件，统一调整招式、等级和努力值。

[English](README.en.md) · [使用教程 Wiki](https://github.com/8CBCA403/WangPluginPkm/wiki) · [历史发布包](https://github.com/8CBCA403/WangPluginPkm/releases)

## 选择版本

| 想用哪个版本 | 获取方式 | 配套 PKHeX |
| --- | --- | --- |
| 当前源码（`main`） | 按下方步骤编译插件 | [PKHeX 26.10.18](https://github.com/kwsch/PKHeX/releases/tag/26.10.18)，源码引用 PKHeX.Core 26.10.18 |
| 历史整合包 v1.7.1 | 从 [v1.7.1 发布页](https://github.com/8CBCA403/WangPluginPkm/releases/tag/v1.7.1) 下载并解压 `PKHeX20241109+WangPlugins.zip` | 直接运行整合包自带的 PKHeX |

## 编译和安装当前源码

1. 在 Windows 上安装 [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)，下载或克隆本仓库。在仓库根目录运行下面的命令。

   ```powershell
   dotnet build WangPluginPkm/WangPluginPkm.csproj -c Release
   ```

2. 关闭 PKHeX。从 `WangPluginPkm/bin/Release/net10.0-windows/` 复制两个 DLL 到 `PKHeX.exe` 旁的 `plugins` 文件夹。首次安装时创建该文件夹，升级时替换同名文件。

   ```text
   PKHeX.exe
   plugins/
     WangPluginPkm.dll
     libz3.dll
   ```

3. 启动 PKHeX，打开 **工具 → 超王插件PKM → 关于和设置** 确认加载成功。英文界面对应 **Tools → Wang PKM Plugin → About and Settings**。插件跟随宿主的语言和深浅色设置，提供简体中文和英文界面。

## 按任务找工具

| 想做什么 | 菜单入口 | 使用提示 |
| --- | --- | --- |
| 查找种子、从 Seed 计算 IV、用 IV 或 PID 反推 | RNG面板 | 先打开目标宝可梦所属世代的存档，再把宝可梦放到 PKHeX 左侧编辑面板。 |
| 制作图鉴、整理盒子 | 图鉴制作器、全部箱子排序 | 图鉴制作器可生成形态，排序菜单会根据存档提供可用的地区图鉴顺序。 |
| 批量修改一组文件 | 超级数据库 | 可以按种类或文件名筛选，并选择本次要修改的字段，例如等级、招式或努力值。建议先在副本上确认结果。 |
| 处理闪光、蛋或配信数据 | 闪光器、变蛋器、派送器 | 可用操作取决于当前存档和宝可梦格式。 |
| 导入对战队伍、查看赛季排名 | 对战王 | 网页队伍与 HOME 排名依赖对应的在线服务。 |

数据库图片可在「关于和设置」里配置地址前缀。插件在前缀后拼接四位全国图鉴编号和 `.png`，例如皮卡丘使用 `0025.png`。留空时显示默认图。

## 开发与反馈

菜单入口在 [Plugins](WangPluginPkm/Plugins)，窗体及事件处理在 [GUI](WangPluginPkm/GUI)。修改后可运行 [Windows 回归检查](tests/PluginRegression/README.md)。测试使用空白存档。

```powershell
dotnet run --project tests/PluginRegression -c Release -- --dark
dotnet run --project tests/PluginRegression -c Release -- --light --zh
```

遇到问题时，请在 [Issues](https://github.com/8CBCA403/WangPluginPkm/issues) 附上 PKHeX 版本、插件来源（发布标签或提交号）、游戏版本、触发问题的菜单和复现步骤。提交截图或日志前，请移除 Cookie、API 密钥及其他凭据。

本项目采用 [GNU AGPL v3](LICENSE)。历代 RNG 研究、插件实现、教程和测试的贡献者见[致谢名单](CREDITS.md)。
