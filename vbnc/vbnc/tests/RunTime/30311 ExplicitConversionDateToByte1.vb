Module ExplicitConversionDateToByte1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Date
        Dim value2 As Byte
        Dim const2 As Byte

        value1 = #01/01/2000 12:34#
        value2 = CByte(value1)
        const2 = CByte(#01/01/2000 12:34#)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionDateToByte1")
            Return 1
        End If
    End Function
End Module
