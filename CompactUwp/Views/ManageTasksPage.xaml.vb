Imports CompactUwp.ViewModels

Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls

Namespace Views
    Public NotInheritable Partial Class ManageTasksPage
        Inherits Page
            property ViewModel as ManageTasksViewModel = New ManageTasksViewModel
        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf ManageTasksPage_Loaded
        End Sub

        Private Async Sub ManageTasksPage_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
