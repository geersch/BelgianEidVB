Imports System.Drawing
Imports System.IO

Namespace BelgianIdentityCardReader

    Public Class eIdReader
        Private mStatus As Status = Nothing
        Private mCardHandle As Integer

        Public Function Connect() As Boolean
            Me.mStatus = UnsafeNativeMethods.Connect("ACS ACR38U 0", _
                                                     PolicyOption.None, _
                                                     PolicyOption.None, _
                                                     Me.mCardHandle)

            Return (Me.mStatus.General = ErrorCode.None)
        End Function

        Public Function Disconnect() As Boolean
            Me.mStatus = UnsafeNativeMethods.Disconnect()
            Return (Me.mStatus.General = ErrorCode.None)
        End Function

        Public Function LoadIdData() As IdData
            Dim CertificateCheck As CertificateCheck = Nothing
            Dim result As IdData = Nothing
            Me.mStatus = UnsafeNativeMethods.GetId(result, CertificateCheck)
            Return result
        End Function

        Public Function LoadAddress() As Address
            Dim CertificateCheck As CertificateCheck = Nothing
            Dim result As Address = Nothing
            Me.mStatus = UnsafeNativeMethods.GetAddress(result, CertificateCheck)
            Return result
        End Function

        Public Function LoadPicture() As Bitmap
            Dim CertificateCheck As CertificateCheck = Nothing
            Dim bytes As Bytes = New Bytes(MAX_PICTURE_LEN)
            Try
                Me.mStatus = UnsafeNativeMethods.GetPicture(bytes, CertificateCheck)
                If (Me.mStatus.General = ErrorCode.None) Then
                    Dim ms As MemoryStream = New MemoryStream(bytes.ToArray())
                    Return Image.FromStream(ms)
                Else
                    Return Nothing
                End If
            Finally
                bytes.Dispose()
            End Try
        End Function

    End Class

End Namespace
