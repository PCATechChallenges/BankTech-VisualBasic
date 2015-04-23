Imports System.IO

Module Module1

    Sub Main()

        Dim phoneList = "PhoneList.txt"
        Dim numbers = File.ReadLines(phoneList)
        Dim spamCount = 0
        Dim goodCount = 0

        For Each phoneNumber As String In numbers

            Dim isSpam = phoneNumber.Contains("SPAM")

            If isSpam Then
                spamCount += 1
            Else
                goodCount += 1
            End If

            Console.WriteLine(If(isSpam, "SPAM", "OK"))

        Next

        Console.WriteLine(vbCrLf + "{2} numbers processed" + vbCrLf + "{0} SPAM numbers found" + vbCrLf + "{1} numbers were OK", spamCount, goodCount, spamCount + goodCount)
        Console.WriteLine("Press any key to exit...")
        Console.ReadLine()

    End Sub

End Module
