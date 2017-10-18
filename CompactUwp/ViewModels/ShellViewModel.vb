Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Windows.Input

Imports CompactUwp.Helpers
Imports CompactUwp.Services
Imports CompactUwp.Views

Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Navigation

Namespace ViewModels
    Public Class ShellViewModel
        Inherits Observable

        Private _lastSelectedItem As ShellNavigationItem

        Private _primaryItems As New ObservableCollection(Of ShellNavigationItem)()
        Public ReadOnly Property PrimaryItems As ObservableCollection(Of ShellNavigationItem)
            Get
                Return _primaryItems
            End Get
        End Property

        Private _secondaryItems As New ObservableCollection(Of ShellNavigationItem)()
        Public ReadOnly Property SecondaryItems As ObservableCollection(Of ShellNavigationItem)
            Get
                Return _secondaryItems
            End Get
        End Property

        Private _itemSelected As ICommand
        Public ReadOnly Property ItemSelectedCommand As ICommand
            Get
                If _itemSelected Is Nothing Then
                    _itemSelected = New RelayCommand(Of ShellNavigationItem)(AddressOf Navigate)
                End If

                Return _itemSelected
            End Get
        End Property

        Public Property LastSelectedItem As ShellNavigationItem
            Get
                Return _lastSelectedItem
            End Get
            Set(value As ShellNavigationItem)
                [Set](_lastSelectedItem, value)
            End Set
        End Property

        Public Sub Initialize(frame As Frame)
            NavigationService.Frame = frame
            AddHandler NavigationService.Frame.Navigated, AddressOf Frame_Navigated
            PopulateNavItems()
        End Sub

        Private Sub PopulateNavItems()
            _primaryItems.Clear()
            _secondaryItems.Clear()

            ' TODO WTS: Change the symbols for each item as appropriate for your app
            ' More on Segoe UI Symbol icons: https://docs.microsoft.com/windows/uwp/style/segoe-ui-symbol-font
            ' Or to use an IconElement instead of a Symbol see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/projectTypes/navigationpane.md
            ' Edit String/en-US/Resources.resw: Add a menu item title for each page
            _primaryItems.Add(ShellNavigationItem.FromType(Of MainPage)("Shell_Main".GetLocalized(), Symbol.Document))
            _primaryItems.Add(ShellNavigationItem.FromType(Of CompactPage)("Shell_Compact".GetLocalized(), Symbol.Document))
            _primaryItems.Add(ShellNavigationItem.FromType(Of RevertCompactPage)("Shell_RevertCompact".GetLocalized(), Symbol.Document))
            _primaryItems.Add(ShellNavigationItem.FromType(Of ManageTasksPage)("Shell_ManageTasks".GetLocalized(), Symbol.Document))
            _primaryItems.Add(ShellNavigationItem.FromType(Of HelpPage)("Shell_Help".GetLocalized(), Symbol.Document))
            _secondaryItems.Add(ShellNavigationItem.FromType(Of SettingsPage)("Shell_Settings".GetLocalized(), Symbol.Setting))
        End Sub

        Private Sub Frame_Navigated(sender As Object, e As NavigationEventArgs)
            Dim navigationItem As ShellNavigationItem = Nothing

            If PrimaryItems IsNot Nothing Then
                navigationItem = PrimaryItems.FirstOrDefault(Function(i As ShellNavigationItem) i.PageType.Equals(e.SourcePageType))
            End If

            If navigationItem Is Nothing AndAlso SecondaryItems IsNot Nothing Then
                navigationItem = SecondaryItems.FirstOrDefault(Function(i as ShellNavigationItem) i.PageType.Equals(e.SourcePageType))
            End If

            If navigationItem IsNot Nothing Then
                LastSelectedItem = navigationItem
            End If
        End Sub

        Private Sub Navigate(item As ShellNavigationItem)
            If item IsNot Nothing Then
                NavigationService.Navigate(item.PageType)
            End If
        End Sub

        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Namespace
