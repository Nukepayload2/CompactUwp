Imports CompactUwp.Services
Imports CompactUwp.ViewModels
Imports Microsoft.Toolkit.Uwp.UI.Controls

Namespace Views
    Partial Public NotInheritable Class ManageTasksPage
        Inherits Page

        ReadOnly Property ViewModel As New ManageTasksViewModel

        Dim _lastState As MasterDetailsViewState?
        Private Sub MasterDetailsViewControl_ViewStateChanged(sender As Object, e As MasterDetailsViewState) Handles MasterDetailsViewControl.ViewStateChanged
            If _lastState.HasValue Then
                If _lastState.Value = MasterDetailsViewState.Details AndAlso e = MasterDetailsViewState.Master Then
                    NavigationService.RepeatPageInNavStack()
                End If
            End If
            _lastState = e
        End Sub
    End Class
End Namespace
