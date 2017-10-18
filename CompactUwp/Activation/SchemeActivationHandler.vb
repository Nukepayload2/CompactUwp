Imports System.Threading.Tasks

Imports CompactUwp.Services
Imports CompactUwp.Views

Imports Windows.ApplicationModel.Activation

Namespace Activation
    ' TODO WTS: Open package.appxmanifest and change the declaration for the scheme (from the default of 'wtsapp') to what you want for your app.
    ' More details about this functionality can be found at https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/features/uri-scheme.md
    ' TODO WTS: Change the image in Assets/Logo.png to one for display if the OS asks the user which app to launch.
    Friend Class SchemeActivationHandler
        Inherits ActivationHandler(Of ProtocolActivatedEventArgs)
        ' By default, this handler expects URIs of the format 'wtsapp:sample?secret={value}'
        Protected Overrides Async Function HandleInternalAsync(args As ProtocolActivatedEventArgs) As Task
            If args.Uri.AbsolutePath.ToLowerInvariant.Equals("sample") Then
                Dim secret = "<<I-HAVE-NO-SECRETS>>"

                Try
                    If args.Uri.Query IsNot Nothing Then
                        ' The following will extract the secret value and pass it to the page. Alternatively, you could pass all or some of the Uri.
                        Dim decoder As New Windows.Foundation.WwwFormUrlDecoder(args.Uri.Query)

                        secret = decoder.GetFirstValueByName("secret")
                    End If
                    ' NullReferenceException if the URI doesn't contain a query
                    ' ArgumentException if the query doesn't contain a param called 'secret'
                Catch ex As Exception
                End Try

                ' It's also possible to have logic here to navigate to different pages. e.g. if you have logic based on the URI used to launch
                NavigationService.Navigate(GetType(Views.UriSchemeExamplePage), secret)
            ElseIf args.PreviousExecutionState <> ApplicationExecutionState.Running Then
                ' If the app isn't running and not navigating to a specific page based on the URI, navigate to the home page
                NavigationService.Navigate(GetType(Views.MainPage))
            End If

            Await Task.CompletedTask
        End Function
        Protected Overrides Function CanHandleInternal(args As ProtocolActivatedEventArgs) As Boolean
            ' If your app has multiple handlers of ProtocolActivationEventArgs
            ' use this method to determine which to use. (possibly checking args.Uri.Scheme)
            Return True
        End Function
    End Class
End Namespace
