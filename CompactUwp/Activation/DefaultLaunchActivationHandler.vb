Imports System.Threading.Tasks

Imports CompactUwp.Helpers
Imports CompactUwp.Services

Imports Windows.ApplicationModel.Activation

Namespace Activation
    Friend Class DefaultLaunchActivationHandler
        Inherits ActivationHandler(Of LaunchActivatedEventArgs)
        Private ReadOnly _navElement As Type
    
        Public Sub New(navElement As Type)
            _navElement = navElement
        End Sub
    
        Protected Overrides Async Function HandleInternalAsync(args As LaunchActivatedEventArgs) As Task
            ' When the navigation stack isn't restored, navigate to the first page and configure
            ' the new page by passing required information in the navigation parameter
            NavigationService.Navigate(_navElement, args.Arguments)

            ' TODO WTS: This is a sample on how to show a toast notification.
            ' You can use this sample to create toast notifications where needed in your app.
            Singleton(Of ToastNotificationsService).Instance.ShowToastNotificationSample()
            Await Task.CompletedTask
        End Function

        Protected Overrides Function CanHandleInternal(args As LaunchActivatedEventArgs) As Boolean
            ' None of the ActivationHandlers has handled the app activation
            Return NavigationService.Frame.Content Is Nothing
        End Function
    End Class
End Namespace
