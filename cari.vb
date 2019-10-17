Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data


Public Class cari

    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim myData As New DataTable
    Dim reader As MySqlDataReader

    Sub koneksi()
        myconn = New MySqlConnection("server='localhost';user id='root';password='';database='himifda'")
        myconn.Open()
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        mycommand = New MySqlCommand("Select * from proker", myconn)
        reader = mycommand.ExecuteReader
        While reader.Read()
            'ComboBox1.Items.Add(reader("Date"))
        End While

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        koneksi()
        mycommand = New MySqlCommand("Select * from proker where Date ='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'", myconn)
        reader = mycommand.ExecuteReader
        If reader.Read() Then
            RichTextBox1.Text = reader("Program")
        End If
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Me.Hide()


    End Sub

    Private Sub ContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactToolStripMenuItem.Click
        Me.Hide()
        data.Show()
    End Sub

    Private Sub ProgramKerjaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramKerjaToolStripMenuItem.Click
        
    End Sub

    Private Sub PemasukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PemasukanToolStripMenuItem.Click
        Me.Hide()
        pemasukkan.Show()
    End Sub

    Private Sub PengeluaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengeluaranToolStripMenuItem.Click
        Me.Hide()
        pengeluaran.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MentoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MentoringToolStripMenuItem.Click
        Me.Hide()
        mentor.Show()
    End Sub
End Class