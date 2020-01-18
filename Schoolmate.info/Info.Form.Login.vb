Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Login
    Inherits System.Windows.Forms.Form

    Private ver_value As Integer = Nothing
    Friend WithEvents Panel_Min As System.Windows.Forms.Panel
    Friend WithEvents Panel_Close As System.Windows.Forms.Panel ' 验证码值

    '用作鼠标坐标点
    Private Mouse_Point As Drawing.Point

    '窗体成功关闭事件
    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    '[鼠标按下事件]
    Private Sub Register_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Mouse_Point = New Drawing.Point(e.X, e.Y)
    End Sub

    '[鼠标移动事件]
    Private Sub Register_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        '按住鼠标左右键均可拖动窗体
        If e.Button = MouseButtons.Left Then 'Or e.Button = MouseButtons.Right Then
            Dim MouseMo As Drawing.Point = sender.findform().MousePosition
            '获得鼠标偏移量
            MouseMo.Offset(-Mouse_Point.X, -Mouse_Point.Y)
            '设置窗体随鼠标一起移动
            sender.findform().Location = MouseMo
        End If
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' 指定控件的样式和行为。
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)

        ' 验证码方法
        verification_code()
        Me.Icon = rm.GetObject("log")
        Me.BackgroundImage = rm.GetObject("Info.Form.Login")
        Panel_Min.BackgroundImage = rm.GetObject("minsize_normal")
        Panel_Close.BackgroundImage = rm.GetObject("close_normal")

        ' 工具提示文本
        Dim toolstip As New ToolTip
        toolstip.SetToolTip(Panel_Min, "最小化")
        toolstip.SetToolTip(Panel_Close, "关闭")
        toolstip.SetToolTip(Button_Ok, "登录")

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Label_Result As System.Windows.Forms.Label
    Friend WithEvents Label_Check_Tip As System.Windows.Forms.Label
    Friend WithEvents Label_Password_Tip As System.Windows.Forms.Label
    Friend WithEvents Label_Username_Tip As System.Windows.Forms.Label
    Friend WithEvents Button_Ok As System.Windows.Forms.Button
    Friend WithEvents LinkLabel_change As System.Windows.Forms.LinkLabel
    Friend WithEvents Label_Check As System.Windows.Forms.Label
    Friend WithEvents Label_Password As System.Windows.Forms.Label
    Friend WithEvents Label_Username As System.Windows.Forms.Label
    Friend WithEvents TextBox_Check As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Password As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Username As System.Windows.Forms.TextBox
    Friend WithEvents Label_Tip As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label_Result = New System.Windows.Forms.Label()
        Me.Label_Check_Tip = New System.Windows.Forms.Label()
        Me.Label_Password_Tip = New System.Windows.Forms.Label()
        Me.Label_Username_Tip = New System.Windows.Forms.Label()
        Me.Button_Ok = New System.Windows.Forms.Button()
        Me.LinkLabel_change = New System.Windows.Forms.LinkLabel()
        Me.Label_Check = New System.Windows.Forms.Label()
        Me.Label_Password = New System.Windows.Forms.Label()
        Me.Label_Username = New System.Windows.Forms.Label()
        Me.TextBox_Check = New System.Windows.Forms.TextBox()
        Me.TextBox_Password = New System.Windows.Forms.TextBox()
        Me.TextBox_Username = New System.Windows.Forms.TextBox()
        Me.Label_Tip = New System.Windows.Forms.Label()
        Me.Panel_Min = New System.Windows.Forms.Panel()
        Me.Panel_Close = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Label_Result
        '
        Me.Label_Result.AutoSize = True
        Me.Label_Result.BackColor = System.Drawing.Color.Transparent
        Me.Label_Result.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label_Result.Location = New System.Drawing.Point(68, 149)
        Me.Label_Result.Name = "Label_Result"
        Me.Label_Result.Size = New System.Drawing.Size(31, 15)
        Me.Label_Result.TabIndex = 43
        Me.Label_Result.Text = "0+0"
        '
        'Label_Check_Tip
        '
        Me.Label_Check_Tip.AutoSize = True
        Me.Label_Check_Tip.BackColor = System.Drawing.Color.Transparent
        Me.Label_Check_Tip.Location = New System.Drawing.Point(195, 128)
        Me.Label_Check_Tip.Name = "Label_Check_Tip"
        Me.Label_Check_Tip.Size = New System.Drawing.Size(0, 12)
        Me.Label_Check_Tip.TabIndex = 42
        '
        'Label_Password_Tip
        '
        Me.Label_Password_Tip.AutoSize = True
        Me.Label_Password_Tip.BackColor = System.Drawing.Color.Transparent
        Me.Label_Password_Tip.Location = New System.Drawing.Point(195, 92)
        Me.Label_Password_Tip.Name = "Label_Password_Tip"
        Me.Label_Password_Tip.Size = New System.Drawing.Size(0, 12)
        Me.Label_Password_Tip.TabIndex = 41
        '
        'Label_Username_Tip
        '
        Me.Label_Username_Tip.AutoSize = True
        Me.Label_Username_Tip.BackColor = System.Drawing.Color.Transparent
        Me.Label_Username_Tip.Location = New System.Drawing.Point(195, 55)
        Me.Label_Username_Tip.Name = "Label_Username_Tip"
        Me.Label_Username_Tip.Size = New System.Drawing.Size(0, 12)
        Me.Label_Username_Tip.TabIndex = 40
        '
        'Button_Ok
        '
        Me.Button_Ok.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button_Ok.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue
        Me.Button_Ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro
        Me.Button_Ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.Button_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Ok.Location = New System.Drawing.Point(111, 174)
        Me.Button_Ok.Name = "Button_Ok"
        Me.Button_Ok.Size = New System.Drawing.Size(75, 24)
        Me.Button_Ok.TabIndex = 39
        Me.Button_Ok.Text = "登  录"
        Me.Button_Ok.UseVisualStyleBackColor = False
        '
        'LinkLabel_change
        '
        Me.LinkLabel_change.AutoSize = True
        Me.LinkLabel_change.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel_change.Location = New System.Drawing.Point(141, 128)
        Me.LinkLabel_change.Name = "LinkLabel_change"
        Me.LinkLabel_change.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel_change.TabIndex = 38
        Me.LinkLabel_change.TabStop = True
        Me.LinkLabel_change.Text = "换一个"
        '
        'Label_Check
        '
        Me.Label_Check.AutoSize = True
        Me.Label_Check.BackColor = System.Drawing.Color.Transparent
        Me.Label_Check.Location = New System.Drawing.Point(20, 128)
        Me.Label_Check.Name = "Label_Check"
        Me.Label_Check.Size = New System.Drawing.Size(47, 12)
        Me.Label_Check.TabIndex = 37
        Me.Label_Check.Text = "验证码:"
        '
        'Label_Password
        '
        Me.Label_Password.AutoSize = True
        Me.Label_Password.BackColor = System.Drawing.Color.Transparent
        Me.Label_Password.Location = New System.Drawing.Point(30, 92)
        Me.Label_Password.Name = "Label_Password"
        Me.Label_Password.Size = New System.Drawing.Size(35, 12)
        Me.Label_Password.TabIndex = 36
        Me.Label_Password.Text = "密码:"
        '
        'Label_Username
        '
        Me.Label_Username.AutoSize = True
        Me.Label_Username.BackColor = System.Drawing.Color.Transparent
        Me.Label_Username.Location = New System.Drawing.Point(18, 55)
        Me.Label_Username.Name = "Label_Username"
        Me.Label_Username.Size = New System.Drawing.Size(47, 12)
        Me.Label_Username.TabIndex = 35
        Me.Label_Username.Text = "用户名:"
        '
        'TextBox_Check
        '
        Me.TextBox_Check.Location = New System.Drawing.Point(71, 125)
        Me.TextBox_Check.Name = "TextBox_Check"
        Me.TextBox_Check.Size = New System.Drawing.Size(64, 21)
        Me.TextBox_Check.TabIndex = 34
        '
        'TextBox_Password
        '
        Me.TextBox_Password.Location = New System.Drawing.Point(71, 89)
        Me.TextBox_Password.Name = "TextBox_Password"
        Me.TextBox_Password.Size = New System.Drawing.Size(118, 21)
        Me.TextBox_Password.TabIndex = 33
        Me.TextBox_Password.UseSystemPasswordChar = True
        '
        'TextBox_Username
        '
        Me.TextBox_Username.Location = New System.Drawing.Point(71, 52)
        Me.TextBox_Username.MaxLength = 254
        Me.TextBox_Username.Name = "TextBox_Username"
        Me.TextBox_Username.Size = New System.Drawing.Size(118, 21)
        Me.TextBox_Username.TabIndex = 32
        '
        'Label_Tip
        '
        Me.Label_Tip.AutoSize = True
        Me.Label_Tip.BackColor = System.Drawing.Color.Transparent
        Me.Label_Tip.Font = New System.Drawing.Font("宋体", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label_Tip.ForeColor = System.Drawing.Color.Sienna
        Me.Label_Tip.Location = New System.Drawing.Point(11, 9)
        Me.Label_Tip.Name = "Label_Tip"
        Me.Label_Tip.Size = New System.Drawing.Size(84, 18)
        Me.Label_Tip.TabIndex = 31
        Me.Label_Tip.Text = "用户登录"
        '
        'Panel_Min
        '
        Me.Panel_Min.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Min.Location = New System.Drawing.Point(250, 7)
        Me.Panel_Min.Name = "Panel_Min"
        Me.Panel_Min.Size = New System.Drawing.Size(16, 16)
        Me.Panel_Min.TabIndex = 44
        '
        'Panel_Close
        '
        Me.Panel_Close.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Close.Location = New System.Drawing.Point(272, 7)
        Me.Panel_Close.Name = "Panel_Close"
        Me.Panel_Close.Size = New System.Drawing.Size(16, 16)
        Me.Panel_Close.TabIndex = 45
        '
        'Login
        '
        Me.AcceptButton = Me.Button_Ok
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(295, 210)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_Close)
        Me.Controls.Add(Me.Panel_Min)
        Me.Controls.Add(Me.Label_Result)
        Me.Controls.Add(Me.Label_Check_Tip)
        Me.Controls.Add(Me.Label_Password_Tip)
        Me.Controls.Add(Me.Label_Username_Tip)
        Me.Controls.Add(Me.Button_Ok)
        Me.Controls.Add(Me.LinkLabel_change)
        Me.Controls.Add(Me.Label_Check)
        Me.Controls.Add(Me.Label_Password)
        Me.Controls.Add(Me.Label_Username)
        Me.Controls.Add(Me.TextBox_Check)
        Me.Controls.Add(Me.TextBox_Password)
        Me.Controls.Add(Me.TextBox_Username)
        Me.Controls.Add(Me.Label_Tip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    '<STAThread()> _
    'Shared Sub Main()
    '    Application.EnableVisualStyles()
    '    Application.Run(New Login())
    'End Sub
#End Region

    '最小化、关闭按钮鼠标按下事件
    Private Sub Bt_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel_Min.MouseDown, Panel_Close.MouseDown
        If sender.name.ToString = "Panel_Min" Then
            Panel_Min.BackgroundImage = rm.GetObject("minsize_press")
        ElseIf sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("close_press")
        End If
    End Sub

    '最小化、关闭按钮鼠标悬停事件
    Private Sub Bt_MouseHover(sender As Object, e As EventArgs) Handles Panel_Min.MouseHover, Panel_Close.MouseHover
        If sender.name.ToString = "Panel_Min" Then
            Panel_Min.BackgroundImage = rm.GetObject("minsize_hover")
        ElseIf sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("close_hover")
        End If
    End Sub

    '最小化、关闭按钮鼠标离开事件
    Private Sub Bt_MouseLeave(sender As Object, e As EventArgs) Handles Panel_Min.MouseLeave, Panel_Close.MouseLeave
        If sender.name.ToString = "Panel_Min" Then
            Panel_Min.BackgroundImage = rm.GetObject("minsize_normal")
        ElseIf sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("close_normal")
        End If
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Panel_Min.Click, Panel_Close.Click
        '通过检测按钮名来进行操作
        If sender.name.ToString = "Panel_Min" Then '最小化按钮

            Me.WindowState = FormWindowState.Minimized
        ElseIf sender.name.ToString = "Panel_Close" Then  '关闭按钮
            '淡出特效
            Dim i As Single
            For i = 95 To 5 Step -10
                Me.Opacity = i / 100
                Me.Refresh()
                Threading.Thread.Sleep(80)
            Next
            Me.Opacity = 100
            Threading.Thread.Sleep(200)
            '停止退出应用程序
            'Application.Exit()
            '为了防止从任务栏关闭窗口无法完全退出bug ，application.exit 写在 closed 事件中
            Me.Close()
        Else
            '
        End If
    End Sub
    ' 输入框控件进入事件
    Private Sub TextEnter(sender As Object, e As EventArgs) Handles _
        TextBox_Username.Enter,
        TextBox_Password.Enter,
        TextBox_Check.Enter

        Select Case sender.name.ToString
            Case "TextBox_Username"
                Label_Username_Tip.ForeColor = Color.Red
                Label_Username_Tip.Text = "请输入用户名"
            Case "TextBox_Password"
                Label_Password_Tip.ForeColor = Color.Red
                Label_Password_Tip.Text = "请输入密码"
            Case "TextBox_Check"
                Label_Check_Tip.ForeColor = Color.Red
                Label_Check_Tip.Text = "输入计算结果"

        End Select
    End Sub

    ' 输入框控件离开事件
    Private Sub TextLeave(sender As Object, e As EventArgs) Handles _
        TextBox_Username.Leave,
        TextBox_Password.Leave,
        TextBox_Check.KeyUp

        Select Case sender.name.ToString
            Case "TextBox_Username"
                If Trim(TextBox_Username.Text).Length < 3 Then
                    Label_Username_Tip.Text = "不得小于3个字符"
                ElseIf Trim(TextBox_Username.Text).Length > 2 Then
                    Label_Username_Tip.Text = Nothing
                End If
            Case "TextBox_Password"
                If Trim(TextBox_Password.Text).Length < 6 Then
                    Label_Password_Tip.Text = "不得少于6个字符"
                ElseIf Trim(TextBox_Password.Text).Length > 5 Then
                    Label_Password_Tip.Text = Nothing
                End If
            Case "TextBox_Check"
                If Trim(TextBox_Check.Text) <> ver_value.ToString Then
                    Label_Check_Tip.Text = "验证码错误"
                ElseIf Trim(TextBox_Check.Text) = ver_value.ToString Then
                    Label_Check_Tip.Text = Nothing
                End If

        End Select
    End Sub
    ' 验证码
    Private Sub verification_code()
        Info_Class.equation_verification_code(Label_Result.Text, ver_value)
    End Sub

    ' 更换验证码事件
    Private Sub LinkLabel_change_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_change.LinkClicked
        verification_code()
        TextBox_Check.Text = Nothing
        Label_Check_Tip.Text = Nothing
    End Sub

    ' 登录按钮事件
    Private Sub Button_Ok_Click(sender As Object, e As EventArgs) Handles Button_Ok.Click
        ' 判断输入是否正确
        If Trim(TextBox_Username.Text).Length > 2 And
            Trim(TextBox_Password.Text).Length > 5 And
            Trim(TextBox_Check.Text) = ver_value.ToString Then
            Console.WriteLine("YES")
        Else
            Console.WriteLine("exit")
            Return
        End If
        Bt_enter()
    End Sub

    ' 登录按钮方法
    Private Sub Bt_enter()
        Dim getstring As String = Nothing ' 返回获取到的数据赋值
        Try
            ' 声明密码变量
            Dim PWD As String = Nothing
            If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Module1.Err_MSG_Text"), System.Media.SystemSounds.Exclamation)
                Application.Exit()
            End If

            ' 操作数据库
            Select Case _
   db.Access_db(
      Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
      "Microsoft.Jet.Oledb.4.0", PWD,
      "SELECT Info_username,Info_password FROM [SYS] WHERE ID=1",
      2, getstring)

                Case "InvalidOperationException"
                    '调用消息弹框
                    Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                    Application.Exit()
                Case "OleDbException"
                    '调用消息弹框
                    Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                    Application.Exit()
            End Select
        Catch ex As Exception
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Exception"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        End Try

        ' 判断用户名密码
        If Trim(TextBox_Username.Text) & Info_Class.GetString_md5(Trim(TextBox_Password.Text)) = getstring Then

            ' 隐藏当前窗口
            Me.Hide()
            ' 显示打开main窗口
            Dim _Main As New Main
            _Main.Show()
            ' 释放当前资源（采用此办法为了不经过closed事件，关闭整个程序）
            Me.Dispose(True)
        Else
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), rm.GetObject("Login_user.pass_isnot"), System.Media.SystemSounds.Asterisk)
            LinkLabel_change_LinkClicked(Nothing, Nothing)
        End If


    End Sub

End Class