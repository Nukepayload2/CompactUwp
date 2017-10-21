Imports CompactUwp.Helpers
Imports CompactUwp.Models
Imports CompactUwp.Views

Namespace ViewModels
    Public Class MainViewModel
        Inherits Observable

        Public ReadOnly Property StatusCommands As New List(Of MainCommandItem) From {
            New MainCommandItem("压缩", Symbol.ClosePane, GetType(CompactPage), $"至上次打开本软件以来，已经节省了 {GetTotalSpaceFreed()} 空间。"),
            New MainCommandItem("解压", Symbol.OpenPane, GetType(RevertCompactPage), $"至上次打开本软件以来，还原了 {GetTotalRevertCount()} 次压缩。"),
            New MainCommandItem("任务", Symbol.List, GetType(ManageTasksPage), $"当前{GetRunningTaskCountDescription()}任务在执行。"),
            New MainCommandItem("帮助", Symbol.Library, GetType(HelpPage), "让您快速了解关于本软件和 NTFS 压缩功能的知识。")
        }

        Private Function GetRunningTaskCountDescription() As String
            ' TODO: 调用真正的任务 API
            Return "没有"
        End Function

        Private Function GetTotalRevertCount() As Integer
            ' TODO: 调用真正的统计 API
            Return 1
        End Function

        Private Function GetTotalSpaceFreed() As String
            ' TODO: 调用真正的统计 API
            Return "5.8 GB"
        End Function
    End Class
End Namespace
