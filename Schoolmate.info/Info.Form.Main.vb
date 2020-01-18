Imports System.Windows.Forms
Imports System.Threading
Imports System.Data.OleDb
Imports System.Data

Public Class Main
    Inherits System.Windows.Forms.Form

    '窗体成功关闭事件
    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    ' 窗体载入时事件
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 移除不必要的控件（为了解决界面缩放导致布局错误）
        Me.Controls.Remove(Panel_info_1)
        Me.Controls.Remove(Panel_info_2)
        Me.Controls.Remove(Panel_info_3)
        Me.Controls.Remove(Panel_info_4)
        Me.Controls.Remove(Panel_info_5)
        Me.Controls.Remove(TextBox_Search_Compellation)
        Me.Controls.Remove(Button_Search)
        Me.Controls.Remove(Button_Next_item)
        Me.Controls.Remove(Button_Save)

        ' 默认生成按钮事件
        ToolStripLabel_basic_information.PerformClick()
    End Sub


    '[鼠标移动事件]
    Private Sub Move_MouseMove(sender As Object, e As MouseEventArgs) Handles _
        Me.MouseMove,
        Label_Title.MouseMove,
        Panel_info_1.MouseMove,
        Panel_info_2.MouseMove,
        Panel_info_3.MouseMove,
        Panel_info_4.MouseMove,
        Panel_info_5.MouseMove,
        Panel_Menu.MouseMove,
        PictureBox_Photo.MouseMove
        Info_Class.Mform(Me.Handle)
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' 指定控件的样式和行为。
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)

        ' \
        '获取设置组合框的数据
        ComboBox_Marital_status.Items.AddRange(New Object() {"未知", "已婚", "未婚"})

        ComboBox_Twelve_animals.Items.AddRange(New Object() {"", "猴", "鸡", "狗", "猪", "鼠", "牛", "羊", "虎", "兔", "龙", "蛇", "马"})

        ComboBox_Blood_type.Items.AddRange(New Object() {"", "A", "B", "O", "AB"})

        ComboBox_Birthday_year.Items.Add("")
        For y As Integer = Now.Year To Now.Year - 99 Step -1
            ComboBox_Birthday_year.Items.Add(y)
        Next

        ComboBox_Birthday_month.Items.Add("")
        For m As Integer = 1 To 12 Step 1
            ComboBox_Birthday_month.Items.Add(m)
        Next

        ComboBox_Birthday_day.Items.Add("")
        For d As Integer = 1 To 31 Step 1
            ComboBox_Birthday_day.Items.Add(d)
        Next

        district(Nothing, 1)

        ComboBox_Entrance_school_year.Items.Add("")
        For i As Integer = Now.Year To Now.Year - 49 Step -1
            ComboBox_Entrance_school_year.Items.Add(i)
        Next

        '获取设置组合框的数据
        ComboBox_Worktime_begin_year.Items.Add("")
        ComboBox_Worktime_finish_year.Items.Add("")
        ComboBox_Worktime_finish_year.Items.Add("现在")
        For i As Integer = Now.Year To Now.Year - 49 Step -1
            ComboBox_Worktime_begin_year.Items.Add(i)
            ComboBox_Worktime_finish_year.Items.Add(i)
        Next

        ComboBox_Worktime_begin_month.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        ComboBox_Worktime_finish_month.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})

        Button_Modify.Enabled = False '初始化禁用修改按钮
        Button_Delete.Enabled = False '初始化禁用删除按钮
        TextBox_Compellation.ReadOnly = True '初始化设姓名文本编辑框只读

        Me.Icon = rm.GetObject("MainIco")
        'Me.TransparencyKey = Drawing.Color.Magenta  '设置窗体透明色
        Me.BackgroundImage = rm.GetObject("Info.Form.Main")
        PictureBox_Photo.BackgroundImage = rm.GetObject("face_border")
        Panel_Min.BackgroundImage = rm.GetObject("sysbtn_min_normal")
        Panel_Close.BackgroundImage = rm.GetObject("sysbtn_close_normal")

        ' 工具提示文本不添加此控件 使用会导致展开菜单项卡断且图片双击查看无效果

        '解决桌面缩放导致的程序界面不规范在初始化中先对控件进行添加,然后再load事件中修复

        Me.Controls.AddRange(New Control() {Panel_info_1,
                                            Panel_info_2,
                                            Panel_info_3,
                                            Panel_info_4,
                                            Panel_info_5,
                                            TextBox_Search_Compellation,
                                            Button_Search,
                                            Button_Next_item,
                                            Button_Save})

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
    Friend WithEvents Label_Title As System.Windows.Forms.Label
    Friend WithEvents ToolStrip_Info As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_basic_information As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_contact_information As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_education_information As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_work_information As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_personal_information As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel_info_1 As System.Windows.Forms.Panel
    Friend WithEvents Panel_Menu As System.Windows.Forms.Panel
    Friend WithEvents PictureBox_Photo As System.Windows.Forms.PictureBox
    Friend WithEvents Label_Birthday_month As System.Windows.Forms.Label
    Friend WithEvents Label_Birthday_year As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Live_city As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Live_province As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Hometown_city As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Hometown_province As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Blood_type As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Birthday_month As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Birthday_year As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Marital_status As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton_Women As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_Men As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox_Compellation As System.Windows.Forms.TextBox
    Friend WithEvents Label_Live As System.Windows.Forms.Label
    Friend WithEvents Label_Hometown As System.Windows.Forms.Label
    Friend WithEvents Label_Blood_type As System.Windows.Forms.Label
    Friend WithEvents Label_Birthday As System.Windows.Forms.Label
    Friend WithEvents Label_Marital_status As System.Windows.Forms.Label
    Friend WithEvents Label_Sex As System.Windows.Forms.Label
    Friend WithEvents Label_Compellation As System.Windows.Forms.Label
    Friend WithEvents Panel_info_4 As System.Windows.Forms.Panel
    Friend WithEvents Panel_info_2 As System.Windows.Forms.Panel
    Friend WithEvents Panel_info_3 As System.Windows.Forms.Panel
    Friend WithEvents Panel_info_5 As System.Windows.Forms.Panel
    Friend WithEvents TextBox_Personal_wish As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Personal_love As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Personal_hobby As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Personal_presentation As System.Windows.Forms.TextBox
    Friend WithEvents Label_Personal_presentation As System.Windows.Forms.Label
    Friend WithEvents Label_Personal_wish As System.Windows.Forms.Label
    Friend WithEvents Label_Personal_love As System.Windows.Forms.Label
    Friend WithEvents Label_Personal_hobby As System.Windows.Forms.Label
    Friend WithEvents Label_Content As System.Windows.Forms.Label
    Friend WithEvents Label_Column As System.Windows.Forms.Label
    Friend WithEvents Label_finish_month As System.Windows.Forms.Label
    Friend WithEvents Label_finish_year As System.Windows.Forms.Label
    Friend WithEvents Label_begin_month As System.Windows.Forms.Label
    Friend WithEvents Label_begin_year As System.Windows.Forms.Label
    Friend WithEvents Label_Worktime_begin_year As System.Windows.Forms.Label
    Friend WithEvents Label_Department As System.Windows.Forms.Label
    Friend WithEvents Label_Company_name As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Worktime_finish_month As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Worktime_finish_year As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Worktime_begin_month As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Worktime_begin_year As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox_Department As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Company_name As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_Entrance_school_year As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Year As System.Windows.Forms.Label
    Friend WithEvents TextBox_Class_name As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_School_name As System.Windows.Forms.TextBox
    Friend WithEvents Label_Entrance_school_year As System.Windows.Forms.Label
    Friend WithEvents Label_Class_name As System.Windows.Forms.Label
    Friend WithEvents Label_School_name As System.Windows.Forms.Label
    Friend WithEvents TextBox_Other_number As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Msn_number As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Qq_number As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Mobile_number As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Email_address As System.Windows.Forms.TextBox
    Friend WithEvents Label_Other_number As System.Windows.Forms.Label
    Friend WithEvents Label_Msn_number As System.Windows.Forms.Label
    Friend WithEvents Label_Qq_number As System.Windows.Forms.Label
    Friend WithEvents Label_Mobile_number As System.Windows.Forms.Label
    Friend WithEvents Label_Email_address As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Live_town As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Live_county As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Hometown_town As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Hometown_county As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip_Info As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel_Statu As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label_Birthday_day As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Birthday_day As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripStatusLabel_Msg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents Button_Setting As System.Windows.Forms.Button
    Friend WithEvents Button_Delete As System.Windows.Forms.Button
    Friend WithEvents Button_Modify As System.Windows.Forms.Button
    Friend WithEvents Button_Add As System.Windows.Forms.Button
    Friend WithEvents Button_Query As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
    Friend WithEvents Button_Next_item As System.Windows.Forms.Button
    Friend WithEvents Button_Search As System.Windows.Forms.Button
    Friend WithEvents TextBox_Search_Compellation As System.Windows.Forms.TextBox
    Friend WithEvents Panel_Min As System.Windows.Forms.Panel
    Friend WithEvents Panel_Close As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip_Photo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_Add_Photo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem_Delete_Photo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBox_Twelve_animals As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Twelve_animals As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label_Title = New System.Windows.Forms.Label()
        Me.ToolStrip_Info = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_basic_information = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_contact_information = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_education_information = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_work_information = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_personal_information = New System.Windows.Forms.ToolStripLabel()
        Me.Panel_info_1 = New System.Windows.Forms.Panel()
        Me.ComboBox_Twelve_animals = New System.Windows.Forms.ComboBox()
        Me.Label_Twelve_animals = New System.Windows.Forms.Label()
        Me.Label_Birthday_day = New System.Windows.Forms.Label()
        Me.ComboBox_Birthday_day = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Live_town = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Live_county = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Hometown_town = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Hometown_county = New System.Windows.Forms.ComboBox()
        Me.PictureBox_Photo = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip_Photo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_Add_Photo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem_Delete_Photo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label_Birthday_month = New System.Windows.Forms.Label()
        Me.Label_Birthday_year = New System.Windows.Forms.Label()
        Me.ComboBox_Live_city = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Live_province = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Hometown_city = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Hometown_province = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Blood_type = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Birthday_month = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Birthday_year = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Marital_status = New System.Windows.Forms.ComboBox()
        Me.RadioButton_Women = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Men = New System.Windows.Forms.RadioButton()
        Me.TextBox_Compellation = New System.Windows.Forms.TextBox()
        Me.Label_Live = New System.Windows.Forms.Label()
        Me.Label_Hometown = New System.Windows.Forms.Label()
        Me.Label_Blood_type = New System.Windows.Forms.Label()
        Me.Label_Birthday = New System.Windows.Forms.Label()
        Me.Label_Marital_status = New System.Windows.Forms.Label()
        Me.Label_Sex = New System.Windows.Forms.Label()
        Me.Label_Compellation = New System.Windows.Forms.Label()
        Me.Panel_Menu = New System.Windows.Forms.Panel()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.Button_Setting = New System.Windows.Forms.Button()
        Me.Button_Delete = New System.Windows.Forms.Button()
        Me.Button_Modify = New System.Windows.Forms.Button()
        Me.Button_Add = New System.Windows.Forms.Button()
        Me.Button_Query = New System.Windows.Forms.Button()
        Me.Panel_info_4 = New System.Windows.Forms.Panel()
        Me.Label_finish_month = New System.Windows.Forms.Label()
        Me.Label_finish_year = New System.Windows.Forms.Label()
        Me.Label_begin_month = New System.Windows.Forms.Label()
        Me.Label_begin_year = New System.Windows.Forms.Label()
        Me.Label_Worktime_begin_year = New System.Windows.Forms.Label()
        Me.Label_Department = New System.Windows.Forms.Label()
        Me.Label_Company_name = New System.Windows.Forms.Label()
        Me.ComboBox_Worktime_finish_month = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Worktime_finish_year = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Worktime_begin_month = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Worktime_begin_year = New System.Windows.Forms.ComboBox()
        Me.TextBox_Department = New System.Windows.Forms.TextBox()
        Me.TextBox_Company_name = New System.Windows.Forms.TextBox()
        Me.Panel_info_2 = New System.Windows.Forms.Panel()
        Me.TextBox_Other_number = New System.Windows.Forms.TextBox()
        Me.TextBox_Msn_number = New System.Windows.Forms.TextBox()
        Me.TextBox_Qq_number = New System.Windows.Forms.TextBox()
        Me.TextBox_Mobile_number = New System.Windows.Forms.TextBox()
        Me.TextBox_Email_address = New System.Windows.Forms.TextBox()
        Me.Label_Other_number = New System.Windows.Forms.Label()
        Me.Label_Msn_number = New System.Windows.Forms.Label()
        Me.Label_Qq_number = New System.Windows.Forms.Label()
        Me.Label_Mobile_number = New System.Windows.Forms.Label()
        Me.Label_Email_address = New System.Windows.Forms.Label()
        Me.Panel_info_3 = New System.Windows.Forms.Panel()
        Me.ComboBox_Entrance_school_year = New System.Windows.Forms.ComboBox()
        Me.Label_Year = New System.Windows.Forms.Label()
        Me.TextBox_Class_name = New System.Windows.Forms.TextBox()
        Me.TextBox_School_name = New System.Windows.Forms.TextBox()
        Me.Label_Entrance_school_year = New System.Windows.Forms.Label()
        Me.Label_Class_name = New System.Windows.Forms.Label()
        Me.Label_School_name = New System.Windows.Forms.Label()
        Me.Panel_info_5 = New System.Windows.Forms.Panel()
        Me.TextBox_Personal_wish = New System.Windows.Forms.TextBox()
        Me.TextBox_Personal_love = New System.Windows.Forms.TextBox()
        Me.TextBox_Personal_hobby = New System.Windows.Forms.TextBox()
        Me.TextBox_Personal_presentation = New System.Windows.Forms.TextBox()
        Me.Label_Personal_presentation = New System.Windows.Forms.Label()
        Me.Label_Personal_wish = New System.Windows.Forms.Label()
        Me.Label_Personal_love = New System.Windows.Forms.Label()
        Me.Label_Personal_hobby = New System.Windows.Forms.Label()
        Me.Label_Content = New System.Windows.Forms.Label()
        Me.Label_Column = New System.Windows.Forms.Label()
        Me.StatusStrip_Info = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_Statu = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Msg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.Button_Next_item = New System.Windows.Forms.Button()
        Me.Button_Search = New System.Windows.Forms.Button()
        Me.TextBox_Search_Compellation = New System.Windows.Forms.TextBox()
        Me.Panel_Min = New System.Windows.Forms.Panel()
        Me.Panel_Close = New System.Windows.Forms.Panel()
        Me.ToolStrip_Info.SuspendLayout()
        Me.Panel_info_1.SuspendLayout()
        CType(Me.PictureBox_Photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Photo.SuspendLayout()
        Me.Panel_Menu.SuspendLayout()
        Me.Panel_info_4.SuspendLayout()
        Me.Panel_info_2.SuspendLayout()
        Me.Panel_info_3.SuspendLayout()
        Me.Panel_info_5.SuspendLayout()
        Me.StatusStrip_Info.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_Title
        '
        Me.Label_Title.AutoSize = True
        Me.Label_Title.BackColor = System.Drawing.Color.Transparent
        Me.Label_Title.Font = New System.Drawing.Font("宋体", 20.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_Title.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.Label_Title.Location = New System.Drawing.Point(12, 14)
        Me.Label_Title.Name = "Label_Title"
        Me.Label_Title.Size = New System.Drawing.Size(208, 27)
        Me.Label_Title.TabIndex = 0
        Me.Label_Title.Text = "个人校友录管理"
        '
        'ToolStrip_Info
        '
        Me.ToolStrip_Info.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip_Info.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip_Info.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip_Info.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_basic_information, Me.ToolStripSeparator1, Me.ToolStripLabel_contact_information, Me.ToolStripSeparator2, Me.ToolStripLabel_education_information, Me.ToolStripSeparator3, Me.ToolStripLabel_work_information, Me.ToolStripSeparator4, Me.ToolStripLabel_personal_information})
        Me.ToolStrip_Info.Location = New System.Drawing.Point(121, 48)
        Me.ToolStrip_Info.Name = "ToolStrip_Info"
        Me.ToolStrip_Info.Size = New System.Drawing.Size(307, 25)
        Me.ToolStrip_Info.TabIndex = 1
        Me.ToolStrip_Info.Text = "ToolStrip1"
        '
        'ToolStripLabel_basic_information
        '
        Me.ToolStripLabel_basic_information.IsLink = True
        Me.ToolStripLabel_basic_information.Name = "ToolStripLabel_basic_information"
        Me.ToolStripLabel_basic_information.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel_basic_information.Text = "基本资料"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_contact_information
        '
        Me.ToolStripLabel_contact_information.IsLink = True
        Me.ToolStripLabel_contact_information.Name = "ToolStripLabel_contact_information"
        Me.ToolStripLabel_contact_information.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel_contact_information.Text = "联系方式"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_education_information
        '
        Me.ToolStripLabel_education_information.IsLink = True
        Me.ToolStripLabel_education_information.Name = "ToolStripLabel_education_information"
        Me.ToolStripLabel_education_information.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel_education_information.Text = "教育情况"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_work_information
        '
        Me.ToolStripLabel_work_information.IsLink = True
        Me.ToolStripLabel_work_information.Name = "ToolStripLabel_work_information"
        Me.ToolStripLabel_work_information.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel_work_information.Text = "工作情况"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_personal_information
        '
        Me.ToolStripLabel_personal_information.IsLink = True
        Me.ToolStripLabel_personal_information.Name = "ToolStripLabel_personal_information"
        Me.ToolStripLabel_personal_information.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel_personal_information.Text = "个人信息"
        '
        'Panel_info_1
        '
        Me.Panel_info_1.BackColor = System.Drawing.Color.Transparent
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Twelve_animals)
        Me.Panel_info_1.Controls.Add(Me.Label_Twelve_animals)
        Me.Panel_info_1.Controls.Add(Me.Label_Birthday_day)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Birthday_day)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Live_town)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Live_county)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Hometown_town)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Hometown_county)
        Me.Panel_info_1.Controls.Add(Me.PictureBox_Photo)
        Me.Panel_info_1.Controls.Add(Me.Label_Birthday_month)
        Me.Panel_info_1.Controls.Add(Me.Label_Birthday_year)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Live_city)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Live_province)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Hometown_city)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Hometown_province)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Blood_type)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Birthday_month)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Birthday_year)
        Me.Panel_info_1.Controls.Add(Me.ComboBox_Marital_status)
        Me.Panel_info_1.Controls.Add(Me.RadioButton_Women)
        Me.Panel_info_1.Controls.Add(Me.RadioButton_Men)
        Me.Panel_info_1.Controls.Add(Me.TextBox_Compellation)
        Me.Panel_info_1.Controls.Add(Me.Label_Live)
        Me.Panel_info_1.Controls.Add(Me.Label_Hometown)
        Me.Panel_info_1.Controls.Add(Me.Label_Blood_type)
        Me.Panel_info_1.Controls.Add(Me.Label_Birthday)
        Me.Panel_info_1.Controls.Add(Me.Label_Marital_status)
        Me.Panel_info_1.Controls.Add(Me.Label_Sex)
        Me.Panel_info_1.Controls.Add(Me.Label_Compellation)
        Me.Panel_info_1.Location = New System.Drawing.Point(87, 77)
        Me.Panel_info_1.Name = "Panel_info_1"
        Me.Panel_info_1.Size = New System.Drawing.Size(441, 231)
        Me.Panel_info_1.TabIndex = 3
        '
        'ComboBox_Twelve_animals
        '
        Me.ComboBox_Twelve_animals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Twelve_animals.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Twelve_animals.FormattingEnabled = True
        Me.ComboBox_Twelve_animals.Location = New System.Drawing.Point(81, 90)
        Me.ComboBox_Twelve_animals.Name = "ComboBox_Twelve_animals"
        Me.ComboBox_Twelve_animals.Size = New System.Drawing.Size(64, 20)
        Me.ComboBox_Twelve_animals.TabIndex = 5
        '
        'Label_Twelve_animals
        '
        Me.Label_Twelve_animals.AutoSize = True
        Me.Label_Twelve_animals.Location = New System.Drawing.Point(40, 93)
        Me.Label_Twelve_animals.Name = "Label_Twelve_animals"
        Me.Label_Twelve_animals.Size = New System.Drawing.Size(35, 12)
        Me.Label_Twelve_animals.TabIndex = 17
        Me.Label_Twelve_animals.Text = "生肖:"
        '
        'Label_Birthday_day
        '
        Me.Label_Birthday_day.AutoSize = True
        Me.Label_Birthday_day.Location = New System.Drawing.Point(319, 122)
        Me.Label_Birthday_day.Name = "Label_Birthday_day"
        Me.Label_Birthday_day.Size = New System.Drawing.Size(17, 12)
        Me.Label_Birthday_day.TabIndex = 0
        Me.Label_Birthday_day.Text = "日"
        '
        'ComboBox_Birthday_day
        '
        Me.ComboBox_Birthday_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Birthday_day.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Birthday_day.FormattingEnabled = True
        Me.ComboBox_Birthday_day.Location = New System.Drawing.Point(258, 119)
        Me.ComboBox_Birthday_day.Name = "ComboBox_Birthday_day"
        Me.ComboBox_Birthday_day.Size = New System.Drawing.Size(55, 20)
        Me.ComboBox_Birthday_day.TabIndex = 8
        '
        'ComboBox_Live_town
        '
        Me.ComboBox_Live_town.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Live_town.FormattingEnabled = True
        Me.ComboBox_Live_town.Location = New System.Drawing.Point(336, 202)
        Me.ComboBox_Live_town.Name = "ComboBox_Live_town"
        Me.ComboBox_Live_town.Size = New System.Drawing.Size(79, 20)
        Me.ComboBox_Live_town.TabIndex = 17
        '
        'ComboBox_Live_county
        '
        Me.ComboBox_Live_county.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Live_county.FormattingEnabled = True
        Me.ComboBox_Live_county.Location = New System.Drawing.Point(251, 202)
        Me.ComboBox_Live_county.Name = "ComboBox_Live_county"
        Me.ComboBox_Live_county.Size = New System.Drawing.Size(79, 20)
        Me.ComboBox_Live_county.TabIndex = 16
        '
        'ComboBox_Hometown_town
        '
        Me.ComboBox_Hometown_town.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Hometown_town.FormattingEnabled = True
        Me.ComboBox_Hometown_town.Location = New System.Drawing.Point(336, 175)
        Me.ComboBox_Hometown_town.Name = "ComboBox_Hometown_town"
        Me.ComboBox_Hometown_town.Size = New System.Drawing.Size(79, 20)
        Me.ComboBox_Hometown_town.TabIndex = 13
        '
        'ComboBox_Hometown_county
        '
        Me.ComboBox_Hometown_county.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Hometown_county.FormattingEnabled = True
        Me.ComboBox_Hometown_county.Location = New System.Drawing.Point(251, 175)
        Me.ComboBox_Hometown_county.Name = "ComboBox_Hometown_county"
        Me.ComboBox_Hometown_county.Size = New System.Drawing.Size(79, 20)
        Me.ComboBox_Hometown_county.TabIndex = 12
        '
        'PictureBox_Photo
        '
        Me.PictureBox_Photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Photo.ContextMenuStrip = Me.ContextMenuStrip_Photo
        Me.PictureBox_Photo.Location = New System.Drawing.Point(226, 6)
        Me.PictureBox_Photo.Name = "PictureBox_Photo"
        Me.PictureBox_Photo.Size = New System.Drawing.Size(105, 105)
        Me.PictureBox_Photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Photo.TabIndex = 0
        Me.PictureBox_Photo.TabStop = False
        '
        'ContextMenuStrip_Photo
        '
        Me.ContextMenuStrip_Photo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Add_Photo, Me.ToolStripSeparator5, Me.ToolStripMenuItem_Delete_Photo})
        Me.ContextMenuStrip_Photo.Name = "ContextMenuStrip_Photo"
        Me.ContextMenuStrip_Photo.Size = New System.Drawing.Size(125, 54)
        '
        'ToolStripMenuItem_Add_Photo
        '
        Me.ToolStripMenuItem_Add_Photo.Name = "ToolStripMenuItem_Add_Photo"
        Me.ToolStripMenuItem_Add_Photo.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem_Add_Photo.Text = "添改图片"
        Me.ToolStripMenuItem_Add_Photo.ToolTipText = "添加或者修改头像"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(121, 6)
        '
        'ToolStripMenuItem_Delete_Photo
        '
        Me.ToolStripMenuItem_Delete_Photo.Name = "ToolStripMenuItem_Delete_Photo"
        Me.ToolStripMenuItem_Delete_Photo.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem_Delete_Photo.Text = "清除图片"
        Me.ToolStripMenuItem_Delete_Photo.ToolTipText = "清空头像信息"
        '
        'Label_Birthday_month
        '
        Me.Label_Birthday_month.AutoSize = True
        Me.Label_Birthday_month.Location = New System.Drawing.Point(235, 122)
        Me.Label_Birthday_month.Name = "Label_Birthday_month"
        Me.Label_Birthday_month.Size = New System.Drawing.Size(17, 12)
        Me.Label_Birthday_month.TabIndex = 0
        Me.Label_Birthday_month.Text = "月"
        '
        'Label_Birthday_year
        '
        Me.Label_Birthday_year.AutoSize = True
        Me.Label_Birthday_year.Location = New System.Drawing.Point(151, 122)
        Me.Label_Birthday_year.Name = "Label_Birthday_year"
        Me.Label_Birthday_year.Size = New System.Drawing.Size(17, 12)
        Me.Label_Birthday_year.TabIndex = 0
        Me.Label_Birthday_year.Text = "年"
        '
        'ComboBox_Live_city
        '
        Me.ComboBox_Live_city.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Live_city.FormattingEnabled = True
        Me.ComboBox_Live_city.Location = New System.Drawing.Point(166, 202)
        Me.ComboBox_Live_city.Name = "ComboBox_Live_city"
        Me.ComboBox_Live_city.Size = New System.Drawing.Size(79, 20)
        Me.ComboBox_Live_city.TabIndex = 15
        '
        'ComboBox_Live_province
        '
        Me.ComboBox_Live_province.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Live_province.FormattingEnabled = True
        Me.ComboBox_Live_province.Location = New System.Drawing.Point(81, 202)
        Me.ComboBox_Live_province.Name = "ComboBox_Live_province"
        Me.ComboBox_Live_province.Size = New System.Drawing.Size(79, 20)
        Me.ComboBox_Live_province.TabIndex = 14
        '
        'ComboBox_Hometown_city
        '
        Me.ComboBox_Hometown_city.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Hometown_city.FormattingEnabled = True
        Me.ComboBox_Hometown_city.Location = New System.Drawing.Point(166, 175)
        Me.ComboBox_Hometown_city.Name = "ComboBox_Hometown_city"
        Me.ComboBox_Hometown_city.Size = New System.Drawing.Size(79, 20)
        Me.ComboBox_Hometown_city.TabIndex = 11
        '
        'ComboBox_Hometown_province
        '
        Me.ComboBox_Hometown_province.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Hometown_province.FormattingEnabled = True
        Me.ComboBox_Hometown_province.Location = New System.Drawing.Point(81, 175)
        Me.ComboBox_Hometown_province.Name = "ComboBox_Hometown_province"
        Me.ComboBox_Hometown_province.Size = New System.Drawing.Size(79, 20)
        Me.ComboBox_Hometown_province.TabIndex = 10
        '
        'ComboBox_Blood_type
        '
        Me.ComboBox_Blood_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Blood_type.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Blood_type.FormattingEnabled = True
        Me.ComboBox_Blood_type.Location = New System.Drawing.Point(81, 146)
        Me.ComboBox_Blood_type.Name = "ComboBox_Blood_type"
        Me.ComboBox_Blood_type.Size = New System.Drawing.Size(64, 20)
        Me.ComboBox_Blood_type.TabIndex = 9
        '
        'ComboBox_Birthday_month
        '
        Me.ComboBox_Birthday_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Birthday_month.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Birthday_month.FormattingEnabled = True
        Me.ComboBox_Birthday_month.Location = New System.Drawing.Point(174, 119)
        Me.ComboBox_Birthday_month.Name = "ComboBox_Birthday_month"
        Me.ComboBox_Birthday_month.Size = New System.Drawing.Size(55, 20)
        Me.ComboBox_Birthday_month.TabIndex = 7
        '
        'ComboBox_Birthday_year
        '
        Me.ComboBox_Birthday_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Birthday_year.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Birthday_year.FormattingEnabled = True
        Me.ComboBox_Birthday_year.Location = New System.Drawing.Point(81, 119)
        Me.ComboBox_Birthday_year.Name = "ComboBox_Birthday_year"
        Me.ComboBox_Birthday_year.Size = New System.Drawing.Size(64, 20)
        Me.ComboBox_Birthday_year.TabIndex = 6
        '
        'ComboBox_Marital_status
        '
        Me.ComboBox_Marital_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Marital_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Marital_status.FormattingEnabled = True
        Me.ComboBox_Marital_status.Location = New System.Drawing.Point(81, 61)
        Me.ComboBox_Marital_status.Name = "ComboBox_Marital_status"
        Me.ComboBox_Marital_status.Size = New System.Drawing.Size(64, 20)
        Me.ComboBox_Marital_status.TabIndex = 4
        '
        'RadioButton_Women
        '
        Me.RadioButton_Women.AutoSize = True
        Me.RadioButton_Women.Location = New System.Drawing.Point(122, 37)
        Me.RadioButton_Women.Name = "RadioButton_Women"
        Me.RadioButton_Women.Size = New System.Drawing.Size(35, 16)
        Me.RadioButton_Women.TabIndex = 3
        Me.RadioButton_Women.Text = "女"
        Me.RadioButton_Women.UseVisualStyleBackColor = True
        '
        'RadioButton_Men
        '
        Me.RadioButton_Men.AutoSize = True
        Me.RadioButton_Men.Location = New System.Drawing.Point(81, 37)
        Me.RadioButton_Men.Name = "RadioButton_Men"
        Me.RadioButton_Men.Size = New System.Drawing.Size(35, 16)
        Me.RadioButton_Men.TabIndex = 2
        Me.RadioButton_Men.Text = "男"
        Me.RadioButton_Men.UseVisualStyleBackColor = True
        '
        'TextBox_Compellation
        '
        Me.TextBox_Compellation.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TextBox_Compellation.Location = New System.Drawing.Point(81, 9)
        Me.TextBox_Compellation.MaxLength = 254
        Me.TextBox_Compellation.Name = "TextBox_Compellation"
        Me.TextBox_Compellation.Size = New System.Drawing.Size(133, 21)
        Me.TextBox_Compellation.TabIndex = 1
        '
        'Label_Live
        '
        Me.Label_Live.AutoSize = True
        Me.Label_Live.Location = New System.Drawing.Point(28, 205)
        Me.Label_Live.Name = "Label_Live"
        Me.Label_Live.Size = New System.Drawing.Size(47, 12)
        Me.Label_Live.TabIndex = 0
        Me.Label_Live.Text = "居住地:"
        '
        'Label_Hometown
        '
        Me.Label_Hometown.AutoSize = True
        Me.Label_Hometown.Location = New System.Drawing.Point(40, 178)
        Me.Label_Hometown.Name = "Label_Hometown"
        Me.Label_Hometown.Size = New System.Drawing.Size(35, 12)
        Me.Label_Hometown.TabIndex = 0
        Me.Label_Hometown.Text = "家乡:"
        '
        'Label_Blood_type
        '
        Me.Label_Blood_type.AutoSize = True
        Me.Label_Blood_type.Location = New System.Drawing.Point(40, 149)
        Me.Label_Blood_type.Name = "Label_Blood_type"
        Me.Label_Blood_type.Size = New System.Drawing.Size(35, 12)
        Me.Label_Blood_type.TabIndex = 0
        Me.Label_Blood_type.Text = "血型:"
        '
        'Label_Birthday
        '
        Me.Label_Birthday.AutoSize = True
        Me.Label_Birthday.Location = New System.Drawing.Point(40, 122)
        Me.Label_Birthday.Name = "Label_Birthday"
        Me.Label_Birthday.Size = New System.Drawing.Size(35, 12)
        Me.Label_Birthday.TabIndex = 0
        Me.Label_Birthday.Text = "生日:"
        '
        'Label_Marital_status
        '
        Me.Label_Marital_status.AutoSize = True
        Me.Label_Marital_status.Location = New System.Drawing.Point(16, 64)
        Me.Label_Marital_status.Name = "Label_Marital_status"
        Me.Label_Marital_status.Size = New System.Drawing.Size(59, 12)
        Me.Label_Marital_status.TabIndex = 0
        Me.Label_Marital_status.Text = "婚姻状况:"
        '
        'Label_Sex
        '
        Me.Label_Sex.AutoSize = True
        Me.Label_Sex.Location = New System.Drawing.Point(40, 39)
        Me.Label_Sex.Name = "Label_Sex"
        Me.Label_Sex.Size = New System.Drawing.Size(35, 12)
        Me.Label_Sex.TabIndex = 0
        Me.Label_Sex.Text = "性别:"
        '
        'Label_Compellation
        '
        Me.Label_Compellation.AutoSize = True
        Me.Label_Compellation.Location = New System.Drawing.Point(40, 12)
        Me.Label_Compellation.Name = "Label_Compellation"
        Me.Label_Compellation.Size = New System.Drawing.Size(35, 12)
        Me.Label_Compellation.TabIndex = 0
        Me.Label_Compellation.Text = "姓名:"
        '
        'Panel_Menu
        '
        Me.Panel_Menu.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Menu.Controls.Add(Me.Button_OK)
        Me.Panel_Menu.Controls.Add(Me.Button_Setting)
        Me.Panel_Menu.Controls.Add(Me.Button_Delete)
        Me.Panel_Menu.Controls.Add(Me.Button_Modify)
        Me.Panel_Menu.Controls.Add(Me.Button_Add)
        Me.Panel_Menu.Controls.Add(Me.Button_Query)
        Me.Panel_Menu.Location = New System.Drawing.Point(-82, 95)
        Me.Panel_Menu.Name = "Panel_Menu"
        Me.Panel_Menu.Size = New System.Drawing.Size(101, 198)
        Me.Panel_Menu.TabIndex = 2
        '
        'Button_OK
        '
        Me.Button_OK.BackColor = System.Drawing.Color.LightSlateGray
        Me.Button_OK.FlatAppearance.BorderSize = 0
        Me.Button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_OK.Location = New System.Drawing.Point(83, 70)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(12, 59)
        Me.Button_OK.TabIndex = 0
        Me.Button_OK.Text = "▓▓▓"
        Me.Button_OK.UseVisualStyleBackColor = False
        '
        'Button_Setting
        '
        Me.Button_Setting.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown
        Me.Button_Setting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Setting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush
        Me.Button_Setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Setting.Location = New System.Drawing.Point(5, 155)
        Me.Button_Setting.Name = "Button_Setting"
        Me.Button_Setting.Size = New System.Drawing.Size(72, 29)
        Me.Button_Setting.TabIndex = 5
        Me.Button_Setting.Text = "设  置"
        Me.Button_Setting.UseVisualStyleBackColor = True
        '
        'Button_Delete
        '
        Me.Button_Delete.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown
        Me.Button_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush
        Me.Button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Delete.Location = New System.Drawing.Point(5, 120)
        Me.Button_Delete.Name = "Button_Delete"
        Me.Button_Delete.Size = New System.Drawing.Size(72, 29)
        Me.Button_Delete.TabIndex = 4
        Me.Button_Delete.Text = "删  除"
        Me.Button_Delete.UseVisualStyleBackColor = True
        '
        'Button_Modify
        '
        Me.Button_Modify.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown
        Me.Button_Modify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Modify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush
        Me.Button_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Modify.Location = New System.Drawing.Point(5, 85)
        Me.Button_Modify.Name = "Button_Modify"
        Me.Button_Modify.Size = New System.Drawing.Size(72, 29)
        Me.Button_Modify.TabIndex = 3
        Me.Button_Modify.Text = "修  改"
        Me.Button_Modify.UseVisualStyleBackColor = True
        '
        'Button_Add
        '
        Me.Button_Add.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown
        Me.Button_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush
        Me.Button_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Add.Location = New System.Drawing.Point(5, 50)
        Me.Button_Add.Name = "Button_Add"
        Me.Button_Add.Size = New System.Drawing.Size(72, 29)
        Me.Button_Add.TabIndex = 2
        Me.Button_Add.Text = "添  加"
        Me.Button_Add.UseVisualStyleBackColor = True
        '
        'Button_Query
        '
        Me.Button_Query.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown
        Me.Button_Query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush
        Me.Button_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Query.Location = New System.Drawing.Point(5, 15)
        Me.Button_Query.Name = "Button_Query"
        Me.Button_Query.Size = New System.Drawing.Size(72, 29)
        Me.Button_Query.TabIndex = 1
        Me.Button_Query.Text = "查  询"
        Me.Button_Query.UseVisualStyleBackColor = True
        '
        'Panel_info_4
        '
        Me.Panel_info_4.BackColor = System.Drawing.Color.Transparent
        Me.Panel_info_4.Controls.Add(Me.Label_finish_month)
        Me.Panel_info_4.Controls.Add(Me.Label_finish_year)
        Me.Panel_info_4.Controls.Add(Me.Label_begin_month)
        Me.Panel_info_4.Controls.Add(Me.Label_begin_year)
        Me.Panel_info_4.Controls.Add(Me.Label_Worktime_begin_year)
        Me.Panel_info_4.Controls.Add(Me.Label_Department)
        Me.Panel_info_4.Controls.Add(Me.Label_Company_name)
        Me.Panel_info_4.Controls.Add(Me.ComboBox_Worktime_finish_month)
        Me.Panel_info_4.Controls.Add(Me.ComboBox_Worktime_finish_year)
        Me.Panel_info_4.Controls.Add(Me.ComboBox_Worktime_begin_month)
        Me.Panel_info_4.Controls.Add(Me.ComboBox_Worktime_begin_year)
        Me.Panel_info_4.Controls.Add(Me.TextBox_Department)
        Me.Panel_info_4.Controls.Add(Me.TextBox_Company_name)
        Me.Panel_info_4.Location = New System.Drawing.Point(107, 77)
        Me.Panel_info_4.Name = "Panel_info_4"
        Me.Panel_info_4.Size = New System.Drawing.Size(441, 231)
        Me.Panel_info_4.TabIndex = 6
        '
        'Label_finish_month
        '
        Me.Label_finish_month.AutoSize = True
        Me.Label_finish_month.Location = New System.Drawing.Point(269, 158)
        Me.Label_finish_month.Name = "Label_finish_month"
        Me.Label_finish_month.Size = New System.Drawing.Size(17, 12)
        Me.Label_finish_month.TabIndex = 0
        Me.Label_finish_month.Text = "月"
        '
        'Label_finish_year
        '
        Me.Label_finish_year.AutoSize = True
        Me.Label_finish_year.Location = New System.Drawing.Point(185, 158)
        Me.Label_finish_year.Name = "Label_finish_year"
        Me.Label_finish_year.Size = New System.Drawing.Size(17, 12)
        Me.Label_finish_year.TabIndex = 0
        Me.Label_finish_year.Text = "年"
        '
        'Label_begin_month
        '
        Me.Label_begin_month.AutoSize = True
        Me.Label_begin_month.Location = New System.Drawing.Point(269, 132)
        Me.Label_begin_month.Name = "Label_begin_month"
        Me.Label_begin_month.Size = New System.Drawing.Size(29, 12)
        Me.Label_begin_month.TabIndex = 0
        Me.Label_begin_month.Text = "月 ~"
        '
        'Label_begin_year
        '
        Me.Label_begin_year.AutoSize = True
        Me.Label_begin_year.Location = New System.Drawing.Point(185, 132)
        Me.Label_begin_year.Name = "Label_begin_year"
        Me.Label_begin_year.Size = New System.Drawing.Size(17, 12)
        Me.Label_begin_year.TabIndex = 0
        Me.Label_begin_year.Text = "年"
        '
        'Label_Worktime_begin_year
        '
        Me.Label_Worktime_begin_year.AutoSize = True
        Me.Label_Worktime_begin_year.Location = New System.Drawing.Point(50, 132)
        Me.Label_Worktime_begin_year.Name = "Label_Worktime_begin_year"
        Me.Label_Worktime_begin_year.Size = New System.Drawing.Size(59, 12)
        Me.Label_Worktime_begin_year.TabIndex = 0
        Me.Label_Worktime_begin_year.Text = "工作时间:"
        '
        'Label_Department
        '
        Me.Label_Department.AutoSize = True
        Me.Label_Department.Location = New System.Drawing.Point(74, 80)
        Me.Label_Department.Name = "Label_Department"
        Me.Label_Department.Size = New System.Drawing.Size(35, 12)
        Me.Label_Department.TabIndex = 0
        Me.Label_Department.Text = "部门:"
        '
        'Label_Company_name
        '
        Me.Label_Company_name.AutoSize = True
        Me.Label_Company_name.Location = New System.Drawing.Point(40, 28)
        Me.Label_Company_name.Name = "Label_Company_name"
        Me.Label_Company_name.Size = New System.Drawing.Size(71, 12)
        Me.Label_Company_name.TabIndex = 0
        Me.Label_Company_name.Text = "公司或机构:"
        '
        'ComboBox_Worktime_finish_month
        '
        Me.ComboBox_Worktime_finish_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Worktime_finish_month.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Worktime_finish_month.FormattingEnabled = True
        Me.ComboBox_Worktime_finish_month.Location = New System.Drawing.Point(208, 155)
        Me.ComboBox_Worktime_finish_month.Name = "ComboBox_Worktime_finish_month"
        Me.ComboBox_Worktime_finish_month.Size = New System.Drawing.Size(55, 20)
        Me.ComboBox_Worktime_finish_month.TabIndex = 6
        '
        'ComboBox_Worktime_finish_year
        '
        Me.ComboBox_Worktime_finish_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Worktime_finish_year.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Worktime_finish_year.FormattingEnabled = True
        Me.ComboBox_Worktime_finish_year.Location = New System.Drawing.Point(115, 155)
        Me.ComboBox_Worktime_finish_year.Name = "ComboBox_Worktime_finish_year"
        Me.ComboBox_Worktime_finish_year.Size = New System.Drawing.Size(64, 20)
        Me.ComboBox_Worktime_finish_year.TabIndex = 5
        '
        'ComboBox_Worktime_begin_month
        '
        Me.ComboBox_Worktime_begin_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Worktime_begin_month.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Worktime_begin_month.FormattingEnabled = True
        Me.ComboBox_Worktime_begin_month.Location = New System.Drawing.Point(208, 129)
        Me.ComboBox_Worktime_begin_month.Name = "ComboBox_Worktime_begin_month"
        Me.ComboBox_Worktime_begin_month.Size = New System.Drawing.Size(55, 20)
        Me.ComboBox_Worktime_begin_month.TabIndex = 4
        '
        'ComboBox_Worktime_begin_year
        '
        Me.ComboBox_Worktime_begin_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Worktime_begin_year.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Worktime_begin_year.FormattingEnabled = True
        Me.ComboBox_Worktime_begin_year.Location = New System.Drawing.Point(115, 129)
        Me.ComboBox_Worktime_begin_year.Name = "ComboBox_Worktime_begin_year"
        Me.ComboBox_Worktime_begin_year.Size = New System.Drawing.Size(64, 20)
        Me.ComboBox_Worktime_begin_year.TabIndex = 3
        '
        'TextBox_Department
        '
        Me.TextBox_Department.Location = New System.Drawing.Point(115, 77)
        Me.TextBox_Department.MaxLength = 204
        Me.TextBox_Department.Name = "TextBox_Department"
        Me.TextBox_Department.Size = New System.Drawing.Size(133, 21)
        Me.TextBox_Department.TabIndex = 2
        '
        'TextBox_Company_name
        '
        Me.TextBox_Company_name.Location = New System.Drawing.Point(115, 25)
        Me.TextBox_Company_name.MaxLength = 254
        Me.TextBox_Company_name.Name = "TextBox_Company_name"
        Me.TextBox_Company_name.Size = New System.Drawing.Size(133, 21)
        Me.TextBox_Company_name.TabIndex = 1
        '
        'Panel_info_2
        '
        Me.Panel_info_2.BackColor = System.Drawing.Color.Transparent
        Me.Panel_info_2.Controls.Add(Me.TextBox_Other_number)
        Me.Panel_info_2.Controls.Add(Me.TextBox_Msn_number)
        Me.Panel_info_2.Controls.Add(Me.TextBox_Qq_number)
        Me.Panel_info_2.Controls.Add(Me.TextBox_Mobile_number)
        Me.Panel_info_2.Controls.Add(Me.TextBox_Email_address)
        Me.Panel_info_2.Controls.Add(Me.Label_Other_number)
        Me.Panel_info_2.Controls.Add(Me.Label_Msn_number)
        Me.Panel_info_2.Controls.Add(Me.Label_Qq_number)
        Me.Panel_info_2.Controls.Add(Me.Label_Mobile_number)
        Me.Panel_info_2.Controls.Add(Me.Label_Email_address)
        Me.Panel_info_2.Location = New System.Drawing.Point(107, 77)
        Me.Panel_info_2.Name = "Panel_info_2"
        Me.Panel_info_2.Size = New System.Drawing.Size(441, 231)
        Me.Panel_info_2.TabIndex = 4
        '
        'TextBox_Other_number
        '
        Me.TextBox_Other_number.Location = New System.Drawing.Point(113, 171)
        Me.TextBox_Other_number.MaxLength = 254
        Me.TextBox_Other_number.Name = "TextBox_Other_number"
        Me.TextBox_Other_number.Size = New System.Drawing.Size(173, 21)
        Me.TextBox_Other_number.TabIndex = 5
        '
        'TextBox_Msn_number
        '
        Me.TextBox_Msn_number.Location = New System.Drawing.Point(113, 136)
        Me.TextBox_Msn_number.MaxLength = 254
        Me.TextBox_Msn_number.Name = "TextBox_Msn_number"
        Me.TextBox_Msn_number.Size = New System.Drawing.Size(173, 21)
        Me.TextBox_Msn_number.TabIndex = 4
        '
        'TextBox_Qq_number
        '
        Me.TextBox_Qq_number.Location = New System.Drawing.Point(113, 101)
        Me.TextBox_Qq_number.MaxLength = 254
        Me.TextBox_Qq_number.Name = "TextBox_Qq_number"
        Me.TextBox_Qq_number.Size = New System.Drawing.Size(173, 21)
        Me.TextBox_Qq_number.TabIndex = 3
        '
        'TextBox_Mobile_number
        '
        Me.TextBox_Mobile_number.Location = New System.Drawing.Point(113, 63)
        Me.TextBox_Mobile_number.MaxLength = 254
        Me.TextBox_Mobile_number.Name = "TextBox_Mobile_number"
        Me.TextBox_Mobile_number.Size = New System.Drawing.Size(173, 21)
        Me.TextBox_Mobile_number.TabIndex = 2
        '
        'TextBox_Email_address
        '
        Me.TextBox_Email_address.Location = New System.Drawing.Point(113, 28)
        Me.TextBox_Email_address.MaxLength = 254
        Me.TextBox_Email_address.Name = "TextBox_Email_address"
        Me.TextBox_Email_address.Size = New System.Drawing.Size(173, 21)
        Me.TextBox_Email_address.TabIndex = 1
        '
        'Label_Other_number
        '
        Me.Label_Other_number.AutoSize = True
        Me.Label_Other_number.Location = New System.Drawing.Point(72, 174)
        Me.Label_Other_number.Name = "Label_Other_number"
        Me.Label_Other_number.Size = New System.Drawing.Size(35, 12)
        Me.Label_Other_number.TabIndex = 0
        Me.Label_Other_number.Text = "其他:"
        '
        'Label_Msn_number
        '
        Me.Label_Msn_number.AutoSize = True
        Me.Label_Msn_number.Location = New System.Drawing.Point(78, 139)
        Me.Label_Msn_number.Name = "Label_Msn_number"
        Me.Label_Msn_number.Size = New System.Drawing.Size(29, 12)
        Me.Label_Msn_number.TabIndex = 0
        Me.Label_Msn_number.Text = "MSN:"
        '
        'Label_Qq_number
        '
        Me.Label_Qq_number.AutoSize = True
        Me.Label_Qq_number.Location = New System.Drawing.Point(84, 104)
        Me.Label_Qq_number.Name = "Label_Qq_number"
        Me.Label_Qq_number.Size = New System.Drawing.Size(23, 12)
        Me.Label_Qq_number.TabIndex = 0
        Me.Label_Qq_number.Text = "QQ:"
        '
        'Label_Mobile_number
        '
        Me.Label_Mobile_number.AutoSize = True
        Me.Label_Mobile_number.Location = New System.Drawing.Point(72, 66)
        Me.Label_Mobile_number.Name = "Label_Mobile_number"
        Me.Label_Mobile_number.Size = New System.Drawing.Size(35, 12)
        Me.Label_Mobile_number.TabIndex = 0
        Me.Label_Mobile_number.Text = "手机:"
        '
        'Label_Email_address
        '
        Me.Label_Email_address.AutoSize = True
        Me.Label_Email_address.Location = New System.Drawing.Point(48, 31)
        Me.Label_Email_address.Name = "Label_Email_address"
        Me.Label_Email_address.Size = New System.Drawing.Size(59, 12)
        Me.Label_Email_address.TabIndex = 0
        Me.Label_Email_address.Text = "电子邮箱:"
        '
        'Panel_info_3
        '
        Me.Panel_info_3.BackColor = System.Drawing.Color.Transparent
        Me.Panel_info_3.Controls.Add(Me.ComboBox_Entrance_school_year)
        Me.Panel_info_3.Controls.Add(Me.Label_Year)
        Me.Panel_info_3.Controls.Add(Me.TextBox_Class_name)
        Me.Panel_info_3.Controls.Add(Me.TextBox_School_name)
        Me.Panel_info_3.Controls.Add(Me.Label_Entrance_school_year)
        Me.Panel_info_3.Controls.Add(Me.Label_Class_name)
        Me.Panel_info_3.Controls.Add(Me.Label_School_name)
        Me.Panel_info_3.Location = New System.Drawing.Point(97, 77)
        Me.Panel_info_3.Name = "Panel_info_3"
        Me.Panel_info_3.Size = New System.Drawing.Size(441, 231)
        Me.Panel_info_3.TabIndex = 5
        '
        'ComboBox_Entrance_school_year
        '
        Me.ComboBox_Entrance_school_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Entrance_school_year.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox_Entrance_school_year.FormattingEnabled = True
        Me.ComboBox_Entrance_school_year.Location = New System.Drawing.Point(152, 154)
        Me.ComboBox_Entrance_school_year.Name = "ComboBox_Entrance_school_year"
        Me.ComboBox_Entrance_school_year.Size = New System.Drawing.Size(64, 20)
        Me.ComboBox_Entrance_school_year.TabIndex = 3
        '
        'Label_Year
        '
        Me.Label_Year.AutoSize = True
        Me.Label_Year.Location = New System.Drawing.Point(222, 157)
        Me.Label_Year.Name = "Label_Year"
        Me.Label_Year.Size = New System.Drawing.Size(17, 12)
        Me.Label_Year.TabIndex = 0
        Me.Label_Year.Text = "年"
        '
        'TextBox_Class_name
        '
        Me.TextBox_Class_name.Location = New System.Drawing.Point(152, 97)
        Me.TextBox_Class_name.MaxLength = 254
        Me.TextBox_Class_name.Name = "TextBox_Class_name"
        Me.TextBox_Class_name.Size = New System.Drawing.Size(133, 21)
        Me.TextBox_Class_name.TabIndex = 2
        '
        'TextBox_School_name
        '
        Me.TextBox_School_name.Location = New System.Drawing.Point(152, 40)
        Me.TextBox_School_name.MaxLength = 254
        Me.TextBox_School_name.Name = "TextBox_School_name"
        Me.TextBox_School_name.Size = New System.Drawing.Size(133, 21)
        Me.TextBox_School_name.TabIndex = 1
        '
        'Label_Entrance_school_year
        '
        Me.Label_Entrance_school_year.AutoSize = True
        Me.Label_Entrance_school_year.Location = New System.Drawing.Point(87, 157)
        Me.Label_Entrance_school_year.Name = "Label_Entrance_school_year"
        Me.Label_Entrance_school_year.Size = New System.Drawing.Size(59, 12)
        Me.Label_Entrance_school_year.TabIndex = 0
        Me.Label_Entrance_school_year.Text = "入学年份:"
        '
        'Label_Class_name
        '
        Me.Label_Class_name.AutoSize = True
        Me.Label_Class_name.Location = New System.Drawing.Point(75, 100)
        Me.Label_Class_name.Name = "Label_Class_name"
        Me.Label_Class_name.Size = New System.Drawing.Size(71, 12)
        Me.Label_Class_name.TabIndex = 0
        Me.Label_Class_name.Text = "班级或院系:"
        '
        'Label_School_name
        '
        Me.Label_School_name.AutoSize = True
        Me.Label_School_name.Location = New System.Drawing.Point(87, 43)
        Me.Label_School_name.Name = "Label_School_name"
        Me.Label_School_name.Size = New System.Drawing.Size(59, 12)
        Me.Label_School_name.TabIndex = 0
        Me.Label_School_name.Text = "学校名称:"
        '
        'Panel_info_5
        '
        Me.Panel_info_5.BackColor = System.Drawing.Color.Transparent
        Me.Panel_info_5.Controls.Add(Me.TextBox_Personal_wish)
        Me.Panel_info_5.Controls.Add(Me.TextBox_Personal_love)
        Me.Panel_info_5.Controls.Add(Me.TextBox_Personal_hobby)
        Me.Panel_info_5.Controls.Add(Me.TextBox_Personal_presentation)
        Me.Panel_info_5.Controls.Add(Me.Label_Personal_presentation)
        Me.Panel_info_5.Controls.Add(Me.Label_Personal_wish)
        Me.Panel_info_5.Controls.Add(Me.Label_Personal_love)
        Me.Panel_info_5.Controls.Add(Me.Label_Personal_hobby)
        Me.Panel_info_5.Controls.Add(Me.Label_Content)
        Me.Panel_info_5.Controls.Add(Me.Label_Column)
        Me.Panel_info_5.Location = New System.Drawing.Point(97, 77)
        Me.Panel_info_5.Name = "Panel_info_5"
        Me.Panel_info_5.Size = New System.Drawing.Size(441, 231)
        Me.Panel_info_5.TabIndex = 7
        '
        'TextBox_Personal_wish
        '
        Me.TextBox_Personal_wish.Location = New System.Drawing.Point(105, 109)
        Me.TextBox_Personal_wish.MaxLength = 254
        Me.TextBox_Personal_wish.Name = "TextBox_Personal_wish"
        Me.TextBox_Personal_wish.Size = New System.Drawing.Size(290, 21)
        Me.TextBox_Personal_wish.TabIndex = 3
        '
        'TextBox_Personal_love
        '
        Me.TextBox_Personal_love.Location = New System.Drawing.Point(105, 78)
        Me.TextBox_Personal_love.MaxLength = 254
        Me.TextBox_Personal_love.Name = "TextBox_Personal_love"
        Me.TextBox_Personal_love.Size = New System.Drawing.Size(290, 21)
        Me.TextBox_Personal_love.TabIndex = 2
        '
        'TextBox_Personal_hobby
        '
        Me.TextBox_Personal_hobby.Location = New System.Drawing.Point(105, 47)
        Me.TextBox_Personal_hobby.MaxLength = 254
        Me.TextBox_Personal_hobby.Name = "TextBox_Personal_hobby"
        Me.TextBox_Personal_hobby.Size = New System.Drawing.Size(290, 21)
        Me.TextBox_Personal_hobby.TabIndex = 1
        '
        'TextBox_Personal_presentation
        '
        Me.TextBox_Personal_presentation.Location = New System.Drawing.Point(105, 140)
        Me.TextBox_Personal_presentation.MaxLength = 254
        Me.TextBox_Personal_presentation.Multiline = True
        Me.TextBox_Personal_presentation.Name = "TextBox_Personal_presentation"
        Me.TextBox_Personal_presentation.Size = New System.Drawing.Size(290, 55)
        Me.TextBox_Personal_presentation.TabIndex = 4
        '
        'Label_Personal_presentation
        '
        Me.Label_Personal_presentation.AutoSize = True
        Me.Label_Personal_presentation.Location = New System.Drawing.Point(40, 160)
        Me.Label_Personal_presentation.Name = "Label_Personal_presentation"
        Me.Label_Personal_presentation.Size = New System.Drawing.Size(59, 12)
        Me.Label_Personal_presentation.TabIndex = 0
        Me.Label_Personal_presentation.Text = "简单介绍:"
        '
        'Label_Personal_wish
        '
        Me.Label_Personal_wish.AutoSize = True
        Me.Label_Personal_wish.Location = New System.Drawing.Point(28, 112)
        Me.Label_Personal_wish.Name = "Label_Personal_wish"
        Me.Label_Personal_wish.Size = New System.Drawing.Size(71, 12)
        Me.Label_Personal_wish.TabIndex = 0
        Me.Label_Personal_wish.Text = "最大的心愿:"
        '
        'Label_Personal_love
        '
        Me.Label_Personal_love.AutoSize = True
        Me.Label_Personal_love.Location = New System.Drawing.Point(28, 81)
        Me.Label_Personal_love.Name = "Label_Personal_love"
        Me.Label_Personal_love.Size = New System.Drawing.Size(71, 12)
        Me.Label_Personal_love.TabIndex = 0
        Me.Label_Personal_love.Text = "喜欢的事物:"
        '
        'Label_Personal_hobby
        '
        Me.Label_Personal_hobby.AutoSize = True
        Me.Label_Personal_hobby.Location = New System.Drawing.Point(40, 50)
        Me.Label_Personal_hobby.Name = "Label_Personal_hobby"
        Me.Label_Personal_hobby.Size = New System.Drawing.Size(59, 12)
        Me.Label_Personal_hobby.TabIndex = 0
        Me.Label_Personal_hobby.Text = "兴趣爱好:"
        '
        'Label_Content
        '
        Me.Label_Content.AutoSize = True
        Me.Label_Content.Location = New System.Drawing.Point(103, 19)
        Me.Label_Content.Name = "Label_Content"
        Me.Label_Content.Size = New System.Drawing.Size(29, 12)
        Me.Label_Content.TabIndex = 0
        Me.Label_Content.Text = "内容"
        '
        'Label_Column
        '
        Me.Label_Column.AutoSize = True
        Me.Label_Column.Location = New System.Drawing.Point(60, 19)
        Me.Label_Column.Name = "Label_Column"
        Me.Label_Column.Size = New System.Drawing.Size(29, 12)
        Me.Label_Column.TabIndex = 0
        Me.Label_Column.Text = "栏目"
        '
        'StatusStrip_Info
        '
        Me.StatusStrip_Info.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip_Info.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_Statu, Me.ToolStripStatusLabel_Msg})
        Me.StatusStrip_Info.Location = New System.Drawing.Point(0, 342)
        Me.StatusStrip_Info.Name = "StatusStrip_Info"
        Me.StatusStrip_Info.Size = New System.Drawing.Size(560, 22)
        Me.StatusStrip_Info.SizingGrip = False
        Me.StatusStrip_Info.TabIndex = 0
        Me.StatusStrip_Info.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel_Statu
        '
        Me.ToolStripStatusLabel_Statu.Name = "ToolStripStatusLabel_Statu"
        Me.ToolStripStatusLabel_Statu.Size = New System.Drawing.Size(35, 17)
        Me.ToolStripStatusLabel_Statu.Text = "状态:"
        '
        'ToolStripStatusLabel_Msg
        '
        Me.ToolStripStatusLabel_Msg.Name = "ToolStripStatusLabel_Msg"
        Me.ToolStripStatusLabel_Msg.Size = New System.Drawing.Size(32, 17)
        Me.ToolStripStatusLabel_Msg.Text = "就绪"
        '
        'Button_Save
        '
        Me.Button_Save.BackColor = System.Drawing.Color.Transparent
        Me.Button_Save.FlatAppearance.BorderSize = 0
        Me.Button_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSlateBlue
        Me.Button_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru
        Me.Button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Save.Location = New System.Drawing.Point(290, 314)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(55, 22)
        Me.Button_Save.TabIndex = 5
        Me.Button_Save.Text = "保存"
        Me.Button_Save.UseVisualStyleBackColor = False
        '
        'Button_Next_item
        '
        Me.Button_Next_item.BackColor = System.Drawing.Color.Transparent
        Me.Button_Next_item.FlatAppearance.BorderSize = 0
        Me.Button_Next_item.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSlateBlue
        Me.Button_Next_item.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru
        Me.Button_Next_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Next_item.Location = New System.Drawing.Point(229, 314)
        Me.Button_Next_item.Name = "Button_Next_item"
        Me.Button_Next_item.Size = New System.Drawing.Size(55, 22)
        Me.Button_Next_item.TabIndex = 4
        Me.Button_Next_item.Text = "下一项"
        Me.Button_Next_item.UseVisualStyleBackColor = False
        '
        'Button_Search
        '
        Me.Button_Search.BackColor = System.Drawing.Color.Transparent
        Me.Button_Search.FlatAppearance.BorderSize = 0
        Me.Button_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSlateBlue
        Me.Button_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru
        Me.Button_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Search.Location = New System.Drawing.Point(343, 314)
        Me.Button_Search.Name = "Button_Search"
        Me.Button_Search.Size = New System.Drawing.Size(55, 22)
        Me.Button_Search.TabIndex = 7
        Me.Button_Search.Text = "查  询"
        Me.Button_Search.UseVisualStyleBackColor = False
        '
        'TextBox_Search_Compellation
        '
        Me.TextBox_Search_Compellation.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TextBox_Search_Compellation.Location = New System.Drawing.Point(221, 314)
        Me.TextBox_Search_Compellation.MaxLength = 8
        Me.TextBox_Search_Compellation.Name = "TextBox_Search_Compellation"
        Me.TextBox_Search_Compellation.Size = New System.Drawing.Size(116, 21)
        Me.TextBox_Search_Compellation.TabIndex = 6
        '
        'Panel_Min
        '
        Me.Panel_Min.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Min.Location = New System.Drawing.Point(487, 12)
        Me.Panel_Min.Name = "Panel_Min"
        Me.Panel_Min.Size = New System.Drawing.Size(30, 27)
        Me.Panel_Min.TabIndex = 3
        '
        'Panel_Close
        '
        Me.Panel_Close.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Close.Location = New System.Drawing.Point(518, 12)
        Me.Panel_Close.Name = "Panel_Close"
        Me.Panel_Close.Size = New System.Drawing.Size(30, 27)
        Me.Panel_Close.TabIndex = 4
        '
        'Main
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(560, 364)
        Me.Controls.Add(Me.Panel_Close)
        Me.Controls.Add(Me.Panel_Min)
        Me.Controls.Add(Me.StatusStrip_Info)
        Me.Controls.Add(Me.Label_Title)
        Me.Controls.Add(Me.Panel_Menu)
        Me.Controls.Add(Me.ToolStrip_Info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Schoolmate Info"
        Me.ToolStrip_Info.ResumeLayout(False)
        Me.ToolStrip_Info.PerformLayout()
        Me.Panel_info_1.ResumeLayout(False)
        Me.Panel_info_1.PerformLayout()
        CType(Me.PictureBox_Photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Photo.ResumeLayout(False)
        Me.Panel_Menu.ResumeLayout(False)
        Me.Panel_info_4.ResumeLayout(False)
        Me.Panel_info_4.PerformLayout()
        Me.Panel_info_2.ResumeLayout(False)
        Me.Panel_info_2.PerformLayout()
        Me.Panel_info_3.ResumeLayout(False)
        Me.Panel_info_3.PerformLayout()
        Me.Panel_info_5.ResumeLayout(False)
        Me.Panel_info_5.PerformLayout()
        Me.StatusStrip_Info.ResumeLayout(False)
        Me.StatusStrip_Info.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    '<STAThread()> _
    'Shared Sub Main()
    '    Application.EnableVisualStyles()
    '    Application.Run(New Main())
    'End Sub
#End Region

    '------ 线程安全 start

    'D_ToolStripStatusLabel_Msg
    Private Sub D_ToolStripStatusLabel_Msg(ByVal [Color] As Drawing.Color)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.StatusStrip_Info.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ToolStripStatusLabel_Msg)
            Me.Invoke(d, New Object() {[Color]})
        Else
            Me.ToolStripStatusLabel_Msg.ForeColor = [Color]
        End If
    End Sub

    'D_RadioButton_Women
    Public Sub D_Button_Modify(ByVal [Bool] As Boolean)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.Button_Modify.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_Button_Modify)
            Me.Invoke(d, New Object() {[Bool]})
        Else
            Me.Button_Modify.Enabled = [Bool]
        End If
    End Sub

    'D_Button_Delete
    Public Sub D_Button_Delete(ByVal [Bool] As Boolean)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.Button_Delete.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_Button_Delete)
            Me.Invoke(d, New Object() {[Bool]})
        Else
            Me.Button_Delete.Enabled = [Bool]
        End If
    End Sub

    'D_TextBox_Search_Compellation
    Public Sub D_TextBox_Search_Compellation(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Search_Compellation.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Search_Compellation)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Search_Compellation.Text = [text]
        End If
    End Sub
    '---- 1....
    'D_TextBox_Compellation
    Public Sub D_TextBox_Compellation(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Compellation.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Compellation)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Compellation.Text = [text]
        End If
    End Sub
    'D_RadioButton_Women
    Public Sub D_RadioButton_Women(ByVal [Bool] As Boolean)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.RadioButton_Women.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_RadioButton_Women)
            Me.Invoke(d, New Object() {[Bool]})
        Else
            Me.RadioButton_Women.Checked = [Bool]
        End If
    End Sub
    'D_RadioButton_Men
    Public Sub D_RadioButton_Men(ByVal [Bool] As Boolean)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.RadioButton_Men.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_RadioButton_Men)
            Me.Invoke(d, New Object() {[Bool]})
        Else
            Me.RadioButton_Men.Checked = [Bool]
        End If
    End Sub
    'D_ComboBox_Marital_status
    Public Sub D_ComboBox_Marital_status(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Marital_status.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Marital_status)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Marital_status.Text = [text]
        End If
    End Sub
    'D_ComboBox_Birthday_year
    Public Sub D_ComboBox_Birthday_year(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Birthday_year.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Birthday_year)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Birthday_year.Text = [text]
        End If
    End Sub
    'D_ComboBox_Birthday_month
    Public Sub D_ComboBox_Birthday_month(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Birthday_month.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Birthday_month)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Birthday_month.Text = [text]
        End If
    End Sub
    'D_ComboBox_Twelve_animals
    Public Sub D_ComboBox_Twelve_animals(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Twelve_animals.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Twelve_animals)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Twelve_animals.Text = [text]
        End If
    End Sub
    'D_ComboBox_Birthday_day
    Public Sub D_ComboBox_Birthday_day(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Birthday_day.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Birthday_day)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Birthday_day.Text = [text]
        End If
    End Sub
    'D_ComboBox_Blood_type
    Public Sub D_ComboBox_Blood_type(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Blood_type.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Blood_type)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Blood_type.Text = [text]
        End If
    End Sub
    'D_ComboBox_Hometown_province
    Public Sub D_ComboBox_Hometown_province(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Hometown_province.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Hometown_province)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Hometown_province.Text = [text]
        End If
    End Sub
    'D_ComboBox_Hometown_city
    Public Sub D_ComboBox_Hometown_city(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Hometown_city.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Hometown_city)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Hometown_city.Text = [text]
        End If
    End Sub
    'D_ComboBox_Hometown_county
    Public Sub D_ComboBox_Hometown_county(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Hometown_county.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Hometown_county)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Hometown_county.Text = [text]
        End If
    End Sub
    'D_ComboBox_Hometown_town
    Public Sub D_ComboBox_Hometown_town(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Hometown_town.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Hometown_town)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Hometown_town.Text = [text]
        End If
    End Sub
    'D_ComboBox_Live_province
    Public Sub D_ComboBox_Live_province(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Live_province.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Live_province)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Live_province.Text = [text]
        End If
    End Sub
    'D_ComboBox_Live_city
    Public Sub D_ComboBox_Live_city(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Live_city.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Live_city)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Live_city.Text = [text]
        End If
    End Sub
    'D_ComboBox_Live_county
    Public Sub D_ComboBox_Live_county(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Live_county.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Live_county)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Live_county.Text = [text]
        End If
    End Sub
    'D_ComboBox_Live_town
    Public Sub D_ComboBox_Live_town(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Live_town.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Live_town)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Live_town.Text = [text]
        End If
    End Sub
    '---- 2....
    'D_TextBox_Email_address
    Public Sub D_TextBox_Email_address(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Email_address.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Email_address)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Email_address.Text = [text]
        End If
    End Sub

    'D_TextBox_Mobile_number
    Public Sub D_TextBox_Mobile_number(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Mobile_number.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Mobile_number)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Mobile_number.Text = [text]
        End If
    End Sub

    'D_TextBox_Qq_number
    Public Sub D_TextBox_Qq_number(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Qq_number.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Qq_number)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Qq_number.Text = [text]
        End If
    End Sub

    'D_TextBox_Msn_number
    Public Sub D_TextBox_Msn_number(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Msn_number.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Msn_number)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Msn_number.Text = [text]
        End If
    End Sub

    'D_TextBox_Other_number
    Public Sub D_TextBox_Other_number(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Other_number.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Other_number)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Other_number.Text = [text]
        End If
    End Sub
    '---- 3....

    'D_TextBox_School_name
    Public Sub D_TextBox_School_name(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_School_name.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_School_name)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_School_name.Text = [text]
        End If
    End Sub

    'D_TextBox_Class_name
    Public Sub D_TextBox_Class_name(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Class_name.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Class_name)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Class_name.Text = [text]
        End If
    End Sub

    'D_ComboBox_Entrance_school_year
    Public Sub D_ComboBox_Entrance_school_year(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Entrance_school_year.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Entrance_school_year)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Entrance_school_year.Text = [text]
        End If
    End Sub
    '---- 4....

    'D_TextBox_Company_name
    Public Sub D_TextBox_Company_name(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Company_name.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Company_name)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Company_name.Text = [text]
        End If
    End Sub

    'D_TextBox_Department
    Public Sub D_TextBox_Department(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Department.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Department)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Department.Text = [text]
        End If
    End Sub

    'D_ComboBox_Worktime_begin_year
    Public Sub D_ComboBox_Worktime_begin_year(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Worktime_begin_year.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Worktime_begin_year)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Worktime_begin_year.Text = [text]
        End If
    End Sub

    'D_ComboBox_Worktime_begin_month
    Public Sub D_ComboBox_Worktime_begin_month(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Worktime_begin_month.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Worktime_begin_month)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Worktime_begin_month.Text = [text]
        End If
    End Sub

    'D_ComboBox_Worktime_finish_year
    Public Sub D_ComboBox_Worktime_finish_year(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Worktime_finish_year.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Worktime_finish_year)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Worktime_finish_year.Text = [text]
        End If
    End Sub

    'D_ComboBox_Worktime_finish_month
    Public Sub D_ComboBox_Worktime_finish_month(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ComboBox_Worktime_finish_month.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_ComboBox_Worktime_finish_month)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ComboBox_Worktime_finish_month.Text = [text]
        End If
    End Sub
    '---- 5....
    'D_TextBox_Personal_hobby
    Public Sub D_TextBox_Personal_hobby(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Personal_hobby.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Personal_hobby)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Personal_hobby.Text = [text]
        End If
    End Sub

    'D_TextBox_Personal_love
    Public Sub D_TextBox_Personal_love(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Personal_love.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Personal_love)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Personal_love.Text = [text]
        End If
    End Sub

    'D_TextBox_Personal_wish
    Public Sub D_TextBox_Personal_wish(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Personal_wish.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Personal_wish)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Personal_wish.Text = [text]
        End If
    End Sub

    'D_TextBox_Personal_presentation
    Public Sub D_TextBox_Personal_presentation(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.TextBox_Personal_presentation.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf D_TextBox_Personal_presentation)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.TextBox_Personal_presentation.Text = [text]
        End If
    End Sub

    '------ 线程安全 end

    '最小化、关闭按钮鼠标按下事件
    Private Sub Bt_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel_Min.MouseDown, Panel_Close.MouseDown
        If sender.name.ToString = "Panel_Min" Then
            Panel_Min.BackgroundImage = rm.GetObject("sysbtn_min_down")
        ElseIf sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("sysbtn_close_down")
        End If
    End Sub

    '最小化、关闭按钮鼠标悬停事件
    Private Sub Bt_MouseHover(sender As Object, e As EventArgs) Handles Panel_Min.MouseHover, Panel_Close.MouseHover
        If sender.name.ToString = "Panel_Min" Then
            Panel_Min.BackgroundImage = rm.GetObject("sysbtn_min_hover")
        ElseIf sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("sysbtn_close_hover")
        End If
    End Sub

    '最小化、关闭按钮鼠标离开事件
    Private Sub Bt_MouseLeave(sender As Object, e As EventArgs) Handles Panel_Min.MouseLeave, Panel_Close.MouseLeave
        If sender.name.ToString = "Panel_Min" Then
            Panel_Min.BackgroundImage = rm.GetObject("sysbtn_min_normal")
        ElseIf sender.name.ToString = "Panel_Close" Then
            Panel_Close.BackgroundImage = rm.GetObject("sysbtn_close_normal")
        End If
    End Sub

    '最小化 关闭按钮单击事件
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Panel_Min.Click, Panel_Close.Click
        '通过检测按钮名来进行操作
        If sender.name.ToString = "Panel_Min" Then '最小化按钮

            Me.WindowState = FormWindowState.Minimized
        ElseIf sender.name.ToString = "Panel_Close" Then  '关闭按钮
            '停止退出应用程序
            'Application.Exit()
            '为了防止从任务栏关闭窗口无法完全退出bug ，application.exit 写在 closed 事件中
            Me.Close()
        Else
            '
        End If
    End Sub

    Private keyname As String = Nothing '对移除指定控件的子健赋值

    '单击事件
    Private Sub All_Click(sender As Object, e As EventArgs) Handles _
        ToolStripLabel_basic_information.Click,
        ToolStripLabel_contact_information.Click,
        ToolStripLabel_education_information.Click,
        ToolStripLabel_work_information.Click,
        ToolStripLabel_personal_information.Click,
        Button_OK.Click,
        Button_Query.Click,
        Button_Add.Click,
        Button_Modify.Click,
        Button_Delete.Click,
        Button_Setting.Click,
        Button_Search.Click,
        Button_Next_item.Click,
        Button_Save.Click,
        ToolStripMenuItem_Add_Photo.Click,
        ToolStripMenuItem_Delete_Photo.Click,
        PictureBox_Photo.DoubleClick

        Select Case sender.name.ToString
            Case "ToolStripLabel_basic_information" '基本资料
                If Me.Controls.ContainsKey("Panel_info_1") Then Return
                ToolStripLabel_basic_information.LinkVisited = True
                ToolStripLabel_contact_information.LinkVisited = False
                ToolStripLabel_education_information.LinkVisited = False
                ToolStripLabel_work_information.LinkVisited = False
                ToolStripLabel_personal_information.LinkVisited = False
                Me.Controls.RemoveByKey(keyname)
                Me.Controls.Add(Panel_info_1)
                keyname = "Panel_info_1"
            Case "ToolStripLabel_contact_information" '联系方式
                If Me.Controls.ContainsKey("Panel_info_2") Then Return
                ToolStripLabel_basic_information.LinkVisited = False
                ToolStripLabel_contact_information.LinkVisited = True
                ToolStripLabel_education_information.LinkVisited = False
                ToolStripLabel_work_information.LinkVisited = False
                ToolStripLabel_personal_information.LinkVisited = False
                Me.Controls.RemoveByKey(keyname)
                Me.Controls.Add(Panel_info_2)
                keyname = "Panel_info_2"
            Case "ToolStripLabel_education_information" '教育情况
                If Me.Controls.ContainsKey("Panel_info_3") Then Return
                ToolStripLabel_basic_information.LinkVisited = False
                ToolStripLabel_contact_information.LinkVisited = False
                ToolStripLabel_education_information.LinkVisited = True
                ToolStripLabel_work_information.LinkVisited = False
                ToolStripLabel_personal_information.LinkVisited = False
                Me.Controls.RemoveByKey(keyname)
                Me.Controls.Add(Panel_info_3)
                keyname = "Panel_info_3"
            Case "ToolStripLabel_work_information" '工作情况
                If Me.Controls.ContainsKey("Panel_info_4") Then Return
                ToolStripLabel_basic_information.LinkVisited = False
                ToolStripLabel_contact_information.LinkVisited = False
                ToolStripLabel_education_information.LinkVisited = False
                ToolStripLabel_work_information.LinkVisited = True
                ToolStripLabel_personal_information.LinkVisited = False
                Me.Controls.RemoveByKey(keyname)
                Me.Controls.Add(Panel_info_4)
                keyname = "Panel_info_4"
            Case "ToolStripLabel_personal_information" '个人信息
                If Me.Controls.ContainsKey("Panel_info_5") Then Return
                ToolStripLabel_basic_information.LinkVisited = False
                ToolStripLabel_contact_information.LinkVisited = False
                ToolStripLabel_education_information.LinkVisited = False
                ToolStripLabel_work_information.LinkVisited = False
                ToolStripLabel_personal_information.LinkVisited = True
                Me.Controls.RemoveByKey(keyname)
                Me.Controls.Add(Panel_info_5)
                keyname = "Panel_info_5"
            Case "Button_OK" '确定

                D_ToolStripStatusLabel_Msg(Drawing.Color.Black)
                ToolStripStatusLabel_Msg.Text = "就绪"

                ' 控件位置
                If Panel_Menu.Location.X > 0 Then
                    Panel_Menu.Location = New System.Drawing.Point(Panel_Menu.Location.X - Panel_Menu.Width - 11, Panel_Menu.Location.Y)

                    ToolStrip_Info.Location = New System.Drawing.Point(ToolStrip_Info.Location.X - 35, ToolStrip_Info.Location.Y)
                    Panel_info_1.Location = New System.Drawing.Point(Panel_info_1.Location.X - 35, Panel_info_1.Location.Y)
                    Panel_info_2.Location = New System.Drawing.Point(Panel_info_2.Location.X - 35, Panel_info_2.Location.Y)
                    Panel_info_3.Location = New System.Drawing.Point(Panel_info_3.Location.X - 35, Panel_info_3.Location.Y)
                    Panel_info_4.Location = New System.Drawing.Point(Panel_info_4.Location.X - 35, Panel_info_4.Location.Y)
                    Panel_info_5.Location = New System.Drawing.Point(Panel_info_5.Location.X - 35, Panel_info_5.Location.Y)

                ElseIf Panel_Menu.Location.X < 0 Then
                    Panel_Menu.Location = New System.Drawing.Point(Panel_Menu.Location.X + Panel_Menu.Width + 11, Panel_Menu.Location.Y)

                    ToolStrip_Info.Location = New System.Drawing.Point(ToolStrip_Info.Location.X + 35, ToolStrip_Info.Location.Y)
                    Panel_info_1.Location = New System.Drawing.Point(Panel_info_1.Location.X + 35, Panel_info_1.Location.Y)
                    Panel_info_2.Location = New System.Drawing.Point(Panel_info_2.Location.X + 35, Panel_info_2.Location.Y)
                    Panel_info_3.Location = New System.Drawing.Point(Panel_info_3.Location.X + 35, Panel_info_3.Location.Y)
                    Panel_info_4.Location = New System.Drawing.Point(Panel_info_4.Location.X + 35, Panel_info_4.Location.Y)
                    Panel_info_5.Location = New System.Drawing.Point(Panel_info_5.Location.X + 35, Panel_info_5.Location.Y)

                End If

            Case "Button_Query" '查询
                D_Button_Delete(False)
                D_Button_Modify(False)
                TextBox_Compellation.ReadOnly = True
                Button_OK.PerformClick()
                '移除控件
                If Me.Controls.ContainsKey("Button_Next_item") Then Me.Controls.RemoveByKey("Button_Next_item")
                If Me.Controls.ContainsKey("Button_Save") Then Me.Controls.RemoveByKey("Button_Save")
                '添加 查询控件
                If Me.Controls.Contains(Button_Search) = False Then Me.Controls.AddRange(New Control() {TextBox_Search_Compellation, Button_Search})
                '设置默认acceptbutton按钮
                If Me.Controls.Contains(Button_Search) Then Me.AcceptButton = Button_Search Else Me.AcceptButton = Nothing
                '击某按钮的同时按 Ctrl 键时发生
                If Control.ModifierKeys = Keys.Control Then
                    '调用遍历数据窗口
                    Dim t As New Threading.Thread(AddressOf Ergodic)
                    t.SetApartmentState(ApartmentState.STA)
                    t.Start()
                    Console.WriteLine("Main thread: Call Join(), to wait until Ergodic ends.")
                    Me.Hide()
                    t.Join()
                    Me.Show()
                End If

            Case "Button_Add" '添加
                D_Button_Delete(False)
                D_Button_Modify(False)
                TextBox_Compellation.ReadOnly = False
                Button_OK.PerformClick()
                '移除控件
                If Me.Controls.ContainsKey("TextBox_Search_Compellation") Then Me.Controls.RemoveByKey("TextBox_Search_Compellation")
                If Me.Controls.ContainsKey("Button_Search") Then Me.Controls.RemoveByKey("Button_Search")
                '添加 添加数据控件
                If Me.Controls.Contains(Button_Save) = False Then Me.Controls.AddRange(New Control() {Button_Next_item, Button_Save})
                '设置默认acceptbutton按钮
                If Me.Controls.Contains(Button_Save) Then Me.AcceptButton = Button_Save Else Me.AcceptButton = Nothing
                '创建线程对象
                Dim Nt1 As Threading.Thread
                Nt1 = New Threading.Thread(AddressOf clean)
                '执行线程
                Nt1.Start()

            Case "Button_Modify" '修改
                Button_OK.PerformClick()
                '移除控件
                If Me.Controls.ContainsKey("TextBox_Search_Compellation") Then Me.Controls.RemoveByKey("TextBox_Search_Compellation")
                If Me.Controls.ContainsKey("Button_Search") Then Me.Controls.RemoveByKey("Button_Search")
                If Me.Controls.ContainsKey("Button_Next_item") Then Me.Controls.RemoveByKey("Button_Next_item")
                If Me.Controls.ContainsKey("Button_Save") Then Me.Controls.RemoveByKey("Button_Save")
                '添加 添加数据（修改）控件
                If Me.Controls.Contains(Button_Save) = False Then Me.Controls.AddRange(New Control() {Button_Next_item, Button_Save})
                '设置默认acceptbutton按钮
                If Me.Controls.Contains(Button_Save) Then Me.AcceptButton = Button_Save Else Me.AcceptButton = Nothing
            Case "Button_Delete" '删除
                Button_OK.PerformClick()
                '移除控件
                If Me.Controls.ContainsKey("TextBox_Search_Compellation") Then Me.Controls.RemoveByKey("TextBox_Search_Compellation")
                If Me.Controls.ContainsKey("Button_Search") Then Me.Controls.RemoveByKey("Button_Search")
                If Me.Controls.ContainsKey("Button_Next_item") Then Me.Controls.RemoveByKey("Button_Next_item")
                If Me.Controls.ContainsKey("Button_Save") Then Me.Controls.RemoveByKey("Button_Save")
                '创建线程对象
                'Dim Nt1 As Threading.Thread
                'Nt1 = New Threading.Thread(AddressOf make_dbdata_D)
                '执行线程
                'Nt1.Start()
                make_dbdata_D()
            Case "Button_Setting" '设置
                Button_OK.PerformClick()
                Dim _Setting As New Setting
                _Setting.TopMost = True '防止异常不显示到最前
                _Setting.ShowDialog()

            Case "Button_Search" ' 搜索
                '为了实现姓名中去除空格，声明一个变量进行存储处理
                Dim sentence As String = TextBox_Search_Compellation.Text
                Dim charsToTrim() As Char = {","c, "."c, " "c}
                Dim words() As String = sentence.Split()
                D_TextBox_Search_Compellation(Nothing) '清空后重新赋值
                For Each word As String In words
                    D_TextBox_Search_Compellation(TextBox_Search_Compellation.Text + word.TrimEnd(charsToTrim))
                Next
                '判断是否完整
                If Trim(TextBox_Search_Compellation.Text).Length < 1 Then
                    '调用消息弹框
                    Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), rm.GetObject("Main.TextBox_Search_Compellation.Text.Length < 1"), System.Media.SystemSounds.Asterisk)
                    Exit Sub
                End If

                '创建线程对象
                Dim Nt1 As New Threading.Thread(AddressOf make_dbdata_Q)
                ' Nt1.IsBackground = True
                '执行线程
                Nt1.Start()
                'Nt1.Join()
                'make_dbdata_Q()
            Case "Button_Next_item" '下一项
                If ToolStripLabel_basic_information.LinkVisited = True Then
                    ToolStripLabel_contact_information.PerformClick()
                ElseIf ToolStripLabel_contact_information.LinkVisited = True Then
                    ToolStripLabel_education_information.PerformClick()
                ElseIf ToolStripLabel_education_information.LinkVisited = True Then
                    ToolStripLabel_work_information.PerformClick()
                ElseIf ToolStripLabel_work_information.LinkVisited = True Then
                    ToolStripLabel_personal_information.PerformClick()
                ElseIf ToolStripLabel_personal_information.LinkVisited = True Then
                    ToolStripLabel_basic_information.PerformClick()
                End If

            Case "Button_Save" '保存
                ' 通过判断文本框执行添加还是更新
                If TextBox_Compellation.ReadOnly = True Then
                    '创建线程对象
                    'Dim Nt1 As Threading.Thread
                    'Nt1 = New Threading.Thread(AddressOf make_dbdata_M)
                    '执行线程
                    'Nt1.Start()
                    make_dbdata_M()
                ElseIf TextBox_Compellation.ReadOnly = False Then

                    '创建线程对象
                    'Dim Nt1 As Threading.Thread
                    'Nt1 = New Threading.Thread(AddressOf make_dbdata_A)
                    '执行线程
                    'Nt1.Start()
                    make_dbdata_A()
                End If

            Case "ToolStripMenuItem_Add_Photo" '添加修改头像
                'Me.TopMost = False
                Dim Nt1 As New Threading.Thread(AddressOf fileshowdialog)
                Nt1.SetApartmentState(ApartmentState.STA)
                Nt1.Start()
                'Nt1.Interrupt()
                'Thread.CurrentThread.Suspend()
                Nt1.Join()
                'Me.TopMost = True
            Case "ToolStripMenuItem_Delete_Photo" '删除头像
                'PictureBox_Photo.Image = Nothing
                If PictureBox_Photo.Image IsNot Nothing Then PictureBox_Photo.Image = Nothing
                If imgbybe IsNot Nothing Then imgbybe = Nothing

            Case "PictureBox_Photo" ' 图片框双击事件
                On Error Resume Next '忽略错误

                ' 图片和桌面分辨率对比选择显示模式
                If Me.PictureBox_Photo.Image.Height <= SystemInformation.PrimaryMonitorSize.Height And
                     Me.PictureBox_Photo.Image.Width <= SystemInformation.PrimaryMonitorSize.Width Then

                    Dim PhotoPrew As New PhotoPrew_form
                    PhotoPrew.PictureBox1.Image = Me.PictureBox_Photo.Image
                    PhotoPrew.TopMost = True
                    PhotoPrew.ShowDialog()

                Else '图片大于桌面

                    Dim PhotoPrew As New PhotoPrew_form '实例化窗体
                    PhotoPrew.Height = SystemInformation.PrimaryMonitorSize.Height '设置窗体高为桌面分辨率高
                    PhotoPrew.Width = SystemInformation.PrimaryMonitorSize.Width '设置窗体长为桌面分辨率长
                    PhotoPrew.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom '图片显示模式，比例对应缩放
                    PhotoPrew.PictureBox1.Image = Me.PictureBox_Photo.Image '赋值
                    PhotoPrew.TopMost = True '窗体显示最前
                    PhotoPrew.ShowDialog() '显示为对话框模式

                End If

        End Select

    End Sub

    ' 打开浏览图片
    Private Sub fileshowdialog()
        Try
            Dim dlg As New OpenFileDialog()
            'dlg.FileName = "Document" ' Default file name
            'dlg.DefaultExt = ".txt" ' Default file extension
            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"

            ' Filter files by extension

            ' Process open file dialog box results
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' Open document
                ' 判断图片大小
                Dim fi As System.IO.FileInfo = New System.IO.FileInfo(dlg.FileName) '实例化文件
                If fi.Length > 1000000 Then '检测文件大小，1MB
                    If imgbybe IsNot Nothing Then imgbybe = Nothing '清空图片数组
                    If PictureBox_Photo.Image IsNot Nothing Then PictureBox_Photo.Image = Nothing '清空图片显示
                    Return '返回
                End If
                imgbybe = Microsoft.VisualBasic.FileIO.FileSystem.ReadAllBytes(dlg.FileName)
                PictureBox_Photo.Image = Drawing.Image.FromStream(New IO.MemoryStream(imgbybe))

                'MsgBox(System.Text.Encoding.Unicode.GetString(imgbybe))’字节转换为字符串

            End If
        Catch ex As System.ArgumentException '不是有效的图片文件
            If imgbybe IsNot Nothing Then imgbybe = Nothing '清空图片数组
            If PictureBox_Photo.Image IsNot Nothing Then PictureBox_Photo.Image = Nothing '清空图片显示
            Console.WriteLine(Err.Description)

        Catch ex As Exception ' 其它任何异常
            If imgbybe IsNot Nothing Then imgbybe = Nothing '清空图片数组
            If PictureBox_Photo.Image IsNot Nothing Then PictureBox_Photo.Image = Nothing '清空图片显示
            Console.WriteLine(Err.Description)
        End Try
    End Sub
    ' 年月日选项
    Private Sub ComboBox_data_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _
      ComboBox_Birthday_year.SelectedIndexChanged, ComboBox_Birthday_month.SelectedIndexChanged, ComboBox_Birthday_day.SelectedIndexChanged
        Select Case sender.name.ToString
            Case "ComboBox_Birthday_year"
                ComboBox_Birthday_month.Text = "1" '默认
                ComboBox_Birthday_day.Text = "1" '默认
                If ComboBox_Birthday_month.Items.Count = 13 Then Return
                ComboBox_Birthday_month.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
            Case "ComboBox_Birthday_month"

                Select Case ComboBox_Birthday_month.Text
                    Case "2"

                        If Char.IsDigit(Trim(ComboBox_Birthday_year.Text)) And Trim(ComboBox_Birthday_year.Text).Length <> 0 Then
                            If Trim(ComboBox_Birthday_year.Text) Mod 4 = 0 And Trim(ComboBox_Birthday_year.Text) Mod 100 <> 0 Or Trim(ComboBox_Birthday_year.Text) Mod 400 = 0 Then
                                If ComboBox_Birthday_day.Items.Count = 29 Then Return
                                ComboBox_Birthday_day.Items.Clear()
                                For d As Integer = 1 To 29
                                    ComboBox_Birthday_day.Items.Add(d)
                                Next
                            Else
                                If ComboBox_Birthday_day.Items.Count = 28 Then Return
                                ComboBox_Birthday_day.Items.Clear()
                                For d As Integer = 1 To 28
                                    ComboBox_Birthday_day.Items.Add(d)
                                Next
                            End If
                        Else
                            '
                        End If

                    Case "1", "3", "5", "7", "8", "10", "12"
                        If ComboBox_Birthday_day.Items.Count = 31 Then Return
                        ComboBox_Birthday_day.Items.Clear()
                        For d As Integer = 1 To 31
                            ComboBox_Birthday_day.Items.Add(d)
                        Next
                    Case "4", "6", "9", "11"
                        If ComboBox_Birthday_day.Items.Count = 30 Then Return
                        ComboBox_Birthday_day.Items.Clear()
                        For d As Integer = 1 To 30
                            ComboBox_Birthday_day.Items.Add(d)
                        Next

                    Case Else
                        If ComboBox_Birthday_day.Items.Count = 31 Then Return
                        ComboBox_Birthday_day.Items.Clear()
                        For d As Integer = 1 To 31
                            ComboBox_Birthday_day.Items.Add(d)
                        Next
                End Select
                ComboBox_Birthday_day.Text = "1"
            Case "ComboBox_Birthday_day"

        End Select
    End Sub
    '地址默认方法
    Private Sub district(ByRef id, ByVal op)
        Try

            Dim PWD As String = Nothing
            If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Module1.Err_MSG_Text"), System.Media.SystemSounds.Exclamation)
                Application.Exit()
            End If
            Select Case op

                Case 1
                    ' 连接数据库获取数据
                    Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat;" + "Jet OLEDB:Database Password=" + PWD + ";")
                        Dim command As New OleDbCommand("SELECT place_name FROM [DISTRICT] WHERE place_upid=0", connection)
                        command.CommandTimeout = 20

                        connection.Open()

                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        While reader.Read()

                            ComboBox_Hometown_province.Items.Add(reader.GetString(0))
                            ComboBox_Live_province.Items.Add(reader.GetString(0))
                        End While
                        reader.Close()
                    End Using
            End Select

        Catch ex As InvalidOperationException
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        Catch ex As OleDbException
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub
    ' 地址选项
    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _
         ComboBox_Hometown_province.SelectedIndexChanged, ComboBox_Hometown_city.SelectedIndexChanged,
         ComboBox_Hometown_county.SelectedIndexChanged, ComboBox_Hometown_town.SelectedIndexChanged,
         ComboBox_Live_province.SelectedIndexChanged, ComboBox_Live_city.SelectedIndexChanged,
         ComboBox_Live_county.SelectedIndexChanged, ComboBox_Live_town.SelectedIndexChanged

        Dim PWD As String = Nothing
        If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Module1.Err_MSG_Text"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        End If

        Try
            Dim getstring As Integer = Nothing


            Select Case sender.name.ToString

                Case "ComboBox_Hometown_province"
                    Select Case _
