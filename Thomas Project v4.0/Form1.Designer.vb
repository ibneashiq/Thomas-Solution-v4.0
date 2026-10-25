<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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

    ' NOTE: The following procedure is required by the Windows Form Designer
    ' It can be modified using the Windows Form Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lvFiles = New System.Windows.Forms.ListView()
        Me.List_Paths = New System.Windows.Forms.ListBox()
        Me.txt_Projects_Path = New System.Windows.Forms.TextBox()
        Me.btn_Browse = New System.Windows.Forms.Button()
        Me.List_Projects = New System.Windows.Forms.ListBox()
        Me.txt_Output_Path = New System.Windows.Forms.TextBox()
        Me.btn_Output = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_Sagsnummer = New System.Windows.Forms.Label()
        Me.txt_Sagsnummer = New System.Windows.Forms.TextBox()
        Me.lbl_Sagsnavn = New System.Windows.Forms.Label()
        Me.txt_Sagsnavn = New System.Windows.Forms.TextBox()
        Me.lbl_CVR = New System.Windows.Forms.Label()
        Me.txt_CVR = New System.Windows.Forms.TextBox()
        Me.lbl_Bygherre = New System.Windows.Forms.Label()
        Me.txt_Bygherre = New System.Windows.Forms.TextBox()
        Me.lbl_Adresse = New System.Windows.Forms.Label()
        Me.txt_Adresse = New System.Windows.Forms.TextBox()
        Me.lbl_Omfang = New System.Windows.Forms.Label()
        Me.txt_Omfang = New System.Windows.Forms.TextBox()
        Me.lbl_Byggepladsadresse = New System.Windows.Forms.Label()
        Me.txt_Byggepladsadresse = New System.Windows.Forms.TextBox()
        Me.lbl_Administrator = New System.Windows.Forms.Label()
        Me.txt_Administrator = New System.Windows.Forms.TextBox()
        Me.lbl_Dato = New System.Windows.Forms.Label()
        Me.txt_Dato = New System.Windows.Forms.TextBox()
        Me.lbl_Projektleder = New System.Windows.Forms.Label()
        Me.txt_Projektleder = New System.Windows.Forms.TextBox()
        Me.lbl_ProjektlederTlf = New System.Windows.Forms.Label()
        Me.txt_ProjektlederTlf = New System.Windows.Forms.TextBox()
        Me.lbl_ProjektlederMail = New System.Windows.Forms.Label()
        Me.txt_ProjektlederMail = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvFiles
        '
        Me.lvFiles.CheckBoxes = True
        Me.lvFiles.HideSelection = False
        Me.lvFiles.Location = New System.Drawing.Point(156, 75)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.Size = New System.Drawing.Size(571, 285)
        Me.lvFiles.TabIndex = 5
        Me.lvFiles.UseCompatibleStateImageBehavior = False
        Me.lvFiles.View = System.Windows.Forms.View.Details
        '
        'List_Paths
        '
        Me.List_Paths.FormattingEnabled = True
        Me.List_Paths.ItemHeight = 16
        Me.List_Paths.Location = New System.Drawing.Point(804, 228)
        Me.List_Paths.Name = "List_Paths"
        Me.List_Paths.Size = New System.Drawing.Size(270, 292)
        Me.List_Paths.TabIndex = 1
        '
        'txt_Projects_Path
        '
        Me.txt_Projects_Path.Location = New System.Drawing.Point(156, 12)
        Me.txt_Projects_Path.Name = "txt_Projects_Path"
        Me.txt_Projects_Path.Size = New System.Drawing.Size(435, 22)
        Me.txt_Projects_Path.TabIndex = 0
        '
        'btn_Browse
        '
        Me.btn_Browse.Location = New System.Drawing.Point(607, 10)
        Me.btn_Browse.Name = "btn_Browse"
        Me.btn_Browse.Size = New System.Drawing.Size(120, 26)
        Me.btn_Browse.TabIndex = 1
        Me.btn_Browse.Text = "Browse"
        Me.btn_Browse.UseVisualStyleBackColor = True
        '
        'List_Projects
        '
        Me.List_Projects.FormattingEnabled = True
        Me.List_Projects.ItemHeight = 16
        Me.List_Projects.Location = New System.Drawing.Point(12, 75)
        Me.List_Projects.Name = "List_Projects"
        Me.List_Projects.Size = New System.Drawing.Size(138, 285)
        Me.List_Projects.TabIndex = 4
        '
        'txt_Output_Path
        '
        Me.txt_Output_Path.Location = New System.Drawing.Point(156, 40)
        Me.txt_Output_Path.Name = "txt_Output_Path"
        Me.txt_Output_Path.Size = New System.Drawing.Size(435, 22)
        Me.txt_Output_Path.TabIndex = 2
        '
        'btn_Output
        '
        Me.btn_Output.Location = New System.Drawing.Point(607, 38)
        Me.btn_Output.Name = "btn_Output"
        Me.btn_Output.Size = New System.Drawing.Size(120, 26)
        Me.btn_Output.TabIndex = 3
        Me.btn_Output.Text = "Browse"
        Me.btn_Output.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Project Folder"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Output Folder"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Sagsnummer
        '
        Me.lbl_Sagsnummer.Location = New System.Drawing.Point(12, 375)
        Me.lbl_Sagsnummer.Name = "lbl_Sagsnummer"
        Me.lbl_Sagsnummer.Size = New System.Drawing.Size(138, 22)
        Me.lbl_Sagsnummer.TabIndex = 22
        Me.lbl_Sagsnummer.Text = "Sagsnummer"
        Me.lbl_Sagsnummer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Sagsnummer
        '
        Me.txt_Sagsnummer.Location = New System.Drawing.Point(156, 375)
        Me.txt_Sagsnummer.Name = "txt_Sagsnummer"
        Me.txt_Sagsnummer.Size = New System.Drawing.Size(195, 22)
        Me.txt_Sagsnummer.TabIndex = 6
        '
        'lbl_Sagsnavn
        '
        Me.lbl_Sagsnavn.Location = New System.Drawing.Point(12, 405)
        Me.lbl_Sagsnavn.Name = "lbl_Sagsnavn"
        Me.lbl_Sagsnavn.Size = New System.Drawing.Size(138, 22)
        Me.lbl_Sagsnavn.TabIndex = 23
        Me.lbl_Sagsnavn.Text = "Sagsnavn"
        Me.lbl_Sagsnavn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Sagsnavn
        '
        Me.txt_Sagsnavn.Location = New System.Drawing.Point(156, 405)
        Me.txt_Sagsnavn.Name = "txt_Sagsnavn"
        Me.txt_Sagsnavn.Size = New System.Drawing.Size(195, 22)
        Me.txt_Sagsnavn.TabIndex = 7
        '
        'lbl_CVR
        '
        Me.lbl_CVR.Location = New System.Drawing.Point(12, 435)
        Me.lbl_CVR.Name = "lbl_CVR"
        Me.lbl_CVR.Size = New System.Drawing.Size(138, 22)
        Me.lbl_CVR.TabIndex = 24
        Me.lbl_CVR.Text = "CVR"
        Me.lbl_CVR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_CVR
        '
        Me.txt_CVR.Location = New System.Drawing.Point(156, 435)
        Me.txt_CVR.Name = "txt_CVR"
        Me.txt_CVR.Size = New System.Drawing.Size(195, 22)
        Me.txt_CVR.TabIndex = 8
        '
        'lbl_Bygherre
        '
        Me.lbl_Bygherre.Location = New System.Drawing.Point(12, 465)
        Me.lbl_Bygherre.Name = "lbl_Bygherre"
        Me.lbl_Bygherre.Size = New System.Drawing.Size(138, 22)
        Me.lbl_Bygherre.TabIndex = 25
        Me.lbl_Bygherre.Text = "Bygherre"
        Me.lbl_Bygherre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Bygherre
        '
        Me.txt_Bygherre.Location = New System.Drawing.Point(156, 465)
        Me.txt_Bygherre.Name = "txt_Bygherre"
        Me.txt_Bygherre.Size = New System.Drawing.Size(195, 22)
        Me.txt_Bygherre.TabIndex = 9
        '
        'lbl_Adresse
        '
        Me.lbl_Adresse.Location = New System.Drawing.Point(12, 495)
        Me.lbl_Adresse.Name = "lbl_Adresse"
        Me.lbl_Adresse.Size = New System.Drawing.Size(138, 22)
        Me.lbl_Adresse.TabIndex = 26
        Me.lbl_Adresse.Text = "Adresse"
        Me.lbl_Adresse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Adresse
        '
        Me.txt_Adresse.Location = New System.Drawing.Point(156, 495)
        Me.txt_Adresse.Name = "txt_Adresse"
        Me.txt_Adresse.Size = New System.Drawing.Size(195, 22)
        Me.txt_Adresse.TabIndex = 10
        '
        'lbl_Omfang
        '
        Me.lbl_Omfang.Location = New System.Drawing.Point(12, 525)
        Me.lbl_Omfang.Name = "lbl_Omfang"
        Me.lbl_Omfang.Size = New System.Drawing.Size(138, 22)
        Me.lbl_Omfang.TabIndex = 27
        Me.lbl_Omfang.Text = "Omfang"
        Me.lbl_Omfang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Omfang
        '
        Me.txt_Omfang.Location = New System.Drawing.Point(156, 525)
        Me.txt_Omfang.Name = "txt_Omfang"
        Me.txt_Omfang.Size = New System.Drawing.Size(195, 22)
        Me.txt_Omfang.TabIndex = 11
        '
        'lbl_Byggepladsadresse
        '
        Me.lbl_Byggepladsadresse.Location = New System.Drawing.Point(360, 375)
        Me.lbl_Byggepladsadresse.Name = "lbl_Byggepladsadresse"
        Me.lbl_Byggepladsadresse.Size = New System.Drawing.Size(150, 22)
        Me.lbl_Byggepladsadresse.TabIndex = 28
        Me.lbl_Byggepladsadresse.Text = "Byggeplads adresse"
        Me.lbl_Byggepladsadresse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Byggepladsadresse
        '
        Me.txt_Byggepladsadresse.Location = New System.Drawing.Point(516, 375)
        Me.txt_Byggepladsadresse.Name = "txt_Byggepladsadresse"
        Me.txt_Byggepladsadresse.Size = New System.Drawing.Size(211, 22)
        Me.txt_Byggepladsadresse.TabIndex = 12
        '
        'lbl_Administrator
        '
        Me.lbl_Administrator.Location = New System.Drawing.Point(360, 405)
        Me.lbl_Administrator.Name = "lbl_Administrator"
        Me.lbl_Administrator.Size = New System.Drawing.Size(150, 22)
        Me.lbl_Administrator.TabIndex = 29
        Me.lbl_Administrator.Text = "Administrator"
        Me.lbl_Administrator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Administrator
        '
        Me.txt_Administrator.Location = New System.Drawing.Point(516, 405)
        Me.txt_Administrator.Name = "txt_Administrator"
        Me.txt_Administrator.Size = New System.Drawing.Size(211, 22)
        Me.txt_Administrator.TabIndex = 13
        '
        'lbl_Dato
        '
        Me.lbl_Dato.Location = New System.Drawing.Point(360, 435)
        Me.lbl_Dato.Name = "lbl_Dato"
        Me.lbl_Dato.Size = New System.Drawing.Size(150, 22)
        Me.lbl_Dato.TabIndex = 30
        Me.lbl_Dato.Text = "Dato"
        Me.lbl_Dato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Dato
        '
        Me.txt_Dato.Location = New System.Drawing.Point(516, 435)
        Me.txt_Dato.Name = "txt_Dato"
        Me.txt_Dato.Size = New System.Drawing.Size(211, 22)
        Me.txt_Dato.TabIndex = 14
        '
        'lbl_Projektleder
        '
        Me.lbl_Projektleder.Location = New System.Drawing.Point(360, 465)
        Me.lbl_Projektleder.Name = "lbl_Projektleder"
        Me.lbl_Projektleder.Size = New System.Drawing.Size(150, 22)
        Me.lbl_Projektleder.TabIndex = 31
        Me.lbl_Projektleder.Text = "Projektleder"
        Me.lbl_Projektleder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Projektleder
        '
        Me.txt_Projektleder.Location = New System.Drawing.Point(516, 465)
        Me.txt_Projektleder.Name = "txt_Projektleder"
        Me.txt_Projektleder.Size = New System.Drawing.Size(211, 22)
        Me.txt_Projektleder.TabIndex = 15
        '
        'lbl_ProjektlederTlf
        '
        Me.lbl_ProjektlederTlf.Location = New System.Drawing.Point(360, 495)
        Me.lbl_ProjektlederTlf.Name = "lbl_ProjektlederTlf"
        Me.lbl_ProjektlederTlf.Size = New System.Drawing.Size(150, 22)
        Me.lbl_ProjektlederTlf.TabIndex = 32
        Me.lbl_ProjektlederTlf.Text = "Projektleder tlf."
        Me.lbl_ProjektlederTlf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_ProjektlederTlf
        '
        Me.txt_ProjektlederTlf.Location = New System.Drawing.Point(516, 495)
        Me.txt_ProjektlederTlf.Name = "txt_ProjektlederTlf"
        Me.txt_ProjektlederTlf.Size = New System.Drawing.Size(211, 22)
        Me.txt_ProjektlederTlf.TabIndex = 16
        '
        'lbl_ProjektlederMail
        '
        Me.lbl_ProjektlederMail.Location = New System.Drawing.Point(360, 525)
        Me.lbl_ProjektlederMail.Name = "lbl_ProjektlederMail"
        Me.lbl_ProjektlederMail.Size = New System.Drawing.Size(150, 22)
        Me.lbl_ProjektlederMail.TabIndex = 33
        Me.lbl_ProjektlederMail.Text = "Projektleder mail"
        Me.lbl_ProjektlederMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_ProjektlederMail
        '
        Me.txt_ProjektlederMail.Location = New System.Drawing.Point(516, 525)
        Me.txt_ProjektlederMail.Name = "txt_ProjektlederMail"
        Me.txt_ProjektlederMail.Size = New System.Drawing.Size(211, 22)
        Me.txt_ProjektlederMail.TabIndex = 17
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(576, 560)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(151, 38)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Submit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 615)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txt_ProjektlederMail)
        Me.Controls.Add(Me.lbl_ProjektlederMail)
        Me.Controls.Add(Me.txt_ProjektlederTlf)
        Me.Controls.Add(Me.lbl_ProjektlederTlf)
        Me.Controls.Add(Me.txt_Projektleder)
        Me.Controls.Add(Me.lbl_Projektleder)
        Me.Controls.Add(Me.txt_Dato)
        Me.Controls.Add(Me.lbl_Dato)
        Me.Controls.Add(Me.txt_Administrator)
        Me.Controls.Add(Me.lbl_Administrator)
        Me.Controls.Add(Me.txt_Byggepladsadresse)
        Me.Controls.Add(Me.lbl_Byggepladsadresse)
        Me.Controls.Add(Me.txt_Omfang)
        Me.Controls.Add(Me.lbl_Omfang)
        Me.Controls.Add(Me.txt_Adresse)
        Me.Controls.Add(Me.lbl_Adresse)
        Me.Controls.Add(Me.txt_Bygherre)
        Me.Controls.Add(Me.lbl_Bygherre)
        Me.Controls.Add(Me.txt_CVR)
        Me.Controls.Add(Me.lbl_CVR)
        Me.Controls.Add(Me.txt_Sagsnavn)
        Me.Controls.Add(Me.lbl_Sagsnavn)
        Me.Controls.Add(Me.txt_Sagsnummer)
        Me.Controls.Add(Me.lbl_Sagsnummer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Output)
        Me.Controls.Add(Me.btn_Browse)
        Me.Controls.Add(Me.txt_Output_Path)
        Me.Controls.Add(Me.txt_Projects_Path)
        Me.Controls.Add(Me.List_Projects)
        Me.Controls.Add(Me.List_Paths)
        Me.Controls.Add(Me.lvFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Generator v4.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvFiles As ListView
    Friend WithEvents List_Paths As ListBox
    Friend WithEvents txt_Projects_Path As TextBox
    Friend WithEvents btn_Browse As Button
    Friend WithEvents List_Projects As ListBox
    Friend WithEvents Button2 As Button
    Friend WithEvents txt_Output_Path As TextBox
    Friend WithEvents btn_Output As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_Sagsnummer As Label
    Friend WithEvents txt_Sagsnummer As TextBox
    Friend WithEvents lbl_Sagsnavn As Label
    Friend WithEvents txt_Sagsnavn As TextBox
    Friend WithEvents lbl_CVR As Label
    Friend WithEvents txt_CVR As TextBox
    Friend WithEvents lbl_Bygherre As Label
    Friend WithEvents txt_Bygherre As TextBox
    Friend WithEvents lbl_Adresse As Label
    Friend WithEvents txt_Adresse As TextBox
    Friend WithEvents lbl_Omfang As Label
    Friend WithEvents txt_Omfang As TextBox
    Friend WithEvents lbl_Byggepladsadresse As Label
    Friend WithEvents txt_Byggepladsadresse As TextBox
    Friend WithEvents lbl_Administrator As Label
    Friend WithEvents txt_Administrator As TextBox
    Friend WithEvents lbl_Dato As Label
    Friend WithEvents txt_Dato As TextBox
    Friend WithEvents lbl_Projektleder As Label
    Friend WithEvents txt_Projektleder As TextBox
    Friend WithEvents lbl_ProjektlederTlf As Label
    Friend WithEvents txt_ProjektlederTlf As TextBox
    Friend WithEvents lbl_ProjektlederMail As Label
    Friend WithEvents txt_ProjektlederMail As TextBox
End Class

