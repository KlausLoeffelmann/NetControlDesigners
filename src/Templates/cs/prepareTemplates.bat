for /d /r "." %%a in (bin\) do if exist "%%a" rmdir "%%a" /s /q
for /d /r "." %%a in (obj\) do if exist "%%a" rmdir "%%a" /s /q

del ".\Templates\*.*" /S /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary\*.*" ".\Templates\CustomTypeEditor\CustomControlLibrary" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.ClientServerCommunication\*.*" ".\Templates\CustomTypeEditor\CustomControlLibrary.ClientServerCommunication" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.Design.Client\*.*" ".\Templates\CustomTypeEditor\CustomControlLibrary.Design.Client" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.Design.Server\*.*" ".\Templates\CustomTypeEditor\CustomControlLibrary.Design.Server" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlPackage\*.*" ".\Templates\CustomTypeEditor\CustomControlPackage" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomTypeEditor\*.*" ".\Templates\CustomTypeEditor\CustomTypeEditor" /s /e /c /f /y
