Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class RoundedButton
    Inherits Button

    Private _borderColor As Color = Color.FromArgb(0, 0, 0)
    Private _borderSize As Integer = 2
    Private _cornerRadius As Integer = 10

    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderSize As Integer
        Get
            Return _borderSize
        End Get
        Set(value As Integer)
            _borderSize = value
            Me.Invalidate()
        End Set
    End Property

    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            _cornerRadius = value
            Me.Invalidate()
        End Set
    End Property

    Sub New()
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0        ' hide default border
        Me.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)  ' transparent
        Me.SetStyle(ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.Clear(Me.Parent.BackColor)   ' paint parent bg first — fixes green bleed

        Dim rect As New Rectangle(
            _borderSize,
            _borderSize,
            Me.Width - (_borderSize * 2) - 1,
            Me.Height - (_borderSize * 2) - 1
        )

        ' fill rounded background
        Using path = GetPath(rect, _cornerRadius)
            Using brush As New SolidBrush(Me.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using
        End Using

        ' draw rounded border
        Using path = GetPath(rect, _cornerRadius)
            Using pen As New Pen(_borderColor, 0.5F)
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using

        ' draw text centered
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        Using brush As New SolidBrush(Me.ForeColor)
            e.Graphics.DrawString(Me.Text, Me.Font, brush, New RectangleF(0, 0, Me.Width, Me.Height), sf)
        End Using
    End Sub

    Private Function GetPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90)
        path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90)
        path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90)
        path.CloseFigure()
        Return path
    End Function

End Class