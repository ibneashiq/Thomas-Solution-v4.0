Imports Microsoft.Office.Tools.Ribbon

Public Class Ribbon1

    Private Sub Ribbon1_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub Main_UI_Click(ByVal sender As Object, ByVal e As RibbonControlEventArgs) Handles Main_UI.Click
        Try
            ' Show the form (modal)
            Form1.ShowForm()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Failed to open Project Exporter: " & ex.Message)
        End Try
    End Sub

End Class
