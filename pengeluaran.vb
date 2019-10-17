Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class pengeluaran
    Dim mycommand As New MySqlCommand
    Dim myData As New DataTable
    Dim reader As MySqlDataReader
    Dim jumlah As Integer

    Sub opentable()
        koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from pengeluaran", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        opentab()
    End Sub
    Sub opentab()
        'koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from pemasukkan", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView2.DataSource = mydata

        Dim subtotal As Integer = 0
        For I As Integer = 0 To DataGridView2.Rows.Count - 1
            subtotal += Val(DataGridView2.Rows(I).Cells(4).Value)
            Label3.Text = subtotal
        Next

    End Sub
    Sub sisa()
        Dim a, b As String
        a = Label3.Text
        b = Label2.Text
        Label10.Text = a - b
    End Sub
    Sub clear()
        TextBox1.Text = ""
        TextBox4.Text = ""
        DateTimePicker1.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub pengeluaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opentable()
        opentab()
        total()
        sisa()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value


    End Sub

    Private Sub PemasukkanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PemasukkanToolStripMenuItem.Click
        Me.Hide()
        pemasukkan.Show()
    End Sub

    Private Sub PengeluaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengeluaranToolStripMenuItem.Click
        Me.Hide()

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox4.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Data belum lengkap")
        Else
            Dim Sqltambah As String = "INSERT INTO pengeluaran(ket, pengeluaran,  Date)values ('" & TextBox4.Text & "','" & TextBox3.Text & "' , '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
            mycommand = New MySqlCommand(Sqltambah, koneksi)
            mycommand.ExecuteNonQuery()
            MsgBox("data berhasil disimpan")
            opentable()
            opentab()
            total()
            sisa()
            clear()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim hapus As String = "delete from pengeluaran where no ='" & TextBox1.Text & "'"
        mycommand = New MySqlCommand(hapus, myconn)
        mycommand.ExecuteNonQuery()
        MsgBox("data berhasil di hapus")
        opentable()
        opentab()
        total()
        sisa()
        clear()
    End Sub

    Sub total()
        Dim subtotal As Integer = 0
        For I As Integer = 0 To DataGridView1.Rows.Count - 1
            subtotal += Val(DataGridView1.Rows(I).Cells(2).Value)
            Label2.Text = subtotal
        Next
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

    Private Sub CariToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CariToolStripMenuItem.Click
        Me.Hide()
        cari.Show()
    End Sub
End Class