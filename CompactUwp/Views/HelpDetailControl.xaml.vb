Imports CompactUwp.Models

Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls

Namespace Views
    Partial Public NotInheritable Class HelpDetailControl
        Inherits UserControl
        Public Property MasterMenuItem As HelpItem
            Get
                Return GetValue(MasterMenuItemProperty)
            End Get
            Set
                SetValue(MasterMenuItemProperty, Value)
            End Set
        End Property
        Public Shared ReadOnly MasterMenuItemProperty As DependencyProperty =
                               DependencyProperty.Register(NameOf(MasterMenuItem),
                               GetType(HelpItem), GetType(HelpDetailControl),
                               New PropertyMetadata(Nothing))

    End Class
End Namespace
