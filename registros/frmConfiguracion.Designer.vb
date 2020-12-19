<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTokenAPI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtURLBase = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TOKEN"
        '
        'txtTokenAPI
        '
        Me.txtTokenAPI.Location = New System.Drawing.Point(171, 34)
        Me.txtTokenAPI.Multiline = True
        Me.txtTokenAPI.Name = "txtTokenAPI"
        Me.txtTokenAPI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTokenAPI.Size = New System.Drawing.Size(602, 132)
        Me.txtTokenAPI.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 190)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "URL BASE API"
        '
        'txtURLBase
        '
        Me.txtURLBase.Location = New System.Drawing.Point(171, 190)
        Me.txtURLBase.Name = "txtURLBase"
        Me.txtURLBase.Size = New System.Drawing.Size(266, 20)
        Me.txtURLBase.TabIndex = 3
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(698, 415)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtURLBase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTokenAPI)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmConfiguracion"
        Me.Text = "Configuracion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtTokenAPI As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtURLBase As TextBox
    Friend WithEvents btnSalir As Button
End Class
