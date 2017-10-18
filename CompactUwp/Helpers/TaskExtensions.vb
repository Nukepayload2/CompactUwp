﻿Imports System.Threading.Tasks

Namespace Helpers
    Public Module TaskExtensions
 
        <System.Runtime.CompilerServices.Extension>
        Public Sub FireAndForget(task As Task)
            ' This method allows you to call an async method with awaiting it.
            ' Use it when you don't want or need to wait for the task to complete.
        End Sub
    End Module
End Namespace
