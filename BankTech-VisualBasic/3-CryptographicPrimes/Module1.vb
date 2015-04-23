Imports System.Math

Module Module1

    Sub Main()

        ' Get the starting number
        Dim startNumber = 0
        While startNumber <= 0  ' Skip negative numbers
            Console.WriteLine("Please enter a valid whole number to start checking primes FROM")
            Integer.TryParse(Console.ReadLine(), startNumber)
        End While

        ' Get the end number
        Dim endNumber = 0
        While endNumber <= 0 Or endNumber <= startNumber    ' Skip negatives and anything less than the starting number
            Console.WriteLine("Please end a number to stop looking at primes:")
            Integer.TryParse(Console.ReadLine(), endNumber)
        End While

        ' Cycle through the given range and count how many primes there are
        Dim primeCounter = 0
        For i As Integer = startNumber To endNumber

            If Not IsPrime(i) Then Continue For
            Console.WriteLine(i)
            primeCounter += 1

        Next

        Console.WriteLine("There are {0} prime numbers between {1} and {2}", primeCounter, startNumber, endNumber)
        Console.Read()

    End Sub

    ''' <summary>
    ''' Takes an int and checks to see if it is a Prime number
    ''' </summary>
    ''' <param name="numberToCheck"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsPrime(ByVal numberToCheck As Integer) As Boolean

        ' 0 and 1 are NOT Prime: http://en.wikipedia.org/wiki/Prime_number
        If (numberToCheck < 2) Then Return False

        ' Any numbers divisible by 2 are automatically not prime, apart from the number 2
        ' Hey look, they all just happen to be EVEN NUMBERS!
        If (numberToCheck Mod 2 = 0) Then Return numberToCheck = 2 'DEV Note: Return value = someOtherValue returns a boolean depending on whether they are equal or not :)

        ' Only interested in odd numbers
        Dim sqrtOfNumber = Convert.ToInt32(Math.Sqrt(numberToCheck))
        For i As Integer = 3 To sqrtOfNumber Step 2

            ' If number to check divides cleanly then it can't be prime!
            If (numberToCheck Mod i = 0) Then Return False

        Next

        ' If we get this far, we've got a Prime number!
        Return True

    End Function

End Module
