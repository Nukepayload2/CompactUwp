Imports CompactUwp.ViewModels
Imports Windows.ApplicationModel.Core

Namespace Services

    Public Module TitleBarService

        Sub New()
            Dim titleBar = CoreApplication.GetCurrentView.TitleBar
            AddHandler titleBar.LayoutMetricsChanged,
                Sub(s, e)
                    ShellViewModel.Instance.TitleMargin = New Thickness(12 + s.SystemOverlayLeftInset, 8, 8, 8)
                End Sub
            AddHandler titleBar.IsVisibleChanged,
                Sub(s, e)
                    ShellViewModel.Instance.TitleBarVisibility = If(s.IsVisible, Visibility.Visible, Visibility.Collapsed)
                End Sub
        End Sub

        Sub SetTitleBarHeight()
            ' 不需要特殊处理。用到这个类型，执行 Sub New 即可。
        End Sub

    End Module

End Namespace
