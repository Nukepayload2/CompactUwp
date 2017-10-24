Imports CompactUwp.Models

Namespace Commands

    Public Class ResumeTaskCommand
        Implements ICommand

        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            ' TODO: 取消选中的任务
        End Sub

        WithEvents Model As TaskItem

        Private Sub Model_PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Handles Model.PropertyChanged
            If e.PropertyName = NameOf(TaskItem.Status) OrElse e.PropertyName = NameOf(TaskItem.IsPaused) Then
                RaiseEvent CanExecuteChanged(Me, e)
            End If
        End Sub

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            If parameter Is Nothing Then
                Return False
            End If
            Dim param = DirectCast(parameter, TaskItem)
            Model = param
            Return param.IsPaused
        End Function

    End Class

End Namespace
