Imports System.Runtime.InteropServices

Namespace BelgianIdentityCardReader

    Public Enum ErrorCode
        None = 0
        System = 1
        PCSC = 2
        Card = 3
        BadParameter = 4
        Internal = 5
        InvalidHandle = 6
        InsufficientBuffer = 7
        CommunicationError = 8
        Timeout = 9
        UnknownCard = 10
        KeypadCanceled = 11
        KeypadTimeout = 12
        KeypadPinMismatch = 13
        KeypadMessageTooLong = 14
        InvalidPinLength = 15
        Verification = 16
        NotInitialized = 17
        Unknown = 18
        UnsupportedFunction = 19
        IncorrectVersion = 20
        InvalidRootCertificate = 21
        Validation = 22
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Status
#Region "Member Fields"
        'General return code
        <MarshalAs(UnmanagedType.I4)> _
        Private mGeneral As ErrorCode
        'System error
        <MarshalAs(UnmanagedType.I4)> _
        Private mSystem As Integer
        'PC/SC error
        <MarshalAs(UnmanagedType.I4)> _
        Private mPCSC As Integer
        'Card status Word
        <MarshalAs(UnmanagedType.I2)> _
        Private mCardSW As Short
        'Reserved for future use
        <MarshalAs(UnmanagedType.I2)> _
        Private mRFU1 As Short
        <MarshalAs(UnmanagedType.I2)> _
        Private mRFU2 As Short
        <MarshalAs(UnmanagedType.I2)> _
        Private mRFU3 As Short
#End Region

#Region "Properties"
        Public ReadOnly Property General() As ErrorCode
            Get
                Return Me.mGeneral
            End Get
        End Property

        Public ReadOnly Property System() As Integer
            Get
                Return Me.mSystem
            End Get
        End Property

        Public ReadOnly Property PCSC() As Integer
            Get
                Return Me.mPCSC
            End Get
        End Property

        Public ReadOnly Property CardSW() As Short
            Get
                Return Me.mCardSW
            End Get
        End Property
#End Region
    End Structure

End Namespace