db.Access_db(
   Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
   "Microsoft.Jet.Oledb.4.0", PWD,
   "SELECT ID FROM [DISTRICT] " & _
   "WHERE place_name='" & Trim(ComboBox_Hometown_province.Text) & "'",
   5, getstring)
                        Case "InvalidOperationException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                        Case "OleDbException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                    End Select


                    ' 连接数据库获取数据
                    Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat;" + "Jet OLEDB:Database Password=" + PWD + ";")
                        Dim command As New OleDbCommand("SELECT place_name FROM [DISTRICT] WHERE place_upid=" & getstring, connection)
                        command.CommandTimeout = 20

                        connection.Open()

                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        ComboBox_Hometown_city.Items.Clear()
                        While reader.Read()

                            ComboBox_Hometown_city.Items.Add(reader.GetString(0))
                        End While
                        reader.Close()
                    End Using
                    '默认
                    ComboBox_Hometown_city.Text = Nothing
                    ComboBox_Hometown_county.Items.Clear()
                    ComboBox_Hometown_town.Items.Clear()
                    ComboBox_Hometown_county.Text = Nothing
                    ComboBox_Hometown_town.Text = Nothing
                Case "ComboBox_Hometown_city"

                    Select Case _
    db.Access_db(
     Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
       "Microsoft.Jet.Oledb.4.0", PWD,
       "SELECT ID FROM [DISTRICT] " & _
       "WHERE place_name='" & Trim(ComboBox_Hometown_city.Text) & "'",
       5, getstring)
                        Case "InvalidOperationException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                        Case "OleDbException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                    End Select

                    ' 连接数据库获取数据
                    Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat;" + "Jet OLEDB:Database Password=" + PWD + ";")
                        Dim command As New OleDbCommand("SELECT place_name FROM [DISTRICT] WHERE place_upid=" & getstring, connection)
                        command.CommandTimeout = 20

                        connection.Open()

                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        ComboBox_Hometown_county.Items.Clear()
                        While reader.Read()

                            ComboBox_Hometown_county.Items.Add(reader.GetString(0))
                        End While
                        reader.Close()
                    End Using
                    '默认


                    ComboBox_Hometown_county.Text = Nothing
                    ComboBox_Hometown_town.Items.Clear()
                    ComboBox_Hometown_town.Text = Nothing


                Case "ComboBox_Hometown_county"

                    Select Case _
