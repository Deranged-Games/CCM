REM Made by Construct, member of tao and the construct.
REM E-mail: construct@theconstruct.tk
REM Stop looking at my source code! lol
@echo off
:start
color 1f
cls
echo;
echo;
echo           ษอออออออออออออออออออออออออออออออออออออออออออออออออออออออออป
echo           บ               Constructs DSO Remover 2.1                บ
echo           ฬอออออออออออออออออออออออออออออออออออออออออออออออออออออออออน
echo           บ This DOS batch file will remove those pesky dso's from  บ
echo           บ your C: drive.                                          บ
echo           ฬอออออออออออออออออออออออออออออออออออออออออออออออออออออออออน
echo           บ 1. Remove dso's from the base directory and other known บ
echo           บ    safe locations.                                      บ
echo           บ                                                         บ
echo           บ 2. Remove all dso's from Tribes 2.                      บ
echo           บ    WARNING: Some mods such as Ninjamod for example are  บ
echo           บ    distributed in dso form.                             บ
echo           บ                                                         บ
echo           บ 0. Exit menu system                                     บ
echo           ศอออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ
echo;
echo;
set /p Input=Press enter after selection (0-2): 
if %Input%==0 goto exit
if %Input%==2 goto all
if %Input%==1 goto most

:most
del /s /q c:\dynamix\tribes2\gamedata\base\*.dso
del /s /q c:\dynamix\tribes2\gamedata\construction\*.dso
del /s /q c:\dynamix\tribes2\gamedata\epic\*.dso
cls
echo;
echo;
echo           ษอออออออออออออออออออออออออออออออออออออออออออออออออออออออออป
echo           บ                        Success!                         บ
echo           บ                                                         บ
echo           บ    All dso's from safe locations have been removed.     บ
echo           ศอออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ
echo;
echo;
pause
goto start

:all
del /s /q c:\dynamix\tribes2\gamedata\*.dso
cls
echo;
echo;
echo           ษอออออออออออออออออออออออออออออออออออออออออออออออออออออออออป
echo           บ                        Success!                         บ
echo           บ                                                         บ
echo           บ         All dso's from Tribes 2 have been removed.      บ
echo           ศอออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ
echo;
echo;
pause
goto start

:exit
cls
cd\
cls
echo;
echo;
echo           ษอออออออออออออออออออออออออออออออออออออออออออออออออออออออออป
echo           บ Made by Construct                                       บ
echo           บ                       E-mail: construct@theconstruct.tk บ
echo           ฬอออออออออออออออออออออออออออออออออออออออออออออออออออออออออน
echo           บ  I'm a lonely batch file... please run me again soon.   บ
echo           ศอออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ
echo;
echo;
pause