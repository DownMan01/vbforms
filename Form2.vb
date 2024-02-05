
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports MySql.Data.MySqlClient

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub search_Click(sender As Object, e As EventArgs) Handles search.Click
        '=================data source from excel(database)==================
        Dim connString As String = "server=localhost; user id=root; password=; database=dbproduct;"
        Dim sqlQuery As String = "SELECT * FROM product WHERE product_code=@productCode"

        Using sqlConn As New MySqlConnection(connString)
            Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                sqlComm.Parameters.AddWithValue("@productCode", product_code.Text)

                Try
                    sqlConn.Open()
                    Dim sqlReader As MySqlDataReader = sqlComm.ExecuteReader()

                    If sqlReader.Read() Then
                        product_name.Text = sqlReader("product_name").ToString()
                        product_price.Text = sqlReader("product_price").ToString()
                        product_quantity.Text = sqlReader("product_quantity").ToString()
                    Else
                        MessageBox.Show("An error has occurred, please provide valid product code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    sqlReader.Close()
                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
        '==================================================================
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles save.Click
        '=================Save button to save data=============================
        Try
            Dim productName As String = product_name.Text.Trim()
            Dim productPrice As String = product_price.Text.Trim()
            Dim productQuantity As String = product_quantity.Text.Trim()

            If productName <> "0" AndAlso Not String.IsNullOrEmpty(productPrice) AndAlso Not String.IsNullOrEmpty(productQuantity) Then
                create("INSERT INTO product (product_name, product_price, product_quantity) VALUES('" & productName & "', '" & productPrice & "', '" & productQuantity & "')")
            Else
                MessageBox.Show("An error has occurred, please provide valid data for all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        '==================================================================
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles delete.Click
        '==================================================================
        Try
            delete_button("DELETE FROM product WHERE product_code='" & product_code.Text & "'")
        Catch ex As Exception
            MessageBox.Show("An error has occurred, please provide valid product code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        '==================================================================
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles clear.Click
        '=================to clear text in textbox=================
        product_code.Text = ""
        product_name.Text = ""
        product_price.Text = ""
        product_quantity.Text = ""
        MessageBox.Show("All fields have been cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '==================================================================
    End Sub
End Class