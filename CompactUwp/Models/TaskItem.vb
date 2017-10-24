Imports CompactUwp.Commands

Namespace Models

    Public Class TaskItem
        Implements INotifyPropertyChanged

        Dim _ShortName As String
        Public Property ShortName As String
            Get
                Return _ShortName
            End Get
            Set(value As String)
                _ShortName = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ShortName)))
            End Set
        End Property

        Dim _Path As String
        Public Property Path As String
            Get
                Return _Path
            End Get
            Set(value As String)
                _Path = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Path)))
            End Set
        End Property

        Dim _Progress As Double
        Public Property Progress As Double
            Get
                Return _Progress
            End Get
            Set(value As Double)
                _Progress = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Progress)))
            End Set
        End Property

        Dim _Status As TaskStatus
        Public Property Status As TaskStatus
            Get
                Return _Status
            End Get
            Set(value As TaskStatus)
                If Not _Status = value Then
                    _Status = value
                    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Status)))
                End If
            End Set
        End Property

        Dim _TotalSizeInMB As Double?
        Public Property TotalSizeInMB As Double?
            Get
                Return _TotalSizeInMB
            End Get
            Set(value As Double?)
                _TotalSizeInMB = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(TotalSizeInMB)))
            End Set
        End Property

        Dim _TotalSpaceInMB As Double?
        Public Property TotalSpaceInMB As Double?
            Get
                Return _TotalSpaceInMB
            End Get
            Set(value As Double?)
                _TotalSpaceInMB = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(TotalSpaceInMB)))
            End Set
        End Property

        Dim _IsUnpack As Boolean
        Public Property IsUnpack As Boolean
            Get
                Return _IsUnpack
            End Get
            Set(value As Boolean)
                _IsUnpack = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(IsUnpack)))
            End Set
        End Property

        Dim _IsPaused As Boolean
        Public Property IsPaused As Boolean
            Get
                Return _IsPaused
            End Get
            Set(value As Boolean)
                _IsPaused = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(IsPaused)))
            End Set
        End Property

        Public ReadOnly Property CancelTaskCommand As New CancelTaskCommand
        Public ReadOnly Property PauseTaskCommand As New PauseTaskCommand
        Public ReadOnly Property ResumeTaskCommand As New ResumeTaskCommand

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class

End Namespace
