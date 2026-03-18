echo off
color 0A
title FootballMaps Gelistirme Sunucusu
echo =======================================================
echo FootballMaps Projesi Baslatiliyor...
echo =======================================================
echo.
echo Geliştirme modu aktif: Kodda veya HTML/CSS dosyalarında 
echo yaptiginiz degisiklikler kaydedildiginde tarayici 
echo otomatik olarak yenilenecektir.
echo.
echo Uygulama tarayicida aciliyor...
echo.


dotnet watch run

pause
