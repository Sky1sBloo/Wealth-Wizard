@echo off
set /p "Year=Year: "
set /p "Month=Month: "
set /p "Day=Day: "

setlocal
START "" "E:\source\repos\Wealth Wizard\Wealth Wizard\bin\Debug\Wealth Wizard.exe" -setdate %Year% %Month% %Day%