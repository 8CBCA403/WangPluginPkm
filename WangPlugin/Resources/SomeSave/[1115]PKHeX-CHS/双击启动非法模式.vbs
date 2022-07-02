if CreateObject("Scripting.FileSystemObject").GetFileVersion("PKHeX.exe") = "1.0.0.0" Then
else if CreateObject("Scripting.FileSystemObject").fileExists("PKHeX.Core.dll") Then
    CreateObject("Scripting.FileSystemObject").DeleteFile("PKHeX.Core.dll")
    end if
end if
createObject("wscript.shell").run "%windir%\system32\cmd.exe /c start PKHeX.exe hax",0