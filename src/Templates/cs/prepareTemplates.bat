for /d /r ".\TemplateSolutions" %%a in (bin) do if exist "%%a" rmdir "%%a" /s /q
for /d /r ".\TemplateSolutions" %%a in (obj) do if exist "%%a" rmdir "%%a" /s /q

rmdir ".\Templates\Templates\CSTypeEditor\CustomControlLibrary" /s /q
rmdir ".\Templates\Templates\CSTypeEditor\CustomControlLibrary.Protocol" /s /q
rmdir ".\Templates\Templates\CSTypeEditor\CustomControlLibrary.Design.Client" /s /q
rmdir ".\Templates\Templates\CSTypeEditor\CustomControlLibrary.Design.Server" /s /q
rmdir ".\Templates\Templates\CSTypeEditor\CustomControlPackage" /s /q
rmdir ".\Templates\Templates\CSTypeEditor\CustomTypeEditor" /s /q

xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary\*.*" ".\Templates\Templates\CSTypeEditor\CustomControlLibrary" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.Protocol\*.*" ".\Templates\Templates\CSTypeEditor\CustomControlLibrary.Protocol" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.Design.Client\*.*" ".\Templates\Templates\CSTypeEditor\CustomControlLibrary.Design.Client" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.Design.Server\*.*" ".\Templates\Templates\CSTypeEditor\CustomControlLibrary.Design.Server" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlPackage\*.*" ".\Templates\Templates\CSTypeEditor\CustomControlPackage" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomTypeEditor\*.*" ".\Templates\Templates\CSTypeEditor\CustomTypeEditor" /s /e /c /f /y /i