db.Access_db(
   Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
   "Microsoft.Jet.Oledb.4.0", PWD,
   "SELECT ID FROM [DISTRICT] " & _
   "WHERE place_name='" & Trim(ComboBox_Hometown_county.Text) & "'",
   5, getstring)
                        Case "InvalidOperationException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                        Case "OleDbException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                    End Select

                    ' 连接数据库获取数据
                    Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat;" + "Jet OLEDB:Database Password=" + PWD + ";")
                        Dim command As New OleDbCommand("SELECT place_name FROM [DISTRICT] WHERE place_upid=" & getstring, connection)
                        command.CommandTimeout = 20

                        connection.Open()

                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        ComboBox_Hometown_town.Items.Clear()
                        While reader.Read()

                            ComboBox_Hometown_town.Items.Add(reader.GetString(0))
                        End While
                        reader.Close()
                    End Using

                    '默认

                    ComboBox_Hometown_town.Text = Nothing
                Case "ComboBox_Hometown_town"



                    '////////
                Case "ComboBox_Live_province"
                    Select Case _
db.Access_db(
Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
"Microsoft.Jet.Oledb.4.0", PWD,
"SELECT ID FROM [DISTRICT] " & _
"WHERE place_name='" & Trim(ComboBox_Live_province.Text) & "'",
5, getstring)
                        Case "InvalidOperationException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                        Case "OleDbException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                    End Select

                    ' 连接数据库获取数据
                    Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat;" + "Jet OLEDB:Database Password=" + PWD + ";")
                        Dim command As New OleDbCommand("SELECT place_name FROM [DISTRICT] WHERE place_upid=" & getstring, connection)
                        command.CommandTimeout = 20

                        connection.Open()

                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        ComboBox_Live_city.Items.Clear()
                        While reader.Read()

                            ComboBox_Live_city.Items.Add(reader.GetString(0))
                        End While
                        reader.Close()
                    End Using
                    '默认
                    ComboBox_Live_city.Text = Nothing
                    ComboBox_Live_county.Items.Clear()
                    ComboBox_Live_town.Items.Clear()
                    ComboBox_Live_county.Text = Nothing
                    ComboBox_Live_town.Text = Nothing
                Case "ComboBox_Live_city"
                    Select Case _
