@echo off
mode con cols=65 lines=20
color 0e
title PKHeX系统设置重置
set /p a=关闭所有 PKHeX 窗口后按任意键继续
echo.
if exist "%LOCALAPPDATA%\ProjectPokémon" (
goto a
) else (
goto b
)
:a
rd /s /q "%LOCALAPPDATA%\ProjectPokémon" >nul
goto b
:b
set /p a=系统设置重置完毕