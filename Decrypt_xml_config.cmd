:: ��ʾ������������ //ECHO [ON | OFF]
@ ECHO OFF

REM ��Լ��ܵ� xml �����ļ��ļ����н���

:: ��ȡ/���õ�ǰ���·������
SET P=%~dp0
ECHO ��ǰĿ¼ �b %P% �e

:: ��ȡ/���õ�ǰʱ�����
SET T=%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%%TIME:~0,2%%TIME:~3,2%%TIME:~6,2%
ECHO ��ǰʱ�� �b %T% �e

::������ɫΪ ����ɫ����ɫ����ɫǰ��ɫ
COLOR 9F

::�������д��ڱ���
TITLE [*����xml�����ļ�*]

:: ����
ECHO.

:: �жϵ�ǰĿ¼���Ƿ�����ļ� Schoolmate.conn.xml
ECHO ���ڼ��Ŀ¼�Ƿ���� XML �����ļ�
IF EXIST "Schoolmate.conn.xml" (
    ECHO. && ECHO # ��ǰĿ¼�����ļ� .\Schoolmate.conn.xml && ECHO. || GOTO error
) ELSE (
    ECHO. && ECHO # ��ǰĿ¼��δ�����ļ� Schoolmate.conn.xml && GOTO end
)

:: �жϵ�ǰĿ¼���Ƿ���ڽ��ܳ��� Schoolmate.Database.Conn
ECHO ���ڼ��Ŀ¼�Ƿ���� XML �����ļ����ܳ���
IF EXIST "Schoolmate.Database.Conn.exe" (
    ECHO. && ECHO # ��ǰĿ¼���ڽ��ܳ��� .\Schoolmate.Database.Conn.exe && ECHO. || GOTO error
) ELSE (
    ECHO. && ECHO # ��ǰĿ¼��δ���ֽ��ܳ��� Schoolmate.Database.Conn.exe && GOTO end
)

:: ����Ŀ¼
ECHO ���ڴ���Ŀ¼ && ECHO "%TEMP%\%T%"
MKDIR "%TEMP%\%T%" > nul
IF /I %errorlevel% EQU 0 (
    ECHO. && ECHO # Ŀ¼ "%TEMP%\%T%" �����ɹ�. && ECHO.
) ELSE (
    ECHO. && ECHO # ����Ŀ¼ "%TEMP%\%T%" ʱ����. && GOTO end
)

:: ���ƽ��ܳ���ϵͳ��ʱĿ¼
ECHO ���ڸ��ƽ��ܳ���ϵͳ��ʱĿ¼
COPY "Schoolmate.Database.Conn.exe" "%TEMP%\%T%\Schoolmate.Database.Conn.exe" /V /Y || GOTO error
ECHO.

:: ����������н���
ECHO ���ڽ��� xml ���������ļ�
"%TEMP%\%T%\Schoolmate.Database.Conn.exe" "Schoolmate.conn.xml" "Decrypt"

::��Ϣ��ʾ������ѡ��
::�ݲ�ʹ�ô˾� CHOICE /C YN /T 10 /D Y /M "���ã����� Y ִ���޸���N �˳�����δ������Ĭ��ʮ����Զ�ִ���޸���
SET /P IS=���ã����� Y ʹ�ü��±��򿪽��ܺ���ļ���N �˳���(�����ִ�Сд���������ֱ���˳�) �����س���
::�ж�������ַ�
::�ݲ�ʹ�ô˾� IF ERRORLEVEL 2 (EXIT) ELSE (GOTO R)
IF /I %IS% EQU Y (ECHO д����... ) ELSE (EXIT)

:: д�뵽 txt �ı��ļ�
ECHO ���ܺ�� XML ���� > "%TEMP%\%T%\Schoolmate.conn.txt"
"%TEMP%\%T%\Schoolmate.Database.Conn.exe" "Schoolmate.conn.xml" "Decrypt" >> "%TEMP%\%T%\Schoolmate.conn.txt"

:: ʹ�ü��±���
notepad.exe "%TEMP%\%T%\Schoolmate.conn.txt" || GOTO error

:: ��ת��ָ����ǩ��ִ��
GOTO end

:: ����-��ǩ
:error
ECHO ����ִ���г���δ֪���� && GOTO end

:: ����-��ǩ
:end
echo. && echo ����ִ�н������밴������˳���
pause>nul