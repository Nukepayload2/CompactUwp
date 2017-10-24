Imports CompactUwp.Models

Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls

Namespace Views
    Public NotInheritable Partial Class ManageTasksDetailControl
        Inherits UserControl

        Public Property TaskItem As TaskItem
            Get
                Return GetValue(TaskItemProperty)
            End Get
            Set
                SetValue(TaskItemProperty, Value)
            End Set
        End Property
        Public Shared ReadOnly TaskItemProperty As DependencyProperty =
                               DependencyProperty.Register(NameOf(TaskItem),
                               GetType(TaskItem), GetType(ManageTasksDetailControl),
                               New PropertyMetadata(Nothing))

        Private Shared Sub OnMasterMenuItemPropertyChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim control = TryCast(d, ManageTasksDetailControl)
            control.ForegroundElement.ChangeView(0, 0, 1)
        End Sub
    End Class
End Namespace
