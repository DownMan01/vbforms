Imports MySql.Data.MySqlClient

Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles search.Click
        '============================= DATA READER ==============================
        Dim connString As String = "server=localhost; user id=root; password=; database=dbproduct;"
        Dim sqlQuery As String = "SELECT * FROM product WHERE product_code=@product_Code"

        Using sqlConn As New MySqlConnection(connString)
            Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                sqlComm.Parameters.AddWithValue("@product_Code", productCode.Text)

                Try
                    sqlConn.Open()
                    Dim sqlReader As MySqlDataReader = sqlComm.ExecuteReader()

                    If sqlReader.Read() Then
                        productNumber.Text = sqlReader("product_code").ToString()
                        productName.Text = sqlReader("product_name").ToString()
                        productPrice.Text = sqlReader("product_price").ToString()
                        productQuantity.Text = sqlReader("product_quantity").ToString()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles delete.Click
        '=========================== DELETE BUTTON ==================================


        '==================================================================
    End Sub

    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        '=========================== ADD BUTTON ==================================
        Try
            Dim product_Code As String = productCode.Text.Trim()
            Dim product_Name As String = productName.Text.Trim()
            Dim product_Price As String = productPrice.Text.Trim()
            Dim product_Quantity As String = productQuantity.Text.Trim()

            create("INSERT INTO sales (productCode, productName, productPrice, productQuantity) VALUES('" & product_Code & "', '" & product_Name & "', '" & product_Price & "', '" & product_Quantity & "')")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        Try
            reload("SELECT * FROM sales", purchasingLV)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        Try
            Dim SubTotal As Double

            SubTotal = productPrice.Text * productQuantity.Text
        Catch ex As Exception

        End Try
        '==================================================================
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click

    End Sub

    Private Sub Total_TextChanged(sender As Object, e As EventArgs) Handles Total.TextChanged
    End Sub

End Class