Namespace Helpers

    Public Class TaskStatusToTextConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
            Dim tskStatus = DirectCast(value, TaskStatus)
            Select Case tskStatus
                Case TaskStatus.Canceled
                    Return "已取消"
                Case TaskStatus.Created
                    Return "已创建, 尚未列入执行队列"
                Case TaskStatus.Faulted
                    Return "错误"
                Case TaskStatus.RanToCompletion
                    Return "已完成"
                Case TaskStatus.Running
                    Return "运行中"
                Case TaskStatus.WaitingForActivation
                    Return "已经加入逻辑执行队列"
                Case TaskStatus.WaitingForChildrenToComplete
                    Return "等待其它任务先完成"
                Case TaskStatus.WaitingToRun
                    Return "等待中"
                Case Else
                    Return String.Empty
            End Select
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
