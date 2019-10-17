Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class pemasukkan

    Dim Sqlhapus As String
    Dim Sqltambah As String
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim myData As New DataTable
    Dim reader As MySqlDataReader
    Sub cmb()
        mycommand = New MySqlCommand("Select * from mahasiswa", koneksi)
        reader = mycommand.ExecuteReader()
        While reader.Read()
            ComboBox1.Items.Add(reader("id_mhs"))
        End While
    End Sub

    Sub opentable()
        koneksi()
        Dim myadapter As New MySqlDataAdapter("select no, nama,  jenis_pemasukkan, pemasukkan, Date from pemasukkan", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        total()
    End Sub


    Sub clear()
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DateTimePicker1.Text = ""
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
        cmb()
        total()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        mycommand = New MySqlCommand("Select * from mahasiswa where id_mhs='" & ComboBox1.Text & "'", koneksi)
        reader = mycommand.ExecuteReader
        While reader.Read()
            TextBox2.Text = reader("nama")
        End While
    End Sub

    Private Sub PemasukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PemasukanToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub PengeluaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengeluaranToolStripMenuItem.Click
        Me.Hide()
        pengeluaran.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data belum lengkap")
        Else
            Dim Sqltambah As String = "INSERT INTO pemasukkan(id_mhs, nama, jenis_pemasukkan, pemasukkan, Date)values ('" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox3.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
            mycommand = New MySqlCommand(Sqltambah, koneksi)
            mycommand.ExecuteNonQuery()
            MsgBox("data berhasil disimpan")
            opentable()
            Me.Show()
            clear()
        End If
    End Sub
    Sub total()
        Dim subtotal As Integer = 0
        For I As Integer = 0 To DataGridView1.Rows.Count - 1
            subtotal += Val(DataGridView1.Rows(I).Cells(3).Value)
            Label9.Text = subtotal
            pengeluaran.Label3.Text = Label9.Text
        Next
    End Sub
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim hapus As String = "delete from pemasukkan where no = '" & TextBox1.Text & "'"
        mycommand = New MySqlCommand(hapus, koneksi)
        mycommand.ExecuteNonQuery()
        clear()
        MsgBox("data berhasil di hapus")
        opentable()
    End Sub

   

 
    Private Sub ContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactToolStripMenuItem.Click
        Me.Hide()
        data.Show()
    End Sub

    Private Sub ProgramKerjaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramKerjaToolStripMenuItem.Click
        Me.Hide()
        proker.Show()
    End Sub

    Private Sub MentoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MentoringToolStripMenuItem.Click
        Me.Hide()
        mentor.Show()
    End Sub
End Class