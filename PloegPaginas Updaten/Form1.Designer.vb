<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.PloegenCmb = New System.Windows.Forms.ComboBox()
        Me.MaakPaginaCodeBtn = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SchrijfNaarWordPressBtn = New System.Windows.Forms.Button()
        Me.CopyBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PaginaIDlbl = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PloegenCmb
        '
        Me.PloegenCmb.FormattingEnabled = True
        Me.PloegenCmb.Location = New System.Drawing.Point(37, 29)
        Me.PloegenCmb.Name = "PloegenCmb"
        Me.PloegenCmb.Size = New System.Drawing.Size(227, 21)
        Me.PloegenCmb.TabIndex = 0
        '
        'MaakPaginaCodeBtn
        '
        Me.MaakPaginaCodeBtn.Location = New System.Drawing.Point(37, 56)
        Me.MaakPaginaCodeBtn.Name = "MaakPaginaCodeBtn"
        Me.MaakPaginaCodeBtn.Size = New System.Drawing.Size(169, 26)
        Me.MaakPaginaCodeBtn.TabIndex = 1
        Me.MaakPaginaCodeBtn.Text = "Maak Pagina Code"
        Me.MaakPaginaCodeBtn.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(33, 141)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(1278, 621)
        Me.TextBox1.TabIndex = 2
        '
        'SchrijfNaarWordPressBtn
        '
        Me.SchrijfNaarWordPressBtn.Location = New System.Drawing.Point(237, 56)
        Me.SchrijfNaarWordPressBtn.Name = "SchrijfNaarWordPressBtn"
        Me.SchrijfNaarWordPressBtn.Size = New System.Drawing.Size(155, 26)
        Me.SchrijfNaarWordPressBtn.TabIndex = 3
        Me.SchrijfNaarWordPressBtn.Text = "Schrijf Naar Wordpress"
        Me.SchrijfNaarWordPressBtn.UseVisualStyleBackColor = True
        '
        'CopyBtn
        '
        Me.CopyBtn.Location = New System.Drawing.Point(432, 56)
        Me.CopyBtn.Name = "CopyBtn"
        Me.CopyBtn.Size = New System.Drawing.Size(143, 26)
        Me.CopyBtn.TabIndex = 4
        Me.CopyBtn.Text = "Copy"
        Me.CopyBtn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Test Pagina"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(164, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Wordpress Pagina ID:"
        '
        'PaginaIDlbl
        '
        Me.PaginaIDlbl.AutoSize = True
        Me.PaginaIDlbl.Location = New System.Drawing.Point(281, 107)
        Me.PaginaIDlbl.Name = "PaginaIDlbl"
        Me.PaginaIDlbl.Size = New System.Drawing.Size(13, 13)
        Me.PaginaIDlbl.TabIndex = 7
        Me.PaginaIDlbl.Text = "0"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(432, 101)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(142, 28)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Batch Sync"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1356, 856)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PaginaIDlbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CopyBtn)
        Me.Controls.Add(Me.SchrijfNaarWordPressBtn)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MaakPaginaCodeBtn)
        Me.Controls.Add(Me.PloegenCmb)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PloegenCmb As ComboBox
    Friend WithEvents MaakPaginaCodeBtn As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents SchrijfNaarWordPressBtn As Button
    Friend WithEvents CopyBtn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PaginaIDlbl As Label
    Friend WithEvents Button2 As Button
End Class
