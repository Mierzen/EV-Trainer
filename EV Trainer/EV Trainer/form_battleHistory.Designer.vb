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
        Me.dgv_history = New System.Windows.Forms.DataGridView()
        CType(Me.dgv_history, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_history
        '
        Me.dgv_history.AllowUserToAddRows = False
        Me.dgv_history.AllowUserToDeleteRows = False
        Me.dgv_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_history.Location = New System.Drawing.Point(12, 12)
        Me.dgv_history.Name = "dgv_history"
        Me.dgv_history.ReadOnly = True
        Me.dgv_history.Size = New System.Drawing.Size(554, 310)
        Me.dgv_history.TabIndex = 1
        '
        'form_battleHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 334)
        Me.Controls.Add(Me.dgv_history)
        Me.Name = "form_battleHistory"
        Me.Text = "Battle history: "
        CType(Me.dgv_history, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_history As System.Windows.Forms.DataGridView
End Class
