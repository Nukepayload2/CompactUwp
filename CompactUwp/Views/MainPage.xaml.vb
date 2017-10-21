Imports CompactUwp.Models
Imports CompactUwp.Services
Imports CompactUwp.ViewModels

Namespace Views
    Partial Public NotInheritable Class MainPage
        Inherits Page
        Property ViewModel As New MainViewModel

        Private Sub GrdFeatures_ItemClick(sender As Object, e As ItemClickEventArgs) Handles GrdFeatures.ItemClick
            GrdFeatures.SelectedIndex = -1
            NavigationService.NavBarSelect(DirectCast(e.ClickedItem, MainCommandItem).PageType)
        End Sub
    End Class
End Namespace
