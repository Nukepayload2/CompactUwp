Imports CompactUwp.Services
Imports CompactUwp.ViewModels
Imports Microsoft.Toolkit.Uwp.UI.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls

Namespace Views
    Partial Public NotInheritable Class HelpPage
        Inherits Page
        ReadOnly Property ViewModel As New HelpViewModel

        Private Async Sub HelpPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub

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
