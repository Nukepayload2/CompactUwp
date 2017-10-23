Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Threading.Tasks

Imports CompactUwp.Models

Namespace Services
    ' This module holds sample data used by some generated pages to show how they can be used.
    ' TODO WTS: Delete this file once your app is using real data.
    Public Module HelpItemsService
        ' TODO WTS: Remove this once your MasterDetail pages are displaying real data
        Public Async Function GetSampleModelDataAsync() As Task(Of IEnumerable(Of SampleOrder))
            Await Task.CompletedTask

            Return AllOrders()
        End Function
    End Module
End Namespace
