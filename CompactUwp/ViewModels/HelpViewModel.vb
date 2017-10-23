Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Threading.Tasks

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

        Public Sub New()
        End Sub

        Public Async Function LoadDataAsync(viewState As MasterDetailsViewState) As Task
            HelpItems.Clear()

            Dim data = Await HelpItemsDataService.GetSampleModelDataAsync()

            For Each item As HelpItem In data
                HelpItems.Add(item)
            Next

            If viewState = MasterDetailsViewState.Both Then
                Selected = HelpItems.First()
            End If
        End Function
    End Class
End Namespace
