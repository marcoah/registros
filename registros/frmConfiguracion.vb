Public Class frmConfiguracion
    Private Sub frmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTokenAPI.Text = My.Settings.TOKEN.ToString
        txtURLBase.Text = My.Settings.URL_API.ToString
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class