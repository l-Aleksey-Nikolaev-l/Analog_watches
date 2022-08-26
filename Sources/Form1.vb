Imports System.Math
Imports System.Drawing.Drawing2D

Public Class Form1

    Dim sec, min, ch As Integer
    Dim x1, x2, y1, y2, x3, y3, xt, yt As Integer, n, t As Double, gr As Graphics, pen1 As New Pen(Color.Red, 2), pen2 As New Pen(Color.Green, 3), pen3 As New Pen(Color.DarkGreen, 4), br As New SolidBrush(Color.White), font1 As New Font("Arial", 16)
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        time()
    End Sub

    Sub time()
        sec = Date.Now.Second
        min = Date.Now.Minute
        ch = Date.Now.Hour
        Label1.Text = DateTime.Now
        Dim bp As New Bitmap(250, 250)
        gr = Graphics.FromImage(bp)
        PictureBox1.Image = bp
        gr.ScaleTransform(1, -1)
        gr.TranslateTransform(125, -125)
        If ch > 12 Then ch -= 12
        x3 = Round(65 * Sin(6.28 * (ch + min / 60) / 12))
        y3 = Round(65 * Cos(6.28 * (ch + min / 60) / 12))
        gr.DrawLine(pen3, 0, 0, x3, y3)
        x2 = Round(90 * Sin(6.283 * min / 60))
        y2 = Round(90 * Cos(6.283 * min / 60))
        gr.DrawLine(pen2, 0, 0, x2, y2)
        x1 = Round(110 * Sin(6.28 * sec / 60))
        y1 = Round(110 * Cos(6.28 * sec / 60))
        gr.DrawLine(pen1, 0, 0, x1, y1)
    End Sub

    Private Sub PictureBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        Application.Exit()   'Выход по двойному клику
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Dim i As Byte
        gr = e.Graphics
        For i = 1 To 12
            xt = 115 + Math.Round(100 * Math.Sin(6.28 * 30 * i / 360))
            yt = 115 - Math.Round(100 * Math.Cos(6.28 * 30 * i / 360))
            gr.DrawString(i, font1, br, xt, yt)
        Next i
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gr1 As GraphicsPath = New GraphicsPath
        gr1.AddEllipse(PictureBox1.ClientRectangle)
        PictureBox1.Region = New Region(gr1)
        gr1 = New GraphicsPath()
        Dim Rectangle = New Rectangle(PictureBox1.Location.X, PictureBox1.Location.Y, PictureBox1.Width, PictureBox1.Height)
        Rectangle.Location = New Point(Rectangle.Location.X + 4, Rectangle.Location.Y + 4)
        gr1.AddEllipse(Rectangle)
        Timer1.Start()
        sec = Date.Now.Second
        min = Date.Now.Minute
        ch = Date.Now.Hour

        time()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("Nikolaev A.D", , "Автор")
    End Sub
End Class
