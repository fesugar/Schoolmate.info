Imports System.Windows.Forms
Imports System.Timers

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public NotInheritable Class Background
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Background
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(43, 34)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Background"
        Me.Opacity = 0.0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)

    End Sub

    ' Private Shared aTimer As System.Timers.Timer

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Icon = Nothing '清空窗体显示的ICO图标
        Run()

        '' Create a timer with a ten second interval.
        'aTimer = New System.Timers.Timer(10000)

        '' Hook up the Elapsed event for the timer.
        'AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        '' Set the Interval to 2 seconds (2000 milliseconds).
        'aTimer.Interval = 2000
        'aTimer.Enabled = True  '启用

        '时间线程

        Dim newThread As New Threading.Timer(AddressOf TimerProc)
        newThread.Change(1000, 3000)

    End Sub


    Private Sub Run()
        Try

            ' 声明密码变量
            Dim PWD As String = Nothing
            If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
                MessageBox.Show(rm.GetString("Module1.Err_MSG_Text"), rm.GetString("ERR_MSG_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If
            Dim state As String = Nothing  ' 声明整形变量获取状态

            ' 操作数据库
            Select Case _
                db.Access_db(
                   Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
                    "Microsoft.Jet.Oledb.4.0", PWD,
                    "SELECT Info_admin FROM [SYS] WHERE ID=1",
                    1, state)

                Case "InvalidOperationException"
                    '调用消息弹框
                    'Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                    MessageBox.Show(rm.GetString("InvalidOperationException"), rm.GetString("ERR_MSG_TITLE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End
                Case "OleDbException"
                    '调用消息弹框
                    'Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                    MessageBox.Show(rm.GetString("OleDbException"), rm.GetString("ERR_MSG_TITLE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End

            End Select

            ' 启用XP视觉样式
            Windows.Forms.Application.EnableVisualStyles()
            ' 检测用户是否存在
            If state = "False" Then ' 未注册管理员状态
                Dim _register As New Register
                _register.Show()
            ElseIf state = "True" Then ' 注册管理员状态
                Dim _login As New Login
                _login.Show()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description, rm.GetString("ERR_MSG_TITLE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Application.Exit()
        End Try
    End Sub
    Private Shared Sub TimerProc()
        Info_Class.ReduceMemory()
        GC.Collect()
        Console.WriteLine("The Elapsed event was raised at {0}", Now.ToString)
    End Sub
End Class
