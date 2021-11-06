Imports System.Runtime.InteropServices

Namespace BelgianIdentityCardReader

    'OCSP and CRL Policy option
    Public Enum PolicyOption
        'CRL Policy is not used
        None = 0
        'CRL Policy is optional
        Elective = 1
        'CRL Policy is mandatory
        Mandatory = 2
    End Enum

End Namespace