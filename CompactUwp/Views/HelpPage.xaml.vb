Imports CompactUwp.ViewModels

Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls

Namespace Views
    Public NotInheritable Partial Class HelpPage
        Inherits Page
            property ViewModel as HelpViewModel = New HelpViewModel
        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf HelpPage_Loaded
        End Sub

        Private Async Sub HelpPage_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
