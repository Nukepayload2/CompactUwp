Imports CompactUwp.Helpers
Imports CompactUwp.Models

Namespace ViewModels
    Public Class ManageTasksViewModel
        Inherits Observable

        Private _selected As TaskItem

        Public Property Selected As TaskItem
            Get
                Return _selected
            End Get
            Set
                [Set](_selected, Value)
            End Set
        End Property

        Public ReadOnly Property TaskItems As New ObservableCollection(Of TaskItem) From {
            New TaskItem With {
                .Path = "C:\Program Files (x86)\Origin Games\Command and Conquer Red Alert 3",
                .ShortName = "Command and Conquer Red Alert 3",
                .Progress = 0.45,
                .Status = TaskStatus.Running,
                .TotalSizeInMB = 6875,
                .TotalSpaceInMB = 5310
            },
            New TaskItem With {
                .Path = "C:\Program Files (x86)\Steam",
                .ShortName = "Steam",
                .Progress = 0.0,
                .Status = TaskStatus.WaitingToRun,
                .TotalSizeInMB = 6875
            }
        }

    End Class
End Namespace
