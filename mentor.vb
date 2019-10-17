Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class mentor
    Dim Sqlhapus As String
    Dim Sqltambah As String
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim myData As New DataTable

    Sub koneksi()
        myconn = New MySqlConnection("server='localhost';user id='root';password='';database='himifda'")
        myconn.Open()
    End Sub

    Sub opentable()
        Dim myadapter As New MySqlDataAdapter("select * from mentoring", myconn)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub

    Sub clear()
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
    End Sub

    Sub mentor()
        koneksi()
        mycommand = New MySqlCommand("Select * from mentoring", myconn)
        reader = mycommand.ExecuteReader
        While reader.Read()
            ComboBox1.Items.Add(reader("pengajar"))
        End While
    End Sub

    Private Sub mentor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
        mentor()
        TextBox1.Enabled = False
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        koneksi()
        If ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Data belum lengkap")
        Else
            Dim Sqltambah As String = "INSERT INTO mentoring(no, pengajar, materi, kelompok, minggu_ke, Hari)values ('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox2.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
            mycommand = New MySqlCommand(Sqltambah, myconn)
            mycommand.ExecuteNonQuery()
            MsgBox("data berhasil disimpan")
            opentable()
            clear()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        koneksi()
        mycommand = New MySqlCommand("UPDATE mentoring SET pengajar = '" & ComboBox1.Text & "',  materi = '" & TextBox2.Text & "',  kelompok = '" & TextBox3.Text & "',  minggu_ke = '" & ComboBox2.Text & "',  Hari = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' where no ='" & TextBox1.Text & "'", myconn)
        mycommand.ExecuteNonQuery()
        opentable()
        MsgBox("data berhasil diupdate", MsgBoxStyle.OkOnly, "pemberitahuan")

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        koneksi()
        Dim hapus As String = "delete from mentoring where no='" & TextBox1.Text & "'"
        mycommand = New MySqlCommand(hapus, myconn)
        mycommand.ExecuteNonQuery()
        clear()
        MsgBox("data berhasil di hapus")
        opentable()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()
        mycommand = New MySqlCommand("Select * from mentoring where pengajar ='" & ComboBox1.Text & "'", myconn)
        reader = mycommand.ExecuteReader
        While reader.Read()
            TextBox2.Text = reader("materi")
            TextBox3.Text = reader("kelompok")
            ComboBox2.Text = reader("minggu_ke")
            'ComboBox3.Text = reader("Hari")
        End While
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
    End Sub

    Private Sub ContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactToolStripMenuItem.Click
        Me.Hide()
        data.Show()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ProgramKerjaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramKerjaToolStripMenuItem.Click
        Me.Hide()
        proker.Show()
    End Sub

    Private Sub CariToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CariToolStripMenuItem.Click
        Me.Hide()
        cari.Show()
    End Sub
End Class