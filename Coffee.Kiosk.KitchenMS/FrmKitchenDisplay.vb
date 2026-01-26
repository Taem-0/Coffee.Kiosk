Imports System.Runtime

Public Class FrmKitchenDisplay


    Private Sub FrmKitchenDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TimerClock.Start()

    End Sub

    Private Sub TimerClock_Tick(sender As Object, e As EventArgs) Handles TimerClock.Tick

        lblTime.Text = Date.Now.ToString("HH:mm:ss")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim card As New ucOrderCard()
        card.SetOrderTime(DateTime.Now)
        flOrders.Controls.Add(card)
        UpdateActiveOrders()

    End Sub

    Public Sub UpdateActiveOrders()
        Dim count As Integer = 0


        For Each ctrl As Control In flOrders.Controls
            If TypeOf ctrl Is ucOrderCard AndAlso ctrl.Visible Then
                count += 1
            End If
        Next


        lblActiveOrder.Text = count.ToString()
    End Sub

End Class
