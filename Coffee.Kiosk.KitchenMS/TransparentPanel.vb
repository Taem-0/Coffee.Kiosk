Imports System.Windows.Forms

Public Class TransparentPanel
    Inherits Panel

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        ' do nothing — makes panel truly transparent
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20  ' WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property

End Class
