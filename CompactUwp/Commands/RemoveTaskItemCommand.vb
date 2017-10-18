Namespace Commands

    Public Class RemoveTaskItemCommand
        Implements ICommand

        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            Throw New NotImplementedException()
        End Sub

        Dim _IsEnabled As Boolean
        Public Property IsEnabled As Boolean
            Get
                Return _IsEnabled
            End Get
            Set
                If Not _IsEnabled.Equals(Value) Then
                    _IsEnabled = Value
                    RaiseEvent CanExecuteChanged(Me, New PropertyChangedEventArgs(NameOf(IsEnabled)))
                End If
            End Set
        End Property

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return IsEnabled
        End Function
    End Class

End Namespace
