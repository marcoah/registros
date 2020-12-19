Imports RestSharp
Imports Newtonsoft.Json
Imports System.Net

Public Class LoginForm

    Public Class JSON_result
        Public token As String
    End Class

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'Me.Close()

        Dim URL As String = My.Settings.URL_API.ToString

        Dim correo As String = txtCorreo.Text
        Dim contrasena As String = txtPassword.Text

        Try
            Dim client As New RestClient()

            client.BaseUrl = New Uri(URL)

            Dim request As New RestRequest("api/login", Method.POST)

            request.AddParameter("email", correo)
            request.AddParameter("password", contrasena)

            Dim respuesta As RestResponse

            respuesta = client.Execute(request)

            Select Case respuesta.StatusCode
                Case HttpStatusCode.OK 'Login autorizado

                    Dim resultado As JSON_result
                    resultado = JsonConvert.DeserializeObject(Of JSON_result)(respuesta.Content)

                    My.Settings.TOKEN = resultado.token

                    Principal.Show()
                    Me.Hide()

                Case HttpStatusCode.Unauthorized 'No autorizado

                    MsgBox("no esta autorizado")

                Case HttpStatusCode.BadRequest 'fallo en el API

                    MsgBox("Revise q tiene conexion a internet")

                Case Else
                    MsgBox(respuesta.StatusCode)
            End Select

        Catch ex As System.Exception
            MsgBox("Error! " & ex.Message)
        End Try


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
