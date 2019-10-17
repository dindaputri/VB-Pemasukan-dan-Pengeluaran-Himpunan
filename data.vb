Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data


Public Class data

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
        Dim myadapter As New MySqlDataAdapter("select * from mahasiswa", myconn)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata

    End Sub

    Sub clear()
        TextBox4.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data belum lengkap")
        Else
            Dim Sqltambah As String = "INSERT INTO mahasiswa(id_mhs,nim, nama, jabatan, alamat)values ('" & TextBox4.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "')"
            mycommand = New MySqlCommand(Sqltambah, myconn)
            mycommand.ExecuteNonQuery()
            MsgBox("data berhasil disimpan")
            opentable()

            Me.Show()
            clear()
        End If
    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Dim hapus As String = "delete from mahasiswa where id_mhs='" & TextBox4.Text & "'"
        mycommand = New MySqlCommand(hapus, myconn)
        mycommand.ExecuteNonQuery()
        clear()
        MsgBox("data berhasil di hapus")
        opentable()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        koneksi()
        mycommand = New MySqlCommand("UPDATE mahasiswa SET nim = '" & TextBox1.Text & "',  nama = '" & TextBox2.Text & "',  jabatan = '" & ComboBox1.Text & "', alamat = '" & TextBox3.Text & "' where id_mhs ='" & TextBox4.Text & "'", myconn)
        mycommand.ExecuteNonQuery()
        opentable()
        MsgBox("data berhasil diupdate", MsgBoxStyle.OkOnly, "pemberitahuan")
    End Sub

    Private Sub PengeluaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengeluaranToolStripMenuItem.Click
        Me.Hide()
        pengeluaran.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
    End Sub

    
    Private Sub PemasukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PemasukanToolStripMenuItem.Click
        Me.Hide()
        pemasukkan.Show()
    End Sub

    Private Sub ContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactToolStripMenuItem.Click
        Me.Hide()
        Me.Show()
    End Sub

    Private Sub ProgramKerjaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramKerjaToolStripMenuItem.Click
        Me.Hide()
        proker.Show()
    End Sub

    Private Sub MentoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MentoringToolStripMenuItem.Click
        Me.Hide()
        mentor.Show()
    End Sub

    Private Sub CariToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CariToolStripMenuItem.Click
        Me.Hide()
        cari.Show()
    End Sub

    Private Sub LaporanDataPengurusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanDataPengurusToolStripMenuItem.Click
        Me.Hide()
        printdata.Show()
    End Sub

    Private Sub ProgramKerjaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramKerjaToolStripMenuItem1.Click
        Me.Hide()
        printproker.Show()
    End Sub

  
End Class
