Public Class ucOrderItem

    ' -------------------------------------------------------
    ' PRIVATE VARIABLES
    ' -------------------------------------------------------
    Private _isFinished As Boolean = False

    ' -------------------------------------------------------
    ' STEP A: load item data into the control
    ' -------------------------------------------------------
    Public Sub LoadItem(item As OrderItem)
        lblItemName.Text = item.ItemName
        lblQuantity.Text = "x" & item.Quantity

        If item.Customizations IsNot Nothing AndAlso item.Customizations.Count > 0 Then
            lblCustomizations.Text = String.Join(" | ", item.Customizations)
            lblCustomizations.Visible = True
            lblCustomizations.BringToFront()
            lblCustomizations.AutoSize = False
            lblCustomizations.Width = Me.Width - 20

            ' auto calculate height based on text wrapping
            Dim g As Graphics = lblCustomizations.CreateGraphics()
            Dim textSize As SizeF = g.MeasureString(
        lblCustomizations.Text,
        lblCustomizations.Font,
        lblCustomizations.Width
    )
            lblCustomizations.Height = CInt(textSize.Height) + 5
            g.Dispose()

            ' resize the whole ucOrderItem to fit content
            Me.Height = lblCustomizations.Top + lblCustomizations.Height + 10

        Else
            lblCustomizations.Text = ""
            lblCustomizations.Visible = False

            ' shrink back to default height when no customizations
            Me.Height = lblItemName.Top + lblItemName.Height + 10
        End If
        SetNormalState()
    End Sub
    ' -------------------------------------------------------
    ' STEP B: click anywhere to toggle finished state
    ' -------------------------------------------------------
    Private Sub ucOrderItem_Click(sender As Object, e As EventArgs) _
        Handles Me.Click, lblItemName.Click, lblQuantity.Click, lblCustomizations.Click

        _isFinished = Not _isFinished

        If _isFinished Then
            SetFinishedState()
        Else
            SetNormalState()
        End If
    End Sub

    ' -------------------------------------------------------
    ' STEP C: normal state — dark, not done
    ' -------------------------------------------------------
    Private Sub SetNormalState()
        Me.BackColor = Color.FromArgb(255, 255, 255)

        lblItemName.BackColor = Color.Transparent
        lblItemName.ForeColor = Color.FromArgb(0, 0, 0)
        lblItemName.Font = New Font(lblItemName.Font, FontStyle.Bold)

        lblQuantity.BackColor = Color.Transparent
        lblQuantity.ForeColor = Color.FromArgb(0, 0, 0)
        lblQuantity.Font = New Font(lblQuantity.Font, FontStyle.Bold)

        lblCustomizations.BackColor = Color.Transparent
        lblCustomizations.ForeColor = Color.FromArgb(0, 0, 0)
        lblCustomizations.Font = New Font(lblCustomizations.Font, FontStyle.Regular)
    End Sub

    Private Sub SetFinishedState()
        Me.BackColor = Color.FromArgb(128, 224, 121)

        lblItemName.BackColor = Color.Transparent
        lblItemName.ForeColor = Color.FromArgb(0, 0, 0)
        lblItemName.Font = New Font(lblItemName.Font, FontStyle.Bold Or FontStyle.Strikeout)

        lblQuantity.BackColor = Color.Transparent
        lblQuantity.ForeColor = Color.FromArgb(0, 0, 0)
        lblQuantity.Font = New Font(lblQuantity.Font, FontStyle.Bold Or FontStyle.Strikeout)

        lblCustomizations.BackColor = Color.Transparent
        lblCustomizations.ForeColor = Color.FromArgb(0, 0, 0)
        lblCustomizations.Font = New Font(lblCustomizations.Font, FontStyle.Strikeout)
    End Sub


    ' -------------------------------------------------------
    ' STEP E: lets ucOrderCard check if this item is done
    ' -------------------------------------------------------
    Public ReadOnly Property IsFinished As Boolean
        Get
            Return _isFinished
        End Get
    End Property

    ' -------------------------------------------------------
    ' HOVER EFFECTS
    ' -------------------------------------------------------
    ' Private Sub ucOrderItem_MouseEnter(sender As Object, e As EventArgs) _
    '     Handles Me.MouseEnter, lblItemName.MouseEnter, lblQuantity.MouseEnter, lblCustomizations.MouseEnter
    '
    '     If _isFinished Then
    '         ' slightly darker green on hover
    '        Me.BackColor = Color.FromArgb(140, 195, 140)
    '    Else
    '       ' slightly darker beige on hover
    '       Me.BackColor = Color.FromArgb(210, 185, 140)
    '    End If
    '
    '   Me.Cursor = Cursors.Hand  ' show hand cursor on hover
    ' End Sub

    '  Private Sub ucOrderItem_MouseLeave(sender As Object, e As EventArgs) _
    '      Handles Me.MouseLeave, lblItemName.MouseLeave, lblQuantity.MouseLeave, lblCustomizations.MouseLeave

    '     If _isFinished Then
    '
    '     SetFinishedState()
    '     Else
    '       SetNormalState()
    '     End If

    '   Me.Cursor = Cursors.Default
    '     End Sub

End Class

