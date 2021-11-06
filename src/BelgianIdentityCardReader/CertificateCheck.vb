Imports System.Runtime.InteropServices

Namespace BelgianIdentityCardReader

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)> _
    Public Structure CertificateCheck
#Region "Member Fields"
        Private mPolicy As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_CERT_NUMBER * 2324, ArraySubType:=UnmanagedType.U1)> _
        Private mCertificates() As Byte
        Private mLength As Integer
        Private mSignatureCheck As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6, ArraySubType:=UnmanagedType.U1)> _
        Private mRFU() As Byte
#End Region
    End Structure

End Namespace