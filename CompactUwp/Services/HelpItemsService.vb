Imports CompactUwp.Models
Imports Windows.Storage

Namespace Services
    ' This module holds sample data used by some generated pages to show how they can be used.
    Public Module HelpItemsService
        Private Const HelpPrefix As String = "ms-appx:///Data/"
        Private Const HelpIndex As String = HelpPrefix + "HelpIndex.json"

        Public Async Function GetHelpDataAsync() As Task(Of HelpItem())
            Dim indexJson = Await StorageFile.GetFileFromApplicationUriAsync(New Uri(HelpIndex))
            Dim json$ = Await FileIO.ReadTextAsync(indexJson)
            Dim helpItems = Await Helpers.ToObjectAsync(Of HelpItem())(json)
            For Each hlp In helpItems
                Dim mdFile = Await StorageFile.GetFileFromApplicationUriAsync(New Uri(HelpPrefix + hlp.FileName))
                Dim mdContent = Await FileIO.ReadTextAsync(mdFile)
                hlp.Text = mdContent
            Next
            Return helpItems
        End Function
    End Module
End Namespace
