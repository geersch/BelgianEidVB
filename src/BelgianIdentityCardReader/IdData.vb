Imports System.Runtime.InteropServices

Namespace BelgianIdentityCardReader

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure IdData
#Region "Member Fields"
        <MarshalAs(UnmanagedType.I2)> _
        Private mVersion As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_CARD_NUMBER_LEN + 1)> _
        Private mCardNumber As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_CHIP_NUMBER_LEN + 1)> _
        Private mChipNumber As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_DATE_BEGIN_LEN + 1)> _
        Private mValidityDateBegin As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_DATE_END_LEN + 1)> _
        Private mValidityDateEnd As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_DELIVERY_MUNICIPALITY_LEN + 1)> _
        Private mMunicipality As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_NATIONAL_NUMBER_LEN + 1)> _
        Private mNationalNumber As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_NAME_LEN + 1)> _
        Private mName As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_FIRST_NAME1_LEN + 1)> _
        Private mFirstName1 As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_FIRST_NAME2_LEN + 1)> _
        Private mFirstName2 As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_FIRST_NAME3_LEN + 1)> _
        Private mFirstName3 As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_NATIONALITY_LEN + 1)> _
        Private mNationality As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_BIRTHPLACE_LEN + 1)> _
        Private mBirthLocation As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_BIRTHDATE_LEN + 1)> _
        Private mBirthdate As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_SEX_LEN + 1)> _
        Private mSex As Char()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_NOBLE_CONDITION_LEN + 1)> _
        Private mNobleCondition As Byte()
        <MarshalAs(UnmanagedType.I4)> _
        Private mDocumentType As Integer
        <MarshalAs(UnmanagedType.Bool)> _
        Private mWhiteCane As Boolean
        <MarshalAs(UnmanagedType.Bool)> _
        Private mYellowCane As Boolean
        <MarshalAs(UnmanagedType.Bool)> _
        Private mExtendedMinority As Boolean
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_HASH_PICTURE_LEN, ArraySubType:=UnmanagedType.U1)> _
        Private mHashPhoto As Byte()
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

        Public ReadOnly Property CardNumber() As String
            Get
                Return Me.mCardNumber
            End Get
        End Property

        Public ReadOnly Property ChipNumber() As String
            Get
                Return Me.mChipNumber
            End Get
        End Property

        Public ReadOnly Property ValidityDateBegin() As Date
            Get
                Dim aDate As String = CType(Me.mValidityDateBegin, String)
                Dim year As String = aDate.ToString.Substring(0, 4)
                Dim month As String = aDate.ToString.Substring(4, 2)
                Dim day As String = aDate.ToString.Substring(6, 2)
                Dim result As Date
                If (Date.TryParse(year & "/" & month & "/" & day, result)) Then
                    Return result
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property ValidityDateEnd() As Date
            Get
                Dim aDate As String = CType(Me.mValidityDateEnd, String)
                Dim year As String = aDate.ToString.Substring(0, 4)
                Dim month As String = aDate.ToString.Substring(4, 2)
                Dim day As String = aDate.ToString.Substring(6, 2)
                Dim result As Date
                If (Date.TryParse(year & "/" & month & "/" & day, result)) Then
                    Return result
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property Municipality() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mMunicipality)
            End Get
        End Property

        Public ReadOnly Property NationalNumber() As String
            Get
                Return Me.mNationalNumber
            End Get
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mName)
            End Get
        End Property

        Public ReadOnly Property FirstName1() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mFirstName1)
            End Get
        End Property

        Public ReadOnly Property FirstName2() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mFirstName2)
            End Get
        End Property

        Public ReadOnly Property FirstName3() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mFirstName3)
            End Get
        End Property

        Public ReadOnly Property Nationality() As String
            Get
                Return Me.mNationality
            End Get
        End Property

        Public ReadOnly Property BirthLocation() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mBirthLocation)
            End Get
        End Property

        Public ReadOnly Property BirthDate() As Date
            Get
                Dim aDate As String = CType(Me.mBirthdate, String)
                Dim year As String = aDate.ToString.Substring(0, 4)
                Dim month As String = aDate.ToString.Substring(4, 2)
                Dim day As String = aDate.ToString.Substring(6, 2)
                Dim result As Date
                If (Date.TryParse(year & "/" & month & "/" & day, result)) Then
                    Return result
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property Sex() As String
            Get
                Return Me.mSex
            End Get
        End Property

        Public ReadOnly Property NobleCondition() As String
            Get
                Return New System.Text.ASCIIEncoding().GetString(Me.mNobleCondition)
            End Get
        End Property

        Public ReadOnly Property DocumentType() As Integer
            Get
                Return Me.mDocumentType
            End Get
        End Property

        Public ReadOnly Property WhiteCane() As Boolean
            Get
                Return Me.mWhiteCane
            End Get
        End Property

        Public ReadOnly Property YellowCane() As Boolean
            Get
                Return Me.mYellowCane
            End Get
        End Property

        Public ReadOnly Property ExtendedMinority() As Boolean
            Get
                Return Me.mExtendedMinority
            End Get
        End Property

        Public Function HashPhoto() As Byte()
            Return Me.mHashPhoto
        End Function
#End Region

    End Structure

End Namespace