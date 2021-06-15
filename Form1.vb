Public Class Form1
    Private enfocado As Boolean

    Private Sub btnAgregBot_MouseEnter(sender As Object, e As EventArgs) Handles btnAgregBot.MouseEnter
        enfocado = True
        btnAgregBot.Invalidate()
    End Sub
    Private Sub btnAgregBot_MouseLeave(sender As Object, e As EventArgs) Handles btnAgregBot.MouseLeave
        enfocado = False
        btnAgregBot.Invalidate()
    End Sub
    Private Sub btnAgregBot_Paint(sender As Object, e As PaintEventArgs) Handles btnAgregBot.Paint
        'MyBase.OnPaint(e)   'Evento de la clase base
        Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(Color.LightSkyBlue, 2)
        If enfocado Then
            e.Graphics.DrawRectangle(myPen,
                New Rectangle(New Drawing.Point(1, 1), New Drawing.Size(btnAgregBot.Width - 2, btnAgregBot.Height - 2))
            )
        End If
    End Sub
    Private Sub DetenerTodos()
        'Detiene todos los contadores
        For Each c As Control In FlowLayoutPanel1.Controls
            If TypeOf c Is PKUserControl.UserControl1 Then
                Dim cont As PKUserControl.UserControl1 = DirectCast(c, PKUserControl.UserControl1)
                cont.Pausar()
            End If
        Next
    End Sub
    Private Sub btnAgregBot_Click(sender As Object, e As EventArgs) Handles btnAgregBot.Click
        Dim txt As String
        txt = InputBox("Nombre: ")
        Dim cont As New PKUserControl.UserControl1(txt)
        FlowLayoutPanel1.Controls.Add(cont)
        'Agrega eventos
        AddHandler cont.OnInicio,
            Sub()
                DetenerTodos()
                cont.Iniciar()
            End Sub
    End Sub

End Class
