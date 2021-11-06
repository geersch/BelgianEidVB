Imports System.Runtime.InteropServices

Namespace BelgianIdentityCardReader

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Bytes
#Region "Member Fields"
        Private mData As IntPtr
        Private mLength As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6, ArraySubType:=UnmanagedType.U1)> _
        Private mRFU As Byte()
#End Region

#Region "Methods"
        Public Sub New(ByVal length As Integer)
            'Allocate and return
            Me.mData = UnsafeNativeMethods.LocalAllocate(MemoryAllocations.FixedZeroInit, length)
            Me.mLength = length
            ReDim mRFU(6)
        End Sub

        Public Sub Dispose()
            UnsafeNativeMethods.LocalFree(Me.mData)
            Me.mData = IntPtr.Zero
            'Me.mData.Dispose()
            Me.mLength = 0
        End Sub
#End Region

#Region "Methods"
        'Marshal the data (IntPtr) to a proper array of bytes
        Public Function ToArray() As Byte()
            'Declare result
            Dim result As Byte() = Nothing
            'Check if zero
            If (Me.mData <> IntPtr.Zero) Then
                'Allocate
                ReDim result(Me.mLength)
                'Copy
                Marshal.Copy(Me.mData, result, 0, Convert.ToInt32(Me.mLength))
            End If
            'Return result
            Return result
        End Function
#End Region

#Region "Propeties"
        Public Property Data() As IntPtr
            Get
                Return Me.mData
            End Get
            Set(ByVal value As IntPtr)
                Me.mData = value
            End Set
        End Property

        Public Property Length() As Integer
            Get
                Return Me.mLength
            End Get
            Set(ByVal value As Integer)
                Me.mLength = value
            End Set
        End Property
#End Region
    End Structure

End Namespace