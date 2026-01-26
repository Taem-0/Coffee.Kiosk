Public Class Form2

    Private monitoringButton As monitoringButtons


    Private Sub CallControl(control As UserControl, panel As FlowLayoutPanel)
        panel.Controls.Clear()
        control.Dock = DockStyle.Fill
        control.BringToFront()
    End Sub

    Private Sub ShowInPanel(control As UserControl)
        CallControl(control, FlowLayoutPanel1)
    End Sub

    Private Sub ShowMonitoring()
        CallControl(monitoringButton, FlowLayoutPanel1)
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ShowMonitoring()

    End Sub
End Class