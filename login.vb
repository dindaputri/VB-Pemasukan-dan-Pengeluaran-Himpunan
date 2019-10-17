Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data


Public Class login
    Dim koneksi As MySqlConnection
    Dim sql, username, password As String
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("isi data dahulu!")
        Else
            username = TextBox1.Text
            password = TextBox2.Text
            sql = "Select * from login where username= '" + username + "' and password= '" + password + "'"
            cmd = New MySqlCommand(sql, koneksi)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                MsgBox("anda berhasil login")
                TextBox1.Text = ""
                TextBox2.Text = ""
                Me.Hide()
                data.ShowDialog()
                rd.Close()
            Else
                MsgBox("Data Salah! ")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()
                rd.Close()
            End If
        End If
    End Sub


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strKoneksi As String
        strKoneksi = "server='localhost';user id='root';password='';database='himifda'"
        koneksi = New MySqlConnection(strKoneksi)
        Try
            koneksi.Open()
        Catch ex As Exception

        End Try
    End Sub
End Class
