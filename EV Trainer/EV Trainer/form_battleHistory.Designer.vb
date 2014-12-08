<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_battleHistory
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv_history = New System.Windows.Forms.DataGridView()
        CType(Me.dgv_history, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_history
        '
        Me.dgv_history.AllowUserToAddRows = False
        Me.dgv_history.AllowUserToDeleteRows = False
        Me.dgv_history.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = DataGridViewCellStyle1.BackColor
        DataGridViewCellStyle1.SelectionForeColor = DataGridViewCellStyle2.ForeColor
        Me.dgv_history.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_history.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = DataGridViewCellStyle2.BackColor
        DataGridViewCellStyle2.SelectionForeColor = DataGridViewCellStyle2.ForeColor
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_history.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_history.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_history.Location = New System.Drawing.Point(2, 2)
        Me.dgv_history.Name = "dgv_history"
        Me.dgv_history.ReadOnly = True
        Me.dgv_history.RowHeadersVisible = False
        Me.dgv_history.Size = New System.Drawing.Size(287, 181)
        Me.dgv_history.TabIndex = 1
        '
        'form_battleHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 185)
        Me.Controls.Add(Me.dgv_history)
        Me.MaximumSize = New System.Drawing.Size(350, 700)
        Me.MinimumSize = New System.Drawing.Size(307, 224)
        Me.Name = "form_battleHistory"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Battle history: "
        CType(Me.dgv_history, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_history As System.Windows.Forms.DataGridView
End Class