db.Access_db(
   Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
   "Microsoft.Jet.Oledb.4.0", PWD,
   "SELECT ID FROM [DISTRICT] " & _
   "WHERE place_name='" & Trim(ComboBox_Live_city.Text) & "'",
   5, getstring)
                        Case "InvalidOperationException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                        Case "OleDbException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                    End Select

                    ' 连接数据库获取数据
                    Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat;" + "Jet OLEDB:Database Password=" + PWD + ";")
                        Dim command As New OleDbCommand("SELECT place_name FROM [DISTRICT] WHERE place_upid=" & getstring, connection)
                        command.CommandTimeout = 20

                        connection.Open()

                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        ComboBox_Live_county.Items.Clear()
                        While reader.Read()

                            ComboBox_Live_county.Items.Add(reader.GetString(0))
                        End While
                        reader.Close()
                    End Using
                    '默认
                    ComboBox_Live_county.Text = Nothing
                    ComboBox_Live_town.Items.Clear()
                    ComboBox_Live_town.Text = Nothing
                Case "ComboBox_Live_county"
                    Select Case _
db.Access_db(
Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
"Microsoft.Jet.Oledb.4.0", PWD,
"SELECT ID FROM [DISTRICT] " & _
"WHERE place_name='" & Trim(ComboBox_Live_county.Text) & "'",
5, getstring)
                        Case "InvalidOperationException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                        Case "OleDbException"
                            '调用消息弹框
                            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                            Application.Exit()
                    End Select

                    ' 连接数据库获取数据
                    Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat;" + "Jet OLEDB:Database Password=" + PWD + ";")
                        Dim command As New OleDbCommand("SELECT place_name FROM [DISTRICT] WHERE place_upid=" & getstring, connection)
                        command.CommandTimeout = 20

                        connection.Open()

                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        ComboBox_Live_town.Items.Clear()
                        While reader.Read()

                            ComboBox_Live_town.Items.Add(reader.GetString(0))
                        End While
                        reader.Close()
                    End Using
                    '默认
                    ComboBox_Live_town.Text = Nothing
                Case "ComboBox_Live_town"

            End Select

        Catch ex As InvalidOperationException
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        Catch ex As OleDbException
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try

    End Sub



    Private imgbybe() As Byte '头像存储数组

    ' 线程 查询
    Private Sub make_dbdata_Q()
        D_ToolStripStatusLabel_Msg(Drawing.Color.Blue)
        ToolStripStatusLabel_Msg.Text = "查询中..."
        '性别 ,并作为修改删除按钮的启用检测
        Dim xingbie As String = Nothing
        ' 声明密码变量
        Dim PWD As String = Nothing
        If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
            '调用消息弹框
            'Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Module1.Err_MSG_Text"), System.Media.SystemSounds.Exclamation)
            'Application.Exit()
            D_ToolStripStatusLabel_Msg(Drawing.Color.Red)
            ToolStripStatusLabel_Msg.Text = "配置信息出现错误，无法继续。"
        End If
        ' 操作过程

        clean() '调用清空方法



        Using connection As New OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat" + ";Jet OLEDB:Database Password=" + PWD + ";")

            ' The insertSQL string contains a SQL statement that
            ' inserts a new row in the source table.
            Dim command As New OleDbCommand("SELECT * FROM [MEMBER] WHERE compellation='" & Trim(TextBox_Search_Compellation.Text) & "'")
            ' 获取或设置在终止对执行命令的尝试并生成错误之前的等待时间。
            command.CommandTimeout = 20

            ' Set the Connection to the new OleDbConnection.
            command.Connection = connection

            ' Open the connection and execute the insert command.
            Try
                connection.Open()
                ' Do something with the database here.

                Console.WriteLine("Query Return:" & command.ExecuteNonQuery())

                Dim reader As OleDbDataReader = command.ExecuteReader()

                ' Call Read before accessing data.
                While reader.Read()

                    D_TextBox_Compellation(reader("compellation").ToString)
                    xingbie = reader("sex").ToString
                    If xingbie = "男" Then
                        D_RadioButton_Men(True)
                    ElseIf xingbie = "女" Then
                        D_RadioButton_Women(True)
                    Else
                        D_RadioButton_Men(False)
                        D_RadioButton_Women(False)
                    End If
                    D_ComboBox_Marital_status(reader("marital_status").ToString)
                    D_ComboBox_Birthday_year(reader("birthday_year").ToString)
                    D_ComboBox_Birthday_month(reader("birthday_month").ToString)
                    D_ComboBox_Twelve_animals(reader("twelve_animals").ToString())
                    D_ComboBox_Birthday_day(reader("birthday_day").ToString())
                    D_ComboBox_Blood_type(reader("blood_type").ToString)
                    D_ComboBox_Hometown_province(reader("hometown_province").ToString)
                    D_ComboBox_Hometown_city(reader("hometown_city").ToString)
                    D_ComboBox_Hometown_county(reader("hometown_county").ToString)
                    D_ComboBox_Hometown_town(reader("hometown_town").ToString)
                    D_ComboBox_Live_province(reader("live_province").ToString)
                    D_ComboBox_Live_city(reader("live_city").ToString)
                    D_ComboBox_Live_county(reader("live_county").ToString)
                    D_ComboBox_Live_town(reader("live_town").ToString)
                    D_TextBox_Email_address(reader("email_address").ToString)
                    D_TextBox_Mobile_number(reader("mobile_number").ToString)
                    D_TextBox_Qq_number(reader("qq_number").ToString)
                    D_TextBox_Msn_number(reader("msn_number").ToString)
                    D_TextBox_Other_number(reader("other_number").ToString)
                    D_TextBox_School_name(reader("school_name").ToString)
                    D_TextBox_Class_name(reader("class_name").ToString)
                    D_ComboBox_Entrance_school_year(reader("entrance_school_year").ToString)
                    D_TextBox_Company_name(reader("company_name").ToString)
                    D_TextBox_Department(reader("department").ToString)
                    D_ComboBox_Worktime_begin_year(reader("worktime_begin_year").ToString)
                    D_ComboBox_Worktime_begin_month(reader("worktime_begin_month").ToString)
                    D_ComboBox_Worktime_finish_year(reader("worktime_finish_year").ToString)
                    D_ComboBox_Worktime_finish_month(reader("worktime_finish_month").ToString)
                    D_TextBox_Personal_hobby(reader("personal_hobby").ToString)
                    D_TextBox_Personal_love(reader("personal_love").ToString)
                    D_TextBox_Personal_wish(reader("personal_wish").ToString)
                    D_TextBox_Personal_presentation(reader("personal_presentation").ToString)

                    ' 头像显示
                    If Not DBNull.Value.Equals(reader(17)) Then '判断是否存在值

                        imgbybe = reader(17)
                        PictureBox_Photo.Image = Drawing.Bitmap.FromStream(New IO.MemoryStream(imgbybe))
                    End If
                    '延时1.5秒并显示数据修改的时间
                    ToolStripStatusLabel_Msg.Text = String.Format("当前数据本地添加时间 - {0}", reader("operation_time").ToString)
                    Thread.Sleep(1500)

                End While

                ' Call Close when done reading.
                reader.Close()


            Catch ex As System.InvalidOperationException
                '调用消息弹框
                'Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                'Application.Exit()
                D_ToolStripStatusLabel_Msg(Drawing.Color.Red)
                ToolStripStatusLabel_Msg.Text = "数据库操作没有成功，无法继续。"
            Catch ex As System.Data.OleDb.OleDbException
                '调用消息弹框
                'Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                'Application.Exit()
                D_ToolStripStatusLabel_Msg(Drawing.Color.Red)
                ToolStripStatusLabel_Msg.Text = "数据库配置信息出现错误，无法继续。"
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                D_ToolStripStatusLabel_Msg(Drawing.Color.Red)
                ToolStripStatusLabel_Msg.Text = "未知错误，无法继续。"
            End Try

        End Using

        If Trim(TextBox_Compellation.Text) <> Trim(TextBox_Search_Compellation.Text) Then
            '调用消息弹框
            'Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), String.Format(rm.GetObject("Main.TextBox_Compellation.Text <> TextBox_Search_Compellation.Text"), TextBox_Search_Compellation.Text), System.Media.SystemSounds.Asterisk)
            D_ToolStripStatusLabel_Msg(Drawing.Color.Red)
            ToolStripStatusLabel_Msg.Text = String.Format(rm.GetObject("Main.TextBox_Compellation.Text <> TextBox_Search_Compellation.Text"), TextBox_Search_Compellation.Text)
            D_Button_Modify(False)
            D_Button_Delete(False)
            Exit Sub
        Else
            D_Button_Modify(True)
            D_Button_Delete(True)
            'Exit Sub
        End If

        D_ToolStripStatusLabel_Msg(Drawing.Color.Black)
        ToolStripStatusLabel_Msg.Text = "就绪"
    End Sub

    ' 线程 添加
    Private Sub make_dbdata_A()
        '为了实现姓名中去除空格，声明一个变量进行存储处理
        Dim sentence As String = TextBox_Compellation.Text
        Dim charsToTrim() As Char = {","c, "."c, " "c}
        Dim words() As String = sentence.Split()
        TextBox_Compellation.Text = Nothing '清空后重新赋值
        For Each word As String In words
            TextBox_Compellation.Text = TextBox_Compellation.Text + word.TrimEnd(charsToTrim)
        Next

        ' 操作过程
        If Trim(TextBox_Compellation.Text).Length < 1 Then
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), rm.GetObject("Main.TextBox_Compellation.Text.Length < 1"), System.Media.SystemSounds.Asterisk)
            ToolStripLabel_basic_information.PerformClick()
            TextBox_Compellation.Focus()
            Exit Sub
        End If

        '性别 ,并作为修改删除按钮的启用检测
        Dim xingbie As String = Nothing
        ' 声明密码变量
        Dim PWD As String = Nothing
        If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Module1.Err_MSG_Text"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        End If

        If RadioButton_Men.Checked = True Then
            xingbie = "男"
        ElseIf RadioButton_Women.Checked = True Then
            xingbie = "女"
        Else
            xingbie = ""
        End If

        ' 执行查询数据是否已经存在
        Dim getstring As String = Nothing
        If db.Access_db(
Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
  "Microsoft.Jet.Oledb.4.0", PWD,
  "SELECT * FROM [MEMBER] WHERE compellation='" & Trim(TextBox_Compellation.Text) & "'",
  3, getstring) = "OleDbException" Then
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        Else

            If getstring = Trim(TextBox_Compellation.Text) Then
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipwarn"), String.Format(rm.GetObject("Main.AddFailed"), TextBox_Compellation.Text), System.Media.SystemSounds.Asterisk)
                Exit Sub
            End If
        End If

        ' 操作数据库
        Select Case _
