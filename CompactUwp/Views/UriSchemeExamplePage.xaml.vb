﻿Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Imports CompactUwp.ViewModels

Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Navigation

Namespace Views
    ' TODO WTS: This page exists purely as an example of how to launch a specific page in response to a protocol launch and pass it a value. It is expected that you will delete this page once you have changed the handling of a protocol launch to meet your needs and redirected to another of your pages.
    Partial Public NotInheritable Class UriSchemeExamplePage
        Inherits Page
        Public ReadOnly Property ViewModel As New UriSchemeExampleViewModel

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)

            ' Capture the passed in value and assign it to a property that's displayed on the view
            ViewModel.Secret = e.Parameter.ToString
        End Sub
    End Class
End Namespace
