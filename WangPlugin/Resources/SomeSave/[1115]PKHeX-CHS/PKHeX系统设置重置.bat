@echo off
mode con cols=65 lines=20
color 0e
title PKHeXϵͳ��������
set /p a=�ر����� PKHeX ���ں����������
echo.
if exist "%LOCALAPPDATA%\ProjectPok��mon" (
goto a
) else (
goto b
)
:a
rd /s /q "%LOCALAPPDATA%\ProjectPok��mon" >nul
goto b
:b
set /p a=ϵͳ�����������