db.Access_db(
Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
  "Microsoft.Jet.Oledb.4.0", PWD,
  "INSERT INTO [MEMBER]" & _
  " (compellation,sex,marital_status,twelve_animals,birthday_year,birthday_month,birthday_day,blood_type,hometown_province,hometown_city,hometown_county," & _
  "hometown_town,live_province,live_city,live_county,live_town,email_address,mobile_number,qq_number,msn_number,other_number," & _
  "school_name,class_name,entrance_school_year,company_name,department,worktime_begin_year,worktime_begin_month,worktime_finish_year,worktime_finish_month,personal_hobby," & _
  "personal_love,personal_wish,personal_presentation)" & _
  " values " & _
  "('" & Trim(TextBox_Compellation.Text) & "', '" & Trim(xingbie) & "', '" & Trim(ComboBox_Marital_status.Text) & "', '" & Trim(ComboBox_Twelve_animals.Text) & "', '" & Trim(ComboBox_Birthday_year.Text) & "', '" & Trim(ComboBox_Birthday_month.Text) & "', '" & Trim(ComboBox_Birthday_day.Text) & "', '" & Trim(ComboBox_Blood_type.Text) & "', '" & Trim(ComboBox_Hometown_province.Text) & "', '" & Trim(ComboBox_Hometown_city.Text) & "', '" & Trim(ComboBox_Hometown_county.Text) & "', '" & Trim(ComboBox_Hometown_town.Text) & "', '" & Trim(ComboBox_Live_province.Text) & "', '" & Trim(ComboBox_Live_city.Text) & "', '" & Trim(ComboBox_Live_county.Text) & "', '" & Trim(ComboBox_Live_town.Text) & "', '" & Trim(TextBox_Email_address.Text) & "', '" & Trim(TextBox_Mobile_number.Text) & "', '" & Trim(TextBox_Qq_number.Text) & "', '" & Trim(TextBox_Msn_number.Text) & "', '" & Trim(TextBox_Other_number.Text) & "', '" & Trim(TextBox_School_name.Text) & "', '" & Trim(TextBox_Class_name.Text) & "', '" & Trim(ComboBox_Entrance_school_year.Text) & "', '" & Trim(TextBox_Company_name.Text) & "', '" & Trim(TextBox_Department.Text) & "', '" & Trim(ComboBox_Worktime_begin_year.Text) & "', '" & Trim(ComboBox_Worktime_begin_month.Text) & "', '" & Trim(ComboBox_Worktime_finish_year.Text) & "', '" & Trim(ComboBox_Worktime_finish_month.Text) & "', '" & Trim(TextBox_Personal_hobby.Text) & "', '" & Trim(TextBox_Personal_love.Text) & "', '" & Trim(TextBox_Personal_wish.Text) & "', '" & Trim(TextBox_Personal_presentation.Text) & "')",
  4, Nothing)
            Case True.ToString
                If imgbybe IsNot Nothing Then pic() '判断图片数据是否存在数据并调用添加图片方法
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), String.Format(rm.GetObject("Main.AddSuccess"), TextBox_Compellation.Text), System.Media.SystemSounds.Asterisk)
            Case "InvalidOperationException"
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                Application.Exit()
            Case "OleDbException"
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                Application.Exit()
        End Select
        TextBox_Compellation.ReadOnly = True
        D_Button_Modify(True)
        D_Button_Delete(True)
    End Sub

    ' 线程 修改
    Private Sub make_dbdata_M()
        '性别 ,并作为修改删除按钮的启用检测
        Dim xingbie As String = Nothing
        ' 声明密码变量
        Dim PWD As String = Nothing
        If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Module1.Err_MSG_Text"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        End If

        If RadioButton_Men.Checked = True Then
            xingbie = "男"
        ElseIf RadioButton_Women.Checked = True Then
            xingbie = "女"
        Else
            xingbie = Nothing
        End If

        ' 操作数据库
        Select Case _
