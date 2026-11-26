# WangPlugin
![License](https://img.shields.io/badge/License-GPLv3-blue.svg)


WangPluginPkm adds RNG tools, Pokédex building, batch editing, and other utilities to PKHeX.

WangPluginPkm 为 PKHeX 提供 RNG 工具、图鉴制作、批量编辑等功能。详细用法见[项目 Wiki](https://github.com/8CBCA403/WangPluginPkm/wiki)。

## Compatibility and installation / 兼容性与安装

This source version targets [PKHeX 26.10.18](https://github.com/kwsch/PKHeX/releases/tag/26.10.18) and uses [PKHeX.Core 26.10.18](https://www.nuget.org/packages/PKHeX.Core/26.10.18). Download PKHeX from [Project Pokémon](https://projectpokemon.org/home/files/file/1-pkhex/). Close PKHeX, place the matching build's `WangPluginPkm.dll` and `libz3.dll` in the `plugins` folder next to `PKHeX.exe`, then restart PKHeX and open the plugin from **Tools**.

当前源码适配 PKHeX 26.10.18，依赖 PKHeX.Core 26.10.18。退出 PKHeX 后，将对应构建的 `WangPluginPkm.dll` 和 `libz3.dll` 放入 `PKHeX.exe` 同目录下的 `plugins` 文件夹。重新启动后，从「工具」菜单打开插件。已有旧版插件时，请替换同名 DLL。

## Build from source / 从源码编译

Use the .NET 10 SDK on Windows. The Release build places both plugin DLLs in `WangPluginPkm/bin/Release/net10.0-windows/`.

请在 Windows 上使用 .NET 10 SDK 编译。Release 构建所需的两个 DLL 都在上述输出目录中。

```powershell
dotnet build WangPluginPkm/WangPluginPkm.csproj -c Release
```

## Language and theme / 语言与主题

The plugin follows PKHeX's selected language and color mode. Simplified Chinese and English are supported; other PKHeX languages currently fall back to English.

插件会跟随 PKHeX 当前选择的语言和深浅色模式。目前完整支持简体中文和英文，其他语言暂时回退到英文。
 
 Credits (in no particular order)
- Manu098vm 
(https://github.com/Manu098vm/SVResearches)
(https://github.com/Manu098vm/Tera-Finder)
- PiousVenom 
(https://github.com/PiousVenom/PKHeX-Plugin-RandomDates)
- foohyfooh 
(https://github.com/foohyfooh/PKHeXInsertionPlugin)
 - Wang.Song BDSPRoaming
(https://github.com/g0dw5)
- Caleeeeeeeeeeeee PIDFinder 猎游者
(https://github.com/ca1e/PIDFinder)
- Easy World
(https://github.com/easyworld)
- CScorpion-h
(https://github.com/CScorpion-h)
- 感谢污教授编写的教程wiki
- foohyfooh PKHeXSortingPlugin
(https://github.com/foohyfooh/PKHeXSortingPlugin)
- Leanny PKHeXSortingPlugin
(https://github.com/Leanny/PKHeX_Raid_Plugin)
- Bill Young, Mike Suleski, and Andrew Ringer for [RNGReporter]
(https://github.com/Slashmolder/RNGReporter)
(https://github.com/Slashmolder/lrng)
- chiizu for PPRNG
(https://github.com/chiizu/PPRNG)
- wwwwwwzx for 3DSRNG Tool
(https://github.com/wwwwwwzx/3DSRNGTool)
- kwsch for providing the IPlugin interface in PKHeX.
(https://github.com/kwsch) 
- berichan for adding USB-Botbase support to LiveHeX.
(https://github.com/berichan) 
- soopercool101 for many improvements to Smogon StrategyDex imports and various other fixes.
(https://github.com/soopercool101) 
- Lusamine for all the help with stress testing the code with wacky sets!
(https://github.com/Lusamine) 
- ReignOfComputer for the sets found in [RoCs-PC]
(https://github.com/ReignOfComputer)
which are used for unit testing.
(https://github.com/ReignOfComputer/RoCs-PC) 
- TORNADO for help with test cases.
- Rino6357 and crzyc for initial help with the Wiki.
(https://github.com/Rino6357)
(https://github.com/crzyc) 
- hp3721 for help with adding localization based on PKHeX's implementation.
(https://github.com/hp3721) 
- Bappsack for his help on Discord in voice chats!
(https://github.com/Bappsack) 
- chenzw95  for help with integration.
(https://github.com/chenzw95)
- BernardoGiordano for many ideas on improving speed.
(https://github.com/BernardoGiordano) 
- olliz0r for developing and maintaining sys-botbase as well which is necessary for LiveHeX to work.
(https://github.com/olliz0r) 
- SteveCookTU and [olliz0r] for [LedyLib] from which a lot of the NTR processing code is liberally referenced.
(https://github.com/olliz0r)
(https://github.com/SteveCookTU)
(https://github.com/olliz0r/Ledybot/tree/master/LedyLib)
- fishguy6564 for creating USB-Botbase (by extending sys-botbase).
(https://github.com/fishguy6564) 
- FlatIcon for their icons. Author credits (Those Icons, Pixel perfect).
(https://www.flaticon.com/)
- Project Pokémon for their Mystery Gift Event Gallery.
(https://github.com/projectpokemon/) 


- The PokemonRNG team for various contributions and research (zaksabeast, EzPzstreamz, Shiny_Sylveon, Vlad, Feder)
- Other great people for various help and research (OmegaDonut, Bond697, Kaphotics, SciresM, Zari, amab, Marin, Lean, etc)
- And all the countless users who have helped improve this project with ideas and suggestions!


