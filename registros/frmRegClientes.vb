Option Strict Off
Option Explicit On
Imports RestSharp
Imports Newtonsoft.Json
Imports System.Net

Public Class frmRegClientes
    Public Class JSON_result
        Public success As String
        Public data As cliente_result
    End Class

    Public Class badrequest_result
        Public success As String
        Public message As String
    End Class

    Public Class cliente_result
        Public id As Integer
        Public nombres As String
        Public apellidos As String
        Public email As String
        Public RIF As String
        Public razon_social As String
        Public celular As String
        Public telefono As String
        Public ciudad As String
        Public estado As String
        Public pais As String
    End Class

    Private Sub frmRegClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        Dim URL As String = My.Settings.URL_API.ToString
        Dim token As String = My.Settings.TOKEN.ToString
        Dim idcliente As String = txtIDCliente.Text

        Try
            Dim client As New RestClient()

            client.BaseUrl = New Uri(URL)

            Dim rutarecurso As String = String.Format("api/clientes/{0}", idcliente)

            'client.AddDefaultHeader("Accept", "application/json")
            client.AddDefaultHeader("Authorization", String.Format("Bearer {0}", token))

            Dim request As New RestRequest(rutarecurso, Method.GET)

            Dim respuesta As RestResponse

            respuesta = client.Execute(request)

            Select Case respuesta.StatusCode
                Case HttpStatusCode.OK 'Login autorizado

                    Dim resultado As JSON_result
                    resultado = JsonConvert.DeserializeObject(Of JSON_result)(respuesta.Content)

                    txtApellidos.Text = resultado.data.apellidos
                    txtNombres.Text = resultado.data.nombres
                    txtEmail.Text = resultado.data.email
                    txtCelular.Text = resultado.data.celular
                    txtTelefono.Text = resultado.data.telefono
                    txtRazonSocial.Text = resultado.data.razon_social
                    txtNRIF.Text = resultado.data.RIF
                    txtCiudad.Text = resultado.data.ciudad
                    txtEstado.Text = resultado.data.estado
                    txtPais.Text = resultado.data.pais

                Case HttpStatusCode.Unauthorized 'No autorizado

                    MsgBox(respuesta.StatusCode & ": no esta autorizado")

                Case HttpStatusCode.BadRequest '400 fallo en el API

                    Dim resultado As badrequest_result
                    resultado = JsonConvert.DeserializeObject(Of badrequest_result)(respuesta.Content)

                    MsgBox(String.Format("StatusCode: {0} / Mensaje {1}", respuesta.StatusCode, resultado.message))

                    'MsgBox(respuesta.StatusCode & ": Solicitud errada")

                Case Else
                    MsgBox(respuesta.StatusCode & ": " & respuesta.StatusDescription)
            End Select

        Catch ex As System.Exception
            MsgBox("Error! " & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim URL As String = My.Settings.URL_API.ToString
        Dim token As String = My.Settings.TOKEN.ToString
        Dim idcliente As String = txtIDCliente.Text

        Try
            Dim client As New RestClient()

            client.BaseUrl = New Uri(URL)
            client.AddDefaultHeader("Authorization", String.Format("Bearer {0}", token))

            Dim rutarecurso As String = String.Format("api/clientes/{0}", idcliente)

            Dim request As New RestRequest(rutarecurso, Method.PUT)

            request.AddParameter("nombres", txtNombres.Text)
            request.AddParameter("apellidos", txtApellidos.Text)
            request.AddParameter("email", txtEmail.Text)
            request.AddParameter("razon_social", txtRazonSocial.Text)
            request.AddParameter("RIF", txtNRIF.Text)
            request.AddParameter("celular", txtCelular.Text)
            request.AddParameter("telefono", txtTelefono.Text)
            request.AddParameter("ciudad", txtCiudad.Text)
            request.AddParameter("estado", txtEstado.Text)
            request.AddParameter("pais", txtPais.Text)

            Dim respuesta As RestResponse

            respuesta = client.Execute(request)

            Select Case respuesta.StatusCode
                Case HttpStatusCode.OK 'Login autorizado

                    Dim resultado As JSON_result
                    resultado = JsonConvert.DeserializeObject(Of JSON_result)(respuesta.Content)

                    MsgBox(String.Format("Guardado correcto {0}", resultado.success))

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

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If MsgBox(String.Format("Seguro que desea eliminar este registro ID: {0} / Cliente {1}{2}{3}", txtIDCliente.Text, txtRazonSocial.Text, txtNombres.Text, txtApellidos.Text), vbQuestion + vbYesNo, "Eliminar registro") = vbYes Then
            Dim URL As String = My.Settings.URL_API.ToString
            Dim token As String = My.Settings.TOKEN.ToString
            Dim idcliente As String = txtIDCliente.Text

            Try
                Dim client As New RestClient()

                client.BaseUrl = New Uri(URL)
                client.AddDefaultHeader("Authorization", String.Format("Bearer {0}", token))

                Dim rutarecurso As String = String.Format("api/clientes/{0}", idcliente)

                Dim request As New RestRequest(rutarecurso, Method.DELETE)
                Dim respuesta As RestResponse
                respuesta = client.Execute(request)

                Select Case respuesta.StatusCode
                    Case HttpStatusCode.OK 'Login autorizado

                        Dim resultado As JSON_result
                        resultado = JsonConvert.DeserializeObject(Of JSON_result)(respuesta.Content)

                        MsgBox(String.Format("Eliminado correcto {0}", resultado.success))

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
        Else

        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim URL As String = My.Settings.URL_API.ToString
        Dim token As String = My.Settings.TOKEN.ToString

        'Preparo JSON cliente

        Dim registrocliente As New cliente_result

        registrocliente.nombres = txtNombres.Text
        registrocliente.apellidos = txtApellidos.Text
        registrocliente.email = txtEmail.Text
        registrocliente.razon_social = txtRazonSocial.Text
        registrocliente.RIF = txtNRIF.Text
        registrocliente.celular = txtCelular.Text
        registrocliente.telefono = txtTelefono.Text
        registrocliente.ciudad = txtCiudad.Text
        registrocliente.estado = txtEstado.Text
        registrocliente.pais = txtPais.Text

        Dim output As String = JsonConvert.SerializeObject(registrocliente) ' Este es el json del cuerpo

        Try
            Dim client As New RestClient()

            client.BaseUrl = New Uri(URL)
            client.AddDefaultHeader("Authorization", String.Format("Bearer {0}", token))
            client.AddDefaultHeader("Accept", "application/json")

            Dim rutarecurso As String = "api/clientes"

            Dim request As New RestRequest(rutarecurso, Method.POST)

            request.AddJsonBody(output)

            Dim respuesta As RestResponse

            respuesta = client.Execute(request)

            Select Case respuesta.StatusCode
                Case HttpStatusCode.OK 'Login autorizado

                    Dim resultado As JSON_result
                    resultado = JsonConvert.DeserializeObject(Of JSON_result)(respuesta.Content)

                    MsgBox(String.Format("Cliente creado correctamente ID: {0}", resultado.data.id))

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
End Class
