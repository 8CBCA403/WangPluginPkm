# WangPluginPkm

WangPluginPkm adds Pokémon RNG research, regional Pokédex sorting and batch file editing to PKHeX on Windows. Load a save to work with the Pokémon in the editor, organize its boxes, or open the Super Database to filter and edit Pokémon files.

[简体中文](README.md) · [Project Wiki](https://github.com/8CBCA403/WangPluginPkm/wiki) · [Releases](https://github.com/8CBCA403/WangPluginPkm/releases)

## Choose a version

| Version | Installation |
| --- | --- |
| Current source (`main`) | Build the plugin for [PKHeX 26.10.18](https://github.com/kwsch/PKHeX/releases/tag/26.10.18). The project references PKHeX.Core 26.10.18. |
| Historical bundle (v1.7.1) | Download `PKHeX20241109+WangPlugins.zip` from [release v1.7.1](https://github.com/8CBCA403/WangPluginPkm/releases/tag/v1.7.1), extract it, and launch the included PKHeX. |

## Build and install the current source

1. Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) on Windows. Clone or download this repository and run the build from its root.

   ```powershell
   dotnet build WangPluginPkm/WangPluginPkm.csproj -c Release
   ```

2. Close PKHeX. Copy `WangPluginPkm.dll` and `libz3.dll` from `WangPluginPkm/bin/Release/net10.0-windows/` into the `plugins` directory beside `PKHeX.exe`. Create the directory on first install or replace both files when upgrading.
3. Start PKHeX and open **Tools → Wang PKM Plugin → About and Settings** to confirm installation. The plugin follows the host theme and displays its interface in Simplified Chinese or English.

## Using the tools

| Task | Where to start |
| --- | --- |
| Search RNG seeds or derive IVs from a seed | Open a save from the target Pokémon’s generation, place the Pokémon in PKHeX’s editor panel, and open **RNG Tools**. |
| Build a Pokédex or organize boxes | Use **Dex Builder** to generate forms, or **All Boxes Sort** to choose a regional Pokédex order supported by the save. |
| Edit Pokémon files in bulk | In **Super Database**, filter by species or filename and select fields to change, such as level, moves or EVs. Try the edit on copies first. |
| Work with shinies, eggs or distributions | Open **Shiny Maker**, **Egg Generator** or **Distribution Tools**. Available operations depend on the save and Pokémon format. |
| Import teams or look up season rankings | Open **Battle Tools**. Online imports and HOME rankings depend on their respective services. |

For species previews in the database, set the Pokémon image URL prefix in **About and Settings**. The plugin appends the four-digit species number and `.png` (for example, `0025.png` for Pikachu). An empty prefix displays the default image.

## Development and feedback

Menu entry points live in [Plugins](WangPluginPkm/Plugins) and WinForms code in [GUI](WangPluginPkm/GUI). Run the [Windows regression checks](tests/PluginRegression/README.md) with disposable blank saves.

```powershell
dotnet run --project tests/PluginRegression -c Release -- --dark
dotnet run --project tests/PluginRegression -c Release -- --light --zh
```

When opening an [issue](https://github.com/8CBCA403/WangPluginPkm/issues), include your PKHeX version, plugin tag or commit, game version, menu action and steps to reproduce. Remove cookies and API keys from logs and screenshots.

Licensed under the [GNU AGPL v3](LICENSE). See the [credits](CREDITS.md) for the contributors, tools and research behind the project.
