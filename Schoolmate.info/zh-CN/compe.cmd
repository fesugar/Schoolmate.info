:: .NET 4.0

echo off

SET Tools_path="C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools"

echo ����Ϊ.resources�ļ�ͨ�������������е� ��Դ�ļ�������(resgen.exe)

::C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools
%Tools_path%\resgen.exe Language.resources.zh-CN.resx


timeout 3

echo .resources�ļ�Ƕ�뵽��̬���ӿ���Դ����������е� ����������(al.exe)

::C:\Windows\Microsoft.NET\Framework\v4.0.30319
%Tools_path%\al.exe /t:lib /embed:Language.resources.zh-CN.resources /culture:zh-CN /out:Schoolmate.info.resources.dll

echo completely !

pause
