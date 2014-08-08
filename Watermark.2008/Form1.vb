Public Class Form1

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TextBox1.Text = Watermark1.WatermarkText
        TextBox3.Text = Watermark1.Font.ToString
        PictureBox1.BackColor = Watermark1.WatermarkColor
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = Nothing Then
            MessageBox.Show("Please Type in Text , Error", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox2.Text = Watermark1.WatermarkText Then
            MessageBox.Show("This Text is Already the Watermark Text", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Watermark1.WatermarkText = TextBox2.Text
            TextBox2.Clear()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ColorDlg As New ColorDialog
        ColorDlg.Color = Watermark1.WatermarkColor
        ColorDlg.ShowDialog()
        Watermark1.WatermarkColor = ColorDlg.Color
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim FontDlg As New FontDialog
        FontDlg.Font = Watermark1.Font
        FontDlg.ShowDialog()
        Watermark1.Font = FontDlg.Font
    End Sub

End Class
