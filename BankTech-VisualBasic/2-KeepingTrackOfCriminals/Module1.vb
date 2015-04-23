Module Module1

    Sub Main()

        Dim serialNumber = ""
        While serialNumber = ""
            Console.WriteLine("Please input the serial number to print:")
            serialNumber = Console.ReadLine()
        End While


        Dim timesToPrint = 0
        While timesToPrint = 0
            Console.WriteLine("Please enter the number of times to print {0}:", serialNumber)
            Integer.TryParse(Console.ReadLine(), timesToPrint)
            If timesToPrint = 0 Then Console.WriteLine("That was an invalid number. Please try again.")
        End While

        'Print out the results!
        For i As Integer = 1 To timesToPrint
            Console.WriteLine(vbTab + serialNumber)
        Next

        Console.WriteLine("DONE! Printed {0} {1} times", serialNumber, timesToPrint)
        Console.ReadLine()

    End Sub

End Module
