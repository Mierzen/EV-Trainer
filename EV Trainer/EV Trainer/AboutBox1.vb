Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.TextBoxDescription.Text = My.Application.Info.Description & vbNewLine & vbNewLine & vbNewLine

        Me.TextBoxDescription.Text += "Feel free to "
        Me.TextBoxDescription.InsertLink("contribute", "http://github.com/Mierzen/EV-Trainer", Me.TextBoxDescription.TextLength)
        'Me.TextBoxDescription.Text += "!"

        Me.TextBoxDescription2.Text = "Please report any issues "
        Me.TextBoxDescription2.InsertLink("here", "http://github.com/Mierzen/EV-Trainer/issues", Me.TextBoxDescription2.TextLength)
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub btn_disclaimer_Click(sender As Object, e As EventArgs) Handles btn_disclaimer.Click
        Dim disclaimer As String
        disclaimer = "Not affiliated with Nintendo or The Pokémon Company." & vbNewLine & "This is a fan-made app for other fans of the Pokémon series to use while playing the game." & vbNewLine & vbNewLine & "All Pokémon references used in this app are copyright to their respective owners and usage of this information falls within US Copyright law guidelines of ""Fair Use"" and equivalent in other jurisdictions." & vbNewLine & "Pokémon, Pokémon character names and other references are trademark of Nintendo. © 2014 Pokémon. © 1995-2014 Nintendo/Creatures Inc./GAME FREAK inc."
        MsgBox(disclaimer, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Disclaimer")
    End Sub
End Class
