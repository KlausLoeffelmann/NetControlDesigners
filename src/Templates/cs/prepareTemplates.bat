for /d /r "." %%a in (bin\) do if exist "%%a" rmdir "%%a" /s /q
for /d /r "." %%a in (obj\) do if exist "%%a" rmdir "%%a" /s /q

del ".\Templates\*.*" /S /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary\*.*" ".\Templates\CustomTypeEditorTemplate\CustomControlLibrary" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.ClientServerCommunication\*.*" ".\Templates\CustomTypeEditorTemplate\CustomControlLibrary.ClientServerCommunication" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.Design.Client\*.*" ".\Templates\CustomTypeEditorTemplate\CustomControlLibrary.Design.Client" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlLibrary.Design.Server\*.*" ".\Templates\CustomTypeEditorTemplate\CustomControlLibrary.Design.Server" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomControlPackage\*.*" ".\Templates\CustomTypeEditorTemplate\CustomControlPackage" /s /e /c /f /y
xcopy ".\TemplateSolutions\CustomTypeEditor\CustomTypeEditor\*.*" ".\Templates\CustomTypeEditorTemplate\CustomTypeEditor" /s /e /c /f /y
