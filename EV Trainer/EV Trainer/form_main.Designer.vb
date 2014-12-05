<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_SelectedPok = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FILEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAVEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DELETESAVEFILEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ABOUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rd_252 = New System.Windows.Forms.RadioButton()
        Me.rd_255 = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lb_TotalCurrent = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lb_TotalPlanned = New System.Windows.Forms.Label()
        Me.tb_CurrentSpd = New System.Windows.Forms.TextBox()
        Me.tb_PlannedSpd = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_CurrentSpDef = New System.Windows.Forms.TextBox()
        Me.tb_PlannedSpDef = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_CurrentSpAtk = New System.Windows.Forms.TextBox()
        Me.tb_PlannedSpAtk = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_CurrentDef = New System.Windows.Forms.TextBox()
        Me.tb_PlannedDef = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_CurrentAtk = New System.Windows.Forms.TextBox()
        Me.tb_PlannedAtk = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_CurrentHP = New System.Windows.Forms.TextBox()
        Me.tb_PlannedHP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_clear = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_5 = New System.Windows.Forms.Button()
        Me.btn_2 = New System.Windows.Forms.Button()
        Me.btn_1 = New System.Windows.Forms.Button()
        Me.lb_EnemySpd = New System.Windows.Forms.Label()
        Me.lb_EnemySpDef = New System.Windows.Forms.Label()
        Me.lb_EnemySpAtk = New System.Windows.Forms.Label()
        Me.lb_EnemyDef = New System.Windows.Forms.Label()
        Me.lb_EnemyAtk = New System.Windows.Forms.Label()
        Me.lb_EnemyHP = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmb_enemy = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip_EnemyList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SortByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PokédexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_details = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip_EnemyList.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Training Pokémon:"
        '
        'cmb_SelectedPok
        '
        Me.cmb_SelectedPok.FormattingEnabled = True
        Me.cmb_SelectedPok.Location = New System.Drawing.Point(112, 45)
        Me.cmb_SelectedPok.Name = "cmb_SelectedPok"
        Me.cmb_SelectedPok.Size = New System.Drawing.Size(189, 21)
        Me.cmb_SelectedPok.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FILEToolStripMenuItem, Me.ToolStripMenuItem1, Me.ABOUTToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(346, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FILEToolStripMenuItem
        '
        Me.FILEToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SAVEToolStripMenuItem, Me.DELETESAVEFILEToolStripMenuItem})
        Me.FILEToolStripMenuItem.Name = "FILEToolStripMenuItem"
        Me.FILEToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.FILEToolStripMenuItem.Text = "FILE"
        '
        'SAVEToolStripMenuItem
        '
        Me.SAVEToolStripMenuItem.Name = "SAVEToolStripMenuItem"
        Me.SAVEToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SAVEToolStripMenuItem.Text = "SAVE"
        '
        'DELETESAVEFILEToolStripMenuItem
        '
        Me.DELETESAVEFILEToolStripMenuItem.Name = "DELETESAVEFILEToolStripMenuItem"
        Me.DELETESAVEFILEToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DELETESAVEFILEToolStripMenuItem.Text = "DELETE SAVE FILE"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(47, 20)
        Me.ToolStripMenuItem1.Text = "HELP"
        '
        'ABOUTToolStripMenuItem
        '
        Me.ABOUTToolStripMenuItem.Name = "ABOUTToolStripMenuItem"
        Me.ABOUTToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ABOUTToolStripMenuItem.Text = "ABOUT"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rd_252)
        Me.GroupBox1.Controls.Add(Me.rd_255)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.lb_TotalCurrent)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lb_TotalPlanned)
        Me.GroupBox1.Controls.Add(Me.tb_CurrentSpd)
        Me.GroupBox1.Controls.Add(Me.tb_PlannedSpd)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.tb_CurrentSpDef)
        Me.GroupBox1.Controls.Add(Me.tb_PlannedSpDef)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tb_CurrentSpAtk)
        Me.GroupBox1.Controls.Add(Me.tb_PlannedSpAtk)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tb_CurrentDef)
        Me.GroupBox1.Controls.Add(Me.tb_PlannedDef)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.tb_CurrentAtk)
        Me.GroupBox1.Controls.Add(Me.tb_PlannedAtk)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tb_CurrentHP)
        Me.GroupBox1.Controls.Add(Me.tb_PlannedHP)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 274)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "EV STATS"
        '
        'rd_252
        '
        Me.rd_252.AutoSize = True
        Me.rd_252.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rd_252.Location = New System.Drawing.Point(100, 36)
        Me.rd_252.Name = "rd_252"
        Me.rd_252.Size = New System.Drawing.Size(84, 17)
        Me.rd_252.TabIndex = 27
        Me.rd_252.TabStop = True
        Me.rd_252.Text = "252 (Gen VI)"
        Me.rd_252.UseVisualStyleBackColor = True
        '
        'rd_255
        '
        Me.rd_255.AutoSize = True
        Me.rd_255.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rd_255.Location = New System.Drawing.Point(100, 18)
        Me.rd_255.Name = "rd_255"
        Me.rd_255.Size = New System.Drawing.Size(93, 17)
        Me.rd_255.TabIndex = 26
        Me.rd_255.TabStop = True
        Me.rd_255.Text = "255 (Gen III-V)"
        Me.rd_255.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Max EVs per stat:"
        '
        'lb_TotalCurrent
        '
        Me.lb_TotalCurrent.AutoSize = True
        Me.lb_TotalCurrent.Location = New System.Drawing.Point(222, 249)
        Me.lb_TotalCurrent.Name = "lb_TotalCurrent"
        Me.lb_TotalCurrent.Size = New System.Drawing.Size(60, 13)
        Me.lb_TotalCurrent.TabIndex = 22
        Me.lb_TotalCurrent.Text = "CURRENT"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(47, 249)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "TOTAL"
        '
        'lb_TotalPlanned
        '
        Me.lb_TotalPlanned.AutoSize = True
        Me.lb_TotalPlanned.Location = New System.Drawing.Point(117, 249)
        Me.lb_TotalPlanned.Name = "lb_TotalPlanned"
        Me.lb_TotalPlanned.Size = New System.Drawing.Size(58, 13)
        Me.lb_TotalPlanned.TabIndex = 20
        Me.lb_TotalPlanned.Text = "PLANNED"
        '
        'tb_CurrentSpd
        '
        Me.tb_CurrentSpd.Location = New System.Drawing.Point(202, 212)
        Me.tb_CurrentSpd.Name = "tb_CurrentSpd"
        Me.tb_CurrentSpd.Size = New System.Drawing.Size(100, 20)
        Me.tb_CurrentSpd.TabIndex = 19
        '
        'tb_PlannedSpd
        '
        Me.tb_PlannedSpd.Location = New System.Drawing.Point(96, 212)
        Me.tb_PlannedSpd.Name = "tb_PlannedSpd"
        Me.tb_PlannedSpd.Size = New System.Drawing.Size(100, 20)
        Me.tb_PlannedSpd.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Speed"
        '
        'tb_CurrentSpDef
        '
        Me.tb_CurrentSpDef.Location = New System.Drawing.Point(202, 186)
        Me.tb_CurrentSpDef.Name = "tb_CurrentSpDef"
        Me.tb_CurrentSpDef.Size = New System.Drawing.Size(100, 20)
        Me.tb_CurrentSpDef.TabIndex = 16
        '
        'tb_PlannedSpDef
        '
        Me.tb_PlannedSpDef.Location = New System.Drawing.Point(96, 186)
        Me.tb_PlannedSpDef.Name = "tb_PlannedSpDef"
        Me.tb_PlannedSpDef.Size = New System.Drawing.Size(100, 20)
        Me.tb_PlannedSpDef.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Special Defence"
        '
        'tb_CurrentSpAtk
        '
        Me.tb_CurrentSpAtk.Location = New System.Drawing.Point(202, 160)
        Me.tb_CurrentSpAtk.Name = "tb_CurrentSpAtk"
        Me.tb_CurrentSpAtk.Size = New System.Drawing.Size(100, 20)
        Me.tb_CurrentSpAtk.TabIndex = 13
        '
        'tb_PlannedSpAtk
        '
        Me.tb_PlannedSpAtk.Location = New System.Drawing.Point(96, 160)
        Me.tb_PlannedSpAtk.Name = "tb_PlannedSpAtk"
        Me.tb_PlannedSpAtk.Size = New System.Drawing.Size(100, 20)
        Me.tb_PlannedSpAtk.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Special Attack"
        '
        'tb_CurrentDef
        '
        Me.tb_CurrentDef.Location = New System.Drawing.Point(202, 134)
        Me.tb_CurrentDef.Name = "tb_CurrentDef"
        Me.tb_CurrentDef.Size = New System.Drawing.Size(100, 20)
        Me.tb_CurrentDef.TabIndex = 10
        '
        'tb_PlannedDef
        '
        Me.tb_PlannedDef.Location = New System.Drawing.Point(96, 134)
        Me.tb_PlannedDef.Name = "tb_PlannedDef"
        Me.tb_PlannedDef.Size = New System.Drawing.Size(100, 20)
        Me.tb_PlannedDef.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Defence"
        '
        'tb_CurrentAtk
        '
        Me.tb_CurrentAtk.Location = New System.Drawing.Point(202, 108)
        Me.tb_CurrentAtk.Name = "tb_CurrentAtk"
        Me.tb_CurrentAtk.Size = New System.Drawing.Size(100, 20)
        Me.tb_CurrentAtk.TabIndex = 7
        '
        'tb_PlannedAtk
        '
        Me.tb_PlannedAtk.Location = New System.Drawing.Point(96, 108)
        Me.tb_PlannedAtk.Name = "tb_PlannedAtk"
        Me.tb_PlannedAtk.Size = New System.Drawing.Size(100, 20)
        Me.tb_PlannedAtk.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Attack"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(222, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "CURRENT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(117, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PLANNED"
        '
        'tb_CurrentHP
        '
        Me.tb_CurrentHP.Location = New System.Drawing.Point(202, 82)
        Me.tb_CurrentHP.Name = "tb_CurrentHP"
        Me.tb_CurrentHP.Size = New System.Drawing.Size(100, 20)
        Me.tb_CurrentHP.TabIndex = 2
        '
        'tb_PlannedHP
        '
        Me.tb_PlannedHP.Location = New System.Drawing.Point(96, 82)
        Me.tb_PlannedHP.Name = "tb_PlannedHP"
        Me.tb_PlannedHP.Size = New System.Drawing.Size(100, 20)
        Me.tb_PlannedHP.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "HP"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_clear)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.lb_EnemySpd)
        Me.GroupBox2.Controls.Add(Me.lb_EnemySpDef)
        Me.GroupBox2.Controls.Add(Me.lb_EnemySpAtk)
        Me.GroupBox2.Controls.Add(Me.lb_EnemyDef)
        Me.GroupBox2.Controls.Add(Me.lb_EnemyAtk)
        Me.GroupBox2.Controls.Add(Me.lb_EnemyHP)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.cmb_enemy)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 370)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 172)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "BATTLED POKÉMON"
        '
        'chk_clear
        '
        Me.chk_clear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_clear.Location = New System.Drawing.Point(16, 135)
        Me.chk_clear.Name = "chk_clear"
        Me.chk_clear.Size = New System.Drawing.Size(76, 33)
        Me.chk_clear.TabIndex = 34
        Me.chk_clear.Text = "Clear after adding?"
        Me.chk_clear.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btn_5)
        Me.Panel1.Controls.Add(Me.btn_2)
        Me.Panel1.Controls.Add(Me.btn_1)
        Me.Panel1.Location = New System.Drawing.Point(97, 130)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 6, 6)
        Me.Panel1.Size = New System.Drawing.Size(125, 42)
        Me.Panel1.TabIndex = 33
        '
        'btn_5
        '
        Me.btn_5.AutoSize = True
        Me.btn_5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_5.Location = New System.Drawing.Point(84, 10)
        Me.btn_5.Name = "btn_5"
        Me.btn_5.Size = New System.Drawing.Size(32, 23)
        Me.btn_5.TabIndex = 35
        Me.btn_5.Text = "× 5"
        Me.btn_5.UseVisualStyleBackColor = True
        '
        'btn_2
        '
        Me.btn_2.AutoSize = True
        Me.btn_2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_2.Location = New System.Drawing.Point(47, 10)
        Me.btn_2.Name = "btn_2"
        Me.btn_2.Size = New System.Drawing.Size(32, 23)
        Me.btn_2.TabIndex = 34
        Me.btn_2.Text = "× 2"
        Me.btn_2.UseVisualStyleBackColor = True
        '
        'btn_1
        '
        Me.btn_1.AutoSize = True
        Me.btn_1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_1.Location = New System.Drawing.Point(10, 10)
        Me.btn_1.Name = "btn_1"
        Me.btn_1.Size = New System.Drawing.Size(32, 23)
        Me.btn_1.TabIndex = 33
        Me.btn_1.Text = "× 1"
        Me.btn_1.UseVisualStyleBackColor = True
        '
        'lb_EnemySpd
        '
        Me.lb_EnemySpd.AutoSize = True
        Me.lb_EnemySpd.Location = New System.Drawing.Point(258, 105)
        Me.lb_EnemySpd.Name = "lb_EnemySpd"
        Me.lb_EnemySpd.Size = New System.Drawing.Size(45, 13)
        Me.lb_EnemySpd.TabIndex = 29
        Me.lb_EnemySpd.Text = "Label21"
        '
        'lb_EnemySpDef
        '
        Me.lb_EnemySpDef.AutoSize = True
        Me.lb_EnemySpDef.Location = New System.Drawing.Point(258, 79)
        Me.lb_EnemySpDef.Name = "lb_EnemySpDef"
        Me.lb_EnemySpDef.Size = New System.Drawing.Size(45, 13)
        Me.lb_EnemySpDef.TabIndex = 28
        Me.lb_EnemySpDef.Text = "Label20"
        '
        'lb_EnemySpAtk
        '
        Me.lb_EnemySpAtk.AutoSize = True
        Me.lb_EnemySpAtk.Location = New System.Drawing.Point(258, 53)
        Me.lb_EnemySpAtk.Name = "lb_EnemySpAtk"
        Me.lb_EnemySpAtk.Size = New System.Drawing.Size(45, 13)
        Me.lb_EnemySpAtk.TabIndex = 27
        Me.lb_EnemySpAtk.Text = "Label19"
        '
        'lb_EnemyDef
        '
        Me.lb_EnemyDef.AutoSize = True
        Me.lb_EnemyDef.Location = New System.Drawing.Point(74, 105)
        Me.lb_EnemyDef.Name = "lb_EnemyDef"
        Me.lb_EnemyDef.Size = New System.Drawing.Size(45, 13)
        Me.lb_EnemyDef.TabIndex = 26
        Me.lb_EnemyDef.Text = "Label18"
        '
        'lb_EnemyAtk
        '
        Me.lb_EnemyAtk.AutoSize = True
        Me.lb_EnemyAtk.Location = New System.Drawing.Point(74, 79)
        Me.lb_EnemyAtk.Name = "lb_EnemyAtk"
        Me.lb_EnemyAtk.Size = New System.Drawing.Size(45, 13)
        Me.lb_EnemyAtk.TabIndex = 25
        Me.lb_EnemyAtk.Text = "Label17"
        '
        'lb_EnemyHP
        '
        Me.lb_EnemyHP.AutoSize = True
        Me.lb_EnemyHP.Location = New System.Drawing.Point(74, 53)
        Me.lb_EnemyHP.Name = "lb_EnemyHP"
        Me.lb_EnemyHP.Size = New System.Drawing.Size(45, 13)
        Me.lb_EnemyHP.TabIndex = 24
        Me.lb_EnemyHP.Text = "Label16"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(159, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Speed"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(159, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Special Defence"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(159, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Special Attack"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Defence"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Attack"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "HP"
        '
        'cmb_enemy
        '
        Me.cmb_enemy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmb_enemy.ContextMenuStrip = Me.ContextMenuStrip_EnemyList
        Me.cmb_enemy.FormattingEnabled = True
        Me.cmb_enemy.Location = New System.Drawing.Point(10, 19)
        Me.cmb_enemy.Name = "cmb_enemy"
        Me.cmb_enemy.Size = New System.Drawing.Size(293, 21)
        Me.cmb_enemy.TabIndex = 4
        '
        'ContextMenuStrip_EnemyList
        '
        Me.ContextMenuStrip_EnemyList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SortByToolStripMenuItem})
        Me.ContextMenuStrip_EnemyList.Name = "ContextMenuStrip_EnemyList"
        Me.ContextMenuStrip_EnemyList.Size = New System.Drawing.Size(112, 26)
        '
        'SortByToolStripMenuItem
        '
        Me.SortByToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PokédexToolStripMenuItem, Me.NameToolStripMenuItem})
        Me.SortByToolStripMenuItem.Name = "SortByToolStripMenuItem"
        Me.SortByToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.SortByToolStripMenuItem.Text = "Sort by"
        '
        'PokédexToolStripMenuItem
        '
        Me.PokédexToolStripMenuItem.Name = "PokédexToolStripMenuItem"
        Me.PokédexToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.PokédexToolStripMenuItem.Text = "Pokédex #"
        '
        'NameToolStripMenuItem
        '
        Me.NameToolStripMenuItem.Name = "NameToolStripMenuItem"
        Me.NameToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.NameToolStripMenuItem.Text = "Name"
        '
        'btn_details
        '
        Me.btn_details.AutoSize = True
        Me.btn_details.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_details.FlatAppearance.BorderSize = 0
        Me.btn_details.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_details.Location = New System.Drawing.Point(303, 44)
        Me.btn_details.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_details.Name = "btn_details"
        Me.btn_details.Size = New System.Drawing.Size(26, 23)
        Me.btn_details.TabIndex = 6
        Me.btn_details.Text = "..."
        Me.btn_details.UseVisualStyleBackColor = True
        '
        'form_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 559)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmb_SelectedPok)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btn_details)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "form_main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EV Counter"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip_EnemyList.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_SelectedPok As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ABOUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FILEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SAVEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DELETESAVEFILEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_CurrentSpd As System.Windows.Forms.TextBox
    Friend WithEvents tb_PlannedSpd As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_CurrentSpDef As System.Windows.Forms.TextBox
    Friend WithEvents tb_PlannedSpDef As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_CurrentSpAtk As System.Windows.Forms.TextBox
    Friend WithEvents tb_PlannedSpAtk As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_CurrentDef As System.Windows.Forms.TextBox
    Friend WithEvents tb_PlannedDef As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_CurrentAtk As System.Windows.Forms.TextBox
    Friend WithEvents tb_PlannedAtk As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_CurrentHP As System.Windows.Forms.TextBox
    Friend WithEvents tb_PlannedHP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lb_EnemySpd As System.Windows.Forms.Label
    Friend WithEvents lb_EnemySpDef As System.Windows.Forms.Label
    Friend WithEvents lb_EnemySpAtk As System.Windows.Forms.Label
    Friend WithEvents lb_EnemyDef As System.Windows.Forms.Label
    Friend WithEvents lb_EnemyAtk As System.Windows.Forms.Label
    Friend WithEvents lb_EnemyHP As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmb_enemy As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_5 As System.Windows.Forms.Button
    Friend WithEvents btn_2 As System.Windows.Forms.Button
    Friend WithEvents btn_1 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip_EnemyList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SortByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PokédexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_details As System.Windows.Forms.Button
    Friend WithEvents lb_TotalCurrent As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lb_TotalPlanned As System.Windows.Forms.Label
    Friend WithEvents chk_clear As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents rd_252 As System.Windows.Forms.RadioButton
    Friend WithEvents rd_255 As System.Windows.Forms.RadioButton

End Class
