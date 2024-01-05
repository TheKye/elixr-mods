@echo off
::Where you have the eco client project installed
set installfolder="..\EM Unity\Built Unity Assets"
set emframework="..\EM Framework\bin\10\Framework\net7.0"
@echo on
rmdir "Built Unity Assets"
rmdir "EM Framework"
mklink /j "Built Unity Assets" %installfolder%
mklink /j "EM Framework" %emframework%
pause
exit 0