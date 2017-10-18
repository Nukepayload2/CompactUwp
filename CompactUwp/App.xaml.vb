Imports CompactUwp.Services

Imports Windows.ApplicationModel
Imports Windows.ApplicationModel.Activation
Imports Windows.UI.Xaml

NotInheritable Partial Class App
    Inherits Application
    Private _activationService As Lazy(Of ActivationService)
    Private ReadOnly Property ActivationService() As ActivationService
        Get
            Return _activationService.Value
        End Get
    End Property

    Public Sub New()
        InitializeComponent()

        AddHandler EnteredBackground, AddressOf App_EnteredBackground

        ' Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
        _activationService = New Lazy(Of ActivationService)(AddressOf CreateActivationService)
    End Sub

    Protected Overrides Async Sub OnLaunched(args As LaunchActivatedEventArgs)
        If Not args.PrelaunchActivated Then
            Await ActivationService.ActivateAsync(args)
        End If
    End Sub

    Protected Overrides Async Sub OnActivated(args As IActivatedEventArgs)
        Await ActivationService.ActivateAsync(args)
    End Sub
    Private Function CreateActivationService() As ActivationService
        Return New ActivationService(Me, GetType(Views.MainPage), New Views.ShellPage())
    End Function

    Private Async Sub App_EnteredBackground(sender As Object, e As EnteredBackgroundEventArgs)
        Dim deferral = e.GetDeferral()
        Await Helpers.Singleton(Of SuspendAndResumeService).Instance.SaveStateAsync()
        deferral.Complete()
    End Sub

    Protected Overrides Async Sub OnBackgroundActivated(args As BackgroundActivatedEventArgs)
        Await ActivationService.ActivateAsync(args)
    End Sub
End Class
