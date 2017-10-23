Namespace Models

    Public Class HelpItem
        Implements INotifyPropertyChanged

        Public Property Title As String

        Public Property FileName As String

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

        Dim _Loaded As Boolean
        Public Property Loaded As Boolean
            Get
                Return _Loaded
            End Get
            Set(value As Boolean)
                _Loaded = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Loaded)))
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class

End Namespace
