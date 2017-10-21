Namespace Models

    Public Class MainCommandItem
        Implements INotifyPropertyChanged

        Public Sub New(title As String, icon As Symbol, pageType As Type, text As String)
            Me.Title = title
            Me.Icon = icon
            Me.PageType = pageType
            Me.Text = text
        End Sub

        Public ReadOnly Property Title As String
        Public ReadOnly Property Icon As Symbol
        Public ReadOnly Property PageType As Type

        Dim _Text As String
        Public Property Text As String
            Get
                Return _Text
            End Get
            Set(value As String)
                _Text = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Text)))
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class

End Namespace
