Option Strict Off
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Partial Public Class Form1

    Private selectedProjectRoot As String = String.Empty

    Public Sub New()
        InitializeComponent()
        ' Wire up handlers to designer controls
        AddHandler btn_Browse.Click, AddressOf btn_Browse_Click
        AddHandler btn_Output.Click, AddressOf btn_Output_Click
        AddHandler List_Projects.SelectedIndexChanged, AddressOf List_Projects_SelectedIndexChanged
        AddHandler Button2.Click, AddressOf btn_Submit_Click

        ' Minor UI initialization
        ' hide the separate List_Paths (we now show path in lvFiles second column)
        List_Paths.Visible = False
        lvFiles.CheckBoxes = True
        lvFiles.FullRowSelect = True
        lvFiles.HideSelection = False
        ' Ensure columns exist
        lvFiles.Columns.Clear()
        lvFiles.Columns.Add("Name", 220)
        lvFiles.Columns.Add("Path", 800)

        ' Pre-fill default date with today's date if empty
        If String.IsNullOrWhiteSpace(txt_Dato.Text) Then
            txt_Dato.Text = DateTime.Today.ToString("dd-MM-yyyy")
        End If

        ' Load persisted paths
        Try
            If Not String.IsNullOrWhiteSpace(My.Settings.ProjectsRoot) Then
                txt_Projects_Path.Text = My.Settings.ProjectsRoot
                selectedProjectRoot = My.Settings.ProjectsRoot
                PopulateProjectFolders(selectedProjectRoot)
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.OutputRoot) Then
                txt_Output_Path.Text = My.Settings.OutputRoot
            End If
        Catch
        End Try
    End Sub

    Private Sub btn_Browse_Click(sender As Object, e As EventArgs)
        Using dlg As New FolderBrowserDialog()
            dlg.Description = "Select projects root folder"
            dlg.ShowNewFolderButton = False
            If dlg.ShowDialog() = DialogResult.OK Then
                txt_Projects_Path.Text = dlg.SelectedPath
                selectedProjectRoot = dlg.SelectedPath
                ' persist projects root for next time
                Try
                    My.Settings.ProjectsRoot = selectedProjectRoot
                    My.Settings.Save()
                Catch
                End Try
                PopulateProjectFolders(selectedProjectRoot)
            End If
        End Using
    End Sub

    Private Sub btn_Output_Click(sender As Object, e As EventArgs)
        Using dlg As New FolderBrowserDialog()
            dlg.Description = "Select output folder"
            dlg.ShowNewFolderButton = True
            If dlg.ShowDialog() = DialogResult.OK Then
                txt_Output_Path.Text = dlg.SelectedPath
                ' persist output root for next time
                Try
                    My.Settings.OutputRoot = dlg.SelectedPath
                    My.Settings.Save()
                Catch
                End Try
            End If
        End Using
    End Sub

    Private Sub PopulateProjectFolders(root As String)
        List_Projects.Items.Clear()
        lvFiles.Items.Clear()
        List_Paths.Items.Clear()
        Try
            If Directory.Exists(root) Then
                Dim dirs = Directory.GetDirectories(root)
                For Each d In dirs
                    List_Projects.Items.Add(Path.GetFileName(d))
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to enumerate project folders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub List_Projects_SelectedIndexChanged(sender As Object, e As EventArgs)
        If List_Projects.SelectedIndex < 0 Then Return
        Dim folderName = List_Projects.SelectedItem.ToString()
        Dim projectFullPath = Path.Combine(selectedProjectRoot, folderName)
        If Not Directory.Exists(projectFullPath) Then
            MessageBox.Show("Selected project folder does not exist: " & projectFullPath, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Repopulate file lists (show name + path in lvFiles)
        lvFiles.Items.Clear()
        List_Paths.Items.Clear()
        Try
            Dim exts As String() = {".xls", ".xlsx", ".xlsm", ".doc", ".docx", ".docm"}
            For Each f In Directory.GetFiles(projectFullPath, "*.*", SearchOption.AllDirectories)
                If exts.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase) Then
                    List_Paths.Items.Add(f)
                    Dim item As New ListViewItem(Path.GetFileName(f))
                    item.SubItems.Add(f)
                    item.Checked = True ' select all by default
                    lvFiles.Items.Add(item)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error scanning project files: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Validates all required inputs, folder selections and field formats.
    ''' Returns True if valid; otherwise shows user message and focuses the invalid field.
    ''' </summary>
    Private Function ValidateInputs() As Boolean
        ' 1. Check Projects root path
        If String.IsNullOrWhiteSpace(txt_Projects_Path.Text) OrElse Not Directory.Exists(txt_Projects_Path.Text) Then
            MessageBox.Show("Vælg venligst en gyldig projektmappe (Project Folder).", "Validering", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btn_Browse.Focus()
            Return False
        End If

        ' 2. Check Project selection
        If List_Projects.SelectedIndex < 0 Then
            MessageBox.Show("Vælg venligst et projekt fra listen.", "Validering", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            List_Projects.Focus()
            Return False
        End If

        ' 3. Check Output root path
        If String.IsNullOrWhiteSpace(txt_Output_Path.Text) Then
            MessageBox.Show("Vælg venligst en destinationsmappe (Output Folder).", "Validering", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btn_Output.Focus()
            Return False
        End If

        ' 4. Check that at least one file is selected
        Dim checkedCount = 0
        For Each item As ListViewItem In lvFiles.Items
            If item.Checked Then checkedCount += 1
        Next
        If checkedCount = 0 Then
            MessageBox.Show("Vælg venligst mindst én fil der skal genereres.", "Validering", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lvFiles.Focus()
            Return False
        End If

        ' 5. Check all 12 input fields for non-empty values
        Dim fieldChecks As New List(Of Tuple(Of String, TextBox)) From {
            Tuple.Create("Sagsnummer", txt_Sagsnummer),
            Tuple.Create("Sagsnavn", txt_Sagsnavn),
            Tuple.Create("CVR", txt_CVR),
            Tuple.Create("Bygherre", txt_Bygherre),
            Tuple.Create("Adresse", txt_Adresse),
            Tuple.Create("Omfang", txt_Omfang),
            Tuple.Create("Byggeplads adresse", txt_Byggepladsadresse),
            Tuple.Create("Administrator", txt_Administrator),
            Tuple.Create("Dato", txt_Dato),
            Tuple.Create("Projektleder", txt_Projektleder),
            Tuple.Create("Projektleder tlf.", txt_ProjektlederTlf),
            Tuple.Create("Projektleder mail", txt_ProjektlederMail)
        }

        Dim missingFields As New List(Of String)()
        Dim firstEmptyBox As TextBox = Nothing

        For Each fc In fieldChecks
            If String.IsNullOrWhiteSpace(fc.Item2.Text) Then
                missingFields.Add(fc.Item1)
                If firstEmptyBox Is Nothing Then firstEmptyBox = fc.Item2
            End If
        Next

        If missingFields.Count > 0 Then
            Dim msg = "Følgende påkrævede felter mangler at blive udfyldt:" & vbCrLf & vbCrLf &
                      "• " & String.Join(vbCrLf & "• ", missingFields)
            MessageBox.Show(msg, "Ufuldstændig formular", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If firstEmptyBox IsNot Nothing Then
                firstEmptyBox.Focus()
            End If
            Return False
        End If

        ' 6. Specific format validations

        ' Projektleder mail validation
        Dim email = txt_ProjektlederMail.Text.Trim()
        Dim emailRegex As New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
        If Not emailRegex.IsMatch(email) Then
            MessageBox.Show("Angiv venligst en gyldig e-mailadresse for 'Projektleder mail' (f.eks. navn@firma.dk).", "Ugyldig e-mail", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_ProjektlederMail.Focus()
            txt_ProjektlederMail.SelectAll()
            Return False
        End If

        ' Projektleder tlf validation (must have at least 8 digits)
        Dim phoneDigits = Regex.Replace(txt_ProjektlederTlf.Text, "[^\d]", "")
        If phoneDigits.Length < 8 Then
            MessageBox.Show("Angiv venligst et gyldigt telefonnummer for 'Projektleder tlf.' (mindst 8 cifre).", "Ugyldigt telefonnummer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_ProjektlederTlf.Focus()
            txt_ProjektlederTlf.SelectAll()
            Return False
        End If

        ' Dato validation
        Dim parsedDate As DateTime
        If Not DateTime.TryParse(txt_Dato.Text.Trim(), parsedDate) Then
            MessageBox.Show("Angiv venligst en gyldig dato for 'Dato' (f.eks. " & DateTime.Today.ToString("dd-MM-yyyy") & ").", "Ugyldig dato", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_Dato.Focus()
            txt_Dato.SelectAll()
            Return False
        End If

        Return True
    End Function

    Private Sub btn_Submit_Click(sender As Object, e As EventArgs)
        ' Run validation first
        If Not ValidateInputs() Then Return

        Dim outputRoot = txt_Output_Path.Text.Trim()
        Dim selectedTemplateName = List_Projects.SelectedItem.ToString()
        Dim projectFullPath = Path.Combine(selectedProjectRoot, selectedTemplateName)

        Dim sagsnummer = txt_Sagsnummer.Text.Trim()
        Dim sagsnavn = txt_Sagsnavn.Text.Trim()
        Dim cvr = txt_CVR.Text.Trim()
        Dim bygherre = txt_Bygherre.Text.Trim()
        Dim adresse = txt_Adresse.Text.Trim()
        Dim omfang = txt_Omfang.Text.Trim()
        Dim byggepladsAdresse = txt_Byggepladsadresse.Text.Trim()
        Dim administrator = txt_Administrator.Text.Trim()
        Dim dato = txt_Dato.Text.Trim()
        Dim projektleder = txt_Projektleder.Text.Trim()
        Dim projektlederTlf = txt_ProjektlederTlf.Text.Trim()
        Dim projektlederMail = txt_ProjektlederMail.Text.Trim()

        ' Output folder must be named: “[Sagsnummer] [Sagsnavn]”
        Dim outputFolderName = $"[{sagsnummer}] [{sagsnavn}]"

        ' Sanitize folder name for invalid filesystem characters (keeping [ and ])
        For Each c In Path.GetInvalidFileNameChars()
            If c <> "["c AndAlso c <> "]"c Then
                outputFolderName = outputFolderName.Replace(c, "_"c)
            End If
        Next

        Dim targetProjectDir = Path.Combine(outputRoot, outputFolderName)

        ' Build replacement dictionary for {#Placeholder} syntax
        Dim textReplacements As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
            {"{#Sagsnummer}", sagsnummer},
            {"{#Sagsnavn}", sagsnavn},
            {"{#CVR}", cvr},
            {"{#Bygherre}", bygherre},
            {"{#Adresse}", adresse},
            {"{#Omfang}", omfang},
            {"{#Byggeplads adresse}", byggepladsAdresse},
            {"{#Byggepladsadresse}", byggepladsAdresse},
            {"{#Administrator}", administrator},
            {"{#Dato}", dato},
            {"{#Projektleder}", projektleder},
            {"{#Projektleder tlf.}", projektlederTlf},
            {"{#Projektleder tlf}", projektlederTlf},
            {"{#Projektleder mail}", projektlederMail},
            {"<NAME>", sagsnavn} ' legacy placeholder fallback
        }

        ' Build Content Control title/tag dictionary (case-insensitive)
        Dim ccReplacements As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
            {"Sagsnummer", sagsnummer},
            {"Sagsnavn", sagsnavn},
            {"CVR", cvr},
            {"Bygherre", bygherre},
            {"Adresse", adresse},
            {"Omfang", omfang},
            {"Byggeplads adresse", byggepladsAdresse},
            {"Byggepladsadresse", byggepladsAdresse},
            {"Administrator", administrator},
            {"Dato", dato},
            {"Projektleder", projektleder},
            {"Projektleder tlf.", projektlederTlf},
            {"Projektleder tlf", projektlederTlf},
            {"Projektleder mail", projektlederMail}
        }

        Try
            ' 1. Create target folder if it does not exist
            If Not Directory.Exists(targetProjectDir) Then
                Directory.CreateDirectory(targetProjectDir)
            End If

            ' 2. Copy checked files preserving relative structure
            Dim processedFiles As New List(Of String)()
            For Each item As ListViewItem In lvFiles.Items
                If item.Checked Then
                    Dim srcPath = item.SubItems(1).Text
                    Dim relative = GetRelativePath(projectFullPath, srcPath)

                    ' Replace any placeholders in relative file/folder paths
                    For Each kvp In textReplacements
                        If relative.IndexOf(kvp.Key, StringComparison.OrdinalIgnoreCase) >= 0 Then
                            relative = Regex.Replace(relative, Regex.Escape(kvp.Key), kvp.Value, RegexOptions.IgnoreCase)
                        End If
                    Next

                    Dim destPath = Path.Combine(targetProjectDir, relative)
                    Dim destDir = Path.GetDirectoryName(destPath)
                    If Not Directory.Exists(destDir) Then Directory.CreateDirectory(destDir)

                    File.Copy(srcPath, destPath, True)
                    processedFiles.Add(destPath)
                End If
            Next

            ' 3. Process placeholders and Content Controls in copied files
            Dim excelApp As Object = Nothing
            Dim wordApp As Object = Nothing

            Try
                For Each destPath In processedFiles
                    Dim ext = Path.GetExtension(destPath).ToLowerInvariant()

                    ' Process Excel files
                    If ext = ".xls" OrElse ext = ".xlsx" OrElse ext = ".xlsm" Then
                        If excelApp Is Nothing Then
                            excelApp = CreateObject("Excel.Application")
                            excelApp.DisplayAlerts = False
                            excelApp.Visible = False
                        End If

                        Try
                            Dim wb = excelApp.Workbooks.Open(destPath)
                            For Each ws In wb.Worksheets
                                ' Replace placeholders in cells (LookAt:=2 is xlPart)
                                For Each kvp In textReplacements
                                    ws.Cells.Replace(What:=kvp.Key, Replacement:=kvp.Value, LookAt:=2, MatchCase:=False)
                                Next

                                ' Also check any Excel drawing shapes with text
                                Try
                                    For Each shp In ws.Shapes
                                        If shp.HasTextFrame = -1 Then ' msoTrue
                                            Dim txt As String = shp.TextFrame.Characters.Text
                                            For Each kvp In textReplacements
                                                If txt.IndexOf(kvp.Key, StringComparison.OrdinalIgnoreCase) >= 0 Then
                                                    txt = Regex.Replace(txt, Regex.Escape(kvp.Key), kvp.Value, RegexOptions.IgnoreCase)
                                                End If
                                            Next
                                            shp.TextFrame.Characters.Text = txt
                                        End If
                                    Next
                                Catch
                                End Try
                            Next

                            wb.Save()
                            wb.Close(False)
                            Marshal.ReleaseComObject(wb)
                        Catch ex As Exception
                            MessageBox.Show("Fejl under behandling af Excel-fil: " & destPath & vbCrLf & ex.Message, "Excel Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                    ' Process Word files
                    ElseIf ext = ".doc" OrElse ext = ".docx" OrElse ext = ".docm" Then
                        If wordApp Is Nothing Then
                            wordApp = CreateObject("Word.Application")
                            wordApp.Visible = False
                            wordApp.DisplayAlerts = 0 ' wdAlertsNone
                        End If

                        Try
                            Dim doc = wordApp.Documents.Open(destPath)

                            ' A. Replace text placeholders across all story ranges (Main text, headers, footers, etc.)
                            For Each storyRange In doc.StoryRanges
                                Dim curRange As Object = storyRange
                                Do While curRange IsNot Nothing
                                    For Each kvp In textReplacements
                                        Dim findObj = curRange.Find
                                        findObj.ClearFormatting()
                                        findObj.Replacement.ClearFormatting()
                                        findObj.Text = kvp.Key
                                        findObj.Replacement.Text = kvp.Value
                                        findObj.Forward = True
                                        findObj.Wrap = 1 ' wdFindContinue
                                        findObj.Format = False
                                        findObj.MatchCase = False
                                        findObj.MatchWholeWord = False
                                        findObj.Execute(Replace:=2) ' wdReplaceAll
                                    Next
                                    curRange = curRange.NextStoryRange
                                Loop
                            Next

                            ' B. Also replace placeholders inside Word shapes
                            Try
                                For Each shp In doc.Shapes
                                    If shp.TextFrame.HasText <> 0 Then
                                        For Each kvp In textReplacements
                                            Dim findObj = shp.TextFrame.TextRange.Find
                                            findObj.ClearFormatting()
                                            findObj.Replacement.ClearFormatting()
                                            findObj.Text = kvp.Key
                                            findObj.Replacement.Text = kvp.Value
                                            findObj.Forward = True
                                            findObj.Wrap = 1
                                            findObj.Format = False
                                            findObj.MatchCase = False
                                            findObj.Execute(Replace:=2)
                                        Next
                                    End If
                                Next
                            Catch
                            End Try

                            ' C. Fill Content Controls with matching title or tag
                            UpdateWordContentControls(doc, ccReplacements)

                            doc.Save()
                            doc.Close(False)
                            Marshal.ReleaseComObject(doc)
                        Catch ex As Exception
                            MessageBox.Show("Fejl under behandling af Word-fil: " & destPath & vbCrLf & ex.Message, "Word Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Next
            Finally
                Try
                    If excelApp IsNot Nothing Then
                        excelApp.Quit()
                        Marshal.ReleaseComObject(excelApp)
                    End If
                Catch
                End Try
                Try
                    If wordApp IsNot Nothing Then
                        wordApp.Quit()
                        Marshal.ReleaseComObject(wordApp)
                    End If
                Catch
                End Try
            End Try

            Dim successMsg = $"Projektet er oprettet succesfuldt!" & vbCrLf & vbCrLf &
                             $"Mappe: {outputFolderName}" & vbCrLf &
                             $"Sti: {targetProjectDir}" & vbCrLf & vbCrLf &
                             $"Antal behandlede filer: {processedFiles.Count}"
            MessageBox.Show(successMsg, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Fejl under generering af projekt: " & ex.Message, "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Searches and updates Word Content Controls matching titles/tags in the values dictionary.
    ''' Handles locked content controls, document body, headers, footers and nested controls.
    ''' </summary>
    Private Sub UpdateWordContentControls(doc As Object, values As Dictionary(Of String, String))
        ' 1. Document-level content controls
        Try
            UpdateContentControlsCollection(doc.ContentControls, values)
        Catch
        End Try

        ' 2. Headers and footers across all sections
        Try
            For Each section In doc.Sections
                For Each header In section.Headers
                    If header.Exists Then
                        Try
                            UpdateContentControlsCollection(header.Range.ContentControls, values)
                        Catch
                        End Try
                    End If
                Next
                For Each footer In section.Footers
                    If footer.Exists Then
                        Try
                            UpdateContentControlsCollection(footer.Range.ContentControls, values)
                        Catch
                        End Try
                    End If
                Next
            Next
        Catch
        End Try

        ' 3. Direct lookup by Title and Tag using Word API to ensure no controls are missed
        For Each kvp In values
            Try
                Dim matchingByTitle = doc.SelectContentControlsByTitle(kvp.Key)
                If matchingByTitle IsNot Nothing Then
                    For Each cc In matchingByTitle
                        SetContentControlText(cc, kvp.Value)
                    Next
                End If
            Catch
            End Try

            Try
                Dim matchingByTag = doc.SelectContentControlsByTag(kvp.Key)
                If matchingByTag IsNot Nothing Then
                    For Each cc In matchingByTag
                        SetContentControlText(cc, kvp.Value)
                    Next
                End If
            Catch
            End Try
        Next
    End Sub

    Private Sub UpdateContentControlsCollection(ccs As Object, values As Dictionary(Of String, String))
        If ccs Is Nothing Then Return
        For Each cc In ccs
            Try
                Dim title As String = ""
                Try : title = CStr(cc.Title) : Catch : End Try
                Dim tag As String = ""
                Try : tag = CStr(cc.Tag) : Catch : End Try

                Dim matchedVal As String = Nothing
                If Not String.IsNullOrEmpty(title) AndAlso values.TryGetValue(title.Trim(), matchedVal) Then
                    SetContentControlText(cc, matchedVal)
                ElseIf Not String.IsNullOrEmpty(tag) AndAlso values.TryGetValue(tag.Trim(), matchedVal) Then
                    SetContentControlText(cc, matchedVal)
                End If
            Catch
            End Try
        Next
    End Sub

    Private Sub SetContentControlText(cc As Object, val As String)
        Try
            Dim wasLocked As Boolean = False
            Try
                wasLocked = CBool(cc.LockContents)
                If wasLocked Then cc.LockContents = False
            Catch
            End Try

            cc.Range.Text = val

            If wasLocked Then
                Try : cc.LockContents = True : Catch : End Try
            End If
        Catch
        End Try
    End Sub

    Private Function GetRelativePath(root As String, fullPath As String) As String
        If Not fullPath.StartsWith(root, StringComparison.OrdinalIgnoreCase) Then
            Return Path.GetFileName(fullPath)
        End If
        Dim rel = fullPath.Substring(root.Length)
        If rel.StartsWith(Path.DirectorySeparatorChar) OrElse rel.StartsWith(Path.AltDirectorySeparatorChar) Then
            rel = rel.Substring(1)
        End If
        Return rel
    End Function

    Public Shared Sub ShowForm()
        Using f As New Form1()
            f.ShowDialog()
        End Using
    End Sub

End Class

