Imports System.ComponentModel

''' <summary>
''' Watermark/Placeholder を実現するテキストボックス
''' </summary>
''' <remarks>http://www.youtube.com/watch?v=db8w3r_KNz8</remarks>
Public Class WatermarkTextBox
    Inherits TextBox

    'Declare A Few Variables
    Friend WaterText As String
    Friend WaterColor As Color
    Friend WaterFont As Font
    Friend WaterBrush As SolidBrush
    Friend WaterContainer As Panel

#Region "Public properties..."
    <Category("Watermark Attributes"), Description("Sets Watermark Text")> Public Property WatermarkText() As String
        Get
            Return WaterText
        End Get
        Set(ByVal value As String)
            WaterText = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Watermark Attributes"), Description("Sets Watermark Color")> Public Property WatermarkColor() As Color
        Get
            Return WaterColor
        End Get
        Set(ByVal value As Color)
            WaterColor = value
            WaterBrush = New SolidBrush(WaterColor)
            Me.Invalidate()
        End Set
    End Property

    <Category("Watermark Attributes"), Description("Sets Watermark Font")> _
    Public Property WatermarkFont() As Font
        Get
            Return WaterFont
        End Get
        Set(ByVal value As Font)
            WaterFont = value
            Me.Invalidate()
        End Set
    End Property
#End Region

    Public Sub New()
        MyBase.New()

        'Assign Values To the Variables
        WaterText = "Default Watermark"
        WaterColor = Color.Gray
        WaterBrush = New SolidBrush(WaterColor)

        CreateWatermark()

        AddHandler TextChanged, AddressOf ChangeText
    End Sub

    Private Sub CreateWatermark()
        WaterContainer = New Panel
        Me.Controls.Add(WaterContainer)
        AddHandler WaterContainer.Click, AddressOf Clicked
        AddHandler WaterContainer.Paint, AddressOf Painted
    End Sub

    Private Sub RemoveWatermark()
        Me.Controls.Remove(WaterContainer)
    End Sub

    Private Sub ChangeText(ByVal sender As Object, ByVal e As EventArgs)
        If Me.TextLength <= 0 Then
            CreateWatermark()
        Else 'If Me.TextLength > 0 Then
            RemoveWatermark()
        End If
    End Sub

    Private Sub Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Me.Focus()
    End Sub

    Private Sub Painted(ByVal sender As Object, ByVal e As PaintEventArgs)
        WaterContainer.Location = New Point(2, 0)
        WaterContainer.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        WaterContainer.Height = Me.Height
        WaterContainer.Width = Me.Width

        Dim Graphic As Graphics = e.Graphics
        Graphic.DrawString(WaterText, If(WaterFont, Me.Font), WaterBrush, New PointF(-2.0!, 1.0!))
    End Sub

    Protected Overrides Sub OnInvalidated(ByVal e As System.Windows.Forms.InvalidateEventArgs)
        MyBase.OnInvalidated(e)
        WaterContainer.Invalidate()
    End Sub

End Class
