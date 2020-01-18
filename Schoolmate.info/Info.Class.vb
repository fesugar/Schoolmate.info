Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.Configuration
Imports System.IO
Imports System.IO.Compression

''' <summary>
''' Schoolmate.info 辅助类方法。
''' </summary>
''' <remarks></remarks>
Public Class InfoClass
    '╔═══════════════════════════════╗
    '║使用 DeflateStream 类压缩和解压缩文件目录。                   ║
    '╚═══════════════════════════════╝
    'user sample
    'Dir_DeflateStream("C:\test")
    Friend Function Dir_DeflateStream(ByVal directoryPath As String)
        'Dim directoryPath As String = "C:\test"

        Dim directorySelected As DirectoryInfo = New DirectoryInfo(directoryPath)

        For Each fileToCompress As FileInfo In directorySelected.GetFiles()
            cmp_Compress(fileToCompress)
        Next

        For Each fileToDecompress As FileInfo In directorySelected.GetFiles("*.cmp")
            cmp_Decompress(fileToDecompress)
        Next
    End Function

    Private Sub cmp_Compress(ByVal fileToCompress As FileInfo)
        Using originalFileStream As FileStream = fileToCompress.OpenRead()
            If (File.GetAttributes(fileToCompress.FullName) And FileAttributes.Hidden) _
              <> FileAttributes.Hidden And fileToCompress.Extension <> ".cmp" Then
                Using compressedFileStream As FileStream = File.Create(fileToCompress.FullName + ".cmp")
                    Using compressionStream As Compression.DeflateStream = New Compression.DeflateStream(compressedFileStream, CompressionMode.Compress)
                        originalFileStream.CopyTo(compressionStream)

                        Console.WriteLine("Compressed {0} from {1} to {2} bytes.", _
                          fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString())
                    End Using
                End Using
            End If
        End Using
    End Sub

    Private Sub cmp_Decompress(ByVal fileToDecompress As FileInfo)
        Using originalFileStream As FileStream = fileToDecompress.OpenRead()
            Dim currentFileName As String = fileToDecompress.FullName
            Dim newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length)

            Using decompressedFileStream As FileStream = File.Create(newFileName)
                Using decompressionStream As Compression.DeflateStream = New Compression.DeflateStream(originalFileStream, CompressionMode.Decompress)
                    decompressionStream.CopyTo(decompressedFileStream)

                    Console.WriteLine("Decompressed: {0}", fileToDecompress.Name)
                End Using
            End Using
        End Using
    End Sub

    '╔═══════════════════════════════╗
    '║使用 GZipStream 类压缩和解压缩文件目录。                      ║
    '╚═══════════════════════════════╝
    'user sample
    'Dir_GZipStream("C:\test")
    Friend Function Dir_GZipStream(ByVal directoryPath As String)
        'Dim directoryPath As String = "C:\test"

        Dim directorySelected As DirectoryInfo = New DirectoryInfo(directoryPath)

        For Each fileToCompress As FileInfo In directorySelected.GetFiles()
            gz_Compress(fileToCompress)
        Next

        For Each fileToDecompress As FileInfo In directorySelected.GetFiles("*.gz")
            gz_Decompress(fileToDecompress)
        Next
    End Function

    Private Sub gz_Compress(ByVal fileToCompress As FileInfo)
        Using originalFileStream As FileStream = fileToCompress.OpenRead()
            If (File.GetAttributes(fileToCompress.FullName) And FileAttributes.Hidden) <> FileAttributes.Hidden And fileToCompress.Extension <> ".gz" Then
                Using compressedFileStream As FileStream = File.Create(fileToCompress.FullName + ".gz")
                    Using compressionStream As Compression.GZipStream = New Compression.GZipStream(compressedFileStream, CompressionMode.Compress)
                        originalFileStream.CopyTo(compressionStream)
                        Console.WriteLine("Compressed {0} from {1} to {2} bytes.", _
                                          fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString())
                    End Using
                End Using
            End If
        End Using
    End Sub

    Private Sub gz_Decompress(ByVal fileToDecompress As FileInfo)
        Using originalFileStream As FileStream = fileToDecompress.OpenRead()
            Dim currentFileName As String = fileToDecompress.FullName
            Dim newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length)

            Using decompressedFileStream As FileStream = File.Create(newFileName)
                Using decompressionStream As Compression.GZipStream = New Compression.GZipStream(originalFileStream, CompressionMode.Decompress)
                    decompressionStream.CopyTo(decompressedFileStream)
                    Console.WriteLine("Decompressed: {0}", fileToDecompress.Name)
                End Using
            End Using
        End Using
    End Sub

    '释放内存
    Friend Sub ReduceMemory()
        System.Diagnostics.Process.GetCurrentProcess.MinWorkingSet = New System.IntPtr(5)
    End Sub

    ' 用 GDI+ 呈现图像方法
    Friend Sub GDI(fp As String, Gr As Drawing.Graphics, x As Integer, y As Integer, w As Integer, h As Integer)
        Try

            '创建一个对象，该对象表示要显示的图像。 此对象必须是从 Image 继承的类的成员，如 Bitmap 或 Metafile。
            ' Uses the System.Environment.GetFolderPath to get the path to the 
            ' current user's MyPictures folder.
            Dim myBitmap As New Drawing.Bitmap(fp)
            '创建一个 Graphics 对象来表示要使用的绘图图面。 
            ' Creates a Graphics object that represents the drawing surface of 
            ' Button1.
            Dim g As Drawing.Graphics = Gr
            '调用图形对象的 DrawImage 以呈现图像。 必须同时指定要绘制的图像以及将绘制它的位置的坐标。
            g.DrawImage(myBitmap, x, y, w, h)

        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error - GDI")
            Application.Exit()
        End Try
    End Sub
    '╔═══════════════════════════════╗
    '║公共移动无边框窗体模块                                        ║
    '╚═══════════════════════════════╝
    '声明窗体消息API函数
    'user sample
    'Private Sub Form_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove '鼠标移动事件
    '   Mform(Me.Handle) '拖动窗体
    'End Sub
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (
                                              ByVal hwnd As IntPtr,
                                              ByVal wMsg As Integer,
                                              ByVal wParam As Integer,
                                              ByVal lParam As Integer) As Boolean
    Declare Function ReleaseCapture Lib "user32" Alias "ReleaseCapture" () As Boolean
    Const WM_SYSCOMMAND = &H112
    Const SC_MOVE = &HF010&
    Const HTCAPTION = 2

    ''' <summary>
    ''' 移动由控件绑定到的窗口句柄。
    ''' </summary>
    ''' <param name="hwnd">获取包含控件的窗口句柄。</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' <example> 这个事例演示如何设置 <c>hwnd</c> 进行指定句柄移动。
    ''' <code>
    ''' Dim M_form As New Mform
    ''' M_form(Me.Handle)
    ''' </code>
    ''' </example>
    ''' </remarks>
    Friend Function Mform(ByVal hwnd As IntPtr) As Long
        ReleaseCapture()
        Mform = SendMessage(hwnd, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0)
    End Function

    '╔═══════════════════════════════╗
    '║  The MD5 hash        ║
    '╚═══════════════════════════════╝
    Public Function GetString_md5(ByVal [source] As String)
        'Dim [source] As String = "Hello World!"
        Using md5Hash As MD5 = MD5.Create()

            Dim hash = GetMd5Hash(md5Hash, source)

            Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".")

            'Console.WriteLine("Verifying the hash...")

            'If VerifyMd5Hash(md5Hash, [source], hash) Then
            '    Console.WriteLine("The hashes are the same.")
            'Else
            '    Console.WriteLine("The hashes are not same.")
            'End If
            Return hash
        End Using
    End Function 'Main

    Private Function GetMd5Hash(ByVal md5Hash As Security.Cryptography.MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(System.Text.Encoding.Default.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New System.Text.StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function

    '╔═══════════════════════════════╗
    '║数学计算方式验证码方法                                        ║
    '╚═══════════════════════════════╝
    'user sample
    'Single_InstanceApplication.Run(Form1, New StartupNextInstanceEventHandler(AddressOf Form1.NewInstanceHandler))
    Friend Sub equation_verification_code(ByRef operation As String, ByRef Result As Integer)
        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and 6.
        'Dim value As Integer = CInt(Int((6 * Rnd()) + 1))
        Dim value1 As Integer = CInt(Int(100 * Rnd()))
        Dim value2 As Integer = CInt(Int(100 * Rnd()))
        Dim mark As Integer = CInt(Int((1 * Rnd()) + 1)) 'case mark 0 or 1 or 2 ...
        Select Case mark
            Case 1 ' 加
                Result = value1 + value2
                operation = value1 & "＋" & value2 & "＝"
            Case 2 ' 减
                Result = value1 - value2
                operation = value1 & "－" & value2 & "＝"
            Case 3 ' 乘
                Result = value1 * value2
                operation = value1 & "×" & value2 & "＝"
            Case 4 ' 除
                If value2 = 0 Then Return ' 确保除数不为零
                Result = value1 / value2
                operation = value1 & "÷" & value2 & "＝"
        End Select

    End Sub

    '┇┏━━━━━━━━━━━━━━━━┓
    '┇┃ 确认字符串是有效的电子邮件格式 ┃
    '┇┗━━━━━━━━━━━━━━━━┛

    Friend Function IsValid_Email_address(strIn As String) As Boolean
        ' Return true if strIn is in valid e-mail format.
        Return Text.RegularExpressions.Regex.IsMatch(strIn, _
                "^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + _
                "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")
    End Function

    ' 手机号码
    Friend Function IsValid_Mobile_number(strIn As String) As Boolean
        ' Return true if strIn is in valid phonenumber format.
        Return Text.RegularExpressions.Regex.IsMatch(strIn, _
                "[1][3458]\d{9}$")
    End Function

    ' QQ号码
    Friend Function IsValid_Qq_number(strIn As String) As Boolean
        ' Return true if strIn is in valid qqnumber format.
        Return Text.RegularExpressions.Regex.IsMatch(strIn, _
                "^[1-9]\d{4,9}$")
    End Function

    '╔═══════════════════════════════╗
    '║使用 IsSingleInstance 确定此应用程序是否为单实例应用程序。    ║
    '╚═══════════════════════════════╝
    '需要Microsoft.VisualBasic.ApplicationServices
    'user sample
    'Single_InstanceApplication.Run(Form1, New StartupNextInstanceEventHandler(AddressOf Form1.NewInstanceHandler))
    Public Shared Sub NewInstanceHandler(ByVal sender As Object, ByVal e As StartupNextInstanceEventArgs)
        e.BringToForeground = True
    End Sub

    ' Nested Types
    Friend Class SingleInstanceApplication
        Inherits WindowsFormsApplicationBase
        ' Methods
        Public Sub New()
            MyBase.IsSingleInstance = True
        End Sub

        Public Overloads Sub Run(ByVal f As Form, ByVal startupHandler As StartupNextInstanceEventHandler)
            Dim app As New SingleInstanceApplication
            app.MainForm = f
            AddHandler app.StartupNextInstance, startupHandler
            app.Run(Environment.GetCommandLineArgs)
        End Sub

    End Class

    '╔═══════════════════════════════╗
    '║消息提示窗口                                       ║
    '╚═══════════════════════════════╝
    'user sample
    ' Msg_Show("标题","图标","内容","声音")
    '实例化对话框实例
    Private Dialog As New ShowDialog
    '实例化对computer类的操作
    Private MVDC As New Microsoft.VisualBasic.Devices.Computer
    Friend Sub Msg_Show(ByVal Title, ByVal ICO, ByVal Text, ByVal Sound)
        '设置对话框标题文本
        Dialog.Label_Title.Text = Title
        '设置对话框图标
        Dialog.Panel_ICO.BackgroundImage = ICO
        '设置对话框消息文本
        Dialog.Label_Msg.Text = Text
        '播放系统声音
        MVDC.Audio.PlaySystemSound(Sound)
        ' 窗体显示到最前
        Dialog.TopMost = True
        '显示对话框
        Dialog.ShowDialog()

    End Sub

    ''' <summary>Determines if a password is sufficiently complex.</summary>
    ''' <param name="pwd">Password to validate</param>
    ''' <param name="minLength">Minimum number of password characters.</param>
    ''' <param name="numUpper">Minimum number of uppercase characters.</param>
    ''' <param name="numLower">Minimum number of lowercase characters.</param>
    ''' <param name="numNumbers">Minimum number of numeric characters.</param>
    ''' <param name="numSpecial">Minimum number of special characters.</param>
    ''' <returns>True if the password is sufficiently complex.</returns>
    Friend Function ValidatePassword(ByVal pwd As String,
        Optional ByVal minLength As Integer = 8,
        Optional ByVal numUpper As Integer = 2,
        Optional ByVal numLower As Integer = 2,
        Optional ByVal numNumbers As Integer = 2,
        Optional ByVal numSpecial As Integer = 2) As Boolean

        ' Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above".
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        ' Check the length.
        If Len(pwd) < minLength Then Return False
        ' Check for minimum number of occurrences.
        If upper.Matches(pwd).Count < numUpper Then Return False
        If lower.Matches(pwd).Count < numLower Then Return False
        If number.Matches(pwd).Count < numNumbers Then Return False
        If special.Matches(pwd).Count < numSpecial Then Return False

        ' Passed all checks.
        Return True
    End Function

End Class
