Imports CompactUwp.Services
Imports CompactUwp.ViewModels

Namespace Views
    Partial Public NotInheritable Class ShellPage
        Inherits Page

        Public ReadOnly Property ViewModel As New ShellViewModel

        Public Sub New()
            Me.InitializeComponent()
            DataContext = ViewModel
            ViewModel.Initialize(shellFrame, NavigationMenu)
            NavigationMenu.SelectedItem = ViewModel.PrimaryItems.First
        End Sub

        Private Sub NavigationMenu_SelectionChanged(sender As NavigationView, args As NavigationViewSelectionChangedEventArgs) Handles NavigationMenu.SelectionChanged
            If ShellViewModel.SuppressPageNavigation Then
                Return
            End If
            Dim cmd As ICommand = ViewModel.ItemSelectedCommand
            Dim selected As Object = If(args.IsSettingsSelected, ViewModel.SecondaryItems.First, args.SelectedItem)
            If cmd.CanExecute(selected) Then
                cmd.Execute(selected)
            End If
        End Sub

        Private Sub ShellPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            TitleBarService.SetTitleBarHeight()
        End Sub
    End Class
End Namespace
