Module Module1

    Sub Main()
        Console.WriteLine("Welcome to Bank Tech's Cashier System" + vbCrLf + "######################################" + vbCrLf)

        ' An infinite loop to continually run the program
        ' Or at least until an 'X' command is typed
        While True
            Dim balance = 0D
            While balance <= 0
                Console.WriteLine("Please enter the customer's starting balance:")
                Double.TryParse(Console.ReadLine(), balance)
                If balance < 0 Then Console.WriteLine("There is no overdraft facility available for this account. Please use positive numbers")
            End While

            ' Hey look! Another infinite loop!
            While True

                'Get an action from the user
                Dim action = ""
                While String.IsNullOrEmpty(action)
                    Console.WriteLine("Current balance is £{0}" + vbCrLf + "Press 'A' to add more funds or 'S' to subtract from the balance or 'X' to exit:", balance)
                    action = Console.ReadLine()
                End While

                ' Exit the program is someone types in 'X'
                If action.ToUpper = "X" Then Exit Sub

                ' Instead of nested If statements, use Select. You can extend this with more commands more easily.
                Select Case action.ToUpper
                    Case "A"
                        AddToBalance(balance)

                    Case "S"
                        SubtractFromBalance(balance)

                    Case Else
                        Console.WriteLine("That command was not recognised. Please try again.")
                End Select

            End While

        End While

    End Sub


    ''' <summary>
    ''' Takes a REFERENCE to the balance variable being passed as Adds funds to it directly.
    ''' </summary>
    ''' <param name="balance"></param>
    ''' <remarks></remarks>
    Sub AddToBalance(ByRef balance As Double)  ' Using Sub instead of Function because there is no return type. Helps to prevent NULL references.
        Console.WriteLine("How much would you like to ADD from the current balance?")

        Dim sumToAdd = 0D  ' Decimals
        While sumToAdd <= 0D
            Double.TryParse(Console.ReadLine(), sumToAdd)
            If sumToAdd <= 0D Then Console.WriteLine("Please enter a valid, positive number")
        End While

        balance += sumToAdd
        Console.WriteLine("Added £{0}", sumToAdd)
    End Sub




    ''' <summary>
    ''' Takes a REFERENCE to the balance variable being passed as subtracts funds from it directly.
    ''' </summary>
    ''' <param name="balance"></param>
    ''' <remarks></remarks>
    Sub SubtractFromBalance(ByRef balance As Double)  ' Using Sub instead of Function because there is no return type. Helps to prevent NULL references.
        Console.WriteLine("How much would you like to SUBTRACT from the current balance?")

        Dim sumToSubtract = 0D  ' Decimals
        While sumToSubtract <= 0D   ' We don't want to risk double negatives, so we'll treat negatives and zero as unwanted
            Double.TryParse(Console.ReadLine(), sumToSubtract)
            If sumToSubtract <= 0D Then Console.WriteLine("Please enter a valid, positive number")
        End While

        balance -= sumToSubtract
        Console.WriteLine("Subtracted £{0}", sumToSubtract)
    End Sub

End Module
