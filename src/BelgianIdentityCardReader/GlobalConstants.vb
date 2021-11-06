Namespace BelgianIdentityCardReader

    'Static holder types should be NotInheritable
    Public NotInheritable Class GlobalConstants

#Region "Hidden constructor"
        'Static holder types should not have constructors. 
        'Hide the default constructor by making it 
        'private.
        Private Sub New()
        End Sub
#End Region

#Region "Dll constants"
        Public Const EIdLibDll As String = "BEIDLIB.DLL"
        Public Const Kernel32Dll As String = "KERNEL32.DLL"
#End Region
    End Class

End Namespace