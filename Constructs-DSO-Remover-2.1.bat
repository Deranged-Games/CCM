REM Made by Construct, member of tao and the construct.
REM E-mail: construct@theconstruct.tk
REM Stop looking at my source code! lol
@echo off
:start
color 1f
cls
echo;
echo;
echo           ���������������������������������������������������������ͻ
echo           �               Constructs DSO Remover 2.1                �
echo           ���������������������������������������������������������͹
echo           � This DOS batch file will remove those pesky dso's from  �
echo           � your C: drive.                                          �
echo           ���������������������������������������������������������͹
echo           � 1. Remove dso's from the base directory and other known �
echo           �    safe locations.                                      �
echo           �                                                         �
echo           � 2. Remove all dso's from Tribes 2.                      �
echo           �    WARNING: Some mods such as Ninjamod for example are  �
echo           �    distributed in dso form.                             �
echo           �                                                         �
echo           � 0. Exit menu system                                     �
echo           ���������������������������������������������������������ͼ
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
echo           ���������������������������������������������������������ͻ
echo           �                        Success!                         �
echo           �                                                         �
echo           �    All dso's from safe locations have been removed.     �
echo           ���������������������������������������������������������ͼ
echo;
echo;
pause
goto start

:all
del /s /q c:\dynamix\tribes2\gamedata\*.dso
cls
echo;
echo;
echo           ���������������������������������������������������������ͻ
echo           �                        Success!                         �
echo           �                                                         �
echo           �         All dso's from Tribes 2 have been removed.      �
echo           ���������������������������������������������������������ͼ
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
echo           ���������������������������������������������������������ͻ
echo           � Made by Construct                                       �
echo           �                       E-mail: construct@theconstruct.tk �
echo           ���������������������������������������������������������͹
echo           �  I'm a lonely batch file... please run me again soon.   �
echo           ���������������������������������������������������������ͼ
echo;
echo;
pause