Imports CompactUwp.ViewModels
Imports Windows.ApplicationModel.Core
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media.Animation
Imports Windows.UI.Xaml.Navigation

Namespace Services
    Public Module NavigationService

        Public Event Navigated As NavigatedEventHandler

        Public Event NavigationFailed As NavigationFailedEventHandler

        Private _frame As Frame
        Private _navView As NavigationView

        Public Property NavigationView As NavigationView
            Get
                Return _navView
            End Get
            Set(value As NavigationView)
                _navView = value
            End Set
        End Property

        Public Property Frame As Frame
            Get
                If _frame Is Nothing Then
                    _frame = TryCast(Window.Current.Content, Frame)
                    RegisterFrameEvents()
                End If

                Return _frame
            End Get
            Set
                UnregisterFrameEvents()
                _frame = Value
                RegisterFrameEvents()
            End Set
        End Property

        Public ReadOnly Property CanGoBack As Boolean
            Get
                Return Frame.CanGoBack
            End Get
        End Property

        Public ReadOnly Property PageTypeNavItem As New Dictionary(Of String, ShellNavigationItem)

        Private _pageStack As New Stack(Of String)

        Public Sub RepeatPageInNavStack()
            _pageStack.Push(_pageStack.Peek)
        End Sub

        Public Sub GoBack()
            Frame.GoBack()
            ShellViewModel.SuppressPageNavigation = True
            _pageStack.Pop()
            Dim pageBack As String = _pageStack.Peek
            Dim navSelected As ShellNavigationItem = PageTypeNavItem(pageBack)
            NavigationView.SelectedItem = navSelected
            If pageBack = "SettingsPage" Then
                ' TODO: 让 NavigationView 选中设置页面
            End If
            ShellViewModel.SuppressPageNavigation = False
        End Sub

        Public Function Navigate(pageType As Type, Optional ByVal parameter As Object = Nothing, Optional ByVal infoOverride As NavigationTransitionInfo = Nothing) As Boolean
            ' Don't open the same page multiple times
            If Frame.Content?.GetType IsNot pageType.GetType Then
                Return Frame.Navigate(pageType, parameter, infoOverride)
            Else
                Return False
            End If
        End Function

        Private Sub RegisterFrameEvents()
            If _frame IsNot Nothing Then
                AddHandler _frame.Navigated, AddressOf Frame_Navigated
                AddHandler _frame.NavigationFailed, AddressOf Frame_NavigationFailed
            End If
        End Sub

        Private Sub UnregisterFrameEvents()
            If _frame IsNot Nothing Then
                RemoveHandler _frame.Navigated, AddressOf Frame_Navigated
                RemoveHandler _frame.NavigationFailed, AddressOf Frame_NavigationFailed
            End If
        End Sub

        Private Sub Frame_NavigationFailed(sender As Object, e As NavigationFailedEventArgs)
            RaiseEvent NavigationFailed(sender, e)
        End Sub

        Sub New()
            AddHandler CoreApplication.GetCurrentView.TitleBar.LayoutMetricsChanged,
                Sub(s, e)
                    ShellViewModel.Instance.TitleMargin = New Thickness(12 + s.SystemOverlayLeftInset, 8, 8, 8)
                End Sub
        End Sub

        Private Sub Frame_Navigated(sender As Object, e As NavigationEventArgs)
            RaiseEvent Navigated(sender, e)
            If e.NavigationMode <> NavigationMode.Back Then
                _pageStack.Push(e.SourcePageType.Name)
            End If
        End Sub

    End Module
End Namespace
