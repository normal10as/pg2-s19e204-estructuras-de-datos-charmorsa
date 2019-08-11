Module Module1
    Private turnos As New Queue(Of String)
    Private nombres, aux As String
    Sub Main()
        Call carga()
        Call informe()
    End Sub
    Sub carga()
        Do
            Console.Write("Ingrese nombre del cliente: ")
            nombres = Console.ReadLine()
            If nombres <> "" Then
                turnos.Enqueue(nombres)
            End If
        Loop Until (nombres = "")
    End Sub

    Sub informe()
        For x = 0 To (turnos.Count - 1)
            Console.Write("oprima cualquier tecla para continuar: ")
            aux = Console.ReadLine()
            Console.WriteLine("el siguiente turno es de --{0}--", turnos.Dequeue)
            Console.WriteLine()
            Console.WriteLine("---------------------------------------------------")
            Console.WriteLine("cantidad de clientes en espera: {0}", turnos.Count)
            Console.WriteLine()
            Console.WriteLine("---------------------------------------------------")
        Next
    End Sub
End Module
