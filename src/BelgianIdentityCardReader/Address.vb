Imports System.Runtime.InteropServices

Namespace BelgianIdentityCardReader

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure Address
#Region "Member fields"
        <MarshalAs(UnmanagedType.I2)> _
        Private mVersion As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_STREET_LEN + 1)> _
        Private mStreet As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_STREET_NR + 1)> _
        Private mStreetNumber As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_STREET_BOX_NR + 1)> _
        Private mBoxNumber As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_ZIP_LEN + 1)> _
        Private mZip As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_MUNICIPALITY_LEN + 1)> _
        Private mMunicipality As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_COUNTRY_LEN + 1)> _
        Private mCountry As Char()
        'Reserved for future use
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6, ArraySubType:=UnmanagedType.U1)> _
        Private mRFU As Byte()
#End Region

#Region "Properties"
        Public ReadOnly Property Version() As Short
            Get
                Return Me.mVersion
            End Get
        End Property

        Public ReadOnly Property Street() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mStreet)
            End Get
        End Property

        Public ReadOnly Property StreetNumber() As String
            Get
                Return Me.mStreetNumber
            End Get
        End Property

        Public ReadOnly Property BoxNumber() As String
            Get
                Return Me.mBoxNumber
            End Get
        End Property

        Public ReadOnly Property Zip() As String
            Get
                Return Me.mZip
            End Get
        End Property

        Public ReadOnly Property Municipality() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mMunicipality)
            End Get
        End Property

        Public ReadOnly Property Country() As String
            Get
                Return Me.mCountry
            End Get
        End Property
#End Region

    End Structure

End Namespace