db.Access_db(
Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
  "Microsoft.Jet.Oledb.4.0", PWD,
  "UPDATE [MEMBER] SET " & _
  "sex='" & Trim(xingbie) & "', marital_status= '" & Trim(ComboBox_Marital_status.Text) & "', twelve_animals= '" & Trim(ComboBox_Twelve_animals.Text) & "', birthday_year= '" & Trim(ComboBox_Birthday_year.Text) & "', birthday_month= '" & Trim(ComboBox_Birthday_month.Text) & "', birthday_day= '" & Trim(ComboBox_Birthday_day.Text) & "', blood_type= '" & Trim(ComboBox_Blood_type.Text) & "', hometown_province= '" & Trim(ComboBox_Hometown_province.Text) & "', hometown_city= '" & Trim(ComboBox_Hometown_city.Text) & "', hometown_county= '" & Trim(ComboBox_Hometown_county.Text) & "', hometown_town= '" & Trim(ComboBox_Hometown_town.Text) & "', live_province= '" & Trim(ComboBox_Live_province.Text) & "', live_city= '" & Trim(ComboBox_Live_city.Text) & "', live_county= '" & Trim(ComboBox_Live_county.Text) & "', live_town= '" & Trim(ComboBox_Live_town.Text) & "', email_address= '" & Trim(TextBox_Email_address.Text) & "', mobile_number= '" & Trim(TextBox_Mobile_number.Text) & "', qq_number= '" & Trim(TextBox_Qq_number.Text) & "', msn_number= '" & Trim(TextBox_Msn_number.Text) & "', other_number= '" & Trim(TextBox_Other_number.Text) & "', school_name= '" & Trim(TextBox_School_name.Text) & "', class_name= '" & Trim(TextBox_Class_name.Text) & "', entrance_school_year= '" & Trim(ComboBox_Entrance_school_year.Text) & "', company_name= '" & Trim(TextBox_Company_name.Text) & "', department= '" & Trim(TextBox_Department.Text) & "', worktime_begin_year= '" & Trim(ComboBox_Worktime_begin_year.Text) & "', worktime_begin_month= '" & Trim(ComboBox_Worktime_begin_month.Text) & "', worktime_finish_year= '" & Trim(ComboBox_Worktime_finish_year.Text) & "', worktime_finish_month= '" & Trim(ComboBox_Worktime_finish_month.Text) & "', personal_hobby= '" & Trim(TextBox_Personal_hobby.Text) & "', personal_love= '" & Trim(TextBox_Personal_love.Text) & "', personal_wish= '" & Trim(TextBox_Personal_wish.Text) & "', personal_presentation= '" & Trim(TextBox_Personal_presentation.Text) & _
  "' WHERE compellation ='" & Trim(TextBox_Compellation.Text) & "'",
  4, Nothing)
            Case True.ToString
                If imgbybe IsNot Nothing Then pic() '判断图片数据是否存在数据并调用添加图片方法
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), String.Format(rm.GetObject("Main.ChangeSuccess"), TextBox_Compellation.Text), System.Media.SystemSounds.Asterisk)
            Case "InvalidOperationException"
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                Application.Exit()
            Case "OleDbException"
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                Application.Exit()
        End Select
    End Sub

    ' 线程 删除
    Private Sub make_dbdata_D()
        '性别 ,并作为修改删除按钮的启用检测
        Dim xingbie As String = Nothing
        ' 声明密码变量
        Dim PWD As String = Nothing
        If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Module1.Err_MSG_Text"), System.Media.SystemSounds.Exclamation)
            Application.Exit()
        End If
        ' 操作过程

        ' 提示是否继续
        '实例化对话框
        Dim Dialog As New ShowDialog
        '设置对话框标题文本
        Dialog.Label_Title.Text = rm.GetObject("INFO_MSG_TITLE")
        '设置对话框图标
        Dialog.Panel_ICO.BackgroundImage = rm.GetObject("tipques")
        '设置对话框消息文本
        Dialog.Label_Msg.Text = String.Format(rm.GetObject("Main.DeleteYesNO"), Trim(TextBox_Compellation.Text))
        '显示对话框
        Dialog.ShowDialog()

        If Dialog.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If

        ' 操作数据库
        Select Case _
