Module Module1
    Sub Main()

        ' Get the starting number
        Dim startingNumber = 0
        While startingNumber <= 0   ' Ignore negative numbers and zero
            Console.WriteLine("Please enter a starting number to find within the Fibonacci sequence:")
            Integer.TryParse(Console.ReadLine(), startingNumber)
            If startingNumber <= 0 Then Console.WriteLine("Please enter a valid integer")
        End While

        ' Get how many fibs to return
        Dim numberOfFibsToReturn = 0
        While numberOfFibsToReturn <= 0
            Console.WriteLine("How many fibonacci number should be returned after the starting value?")
            Integer.TryParse(Console.ReadLine(), numberOfFibsToReturn)
            If numberOfFibsToReturn <= 0 Then Console.WriteLine("Please enter a valid integer")
        End While

        ' Call our Fib function
        Dim fibNumbers = GenerateFibs(startingNumber, numberOfFibsToReturn)

        ' Output the results
        For Each fib As Integer In fibNumbers
            Console.WriteLine(fib)
        Next

        Console.WriteLine("The first available fib after {0} was {1}", startingNumber, fibNumbers.First())
        Console.Read()

    End Sub


    ''' <summary>
    ''' Generates X number of fibonacci numbers grom the given starting number
    ''' </summary>
    ''' <param name="checkpoint"></param>
    ''' <param name="numbersAfter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GenerateFibs(ByVal checkpoint As Integer, ByVal numbersAfter As Integer) As List(Of Integer)
        ' Fibonacci numbers equate to Fn = Fn-1 + Fn-2
        ' We can forget abou the first three numbers in the sequence for this (0,1,1)
        Dim F_n = New List(Of Integer)
        Dim F_n_1 = 1
        Dim F_n_2 = 0

        ' Can you see what is going on here?
        While F_n.Count <> (numbersAfter + 1)

            Dim fibNumber = F_n_1 + F_n_2
            If (fibNumber >= checkpoint) Then F_n.Add(fibNumber)

            F_n_2 = F_n_1
            F_n_1 = fibNumber

        End While

        Return F_n

    End Function



End Module
