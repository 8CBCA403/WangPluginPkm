# Plugin regression checks

Requires Windows and the .NET 10 SDK. Uses disposable blank saves and in-process WinForms controls; no real save files or remote services are accessed by the checks.

```powershell
dotnet run --project tests/PluginRegression -c Release -- --dark
dotnet run --project tests/PluginRegression -c Release -- --light
```

Checks Chinese/English localization coverage, independent move selection, PK8/PB8/PA8 stat alignment conversion, host theme inheritance, semantic colors, and dynamically added controls. A failing assertion exits nonzero.

Launch without arguments to preview the settings window in dark mode, or use `--preview --light` for a light preview. Close the preview before rebuilding to release the DLL file lock.