db.Access_db(
  Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat",
  "Microsoft.Jet.Oledb.4.0", PWD,
  "DELETE FROM [MEMBER] " & _
  "WHERE compellation='" & Trim(TextBox_Compellation.Text) & "'",
  4, Nothing)
            Case True.ToString
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("INFO_MSG_TITLE"), rm.GetObject("tipnorm"), String.Format(rm.GetObject("Main.DeleteSuccess"), TextBox_Compellation.Text), System.Media.SystemSounds.Asterisk)
            Case "InvalidOperationException"
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                Application.Exit()
            Case "OleDbException"
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                Application.Exit()
        End Select
        D_Button_Delete(False)
        D_Button_Modify(False)
        TextBox_Compellation.ReadOnly = True
        '创建线程对象
        Dim Nt1 As Threading.Thread
        Nt1 = New Threading.Thread(AddressOf clean)
        '执行线程
        Nt1.Start()
    End Sub

    ' 线程 初始化数据方法
    Private Sub clean()
        ' 初始化数据
        D_TextBox_Compellation(Nothing)
        D_RadioButton_Men(False)
        D_RadioButton_Women(False)
        D_ComboBox_Marital_status(Nothing)
        D_ComboBox_Birthday_year(Nothing)
        D_ComboBox_Birthday_month(Nothing)
        D_ComboBox_Twelve_animals(Nothing)
        D_ComboBox_Birthday_day(Nothing)
        D_ComboBox_Blood_type(Nothing)
        D_ComboBox_Hometown_province(Nothing)
        D_ComboBox_Hometown_city(Nothing)
        D_ComboBox_Hometown_county(Nothing)
        D_ComboBox_Hometown_town(Nothing)
        D_ComboBox_Live_province(Nothing)
        D_ComboBox_Live_city(Nothing)
        D_ComboBox_Live_county(Nothing)
        D_ComboBox_Live_town(Nothing)
        D_TextBox_Email_address(Nothing)
        D_TextBox_Mobile_number(Nothing)
        D_TextBox_Qq_number(Nothing)
        D_TextBox_Msn_number(Nothing)
        D_TextBox_Other_number(Nothing)
        D_TextBox_School_name(Nothing)
        D_TextBox_Class_name(Nothing)
        D_ComboBox_Entrance_school_year(Nothing)
        D_TextBox_Company_name(Nothing)
        D_TextBox_Department(Nothing)
        D_ComboBox_Worktime_begin_year(Nothing)
        D_ComboBox_Worktime_begin_month(Nothing)
        D_ComboBox_Worktime_finish_year(Nothing)
        D_ComboBox_Worktime_finish_month(Nothing)
        D_TextBox_Personal_hobby(Nothing)
        D_TextBox_Personal_love(Nothing)
        D_TextBox_Personal_wish(Nothing)
        D_TextBox_Personal_presentation(Nothing)
        PictureBox_Photo.Image = Nothing
        imgbybe = Nothing
    End Sub

    ' 添加修改图片
    Private Sub pic()
        On Error Resume Next '忽略错误

        ' 判断图片数组变量是否存在数据
        If imgbybe Is Nothing Then
            Exit Sub
        End If

        ' 声明密码变量
        Dim PWD As String = Nothing
        If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
            Exit Sub
        End If

        Using connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat" + ";Jet OLEDB:Database Password=" + PWD + ";")
            Dim command As New OleDbCommand("UPDATE [MEMBER] SET pic=(?) WHERE compellation ='" & Trim(TextBox_Compellation.Text) & "'", connection)
            command.CommandTimeout = 20
            command.Parameters.Add(New OleDbParameter)
            command.Parameters(0).Value = imgbybe
            connection.Open()
            If command.ExecuteNonQuery > 0 Then
                Console.WriteLine("添加图片成功")
            End If
        End Using
    End Sub

    '输入框释放按键事件
    Private Sub TextBox_KeyPress(sender As Object, e As EventArgs) Handles _
        TextBox_Email_address.KeyUp,
        TextBox_Mobile_number.KeyUp,
        TextBox_Qq_number.KeyUp


        Select Case sender.name.ToString

            Case "TextBox_Email_address"
                If Info_Class.IsValid_Email_address(Trim(TextBox_Email_address.Text)) = True Or Trim(TextBox_Email_address.Text) = Nothing Then
                    D_ToolStripStatusLabel_Msg(Drawing.Color.Black)
                    ToolStripStatusLabel_Msg.Text = "就绪"
                Else
                    D_ToolStripStatusLabel_Msg(Drawing.Color.Red)
                    ToolStripStatusLabel_Msg.Text = "警告 - [联系方式]电子邮箱地址不符合规范"
                End If

            Case "TextBox_Mobile_number"
                '限制只能输入 数字 0-9 和退格
                '  If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
                'e.Handled = False
                ' Else
                ' e.Handled = True
                ' End If
                '130-0000-0000 如此格式
                If Info_Class.IsValid_Mobile_number(Trim(TextBox_Mobile_number.Text)) = True Or Trim(TextBox_Mobile_number.Text) = Nothing Then
                    D_ToolStripStatusLabel_Msg(Drawing.Color.Black)
                    ToolStripStatusLabel_Msg.Text = "就绪"
                Else
                    D_ToolStripStatusLabel_Msg(Drawing.Color.Red)
                    ToolStripStatusLabel_Msg.Text = "警告 - [联系方式]手机号码不符合规范"
                End If

            Case "TextBox_Qq_number"
                If Info_Class.IsValid_Qq_number(Trim(TextBox_Qq_number.Text)) = True Or Trim(TextBox_Qq_number.Text) = Nothing Then
                    D_ToolStripStatusLabel_Msg(Drawing.Color.Black)
                    ToolStripStatusLabel_Msg.Text = "就绪"
                Else
                    D_ToolStripStatusLabel_Msg(Drawing.Color.Red)
                    ToolStripStatusLabel_Msg.Text = "警告 - [联系方式]QQ号码不符合规范"
                End If

        End Select

    End Sub

    ' 填充数据集
    Private Function CreateDataAdapter(ByVal selectCommand As String, _
   ByVal connection As OleDbConnection) As OleDbDataAdapter

        Dim adapter As OleDbDataAdapter = _
            New OleDbDataAdapter(selectCommand, connection)

        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ' Create the commands.
        adapter.InsertCommand = New OleDbCommand( _
            "INSERT INTO Customers (CustomerID, CompanyName) " & _
             "VALUES (?, ?)")

        adapter.UpdateCommand = New OleDbCommand( _
            "UPDATE Customers SET CustomerID = ?, CompanyName = ? " & _
            "WHERE CustomerID = ?")

        adapter.DeleteCommand = New OleDbCommand( _
            "DELETE FROM Customers WHERE CustomerID = ?")

        ' Create the parameters.
        adapter.InsertCommand.Parameters.Add( _
            "@CustomerID", OleDbType.Char, 5, "CustomerID")
        adapter.InsertCommand.Parameters.Add( _
            "@CompanyName", OleDbType.VarChar, 40, "CompanyName")

        adapter.UpdateCommand.Parameters.Add( _
            "@CustomerID", OleDbType.Char, 5, "CustomerID")
        adapter.UpdateCommand.Parameters.Add( _
            "@CompanyName", OleDbType.VarChar, 40, "CompanyName")
        adapter.UpdateCommand.Parameters.Add( _
            "@oldCustomerID", OleDbType.Char, 5, "CustomerID").SourceVersion = _
            DataRowVersion.Original

        adapter.DeleteCommand.Parameters.Add( _
            "@CustomerID", OleDbType.Char, 5, "CustomerID").SourceVersion = _
            DataRowVersion.Original

        Return adapter
    End Function

    ' 显示全部数据窗口
    Private Sub Ergodic()

        Dim Ergodic_Form As New Form
        Dim datatable As New Data.DataTable
        Dim DataGridView1 As New DataGridView

        With Ergodic_Form
            .StartPosition = FormStartPosition.CenterParent
            .Text = "遍历数据"
            .Icon = rm.GetObject("MainIco")
            .Controls.Add(DataGridView1)
        End With

        'xxxxxx
        Dim PWD As String = Nothing
        If Database_Conn.dbconn(PWD) = False Then   '调用密码，并赋值，探测执行是否成功
            '调用消息弹框
            Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("Module1.Err_MSG_Text"), System.Media.SystemSounds.Exclamation)
            'Ergodic_Form.Close()
            Application.ExitThread()
            Exit Sub
        End If

        Using connection As New OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + Application_StartupPath + "66ed5fcaf39b2fa003968f9477204ae4.dat" + ";Jet OLEDB:Database Password=" + PWD + ";")


            Try
                CreateDataAdapter(
                    "SELECT ID,compellation,sex,marital_status,twelve_animals,birthday_year,birthday_month,birthday_day,blood_type,hometown_province,hometown_city,hometown_county,hometown_town,live_province,live_city,live_county,live_town,email_address,mobile_number,qq_number,msn_number,other_number,school_name,class_name,entrance_school_year,company_name,department,worktime_begin_year,worktime_begin_month,worktime_finish_year,worktime_finish_month,personal_hobby,personal_love,personal_wish,personal_presentation,operation_time FROM [MEMBER]" _
                                  , connection).Fill(datatable)
                'CreateDataAdapter("SELECT * FROM [MEMBER]", connection).Fill(datatable)
                DataGridView1.DataSource = datatable

                With DataGridView1
                    .BackgroundColor = Drawing.Color.WhiteSmoke
                    .Dock = DockStyle.Fill

                    '.Columns(0).Name = "Release Date"
                    '.Columns(1).Name = "Track"
                    '.Columns(2).Name = "Title"
                    '.Columns(3).Name = "Artist"
                    '.Columns(4).Name = "Album"
                    '.Columns(0).DisplayIndex = 3
                    .Columns(0).HeaderText = "序列"
                    .Columns(1).HeaderText = "姓名"
                    .Columns(2).HeaderText = "性别"
                    .Columns(3).HeaderText = "婚姻状况"
                    .Columns(4).HeaderText = "生肖"
                    .Columns(5).HeaderText = "生日(年)"
                    .Columns(6).HeaderText = "生日(月)"
                    .Columns(7).HeaderText = "生日(日)"
                    .Columns(8).HeaderText = "血型"
                    .Columns(9).HeaderText = "家乡(省)"
                    .Columns(10).HeaderText = "家乡(市)"
                    .Columns(11).HeaderText = "家乡(县)"
                    .Columns(12).HeaderText = "家乡(镇)"
                    .Columns(13).HeaderText = "居住地(省)"
                    .Columns(14).HeaderText = "居住地(市)"
                    .Columns(15).HeaderText = "居住地(县)"
                    .Columns(16).HeaderText = "居住地(镇)"
                    '.Columns(16).HeaderText = "个人头像"
                    .Columns(17).HeaderText = "电子邮箱"
                    .Columns(18).HeaderText = "手机号码"
                    .Columns(19).HeaderText = "QQ号码"
                    .Columns(20).HeaderText = "MSN号码"
                    .Columns(21).HeaderText = "其他号码"
                    .Columns(22).HeaderText = "学校名称"
                    .Columns(23).HeaderText = "班级或院系"
                    .Columns(24).HeaderText = "入学年份"
                    .Columns(25).HeaderText = "公司或机构"
                    .Columns(26).HeaderText = "部门"
                    .Columns(27).HeaderText = "工作开始(年)"
                    .Columns(28).HeaderText = "工作开始(月)"
                    .Columns(29).HeaderText = "工作截止(年)"
                    .Columns(30).HeaderText = "工作截止(月)"
                    .Columns(31).HeaderText = "兴趣爱好"
                    .Columns(32).HeaderText = "喜欢的事物"
                    .Columns(33).HeaderText = "最大的心愿"
                    .Columns(34).HeaderText = "简单介绍"
                    .Columns(35).HeaderText = "资料添加时间"

                    .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(18).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(19).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(20).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(21).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(22).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(23).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(24).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(25).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(26).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(27).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(28).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(29).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(30).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns(35).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                End With

            Catch ex As InvalidOperationException
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("InvalidOperationException"), System.Media.SystemSounds.Exclamation)
                Application.ExitThread()
                Exit Sub
            Catch ex As OleDbException
                '调用消息弹框
                Info_Class.Msg_Show(rm.GetObject("ERR_MSG_TITLE"), rm.GetObject("tiperror"), rm.GetObject("OleDbException"), System.Media.SystemSounds.Exclamation)
                Application.ExitThread()
                Exit Sub
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End Using
        'Application.Run(Ergodic_Form)
        Ergodic_Form.ShowDialog()

    End Sub

End Class