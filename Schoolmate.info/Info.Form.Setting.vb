Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
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
    Friend WithEvents GroupBox_Change As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Reset As System.Windows.Forms.Button
    Friend WithEvents Button_Change As System.Windows.Forms.Button
    Friend WithEvents TextBox_New_Password2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_New_Password1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_New_Username As System.Windows.Forms.TextBox
    Friend WithEvents Label_Old_Password As System.Windows.Forms.Label
    Friend WithEvents Label_New_Password As System.Windows.Forms.Label
    Friend WithEvents Label_New_Username As System.Windows.Forms.Label
    Friend WithEvents Panel_Title_ICO As System.Windows.Forms.Panel
    Friend WithEvents Label_Title As System.Windows.Forms.Label
    Friend WithEvents Panel_Close As System.Windows.Forms.Panel
    Friend WithEvents TextBox_Checkcode As System.Windows.Forms.TextBox
    Friend WithEvents Label_Checkcode As System.Windows.Forms.Label
    Friend WithEvents PictureBox_Checkcode As System.Windows.Forms.PictureBox

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox_Change = New System.Windows.Forms.GroupBox()
        Me.PictureBox_Checkcode = New System.Windows.Forms.PictureBox()
        Me.TextBox_Checkcode = New System.Windows.Forms.TextBox()
        Me.Label_Checkcode = New System.Windows.Forms.Label()
        Me.TextBox_New_Password2 = New System.Windows.Forms.TextBox()
        Me.TextBox_New_Password1 = New System.Windows.Forms.TextBox()
        Me.TextBox_New_Username = New System.Windows.Forms.TextBox()
        Me.Label_Old_Password = New System.Windows.Forms.Label()
        Me.Label_New_Password = New System.Windows.Forms.Label()
        Me.Label_New_Username = New System.Windows.Forms.Label()
        Me.Button_Reset = New System.Windows.Forms.Button()
        Me.Button_Change = New System.Windows.Forms.Button()
        Me.Panel_Title_ICO = New System.Windows.Forms.Panel()
        Me.Label_Title = New System.Windows.Forms.Label()
        Me.Panel_Close = New System.Windows.Forms.Panel()
        Me.GroupBox_Change.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_Change
        '
        Me.GroupBox_Change.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_Change.Controls.Add(Me.PictureBox_Checkcode)
        Me.GroupBox_Change.Controls.Add(Me.TextBox_Checkcode)
        Me.GroupBox_Change.Controls.Add(Me.Label_Checkcode)
        Me.GroupBox_Change.Controls.Add(Me.TextBox_New_Password2)
        Me.GroupBox_Change.Controls.Add(Me.TextBox_New_Password1)
        Me.GroupBox_Change.Controls.Add(Me.TextBox_New_Username)
        Me.GroupBox_Change.Controls.Add(Me.Label_Old_Password)
        Me.GroupBox_Change.Controls.Add(Me.Label_New_Password)
        Me.GroupBox_Change.Controls.Add(Me.Label_New_Username)
        Me.GroupBox_Change.Location = New System.Drawing.Point(14, 42)
        Me.GroupBox_Change.Name = "GroupBox_Change"
        Me.GroupBox_Change.Size = New System.Drawing.Size(283, 154)
        Me.GroupBox_Change.TabIndex = 0
        Me.GroupBox_Change.TabStop = False
        Me.GroupBox_Change.Text = "修改用户名或密码"
        '
        'PictureBox_Checkcode
        '
        Me.PictureBox_Checkcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Checkcode.Location = New System.Drawing.Point(195, 113)
        Me.PictureBox_Checkcode.Name = "PictureBox_Checkcode"
        Me.PictureBox_Checkcode.Size = New System.Drawing.Size(63, 21)
        Me.PictureBox_Checkcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_Checkcode.TabIndex = 8
        Me.PictureBox_Checkcode.TabStop = False
        '
        'TextBox_Checkcode
        '
        Me.TextBox_Checkcode.Location = New System.Drawing.Point(122, 113)
        Me.TextBox_Checkcode.Name = "TextBox_Checkcode"
        Me.TextBox_Checkcode.Size = New System.Drawing.Size(61, 21)
        Me.TextBox_Checkcode.TabIndex = 7
        '
        'Label_Checkcode
        '
        Me.Label_Checkcode.AutoSize = True
        Me.Label_Checkcode.BackColor = System.Drawing.Color.Transparent
        Me.Label_Checkcode.Location = New System.Drawing.Point(33, 116)
        Me.Label_Checkcode.Name = "Label_Checkcode"
        Me.Label_Checkcode.Size = New System.Drawing.Size(83, 12)
        Me.Label_Checkcode.TabIndex = 6
        Me.Label_Checkcode.Text = "请输入验证码:"
        '
        'TextBox_New_Password2
        '
        Me.TextBox_New_Password2.Location = New System.Drawing.Point(122, 82)
        Me.TextBox_New_Password2.Name = "TextBox_New_Password2"
        Me.TextBox_New_Password2.Size = New System.Drawing.Size(136, 21)
        Me.TextBox_New_Password2.TabIndex = 5
        Me.TextBox_New_Password2.UseSystemPasswordChar = True
        '
        'TextBox_New_Password1
        '
        Me.TextBox_New_Password1.Location = New System.Drawing.Point(122, 52)
        Me.TextBox_New_Password1.Name = "TextBox_New_Password1"
        Me.TextBox_New_Password1.Size = New System.Drawing.Size(136, 21)
        Me.TextBox_New_Password1.TabIndex = 4
        Me.TextBox_New_Password1.UseSystemPasswordChar = True
        '
        'TextBox_New_Username
        '
        Me.TextBox_New_Username.Location = New System.Drawing.Point(122, 21)
        Me.TextBox_New_Username.MaxLength = 254
        Me.TextBox_New_Username.Name = "TextBox_New_Username"
        Me.TextBox_New_Username.Size = New System.Drawing.Size(136, 21)
        Me.TextBox_New_Username.TabIndex = 3
        '
        'Label_Old_Password
        '
        Me.Label_Old_Password.AutoSize = True
        Me.Label_Old_Password.BackColor = System.Drawing.Color.Transparent
        Me.Label_Old_Password.Location = New System.Drawing.Point(21, 85)
        Me.Label_Old_Password.Name = "Label_Old_Password"
        Me.Label_Old_Password.Size = New System.Drawing.Size(95, 12)
        Me.Label_Old_Password.TabIndex = 2
        Me.Label_Old_Password.Text = "再次输入新密码:"
        '
        'Label_New_Password
        '
        Me.Label_New_Password.AutoSize = True
        Me.Label_New_Password.BackColor = System.Drawing.Color.Transparent
        Me.Label_New_Password.Location = New System.Drawing.Point(45, 55)
        Me.Label_New_Password.Name = "Label_New_Password"
        Me.Label_New_Password.Size = New System.Drawing.Size(71, 12)
        Me.Label_New_Password.TabIndex = 1
        Me.Label_New_Password.Text = "输入新密码:"
        '
        'Label_New_Username
        '
        Me.Label_New_Username.AutoSize = True
        Me.Label_New_Username.BackColor = System.Drawing.Color.Transparent
        Me.Label_New_Username.Location = New System.Drawing.Point(33, 24)
        Me.Label_New_Username.Name = "Label_New_Username"
        Me.Label_New_Username.Size = New System.Drawing.Size(83, 12)
        Me.Label_New_Username.TabIndex = 0
        Me.Label_New_Username.Text = "输入新用户名:"
        '
        'Button_Reset
        '
        Me.Button_Reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Reset.FlatAppearance.BorderSize = 0
        Me.Button_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Reset.Location = New System.Drawing.Point(202, 201)
        Me.Button_Reset.Name = "Button_Reset"
        Me.Button_Reset.Size = New System.Drawing.Size(75, 24)
        Me.Button_Reset.TabIndex = 7
        Me.Button_Reset.Text = "重  填"
        Me.Button_Reset.UseVisualStyleBackColor = True
        '
        'Button_Change
        '
        Me.Button_Change.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Change.FlatAppearance.BorderSize = 0
        Me.Button_Change.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Change.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Change.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Change.Location = New System.Drawing.Point(34, 201)
        Me.Button_Change.Name = "Button_Change"
        Me.Button_Change.Size = New System.Drawing.Size(75, 24)
        Me.Button_Change.TabIndex = 6
        Me.Button_Change.Text = "修  改"
        Me.Button_Change.UseVisualStyleBackColor = True
        '
        'Panel_Title_ICO
        '
        Me.Panel_Title_ICO.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Title_ICO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Title_ICO.Location = New System.Drawing.Point(7, 6)
        Me.Panel_Title_ICO.Name = "Panel_Title_ICO"
        Me.Panel_Title_ICO.Size = New System.Drawing.Size(20, 20)
        Me.Panel_Title_ICO.TabIndex = 3
        '
        'Label_Title
        '
        Me.Label_Title.AutoSize = True
        Me.Label_Title.BackColor = System.Drawing.Color.Transparent
        Me.Label_Title.Location = New System.Drawing.Point(33, 10)
        Me.Label_Title.Name = "Label_Title"
        Me.Label_Title.Size = New System.Drawing.Size(29, 12)
        Me.Label_Title.TabIndex = 4
        Me.Label_Title.Text = "设置"
        '
        'Panel_Close
        '
        Me.Panel_Close.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Close.Location = New System.Drawing.Point(276, 2)
        Me.Panel_Close.Name = "Panel_Close"
        Me.Panel_Close.Size = New System.Drawing.Size(37, 16)
        Me.Panel_Close.TabIndex = 5
        '
        'Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(314, 233)
        Me.Controls.Add(Me.Button_Reset)
        Me.Controls.Add(Me.Panel_Close)
        Me.Controls.Add(Me.Button_Change)
        Me.Controls.Add(Me.Label_Title)
        Me.Controls.Add(Me.Panel_Title_ICO)
        Me.Controls.Add(Me.GroupBox_Change)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "设置"
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.GroupBox_Change.ResumeLayout(False)
        Me.GroupBox_Change.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub Setting_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Info_Class.Mform(Me.Handle)
    End Sub

    Private checkcodestring As String = Nothing  '获取验证码存储变量
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        ' 指定控件的样式和行为。
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)

        Me.BackgroundImage = rm.GetObject("Info.Form.Setting")
        Panel_Title_ICO.BackgroundImage = rm.GetObject("SettingTitle_ICO")
        Panel_Close.BackgroundImage = rm.GetObject("btn_close_normal")
        Button_Reset.BackgroundImage = rm.GetObject("btn_normal")
        Button_Change.BackgroundImage = rm.GetObject("btn_normal")
        CodeImage(CheckCode) '验证码赋值

        ' 工具提示文本
        Dim toolstip As New ToolTip
        toolstip.SetToolTip(Panel_Close, "关闭")
        toolstip.SetToolTip(Button_Change, "修改")
        toolstip.SetToolTip(Button_Reset, "重填")

    End Sub

    ' 单击事件
    Private Sub All_Close_Click(sender As Object, e As EventArgs) Handles _
        Panel_Close.Click,
        Button_Reset.Click,
        Button_Change.Click,
        PictureBox_Checkcode.Click

        Select Case sender.name.ToString

            Case "Panel_Close" '关闭
                Me.Close()

            Case "Button_Reset"
                TextBox_New_Username.Text = Nothing
                TextBox_New_Password1.Text = Nothing
                TextBox_New_Password2.Text = Nothing
                TextBox_Checkcode.Text = Nothing

            Case "Button_Change"
                ' 判断输入是否正确
                If Trim(TextBox_New_Username.Text).Length > 2 And
                    Trim(TextBox_New_Password1.Text).Length > 5 And
            Trim(TextBox_New_Password2.Text) = Trim(TextBox_New_Password1.Text) And
            Trim(TextBox_Checkcode.Text) = checkcodestring Then
                    Console.WriteLine("YES")
                Else

                    If Trim(TextBox_New_Username.Text).Length < 3 Then '登录名小于3位字符
                        '调用消息弹框
                        Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), rm.GetObject("Info.Form.Setting.TextBox_New_Username.Text.Length < 3"), System.Media.SystemSounds.Asterisk)
                        Return
                    ElseIf Trim(TextBox_New_Password1.Text).Length < 6 Then '密码小于6位字符
                        '调用消息弹框
                        Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), rm.GetObject("Info.Form.Setting.TextBox_New_Password1.Text.Length < 6"), System.Media.SystemSounds.Asterisk)
                        Return
                    ElseIf Trim(TextBox_New_Password2.Text) <> Trim(TextBox_New_Password1.Text) Then '两次密码不同
                        '调用消息弹框
                        Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), rm.GetObject("Info.Form.Setting.TextBox_New_Password2.Text <> TextBox_New_Password1.Text"), System.Media.SystemSounds.Asterisk)
                        Return
                    ElseIf Trim(TextBox_Checkcode.Text) <> checkcodestring Then '验证码错误
                        '调用消息弹框
                        Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), rm.GetObject("Info.Form.Setting.Trim(TextBox_Checkcode.Text) <> checkcodestring"), System.Media.SystemSounds.Asterisk)
                        Return
                    End If
                    
                End If
                Bt_enter()

            Case "PictureBox_Checkcode" '验证码图片单击
                CodeImage(CheckCode) '验证码

        End Select
    End Sub

    ' 完成设置按钮方法
    Private Sub Bt_enter()
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
      "UPDATE [SYS] SET Info_admin = 1,Info_username = '" & Trim(TextBox_New_Username.Text) & "',Info_password = '" & Info_Class.GetString_md5(Trim(TextBox_New_Password1.Text)) & "' WHERE ID = 1",
      1, Nothing)

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
        '调用消息弹框,提示修改成功
        Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), String.Format(rm.GetObject("Info.Form.Setting.ChangeSuccess"), Trim(TextBox_New_Username.Text), Trim(TextBox_New_Password2.Text)), System.Media.SystemSounds.Asterisk)
        Me.Close() '关闭窗口
    End Sub

    ' 鼠标移动到事件
    Private Sub Panel_Close_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles _
        Panel_Close.MouseDown,
        Button_Reset.MouseDown,
        Button_Change.MouseDown

        If sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("btn_close_down")
        ElseIf sender.name.ToString = "Button_Reset" Then
            Button_Reset.BackgroundImage = rm.GetObject("btn_down")
        ElseIf sender.name.ToString = "Button_Change" Then
            Button_Change.BackgroundImage = rm.GetObject("btn_down")
        End If
    End Sub

    '鼠标悬停事件
    Private Sub Panel_Close_MouseHover(sender As Object, e As EventArgs) Handles _
        Panel_Close.MouseHover,
        Button_Reset.MouseHover,
        Button_Change.MouseHover

        If sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("btn_close_highlight")
        ElseIf sender.name.ToString = "Button_Reset" Then
            Button_Reset.BackgroundImage = rm.GetObject("btn_hover")
        ElseIf sender.name.ToString = "Button_Change" Then
            Button_Change.BackgroundImage = rm.GetObject("btn_hover")
        End If
    End Sub

    '鼠标离开事件
    Private Sub Panel_Close_MouseLeave(sender As Object, e As EventArgs) Handles _
        Panel_Close.MouseLeave,
        Button_Reset.MouseLeave,
        Button_Change.MouseLeave

        If sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("btn_close_normal")
        ElseIf sender.name.ToString = "Button_Reset" Then
            Button_Reset.BackgroundImage = rm.GetObject("btn_normal")
        ElseIf sender.name.ToString = "Button_Change" Then
            Button_Change.BackgroundImage = rm.GetObject("btn_normal")
        End If
    End Sub

    '字母+数字 四位 验证码
    Private Function CheckCode() As String
        Dim chkcode As String = String.Empty
        Dim random As New Random
        Dim i As Integer
        For i = 0 To 4 - 1
            Dim code As Char
            Dim number As Integer = random.Next
            If ((number Mod 2) = 0) Then
                code = DirectCast(Microsoft.VisualBasic.ChrW((&H30 + CUShort((number Mod 10)))), Char)
            Else
                code = DirectCast(Microsoft.VisualBasic.ChrW((&H41 + CUShort((number Mod &H1A)))), Char)
            End If
            chkcode = (chkcode & " " & code.ToString)
        Next i
        '清除字符中的所有空格
        checkcodestring = chkcode
        Dim charsToTrim() As Char = {" "c}
        Dim words() As String = checkcodestring.Split()
        checkcodestring = Nothing '清空后重新赋值
        For Each word As String In words
            checkcodestring = checkcodestring + word.TrimEnd(charsToTrim)
        Next

        Return chkcode
    End Function

    Private Sub CodeImage(ByVal checkCode As String)
        If ((Not checkCode Is Nothing) AndAlso Not (checkCode.Trim = String.Empty)) Then
            Dim image As New Bitmap(CInt(Math.Ceiling(CDbl((checkCode.Length * 80)))), 90)
            Dim g As Graphics = Graphics.FromImage(image)
            Try
                Dim i As Integer
                Dim random As New Random
                g.Clear(Color.White)

                For i = 0 To 3 - 1
                    Dim x1 As Integer = random.Next(image.Width)
                    Dim x2 As Integer = random.Next(image.Width)
                    Dim y1 As Integer = random.Next(image.Height)
                    Dim y2 As Integer = random.Next(image.Height)
                    g.DrawLine(New Pen(Color.Black), x1, y1, x2, y2)
                Next i
                Dim font As New Font("Arial", 60.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
                g.DrawString(checkCode, font, New SolidBrush(Color.Red), CSng(2.0!), CSng(2.0!))

                For i = 0 To &H7D0 - 1
                    Dim x As Integer = random.Next(image.Width)
                    Dim y As Integer = random.Next(image.Height)
                    image.SetPixel(x, y, Color.FromArgb(random.Next))
                Next i
                g.DrawRectangle(New Pen(Color.Silver), 0, 0, (image.Width - 1), (image.Height - 1))
                'Me.PictureBox_Checkcode.Width = image.Width
                'Me.PictureBox_Checkcode.Height = image.Height
                PictureBox_Checkcode.Image = image
            Catch ex As Exception
                Console.WriteLine(Err.Description)
            End Try
        End If
    End Sub

    ' 限定用户名不大于15个字符
    Private Sub TextBox_New_Username_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
        TextBox_New_Username.KeyPress,
        TextBox_Checkcode.KeyPress
        Select Case sender.name.ToString
            Case "TextBox_New_Username"
                '去除空格和非法字符
                Dim sentence As String = TextBox_New_Username.Text
                Dim charsToTrim() As Char = {" "c, "~"c, "·"c, "！"c, "￥"c, "…"c}
                Dim words() As String = sentence.Split()
                TextBox_New_Username.Text = Nothing '清空后重新赋值
                For Each word As String In words
                    TextBox_New_Username.AppendText(word.TrimEnd(charsToTrim))
                Next

                If Trim(TextBox_New_Username.Text).Length > 14 And e.KeyChar <> Chr(8) Then e.Handled = True
             
            Case "TextBox_Checkcode"
                If Trim(TextBox_Checkcode.Text).Length > 3 And e.KeyChar <> Chr(8) Then e.Handled = True

        End Select
        
    End Sub
End Class
