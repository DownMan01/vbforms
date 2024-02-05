Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            reload("SELECT * FROM product", DTGLIST)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class