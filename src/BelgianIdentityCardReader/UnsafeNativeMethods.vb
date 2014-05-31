Imports System.Runtime.InteropServices

Namespace BelgianIdentityCardReader

#Region "Kernel32 Enumerations"
    <FlagsAttribute()> _
    Public Enum MemoryAllocations As Integer
        'None = Fixed
        None = 0
        Movable = 2
        ZeroInit = &H40
        FixedZeroInit = (None + ZeroInit)
    End Enum
#End Region

    Partial Friend NotInheritable Class UnsafeNativeMethods

#Region "BEIDLib.DLL Version Constants"

        'Changes each time the interface is modified
        Private Const INTERFACE_VERSION As Short = 2
        'Stays until incompatible changes in existing functions. 
        'Typically, this is not updated when functions are added.
        Private Const INTERFACE_COMAT_VERSION As Short = 1

#End Region

#Region "Hidden constructor"
        'Static holder types should not have constructors. 
        'Hide the default constructor by making it 
        'private.
        Private Sub New()
        End Sub
#End Region

#Region "High Level API"

        Friend Shared Function Connect(ByVal readerName As String, ByVal ocsp As PolicyOption, _
                                       ByVal crl As PolicyOption, ByRef cardHandle As IntPtr) As Status
            Return InitEx(readerName, ocsp, crl, cardHandle, INTERFACE_VERSION, INTERFACE_COMAT_VERSION)
        End Function

        <DllImport(GlobalConstants.EIdLibDll, EntryPoint:="BEID_InitEx", CharSet:=CharSet.Ansi, _
                   BestFitMapping:=False, ThrowOnUnmappableChar:=True, SetLastError:=True)> _
        Private Shared Function InitEx(ByVal readerName As String, _
                                       ByVal ocsp As PolicyOption, ByVal crl As PolicyOption, _
                                       ByRef cardHandle As IntPtr, ByVal interfaceVersion As Integer, _
                                       ByVal interfaceCompVersion As Integer) As Status
        End Function

        <DllImport(GlobalConstants.EIdLibDll, EntryPoint:="BEID_Exit", SetLastError:=True)> _
        Friend Shared Function Disconnect() As Status
        End Function

        <DllImport(GlobalConstants.EIdLibDll, EntryPoint:="BEID_GetID", SetLastError:=True)> _
        Friend Shared Function GetId(ByRef data As IdData, ByRef CertificateCheck As CertificateCheck) As Status
        End Function

        <DllImport(GlobalConstants.EIdLibDll, EntryPoint:="BEID_GetAddress", CharSet:=CharSet.Ansi)> _
        Friend Shared Function GetAddress(ByRef Address As Address, ByRef CertificateCheck As CertificateCheck) As Status
        End Function

        <DllImport(GlobalConstants.EIdLibDll, EntryPoint:="BEID_GetPicture", SetLastError:=True)> _
        Friend Shared Function GetPicture(ByRef picture As Bytes, ByRef check As CertificateCheck) As Status
        End Function

#End Region

#Region "Kernel32.DLL Imports"
        <DllImport(GlobalConstants.Kernel32Dll, EntryPoint:="LocalAlloc", SetLastError:=True)> _
        Friend Shared Function LocalAllocate(ByVal flags As MemoryAllocations, _
                                             ByVal bytes As Integer) As IntPtr
        End Function

        <DllImport(GlobalConstants.Kernel32Dll, EntryPoint:="LocalFree", SetLastError:=True)> _
        Friend Shared Function LocalFree(ByVal handle As IntPtr) As IntPtr
        End Function
#End Region

    End Class

End Namespace