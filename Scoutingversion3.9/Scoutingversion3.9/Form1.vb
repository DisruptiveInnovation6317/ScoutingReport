Imports System.IO
Imports Newtonsoft.Json
Public Class Form1
    Dim a As StreamReader
    Dim b As String
    Dim c As String = "C:\Users\hs131455\Documents\Visual Studio 2013\ScoutingTextDesk.txt"
    Private Sub btnResult_Click(sender As Object, e As EventArgs) Handles btnResult.Click
        'Autonomous Scoring Code!!!!!!!!!!!
        'Autonomous Scoring Code!!!!!!!!!!!
        'Autonomous Scoring Code!!!!!!!!!!!
        Dim dblUpperAutoPts As Double
        Dim dblLowerAutoPts As Double
        Dim blnInputOk = True
        Dim dblResult As Double
        Const intBreakB As Integer = 5
        Const intRotor As Integer = 60
        'Converting strings to integers(Autonomous)
        dblUpperAutoPts = CDbl(UpperAutoPts.Text)
        dblLowerAutoPts = CDbl(LowerAutoPts.Text)
        dblResult = dblUpperAutoPts + (dblLowerAutoPts / 3)
        lblResult.Text = CStr(dblResult)
        If BreakB.Checked = True Then
            dblResult = dblUpperAutoPts + (dblLowerAutoPts / 3) + intBreakB
            lblResult.Text = CStr(dblResult)
        End If
        If Rotor.Checked = True Then
            dblResult = dblUpperAutoPts + (dblLowerAutoPts / 3) + intRotor
            lblResult.Text = CStr(dblResult)
        End If
        If Rotor.Checked And BreakB.Checked = True Then
            dblResult = dblUpperAutoPts + (dblLowerAutoPts / 3) + intBreakB + intRotor
            lblResult.Text = CStr(dblResult)
        End If
        'Teleop Scoring Code!!!!!!!!!!!
        'Teleop Scoring Code!!!!!!!!!!!
        'Teleop Scoring Code!!!!!!!!!!!
        Dim dblUpperTeleopPts, dblTotal, dblLowerTeleopPts As Double
        Const intRope As Integer = 50
        Const intRotor40 As Integer = 40
        Const intRotor80 As Integer = 80
        Const intRotor120 As Integer = 120
        Const intRotor160 As Integer = 160
        'Converting strings to integers(Teleop)
        dblUpperTeleopPts = CDbl(UpperTeleopPts.Text)
        dblLowerTeleopPts = CDbl(LowerTeleopPts.Text)

        dblTotal = (dblUpperTeleopPts / 3) + (dblLowerTeleopPts / 9)
        lblTotal.Text = CStr(dblTotal)
        'If check boxes are checked.
        If Rope.Checked = True Then
            dblTotal = (dblUpperTeleopPts / 3) + (dblLowerTeleopPts / 9) + intRope
            lblTotal.Text = CStr(dblTotal)
        End If
        If Rotor40.Checked = True Then
            dblTotal = (dblUpperTeleopPts / 3) + (dblLowerTeleopPts / 9) + intRotor40
            lblTotal.Text = CStr(dblTotal)
        End If
        If Rotor80.Checked = True Then
            dblTotal = dblUpperTeleopPts + (dblLowerTeleopPts / 3) + intRotor80
            lblTotal.Text = CStr(dblTotal)
        End If
        If Rotor120.Checked = True Then
            dblTotal = dblUpperTeleopPts + (dblLowerTeleopPts / 3) + intRotor120
            lblTotal.Text = CStr(dblTotal)
        End If
        If Rotor160.Checked = True Then
            dblTotal = dblUpperTeleopPts + (dblLowerTeleopPts / 3) + intRotor160
            lblTotal.Text = CStr(dblTotal)
        End If
        'If one of the 4 rotor check boxes is checked plus the rope if completed.
        If Rope.Checked And Rotor40.Checked = True Then
            dblTotal = (dblUpperTeleopPts / 3) + (dblLowerTeleopPts / 9) + intRope + intRotor40
            lblTotal.Text = CStr(dblTotal)
        End If
        If Rope.Checked And Rotor80.Checked = True Then
            dblTotal = (dblUpperTeleopPts / 3) + (dblLowerTeleopPts / 9) + intRope + intRotor80
            lblTotal.Text = CStr(dblTotal)
        End If
        If Rope.Checked And Rotor120.Checked = True Then
            dblTotal = (dblUpperTeleopPts / 3) + (dblLowerTeleopPts / 9) + intRope + intRotor120
            lblTotal.Text = CStr(dblTotal)
        End If
        If Rope.Checked And Rotor160.Checked = True Then
            dblTotal = (dblUpperTeleopPts / 3) + (dblLowerTeleopPts / 9) + intRope + intRotor160
            lblTotal.Text = CStr(dblTotal)
        End If
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Unchecking the CheckBoxes!
        BreakB.Checked = False
        Rotor.Checked = False
        Rope.Checked = False
        Rotor40.Checked = False
        Rotor80.Checked = False
        Rotor120.Checked = False
        Rotor160.Checked = False
        'Clearing the Team Name and Number Text Boxes
        txtTeamName.Text = String.Empty
        txtTeamNum.Text = String.Empty
        txtSpecial.Text = String.Empty
        'Clearing the Numeric Up and Down Boxes
        UpperAutoPts.Text = 0
        LowerAutoPts.Text = 0
        UpperTeleopPts.Text = 0
        LowerTeleopPts.Text = 0
        'Clearing The Total Labels
        lblResult.Text = String.Empty
        lblTotal.Text = String.Empty
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(c) Then
            Dim d As FileStream
            d = File.Create(c)
            d.Close()
        End If
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        'Exports the data to notepad 
        ' Puts the information into a text box and accumulates the information
        If lblResult.Text And lblTotal.Text = Nothing Then
            MsgBox("Enter a password to be saved.")
        Else
            File.AppendAllText(c, "Team Name: " & TextBox1.Text & " Team Number: " & TextBox2.Text &
                               " Autonomous: " & lblResult.Text & " Teloperated: " & lblTotal.Text &
                               " Special Notes: " & txtSpecial.Text & vbCrLf)
            lblResult.Text = ""
            MsgBox("Password saved!", MsgBoxStyle.Information, "Saved")
        End If
    End Sub
    Private Sub ReadFile()
        Try
            ComboBox1.Items.Clear()
            a = File.OpenText(c)
            While a.Peek <> -1
                b = a.ReadLine()
                ComboBox1.Items.Add(b)
            End While
            a.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class


