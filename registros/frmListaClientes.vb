Option Strict Off
Option Explicit On
Imports RestSharp
Imports Newtonsoft.Json
Imports System.Net

Public Class frmListaClientes
    Public Class JSON_result
        Public success As String
        Public data As List(Of cliente_result)
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
    Private Sub frmListaClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim URL As String = My.Settings.URL_API.ToString
        Dim token As String = My.Settings.TOKEN.ToString

        Try
            Dim client As New RestClient()

            client.BaseUrl = New Uri(URL)

            Dim rutarecurso As String = "api/clientes"

            'client.AddDefaultHeader("Accept", "application/json")
            client.AddDefaultHeader("Authorization", String.Format("Bearer {0}", token))

            Dim request As New RestRequest(rutarecurso, Method.GET)

            Dim respuesta As RestResponse

            respuesta = client.Execute(request)

            Select Case respuesta.StatusCode
                Case HttpStatusCode.OK 'Login autorizado

                    Dim resultado As JSON_result
                    resultado = JsonConvert.DeserializeObject(Of JSON_result)(respuesta.Content)

                    Dim table As New DataTable
                    ' Create four typed columns in the DataTable.
                    table.Columns.Add("ID", GetType(Integer))
                    table.Columns.Add("nombres", GetType(String))
                    table.Columns.Add("apellidos", GetType(String))
                    table.Columns.Add("email", GetType(String))
                    table.Columns.Add("razon_social", GetType(String))
                    table.Columns.Add("RIF", GetType(String))
                    table.Columns.Add("celular", GetType(String))
                    table.Columns.Add("telefono", GetType(String))
                    table.Columns.Add("ciudad", GetType(String))
                    table.Columns.Add("estado", GetType(String))
                    table.Columns.Add("pais", GetType(String))

                    For Each dato As cliente_result In resultado.data
                        ' Add five rows with those columns filled in the DataTable.
                        table.Rows.Add(dato.id, dato.nombres, dato.apellidos, dato.email, dato.razon_social, dato.RIF, dato.celular, dato.telefono, dato.ciudad, dato.estado, dato.pais)
                    Next


                    DataGridView1.DataSource = table

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
End Class