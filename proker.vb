Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class proker

    Dim Sqlhapus As String
    Dim Sqltambah As String
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim myData As New DataTable
    Dim reader As MySqlDataReader

    Sub koneksi()
        myconn = New MySqlConnection("server='localhost';user id='root';password='';database='himifda'")
        myconn.Open()
    End Sub

    Sub opentable()
        Dim myadapter As New MySqlDataAdapter("select * from proker", myconn)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub

    Sub clear()

        TextBox1.Text = ""
        DateTimePicker1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub proker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
        TextBox1.Enabled = False
    End Sub


    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick


        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("Data belum lengkap")
        Else
            Dim Sqltambah As String = "INSERT INTO proker(No, Date, Program)values ('" & TextBox1.Text & "', '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', '" & TextBox2.Text & "')"
            mycommand = New MySqlCommand(Sqltambah, myconn)
            mycommand.ExecuteNonQuery()
            MsgBox("data berhasil disimpan")
            opentable()

            Me.Show()
            clear()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        koneksi()
        mycommand = New MySqlCommand("UPDATE proker SET Date = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "',  Program = '" & TextBox2.Text & "' where no ='" & TextBox1.Text & "'", myconn)
        mycommand.ExecuteNonQuery()
        opentable()
        MsgBox("data berhasil diupdate", MsgBoxStyle.OkOnly, "pemberitahuan")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim hapus As String = "delete from proker where no='" & TextBox1.Text & "'"
        mycommand = New MySqlCommand(hapus, myconn)
        mycommand.ExecuteNonQuery()
        clear()
        MsgBox("data berhasil di hapus")
        opentable()
    End Sub

   
    Private Sub ContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactToolStripMenuItem.Click
        Me.Hide()
        data.Show()
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

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Me.Hide()
        cari.Show()
    End Sub

    Private Sub MentoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MentoringToolStripMenuItem.Click
        Me.Hide()
        mentor.Show()
    End Sub

  
End Class

