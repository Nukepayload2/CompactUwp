Imports CompactUwp.Helpers
Imports CompactUwp.Models
Imports CompactUwp.Services

Imports Microsoft.Toolkit.Uwp.UI.Controls

Namespace ViewModels
    Public Class HelpViewModel
        Inherits Observable

        Private _selected As HelpItem

        Public Property Selected As HelpItem
            Get
                Return _selected
            End Get
            Set
                [Set](_selected, Value)
            End Set
        End Property

        Public ReadOnly Property HelpItems As New ObservableCollection(Of HelpItem)

        Public Async Function LoadDataAsync(viewState As MasterDetailsViewState) As Task
            If HelpItems.Count > 0 Then
                Return
            End If

            HelpItems.Clear()

            Dim data = Await GetHelpDataAsync()

            For Each item In data
                HelpItems.Add(item)
            Next

            If viewState = MasterDetailsViewState.Both Then
                Selected = HelpItems.First()
            End If
        End Function
    End Class
End Namespace
