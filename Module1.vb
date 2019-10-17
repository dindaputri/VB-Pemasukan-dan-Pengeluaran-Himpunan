Imports MySql.Data.MySqlClient
Imports System.Data
Module Module1

    Public myconn As New MySqlConnection
    Public mycommand As New MySqlCommand
    Public myadapter As New MySqlDataAdapter
    Public myData As New DataTable
    Public reader As MySqlDataReader

    Public Function koneksi() As MySqlConnection
        myconn = New MySqlConnection("server='localhost';user id='root';password='';database='himifda'")
        myconn.Open()
        Return (myconn)
    End Function
End Module
