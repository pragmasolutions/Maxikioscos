@echo off
tasklist /nh /fi "imagename eq MaxiKioscos.Winforms.exe" | find /i "MaxiKioscos.Winforms.exe" >nul && (
echo MaxiKioscos.Winforms.exe is running
) || (
rmdir /s /q %LocalAppData%\Apps\2.0
)
