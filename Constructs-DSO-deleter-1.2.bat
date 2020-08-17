REM Made by Construct, member of tao and the construct.
REM E-mail: construct@charter.net
REM Complex source code huh? lol
REM Designed with Notepad for use in all M$ OS's.
@echo off
color 09
cls
echo;
echo  The humble Tribes 2 dso deleter. Will delete all dso's from
echo  the \dynamix\tribes\gamedata\ directory no matter what drive
echo  it is installed.
echo;
echo  By Construct
echo;
pause

del /s /q \dynamix\tribes2\gamedata\*.dso

cls
echo;
echo  All done... Have fun.
echo;
pause