Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Resources
Imports System.Security.Cryptography
Imports System.Xml
Imports System.Data.OleDb

<Assembly: AssemblyVersionAttribute("4.3.4.0")> 
<Assembly: AssemblyProduct("Schoolmate.info .NET")> 
<Assembly: AssemblyDescription("Schoolmate.info .NET Framework 4")> 
<Assembly: AssemblyTitle("Schoolmate - Info .NET")> 
<Assembly: AssemblyCopyright("Copyright © 2014-2015 T-Sugar All rights reserved.")> 
<Assembly: Runtime.CompilerServices.CompilationRelaxationsAttribute(8)> 
<Assembly: NeutralResourcesLanguage("zh-CN", UltimateResourceFallbackLocation.Satellite)>                    '命令行
'<Assembly: NeutralResourcesLanguageAttribute("zh-CN")> 

'桌面

Module Module_Schoolmate

    ' 声明 Schoolmate.Forms 类中的方法
    'Public Info_Forms_menu As New Schoolmate.Forms.menu_UserControl
    ' 实例化数据库操作
    Friend db As New Schoolmate.Database.Database
    ' 实例化密码方法
    Friend Database_Conn As New Schoolmate.Database.Conn.Conn
    ' 实例化当前项目的类操作
    Friend Info_Class As New Schoolmate.info.InfoClass
    ' 软件运行目录
    Friend Application_StartupPath As String = Application.StartupPath

    ' 实例化窗体
    ' Public Login_Form As New Login
    '  Public Main_Form As New Main
    '' 实例化用户控件
    'Public login_User As New login_UserControl
    'Public register_User As New register_UserControl
    'Public menu_User As New menu_UserControl
    'Public query_info As New query_info_UserControl
    'Public info_user As New _info_UserControl
    'Public modification_info As New modification_info_UserControl
    'Public delete_info As New delete_info_UserControl
    'Public setting As New setting_UserControl
    'Public _info_1 As New _info_UserControl1
    'Public _info_2 As New _info_UserControl2
    'Public _info_3 As New _info_UserControl3
    'Public _info_4 As New _info_UserControl4
    'Public _info_5 As New _info_UserControl5
    ' 实例化外部语言资源文件
    Friend rm As New ResourceManager("Language.resources", GetType(Module_Schoolmate).Assembly)
    'Dim greeting As String = rm.GetString("Greeting")

    <STAThread()> _
    Public Sub Main()

        ' Application_StartupPath 启动目录路径赋值
        If Not Application_StartupPath.Trim().EndsWith("\") Then Application_StartupPath += "\"
        'Application_StartupPath += ""
        'System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("zh-CN")
        ' 探测指定位置文件是否存在
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat") = True _
            And Microsoft.VisualBasic.FileIO.FileSystem.FileExists(Application_StartupPath + "Schoolmate.conn.xml") _
            = True Then
            Console.WriteLine("file is found, so pass.")
            ' 数据库和配置文件都不存在
        ElseIf Microsoft.VisualBasic.FileIO.FileSystem.FileExists(Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat") = False _
        And Microsoft.VisualBasic.FileIO.FileSystem.FileExists(Application_StartupPath + "Schoolmate.conn.xml") _
        = False Then
            Console.WriteLine("file is not found .")
            Dim t As New Threading.Thread(AddressOf file_dispos)
            t.Start()
            Console.WriteLine("Main thread: Call Join(), to wait until file_dispos ends.")
            t.Join()

        Else '其他情况
            Console.WriteLine("other..")
            'Throw New System.Exception("An exception has occurred.")
        End If

        '创建线程对象
        'Dim Nt1 As Threading.Thread
        Dim Nt1 As New Threading.Thread(AddressOf Run)
        '执行线程
        Nt1.Start()
        ' 调用方法
        ' Rum()

    End Sub

    ' 继续运行
    Private Sub Run()
      
        ' 实例化单实例过程
        Dim Single_InstanceApplication As New InfoClass.SingleInstanceApplication
        ' 实例化窗体
        'Dim bck As New Background
        ' 启用XP视觉样式
        Windows.Forms.Application.EnableVisualStyles()

        ' Windows.Forms.Application.Run(Login_Form)
        ' 运行显示窗体
        Single_InstanceApplication.Run(New Background, New StartupNextInstanceEventHandler(AddressOf InfoClass.NewInstanceHandler))

    End Sub

    ' 释放文件
    Private Sub file_dispos()
        Try
            ' 解压缩模版数据库文件并以当前时间创建目录存放
            Info_Class.Dir_DeflateStream(Application_StartupPath + "DB\Templates")
            ' 判断是否解压文件，然后移动到创建的目录里
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(Application_StartupPath + "DB\Templates\66ed5fcaf39b2fa003968f9477204ae4.dat") = True Then
                'Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(App_StartupPath + "DB\" + StrName)
                Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(Application_StartupPath + "DB\Templates\66ed5fcaf39b2fa003968f9477204ae4.dat",
                                                                 Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
                                                                  FileIO.UIOption.AllDialogs,
                                                                  FileIO.UICancelOption.ThrowException)
            Else
                'Throw New System.Exception("An exception has occurred.")
                Throw New IO.FileNotFoundException
            End If

            Dim computer As New Microsoft.VisualBasic.Devices.ServerComputer
            ' 设立密码
            Dim pass As String = Info_Class.GetString_md5(computer.Info.AvailablePhysicalMemory.ToString +
                                                          computer.Info.AvailableVirtualMemory.ToString +
                                                          computer.Info.InstalledUICulture.ToString +
                                                          computer.Info.OSFullName +
                                                          computer.Info.OSPlatform +
                                                          computer.Info.OSVersion +
                                                          computer.Info.TotalPhysicalMemory.ToString +
                                                          computer.Info.TotalVirtualMemory.ToString +
                                                          Now.ToString)

            ' 连接数据库获取数据
            Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat" + ";Mode=Share Deny Read|Share Deny Write;Persist Security Info=False;")
                Dim command As New OleDbCommand("Alter Database password " + Mid(pass, 1, 16) + " null", connection)
                command.CommandTimeout = 20

                connection.Open()

                Dim reader As OleDbDataReader = command.ExecuteReader()
                While reader.Read()

                End While
                reader.Close()
            End Using

            'XML 配置文件

            ' Create an XmlDocument object.
            Dim xmlDoc As New XmlDocument()
            ' Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = True
            xmlDoc.LoadXml(
                "<?xml version=""1.0"" encoding=""utf-8""?>" + vbNewLine & _
                "<Schoolmate>" + vbNewLine & _
                "  <Conn>" + vbNewLine & _
                "    <PWD value=""" + Mid(pass, 1, 16) + """ />" + vbNewLine & _
                "  </Conn>" + vbNewLine & _
                "</Schoolmate>"
                           )

            ' Create a new CspParameters object to specify
            ' a key container.
            Dim cspParams As New CspParameters()
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY"
            ' Create a new RSA key and save it in the container.  This key will encrypt
            ' a symmetric key, which will then be encryped in the XML document.
            Dim rsaKey As New RSACryptoServiceProvider(cspParams)

            ' Encrypt the "creditcard" element.
            Database.Conn.Conn.Encrypt(xmlDoc, "Conn", "EncryptedElement1", rsaKey, "rsaKey")
            ' Save the XML document.
            xmlDoc.Save(Application_StartupPath & "Schoolmate.conn.xml")

        Catch ex As System.UnauthorizedAccessException '路径拒绝访问异常
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(Err.Description, rm.GetString("ERR_MSG_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub
End Module
