Imports CompactUwp.Helpers

Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media

Namespace ViewModels
    Public NotInheritable Class ShellNavigationItem
        Inherits Observable

        Public Property Label As String

        Public Property PageType As Type

        Public Property Symbol As Symbol

        Private Sub New(label As String, symbol As Symbol, pageType As Type)
            Me.New(label, pageType)
            Me.Symbol = symbol
        End Sub

        Private Sub New(label As String, pageType As Type)
            Me.Label = label
            Me.PageType = pageType
        End Sub

        Public Shared Function FromType(Of T As Page)(label As String, symbol As Symbol) As ShellNavigationItem
            Return New ShellNavigationItem(label, symbol, GetType(T))
        End Function

        Public Overrides Function ToString() As String
            Return Label
        End Function

    End Class
End Namespace
