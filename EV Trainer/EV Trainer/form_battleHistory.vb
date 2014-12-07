Public Class form_battleHistory

    Private Sub form_battleHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Battle history: " & form_main.cmb_SelectedPok.Text

        dgv_history.DataSource = form_main.tableBattled
        dgv_history.AutoResizeColumns()
    End Sub
End Class