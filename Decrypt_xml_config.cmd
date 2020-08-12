:: 显示或者隐藏命令 //ECHO [ON | OFF]
@ ECHO OFF

REM 针对加密的 xml 配置文件文件进行解密

:: 获取/设置当前相对路径变量
SET P=%~dp0
ECHO 当前目录 ╞ %P% ╡

:: 获取/设置当前时间变量
SET T=%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%%TIME:~0,2%%TIME:~3,2%%TIME:~6,2%
ECHO 当前时间 ╞ %T% ╡

::设置颜色为 淡蓝色背景色，白色前景色
COLOR 9F

::设置运行窗口标题
TITLE [*解密xml配置文件*]

:: 换行
ECHO.

:: 判断当前目录下是否存在文件 Schoolmate.conn.xml
ECHO 正在检查目录是否存在 XML 加密文件
IF EXIST "Schoolmate.conn.xml" (
    ECHO. && ECHO # 当前目录存在文件 .\Schoolmate.conn.xml && ECHO. || GOTO error
) ELSE (
    ECHO. && ECHO # 当前目录下未发现文件 Schoolmate.conn.xml && GOTO end
)

:: 判断当前目录下是否存在解密程序 Schoolmate.Database.Conn
ECHO 正在检查目录是否存在 XML 加密文件解密程序
IF EXIST "Schoolmate.Database.Conn.exe" (
    ECHO. && ECHO # 当前目录存在解密程序 .\Schoolmate.Database.Conn.exe && ECHO. || GOTO error
) ELSE (
    ECHO. && ECHO # 当前目录下未发现解密程序 Schoolmate.Database.Conn.exe && GOTO end
)

:: 创建目录
ECHO 正在创建目录 && ECHO "%TEMP%\%T%"
MKDIR "%TEMP%\%T%" > nul
IF /I %errorlevel% EQU 0 (
    ECHO. && ECHO # 目录 "%TEMP%\%T%" 创建成功. && ECHO.
) ELSE (
    ECHO. && ECHO # 创建目录 "%TEMP%\%T%" 时出错. && GOTO end
)

:: 复制解密程序到系统临时目录
ECHO 正在复制解密程序到系统临时目录
COPY "Schoolmate.Database.Conn.exe" "%TEMP%\%T%\Schoolmate.Database.Conn.exe" /V /Y || GOTO error
ECHO.

:: 运行命令进行解密
ECHO 正在解密 xml 加密配置文件
"%TEMP%\%T%\Schoolmate.Database.Conn.exe" "Schoolmate.conn.xml" "Decrypt"

::信息提示并作出选择
::暂不使用此句 CHOICE /C YN /T 10 /D Y /M "您好，键入 Y 执行修复，N 退出，如未操作，默认十秒后自动执行修复。
SET /P IS=您好，键入 Y 使用记事本打开解密后的文件，N 退出。(不区分大小写，输入错误将直接退出) 输入后回车：
::判断输入的字符
::暂不使用此句 IF ERRORLEVEL 2 (EXIT) ELSE (GOTO R)
IF /I %IS% EQU Y (ECHO 写入中... ) ELSE (EXIT)

:: 写入到 txt 文本文件
ECHO 解密后的 XML 内容 > "%TEMP%\%T%\Schoolmate.conn.txt"
"%TEMP%\%T%\Schoolmate.Database.Conn.exe" "Schoolmate.conn.xml" "Decrypt" >> "%TEMP%\%T%\Schoolmate.conn.txt"

:: 使用记事本打开
notepad.exe "%TEMP%\%T%\Schoolmate.conn.txt" || GOTO error

:: 跳转至指定标签处执行
GOTO end

:: 错误-标签
:error
ECHO 命令执行中出现未知错误 && GOTO end

:: 结束-标签
:end
echo. && echo 命令执行结束，请按任意键退出。
pause>nul