Imports CompactUwp.ViewModels

Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Navigation

Namespace Views
    Public NotInheritable Partial Class SettingsPage
        Inherits Page
            property ViewModel as SettingsViewModel = New SettingsViewModel
        ' TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            ViewModel.Initialize()
        End Sub
    End Class
End Namespace
