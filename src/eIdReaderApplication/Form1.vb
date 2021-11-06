Imports BelgianIdentityCardReader.BelgianIdentityCardReader

Public Class eId

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim reader As New eIdReader()

        reader.Connect()
        Try
            Dim id As IdData = reader.LoadIdData()
            lblName.Text = id.FirstName1
            lblName.Text += " " + id.Name

            Dim address As Address = reader.LoadAddress()
            lblAddress.Text = address.Street
            lblAddress.Text += " " & address.StreetNumber
            lblAddress.Text += " " & address.Zip
            lblAddress.Text += " " & address.Municipality

            PictureBox1.Image = reader.LoadPicture()
        Finally
            reader.Disconnect()
        End Try
    End Sub
End Class
