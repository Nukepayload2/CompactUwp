﻿Imports CompactUwp.ViewModels

Namespace Views
    Public NotInheritable Partial Class ShellPage
      Inherits Page

        Public ReadOnly Property ViewModel As New ShellViewModel

        Public Sub New()
            Me.InitializeComponent()
            DataContext = ViewModel
            ViewModel.Initialize(shellFrame)
        End Sub

        Private Sub NavigationMenu_SelectionChanged(sender As NavigationView, args As NavigationViewSelectionChangedEventArgs) Handles NavigationMenu.SelectionChanged
            Dim cmd As ICommand = ViewModel.ItemSelectedCommand
            Dim selected As Object = If(args.IsSettingsSelected, ViewModel.SecondaryItems.First, args.SelectedItem)
            If cmd.CanExecute(selected) Then
                cmd.Execute(selected)
            End If
        End Sub
    End Class
End Namespace
