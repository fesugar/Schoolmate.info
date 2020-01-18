Imports System.Drawing
Imports System.Drawing.Drawing2D

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowDialog
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
    Friend WithEvents Panel_ICO As System.Windows.Forms.Panel
    Friend WithEvents Label_Msg As System.Windows.Forms.Label
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents Label_Title As System.Windows.Forms.Label
    Friend WithEvents Panel_Close As System.Windows.Forms.Panel

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel_ICO = New System.Windows.Forms.Panel()
        Me.Label_Msg = New System.Windows.Forms.Label()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.Label_Title = New System.Windows.Forms.Label()
        Me.Panel_Close = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Panel_ICO
        '
        Me.Panel_ICO.BackColor = System.Drawing.Color.Transparent
        Me.Panel_ICO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_ICO.Location = New System.Drawing.Point(12, 36)
        Me.Panel_ICO.Name = "Panel_ICO"
        Me.Panel_ICO.Size = New System.Drawing.Size(40, 40)
        Me.Panel_ICO.TabIndex = 2
        '
        'Label_Msg
        '
        Me.Label_Msg.BackColor = System.Drawing.Color.Transparent
        Me.Label_Msg.Location = New System.Drawing.Point(62, 25)
        Me.Label_Msg.Name = "Label_Msg"
        Me.Label_Msg.Size = New System.Drawing.Size(185, 59)
        Me.Label_Msg.TabIndex = 3
        Me.Label_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_OK
        '
        Me.Button_OK.BackColor = System.Drawing.Color.Transparent
        Me.Button_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_OK.FlatAppearance.BorderSize = 0
        Me.Button_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_OK.Location = New System.Drawing.Point(208, 98)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(75, 25)
        Me.Button_OK.TabIndex = 4
        Me.Button_OK.Text = "确定"
        Me.Button_OK.UseVisualStyleBackColor = False
        '
        'Label_Title
        '
        Me.Label_Title.AutoSize = True
        Me.Label_Title.BackColor = System.Drawing.Color.Transparent
        Me.Label_Title.Location = New System.Drawing.Point(10, 9)
        Me.Label_Title.Name = "Label_Title"
        Me.Label_Title.Size = New System.Drawing.Size(0, 12)
        Me.Label_Title.TabIndex = 5
        '
        'Panel_Close
        '
        Me.Panel_Close.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Close.Location = New System.Drawing.Point(264, 0)
        Me.Panel_Close.Name = "Panel_Close"
        Me.Panel_Close.Size = New System.Drawing.Size(26, 30)
        Me.Panel_Close.TabIndex = 6
        '
        'ShowDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(290, 130)
        Me.Controls.Add(Me.Panel_Close)
        Me.Controls.Add(Me.Label_Title)
        Me.Controls.Add(Me.Button_OK)
        Me.Controls.Add(Me.Panel_ICO)
        Me.Controls.Add(Me.Label_Msg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ShowDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub ShowDialog_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Info_Class.Mform(Me.Handle)
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        ' 指定控件的样式和行为。
        SetStyle(Windows.Forms.ControlStyles.UserPaint Or Windows.Forms.ControlStyles.AllPaintingInWmPaint Or Windows.Forms.ControlStyles.DoubleBuffer, True)

        Dim rm As New Resources.ResourceManager("Language.resources", GetType(Module_Schoolmate).Assembly)
        Me.BackgroundImage = rm.GetObject("Tips_bk")
        Panel_Close.BackgroundImage = rm.GetObject("msg_normal")
        Button_OK.BackgroundImage = rm.GetObject("LighterTipsButton_Normal")
    End Sub

    Private Sub Panel_Close_Click(sender As Object, e As EventArgs) Handles Panel_Close.Click, Button_OK.Click

        If sender.name.ToString = "Panel_Close" Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        ElseIf sender.name.ToString = "Button_OK" Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If
        Me.Close()
    End Sub

    Private Sub Panel_Close_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Panel_Close.MouseDown, Button_OK.MouseDown
        If sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("msg_down")
        ElseIf sender.name.ToString = "Button_OK" Then
            Button_OK.BackgroundImage = rm.GetObject("LighterTipsButton_Down")
        End If
    End Sub

    Private Sub Panel_Close_MouseHover(sender As Object, e As EventArgs) Handles Panel_Close.MouseHover, Button_OK.MouseHover
        If sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("msg_hover")
        ElseIf sender.name.ToString = "Button_OK" Then
            Button_OK.BackgroundImage = rm.GetObject("LighterTipsButton_Hover")
        End If
    End Sub

    Private Sub Panel_Close_MouseLeave(sender As Object, e As EventArgs) Handles Panel_Close.MouseLeave, Button_OK.MouseLeave
        If sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("msg_normal")
        ElseIf sender.name.ToString = "Button_OK" Then
            Button_OK.BackgroundImage = rm.GetObject("LighterTipsButton_Normal")
        End If
    End Sub
End Class
